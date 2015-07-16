﻿using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModpackHelper.UserInteraction;

namespace ModpackHelper.CLI
{
    public class Handler
    {
        private IFileSystem _fileSystem;
        public Handler():this(new FileSystem()) { }

        public Handler(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public bool ClearOutputDirectoryOnRun { get; set; }
        public string InputDirectory { get; set; }
        public string OutputDirectory { get; set; }
        public bool GetForgeVersions { get; set; }

        /// <summary>
        /// Starts the entire modpacking process
        /// </summary>
        /// <param name="args"></param>
        /// <param name="messageShower"></param>
        /// <returns>True if the process successed, otherwise false</returns>
        public bool Start(List<string> args, IMessageShower messageShower)
        {
            // Check if the user specified any arguments
            if (args.Count == 0)
            {
                messageShower.ShowMessageAsync(Messages.Usage);
                return false;
            }

            // Get the input directory
            if (args.Contains("-i"))
            {
                // Check if the user specified the output directory, 
                // which is needed with the input directory
                if (!args.Contains("-o"))
                {
                    messageShower.ShowMessageAsync(Messages.MissingOutputDirectory);
                    return false;
                }

                int index = args.IndexOf("-i");
                
                // Check if the the index is the last argument
                // Also done to avoid an out of range exception in the next piece of code
                if (index + 1 == args.Count)
                {
                    messageShower.ShowMessageAsync(Messages.MissingInputDirectory);
                    return false;
                }
                string supposedInputDirectory = args[index + 1];

                // Check if the user didn't specify an input directory
                if (supposedInputDirectory.StartsWith("-"))
                {
                    messageShower.ShowMessageAsync(Messages.MissingInputDirectory);
                    return false;
                }

                // Check to make sure the user specified the 
                // /mods/ directory as input directory
                if (!supposedInputDirectory.EndsWith(_fileSystem.Path.PathSeparator + "mods"))
                {
                    messageShower.ShowMessageAsync(Messages.NotAModsDirectory);
                    return false;
                }

                // Check to make sure the inputdirectory actually exists
                if (!_fileSystem.Directory.Exists(supposedInputDirectory))
                {
                    messageShower.ShowMessageAsync(Messages.InputDirectoryNotFound);
                    return false;
                }

                InputDirectory = supposedInputDirectory;
                args.Remove("-i");
                args.Remove(supposedInputDirectory);
            }

            // Get the output directory
            if (args.Contains("-o"))
            {
                // Check if the input directory was specified
                if (string.IsNullOrWhiteSpace(InputDirectory))
                {
                    messageShower.ShowMessageAsync(Messages.MissingInputDirectory);
                    return false;
                }

                int index = args.IndexOf("-o");

                // Check if the the index is the last argument
                // Also done to avoid an out of range exception in the next piece of code
                if (index + 1 == args.Count)
                {
                    messageShower.ShowMessageAsync(Messages.MissingOutputDirectory);
                    return false;
                }

                string supposedOutputDirectory = args[index + 1];

                // Check if the user didn't specify an input directory
                if (supposedOutputDirectory.StartsWith("-"))
                {
                    messageShower.ShowMessageAsync(Messages.MissingOutputDirectory);
                    return false;
                }

                OutputDirectory = supposedOutputDirectory;
                args.Remove("-o");
                args.Remove(supposedOutputDirectory);
            }

            // Check to see if we should recreate the local forge versions list
            if (args.Contains("-f"))
            {
                GetForgeVersions = true;
                args.Remove("-f");
            }

            // Check if we should clear the output directory before run
            if (args.Contains("-c"))
            {
                ClearOutputDirectoryOnRun = true;
                args.Remove("-c");
            }





            return true;
        }
    }
}
