﻿using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Net.Http;
using Mono.Data.Sqlite;
using Newtonsoft.Json;

namespace TechnicSolderHelper.SQL
{
    public class FtbPermissionsSqlHelper
    {
        public static readonly string PermissionsFile =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "SolderHelper",
                "permissions.json");

        private readonly IFileSystem _fileSystem;
        private List<Permission> _permissions;

        public FtbPermissionsSqlHelper(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
            Load();
        }

        public FtbPermissionsSqlHelper()
            : this(new FileSystem())
        {
        }

        public string GetShortName(string modId)
        {
            if (string.IsNullOrWhiteSpace(modId))
            {
                return "";
            }
            else
            {
                Permission permission = _permissions.SingleOrDefault(p => p.modids.Contains(modId));
                return permission == null ? "" : permission.shortName;
            }
        }

        public Permission GetPermissionFromShortname(string shortname)
        {
            return _permissions.SingleOrDefault(p => p.shortName.Equals(shortname));
        }

        public Permission GetPermissionFromModId(string modId)
        {
            return string.IsNullOrWhiteSpace(modId) ? null : _permissions.FirstOrDefault(p => p.modids.Contains(modId));
        }

        public PermissionPolicy FindPermissionPolicy(string toCheck, bool isPublic)
        {
            if (string.IsNullOrWhiteSpace(toCheck))
            {
                return PermissionPolicy.Unknown;
            }
            else
            {
                Permission perm =
                    _permissions.FirstOrDefault(p => p.modids.Contains(toCheck) || p.shortName.Equals(toCheck));
                if (perm == null) return PermissionPolicy.Unknown;
                return isPublic ? perm.publicPolicy : perm.privatePolicy;
            }
        }

        private void Load()
        {
            if (_fileSystem.File.Exists(PermissionsFile))
                using (Stream s = _fileSystem.File.OpenRead(PermissionsFile))
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    _permissions = serializer.Deserialize<List<Permission>>(reader);
                }
            else
                LoadOnlinePermissions();
        }

        private void Save()
        {
            string json = JsonConvert.SerializeObject(_permissions);
            _fileSystem.File.WriteAllText(PermissionsFile, json);
        }

        public void LoadOnlinePermissions()
        {
            List<Permission> permissions;
            HttpClient client = new HttpClient();
            try
            {
                using (Stream s = client.GetStreamAsync("http://www.feed-the-beast.com/mods/json").Result)
                using (StreamReader sr = new StreamReader(s))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    JsonSerializer serializer = new JsonSerializer();

                    // read the json from a stream
                    // json size doesn't matter because only a small piece is read at a time from the HTTP request
                    permissions = serializer.Deserialize<List<Permission>>(reader);
                }
                _permissions = new List<Permission>();
                foreach (Permission p in permissions.Where(p => !String.IsNullOrWhiteSpace(p.privateStringPolicy) &&
                                                                !String.IsNullOrWhiteSpace(p.publicStringPolicy)))
                {
                    PermissionPolicy pp;
                    bool r = Enum.TryParse(p.privateStringPolicy, out pp);
                    if (r)
                    {
                        p.privatePolicy = pp;
                    }
                    r = Enum.TryParse(p.publicStringPolicy, out pp);
                    if (r) p.publicPolicy = pp;
                    p.privateStringPolicy = null;
                    p.publicStringPolicy = null;
                    _permissions.Add(p);
                }
                Save();
            }
            catch (Exception)
            {
                _permissions = new List<Permission>();

            }
        }
    }
}
