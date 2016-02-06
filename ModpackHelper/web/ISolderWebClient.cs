﻿using ModpackHelper.Shared.Mods;
using ModpackHelper.Shared.Utils.Config;

namespace ModpackHelper.Shared.Web
{
    public interface ISolderWebClient
    {
        /// <summary>
        /// Logs into the service
        /// </summary>
        /// <param name="email">The email to login with</param>
        /// <param name="password">The password to login with</param>
        /// <returns>True if login was a success</returns>
        bool Login(string email, string password);

        /// <summary>
        /// Create a pack with the specific name and slug
        /// Should hit http://solder.zlepper.dk/modpack/create with POST
        /// Paramerters of request is:
        ///         name: Modpackname
        ///         slug: modpack slug
        /// </summary>
        /// <param name="modpackname">The name of the modpack to create</param>
        /// <param name="slug">The slug to create the modpack with</param>
        string CreatePack(string modpackname, string slug);

        /// <summary>
        /// Adds a mod to solder
        /// Should hit: http://solder.zlepper.dk/mod/create with POST
        /// Parameters of request:
        ///         pretty_name: Mod name
        ///         name: mod slug
        ///         author: Author
        ///         description: Description
        ///         link: Mod url
        /// </summary>
        /// <param name="mod">The mod to add to solder</param>
        string AddMod(Mcmod mod);

        /// <summary>
        /// Adds/update a version of a mod
        /// Should hit: http://solder.zlepper.dk/mod/add-version with POST
        ///         mod-id: the numeric id of the mod
        ///         add-version: The version of the mod (minecraft version + "-" + mod version)
        ///         add-md5: The md5 of the packed mod
        /// </summary>
        /// <param name="modId"></param>
        /// <param name="md5">The md5 value of the packed mod</param>
        /// <param name="version"></param>
        void AddModVersion(string modId, string md5, string version);

        /// <summary>
        /// Rehashes a specific mod version
        /// Should hit: http://solder.zlepper.dk/mod/rehash with POST
        /// Paremeters of request:
        ///         ver_id: The id of the modversion
        /// </summary>
        /// <param name="modversionId"></param>
        /// <param name="md5">The md5 of the packed mod</param>
        void RehashModVersion(string modversionId, string md5);
        
        /// <summary>
        /// Tries to find a specific mod on solder
        /// </summary>
        /// <param name="mod">The mod to find</param>
        /// <returns>The id of the mod if found, otherwise null</returns>
        string GetModId(Mcmod mod);

        string CreateBuild(Modpack modpack);

        string CreateBuild(Modpack modpack, string id);

        string GetModpackId(string slug);

        void AddModversionToBuild(Mcmod mod, string modpackbuildid);

        string GetBuildId(Modpack modpack);

        bool IsModversionOnline(Mcmod mod);

        bool IsModInBuild(Mcmod mod, string buildid);
        void SetModversionInBuild(Mcmod mod, string buildid);
        string GetModVersionId(Mcmod mod);
        bool IsPackOnline(Modpack modpack);
        bool IsBuildOnline(Modpack modpack);
        bool IsModversionActiveInBuild(Mcmod mod, string buildid);
    }
}
