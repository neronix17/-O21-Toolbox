﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace O21Toolbox.Alliances
{
    /// <summary>
    /// Defines Alliances.
    /// </summary>
    public class AllianceDef : Def
    {
        /// <summary>
        /// Members of the defined alliance.
        /// </summary>
        public List<FactionDef> memberFactions = new List<FactionDef>();
    }
}