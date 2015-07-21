﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ModpackHelper.Utils;
using Newtonsoft.Json;

namespace ModpackHelper.mods
{
    /// <summary>
    /// Used to descripe a minecraft mod
    /// Also the pattern in normal mcmod.info files
    /// </summary>
    public class Mcmod
    {
        public bool Equals(Mcmod other)
        {
            return string.Equals(Modid, other.Modid) && 
                string.Equals(Name, other.Name) && 
                string.Equals(Version, other.Version) && 
                string.Equals(Mcversion, other.Mcversion) && 
                string.Equals(Url, other.Url) && 
                string.Equals(Description, other.Description) && 
                HasBeenWritenToModlist == other.HasBeenWritenToModlist && 
                IsSkipping == other.IsSkipping && 
                Lists.AreEqual(AuthorList, other.AuthorList) && 
                Lists.AreEqual(Authors, other.Authors) && 
                PublicPerms == other.PublicPerms && 
                PrivatePerms == other.PrivatePerms && 
                FromSuggestion == other.FromSuggestion && 
                FromUserInput == other.FromUserInput && 
                string.Equals(Filename, other.Filename) && 
                string.Equals(Path, other.Path) && 
                Aredone == other.Aredone;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Modid != null ? Modid.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Version != null ? Version.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Mcversion != null ? Mcversion.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Description != null ? Description.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ HasBeenWritenToModlist.GetHashCode();
                hashCode = (hashCode*397) ^ IsSkipping.GetHashCode();
                hashCode = (hashCode*397) ^ (AuthorList != null ? AuthorList.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Authors != null ? Authors.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) PublicPerms;
                hashCode = (hashCode*397) ^ (int) PrivatePerms;
                hashCode = (hashCode*397) ^ FromSuggestion.GetHashCode();
                hashCode = (hashCode*397) ^ FromUserInput.GetHashCode();
                hashCode = (hashCode*397) ^ (Filename != null ? Filename.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (Path != null ? Path.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Aredone.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// The modid of the mod
        /// </summary>
        public string Modid { get; set; }

        /// <summary>
        /// The name of the mod
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The version of the mod
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// The Minecraft version of the mod
        /// </summary>
        public string Mcversion { get; set; }

        /// <summary>
        /// The info url of the mod
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// A short description of the mod
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Indicates if this mod has been written to the output modlist
        /// </summary>
        public bool HasBeenWritenToModlist { get; set; }

        /// <summary>
        /// Indicates if this mod should be skipped when packing
        /// </summary>
        public bool IsSkipping { get; set; }

        /// <summary>
        /// A list of the authors of the mod
        /// </summary>
        public List<string> AuthorList { get; set; }

        /// <summary>
        /// A list of the authors of the mod
        /// </summary>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Indicates the permissions needed to distribute the mod
        /// in a public modpack
        /// </summary>
        public PermissionLevel PublicPerms { get; set; }

        /// <summary>
        /// Indicates the permissions needed to distribute the mod
        /// in a private modpack
        /// </summary>
        public PermissionLevel PrivatePerms { get; set; }

        /// <summary>
        /// Indicates if this info was fetched from my remote database
        /// and therefor should not be put back into the databasee
        /// TODO write a json api instead of the direct db interaction
        /// </summary>
        public bool FromSuggestion { get; set; }

        /// <summary>
        /// Indicates that the mods information was from a users input
        /// </summary>
        public bool FromUserInput { get; set; }

        /// <summary>
        /// The name of the file itself
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The path of the mod
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Indicates that all informatio has been entered for the mod
        /// </summary>
        public bool Aredone { get; set; }



        public static Mcmod GetMcmod(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<Mcmod>>(json)[0];
            }
            catch (JsonSerializationException)
            {
                return null;
            }
            catch (JsonReaderException)
            {
                return null;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Mcmod) obj);
        }
    }
}
