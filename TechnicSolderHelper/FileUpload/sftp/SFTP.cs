﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using TechnicSolderHelper.Confighandler;

namespace TechnicSolderHelper.FileUpload.sftp
{
    class SFTP
    {
        private Confighandler.ConfigHandler cfg = new ConfigHandler();
        private SftpClient client;
        public SFTP()
        {
            client = new SftpClient(cfg.GetConfig("sftpHost"), int.Parse(cfg.GetConfig("sftpPort")), cfg.GetConfig("sftpUserName"), cfg.GetConfig("sftpPassword"));
        }
        public SFTP(string host, string username,
            string password,  int port)
        {
            client = new SftpClient(host, port, username, password);
        }
        

    
            public void UploadSFTPFile( string sourcefile, string destinationpath)
            {
                
                    client.Connect();
                    client.ChangeDirectory(destinationpath);
                    using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
                    {
                        client.BufferSize = 4 * 1024;
                        client.UploadFile(fs, Path.GetFileName(sourcefile));
                    
                    }
                
            }

        public void UploadFolder(string localPath, string remotePath)
        {
            Console.WriteLine("Uploading directory {0} to {1}", localPath, remotePath);

            IEnumerable<FileSystemInfo> infos =
                new DirectoryInfo(localPath).EnumerateFileSystemInfos();
            foreach (FileSystemInfo info in infos)
            {
                if (info.Attributes.HasFlag(FileAttributes.Directory))
                {
                    string subPath = remotePath + "/" + info.Name;
                    if (!client.Exists(subPath))
                    {
                        client.CreateDirectory(subPath);
                    }
                    UploadFolder( info.FullName, remotePath + "/" + info.Name);
                }
                else
                {
                    using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
                    {
                        Console.WriteLine(
                            "Uploading {0} ({1:N0} bytes)", info.FullName, ((FileInfo)info).Length);
                        client.UploadFile(fileStream, remotePath + "/" + info.Name);
                    }
                }
            }
        }

        public void Dispose()
        {
            client.Disconnect();
            client.Dispose();
        }
        }
    }


