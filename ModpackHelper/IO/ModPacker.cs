﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client;
using ModpackHelper.Shared.Mods;

namespace ModpackHelper.Shared.IO
{
    public class ModPacker
    {
        private readonly IFileSystem fileSystem;
        private readonly StringBuilder sb;

		public ModPacker ():this(new FileSystem())
		{
			
		}

        public ModPacker(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            sb = new StringBuilder();
            const string html = "<!DOCTYPE html><html><head><meta charset=\"utf-8\" /><script src=\"https://ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js\"></script><script src=\"http://zlepper.dk/modpackhelper.js\"></script><link rel=\"stylesheet\" href=\"https://cdnjs.cloudflare.com/ajax/libs/materialize/0.97.0/css/materialize.min.css\"></head><body class=\"container\"><table class=\"\"><thead><tr><th>Modname</th><th>Modslug</th><th>Version</th></tr></thead><tbody>";
            sb.AppendLine(html);
        }

        public void Pack(List<Mcmod> mods, DirectoryInfoBase outputDirectory)
        {
            // Create a SignalR connection to the api
            using (HubConnection hubConnection = new HubConnection(Constants.ApiUrl))
            {
                IHubProxy apiHubProxy = hubConnection.CreateHubProxy("ApiHub");
                Task con = hubConnection.Start();

                // Create the output directory where we should put all the new files
                outputDirectory.Create();
                List<BackgroundWorker> backgroundWorkers = new List<BackgroundWorker>(mods.Count);
                ZipUtils zipUtils = new ZipUtils(fileSystem);
                using (ModsDBContext db = new ModsDBContext(fileSystem))
                {
                    // Wait for the SignalR connection to be established
                    con.Wait();
                    foreach (Mcmod mod in mods)
                    {
                        BackgroundWorker bw = new BackgroundWorker();
                        bw.DoWork += (sender, args) =>
                        {
                            string modID = mod.Modid.Replace("|", string.Empty).ToLower();
                            string modversion = (mod.Mcversion + "-" + mod.Version).ToLower();

                            // Check if mod is online
                            Mcmod mo = db.Mods.FirstOrDefault(m => m.JarMd5.Equals(mod.JarMd5));
                            if (mo != null && mo.IsOnSolder) return;
                            // Create the output directory 
                            string zipFileDirectory = fileSystem.Path.Combine(outputDirectory.FullName, "mods", modID);
                            fileSystem.Directory.CreateDirectory(zipFileDirectory);

                            string zipFileName = fileSystem.Path.Combine(outputDirectory.FullName, "mods", modID,
                                modID + "-" + modversion + ".zip");
                            FileInfoBase zipFile = fileSystem.FileInfo.FromFileName(zipFileName);

                            Debug.WriteLine("Packing " + modID);
                            zipUtils.SpecialPackSolderMod(mod.GetPath(), zipFile);
                            Debug.WriteLine("Done packing " + modID);
                            mod.IsOnSolder = true;
                            AddDataToOutput(mod.Name, modID, modversion);

                            // Check if this mods data was entered by the user
                            // And if it is, upload it to the webapi
                            if (mod.FromUser && !mod.FromSuggestion)
                            {
                                mod.UploadToApi(apiHubProxy);
                            }
                        };
                        backgroundWorkers.Add(bw);
                        bw.RunWorkerAsync();
                    }
                    // Make sure all backgroundworkers are finished running before returning to the caller
                    int count = -1;
                    while (backgroundWorkers.Any())
                    {
                        // Remove background workers that are done
                        foreach (BackgroundWorker bw in backgroundWorkers.Where(b => !b.IsBusy))
                        {
                            bw.Dispose();
                        }
                        backgroundWorkers.RemoveAll(b => !b.IsBusy);
                        int c = backgroundWorkers.Count;
                        if (c != count)
                        {
                            count = c;
                            Debug.WriteLine(count + " backgroundworkers remaining.");
                        }
                    }
                    foreach (Mcmod mod in mods)
                    {
                        db.Mods.RemoveAll(m => m.JarMd5.Equals(mod.JarMd5));
                        db.Mods.Add(mod);
                    }
                }
            }
        }

        private void AddDataToOutput(string name, string id, string version)
        {
            string addedMod = $"<tr><td><input readonly type=\"text\" class=\"containsInfo\" value=\"{name}\"></td>" +
                              $"<td><input readonly type=\"text\" class=\"containsInfo\" value=\"{id}\"></td>" +
                              $"<td><input readonly type=\"text\" class=\"containsInfo\" value=\"{version}\"></td>" +
                              "<td><button class=\"waves-effect waves-light btn\" type=\"button\">Hide</button></td></tr>";
            sb.AppendLine(addedMod);
        }

        public string GetFinishedHTML()
        {
            sb.AppendLine(
                @"</table><button id=""Reshow"" type=""button"">Unhide Everything</button><p>List autogenerated by Modpack Helper &copy; 2015 - Rasmus Hansen</p></body></html>");
            return sb.ToString();
        }
    }
}
