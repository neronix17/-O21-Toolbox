﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using RimWorld;
using Verse;

namespace O21Toolbox.Abilities
{
    public class PassiveEffectWorker
    {
        public PassiveEffectProperties Props { get; set; }

        public virtual void DoEffect(Comp_AbilityUser abilityUser)
        {
            if (Props?.hediffs is List<HediffDef> hList && !hList.NullOrEmpty())
                foreach (var h in hList)
                    HealthUtility.AdjustSeverity(abilityUser.AbilityUser, h, 1f);
        }

        public virtual bool TryDoEffect(Comp_AbilityUser abilityUser)
        {
            DoEffect(abilityUser);
            return true;
        }

        public virtual bool CanDoEffect(Comp_AbilityUser abilityUser)
        {
            if (abilityUser == null)
                return false;
            var pawn = abilityUser.AbilityUser;
            if (pawn == null)
                return false;
            if (pawn.jobs == null)
                return false;
            if (Props.awakeOnly && pawn?.CurJob?.def == JobDefOf.LayDown || pawn.Downed)
                return false;
            if (pawn.mindState == null)
                return false;
            if (Props.combatOnly && Props.combatOnly && !pawn.mindState.anyCloseHostilesRecently)
                return false;
            return true;
        }

        public virtual void Tick(Comp_AbilityUser abilityUser)
        {
            var rate = -1;
            switch (Props.tickerType)
            {
                case TickerType.Rare:
                    rate = 250;
                    break;
                case TickerType.Normal:
                    rate = 60;
                    break;
                case TickerType.Long:
                    rate = 2000;
                    break;
            }
            if (rate != -1)
                if (Find.TickManager.TicksGame % rate == 0 && CanDoEffect(abilityUser))
                    TryDoEffect(abilityUser);
        }
    }
}
