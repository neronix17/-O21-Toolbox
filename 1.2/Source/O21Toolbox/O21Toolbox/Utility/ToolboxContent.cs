﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace O21Toolbox.Utility
{
    [StaticConstructorOnStartup]
    public class ToolboxContent
    {
        static ToolboxContent()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(ToolboxContent));
        }

        public static readonly Texture2D UnknownBuildable = ContentFinder<Texture2D>.Get("UI/Toolbox/Unknown");
    }
}
