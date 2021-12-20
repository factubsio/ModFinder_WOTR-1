﻿using ModFinder_WOTR.Infrastructure;
using System;

namespace ModFinder_WOTR
{
    /// <summary>
    /// This is the "static" state of a mod
    /// </summary>
    public class ModDetailsInternal
    {
        public string Author { get; set; }

        public string Description { get; set; }

        public string DownloadLink { get; set; }

        public string GithubOwner { get; set; }

        public string GithubRepo { get; set; }

        //This MUST match the UMMInfo.Id or OwlcatMod.UniqueName
        public ModId ModId { get; set; }

        public ModVersion Latest { get; set; }

        //These need to be manually filled in
        public string Name { get; set; }
        public long NexusModID { get; set; }

        public ModSource Source { get; set; }

        public bool IsSame(ModId id) => id == ModId;

    }

    /// <summary>
    /// Unique mod identifier (technically a UMM mod and owlcat mod can have the same unique name so we need to disambiguate them here)
    /// </summary>
    public struct ModId
    {
        public string Identifier { get; set; }
        public ModType ModType { get; set; }

        public ModId(string identifier, ModType modtype)
        {
            Identifier = identifier;
            ModType = modtype;
        }

        public override bool Equals(object obj)
        {
            return obj is ModId id &&
                   Identifier == id.Identifier &&
                   ModType == id.ModType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Identifier, ModType);
        }

        public static bool operator ==(ModId left, ModId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ModId left, ModId right)
        {
            return !(left == right);
        }
    }
}
