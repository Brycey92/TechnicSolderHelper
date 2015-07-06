﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ModpackHelper.IO
{
    public class Finder
    {
        private IFileSystem _fileSystem;

        public Finder(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public Finder(): this(fileSystem: new FileSystem()){}

        public List<FileInfoBase> GetModFiles(DirectoryInfoBase dir)
        {
            List<FileInfoBase> files = dir.EnumerateFiles("*.zip", SearchOption.AllDirectories).Where(file => !Regex.IsMatch(file.Name, @"-?[0-9]+,-?[0-9]+.zip")).ToList();
            files.AddRange(dir.EnumerateFiles("*.jar", SearchOption.AllDirectories));
            files.AddRange(dir.EnumerateFiles("*.litemod", SearchOption.AllDirectories));
            files.AddRange(dir.EnumerateFiles("*.disabled", SearchOption.AllDirectories));
            return files;
        }

        public List<FileInfoBase> GetModFiles(string dir)
        {
            return GetModFiles(_fileSystem.DirectoryInfo.FromDirectoryName(dir));
        } 
    }
}
