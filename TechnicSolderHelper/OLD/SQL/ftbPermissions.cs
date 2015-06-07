﻿using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace TechnicSolderHelper.OLD.SQL
{
    public class ftbPermissions
    {
        public string shortName { get; set; }
        public string modName { get; set; }
        public string modAuthor { get; set; }
        public string modLink { get; set; }
        public string licenseLink { get; set; }
        public string licenseImage { get; set; }
        public string privateLicenseLink { get; set; }
        public string privateLicenseImage { get; set; }
        public int publicPolicy { get; set; }
        public int privatePolicy { get; set; }
        public List<string> modIDs { get; set; }
    }
}
