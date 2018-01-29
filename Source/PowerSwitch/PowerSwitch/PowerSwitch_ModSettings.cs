using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace PowerSwitch
{
    public class PowerSwitch_ModSettings : ModSettings
    {

        public static bool switchEnemyDetectionViaDesignation = true;
        public static float enemyDetectionRangePercentofMap = 0.45f;
        public static float pawnNearbyDetectionRange = 7f;

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<bool>(ref switchEnemyDetectionViaDesignation, "switchEnemyDetectionViaDesignation", true);
            Scribe_Values.Look<float>(ref enemyDetectionRangePercentofMap, "enemyDetectionRangePercentofMap", 0.45f);
            Scribe_Values.Look<float>(ref pawnNearbyDetectionRange, "pawnNearbyDetectionRange", 7f);
        }

    }
}