﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using TechnicSolderHelper.Confighandler;
using TechnicSolderHelper.Cryptography;

namespace TechnicSolderHelper.FileUpload
{
    public class Ftp
    {
        private string _userName;
        private string _password;
        private string _url;

        public Ftp()
        {
            Crypto crypto = new Crypto();
            ConfigHandler ch = new ConfigHandler();
            _url = ch.GetConfig("ftpUrl");
            try
            {
                _password = crypto.DecryptString(ch.GetConfig("ftpPassword"));
            }
            catch (Exception)
            {
                _password = "";
            }
            _userName = ch.GetConfig("ftpUserName");
            if (_url.EndsWith("/"))
            {
                _url.Remove(_url.Length - 1);
            }
            if (!_url.StartsWith("ftp://"))
            {
                _url = "ftp://" + _url;
            }
        }

        public void UploadFolder(string folderPath)
        {
            string[] files;
            if (Directory.Exists(folderPath))
            {
                files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            }
            else
            {
                Debug.WriteLine("No files was created, so no reason to upload anything");
                return;
            }
            MessageToUser m = new MessageToUser();
            Thread startingThread = new Thread(m.UploadingToFtp);
            startingThread.Start();

            foreach (string file in files)
            {
                UploadFile(file, file.Replace(folderPath + Globalfunctions.PathSeperator, ""), "mods");
            }

        }

        private List<string> GetDirectoryContent(string location)
        {
            List<string> folderContent = new List<string>();
            FtpWebRequest request;
            if (location == null)
            {
                request = (FtpWebRequest)WebRequest.Create(_url);
            }
            else
            {
                request = (FtpWebRequest)WebRequest.Create(location);
            }
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            request.Credentials = new NetworkCredential(_userName, _password);

            using (FtpWebResponse responce = (FtpWebResponse)request.GetResponse())
            {
                Stream responceStream = responce.GetResponseStream();
                using (StreamReader reader = new StreamReader(responceStream))
                {
                    while (true)
                    {
                        try
                        {
                            string s = reader.ReadLine();
                            if (s.Contains("/"))
                            {
                                s = s.Substring(s.LastIndexOf("/") + 1);
                            }
                            folderContent.Add(s);
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
            }

            return folderContent;
        }

        private void UploadFile(string fullyQualifiedPathName, string destinationOnServer, string constant)
        {
            GetDirectoryContent(null);
            if (constant != null)
            {
                destinationOnServer = constant + Globalfunctions.PathSeperator + destinationOnServer;
            }
            string[] tmp = destinationOnServer.Split(Globalfunctions.PathSeperator);
            List<string> folders = new List<string>(tmp);
            string fileToUpload = folders[folders.Count - 1];
            folders.Remove(folders[folders.Count - 1]);
            for (int i = 0; i < folders.Count; i++)
            {
                folders[i] = folders[i].Replace(Globalfunctions.PathSeperator.ToString(), "");
            }
            FtpWebRequest request = WebRequest.Create(_url) as FtpWebRequest;
            request.Credentials = new NetworkCredential(_userName, _password);
            foreach (string folder in folders)
            {
                List<string> directoryContent = GetDirectoryContent(request.RequestUri.ToString());
                if (directoryContent.Contains(folder))
                {
                    if (request.RequestUri.ToString().EndsWith("/"))
                    {
                        request = WebRequest.Create(request.RequestUri + folder) as FtpWebRequest;
                    }
                    else
                    {
                        request = WebRequest.Create(request.RequestUri + "/" + folder) as FtpWebRequest;
                    }
                }
                else
                {
                    if (request.RequestUri.ToString().EndsWith("/"))
                    {
                        request = WebRequest.Create(request.RequestUri + folder) as FtpWebRequest;
                    }
                    else
                    {
                        request = WebRequest.Create(request.RequestUri + "/" + folder) as FtpWebRequest;
                    }
                    request.Credentials = new NetworkCredential(_userName, _password);
                    request.Method = WebRequestMethods.Ftp.MakeDirectory;
                    try
                    {
                        FtpWebResponse responce = (FtpWebResponse)request.GetResponse();
                    }
                    catch (WebException)
                    {
                    }
                }
            }

            try
            {
                request = WebRequest.Create(request.RequestUri + "/" + fileToUpload) as FtpWebRequest;
                request.Credentials = new NetworkCredential(_userName, _password);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.UseBinary = true;
                request.UsePassive = true;
                request.KeepAlive = true;
                using (FileStream fs = File.OpenRead(fullyQualifiedPathName))
                {
                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    fs.Close();
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(buffer, 0, buffer.Length);
                    requestStream.Close();
                    requestStream.Flush();
                }
            }
            catch (WebException)
            {
                //Console.WriteLine("error getting responce");
            }
        }

    }
}

