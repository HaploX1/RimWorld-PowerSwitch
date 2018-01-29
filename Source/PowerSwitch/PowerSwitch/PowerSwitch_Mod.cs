using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using RimWorld;
using Verse;

namespace PowerSwitch
{
    public class PowerSwitch_Mod : Mod
    {
        public static string Text_Category = "PowerSwitch_ModOptions_Category";

        public static string Text_Option_EnemyDetectionViaDesignation = "PowerSwitch_ModOptions_EnemyDetectionViaDesignation";
        public static string ToolTip_Option_EnemyDetectionViaDesignation = "PowerSwitch_ModOptions_EnemyDetectionViaDesignation_hint";
        public static string Text_Option_EnemyDetectionRangePercentofMap = "PowerSwitch_ModOptions_EnemyDetectionRangePercentofMap";


        public PowerSwitch_Mod(ModContentPack mcp) : base(mcp)
        {
            LongEventHandler.ExecuteWhenFinished(SetTexts);
            LongEventHandler.ExecuteWhenFinished(GetSettings);
        }

        public void SetTexts()
        {
            Text_Category = Text_Category.Translate();

            Text_Option_EnemyDetectionViaDesignation = Text_Option_EnemyDetectionViaDesignation.Translate();
            ToolTip_Option_EnemyDetectionViaDesignation = ToolTip_Option_EnemyDetectionViaDesignation.Translate();
            Text_Option_EnemyDetectionRangePercentofMap = Text_Option_EnemyDetectionRangePercentofMap.Translate();
        }
        public void GetSettings()
        {
            GetSettings<PowerSwitch_ModSettings>();
        }
        public override string SettingsCategory()
        {
            return Text_Category;
        }

        public override void DoSettingsWindowContents(Rect rect)
        {

            Rect rectLH = rect.LeftHalf().Rounded();
            Rect rectRH = rect.RightHalf().Rounded();

            //Rect rectLH =  new Rect(rect.x, rect.y, rect.width / 2 - 5, rect.height);
            //Rect rectRH = new Rect(rect.x + rect.width / 2 + 5, rect.y, rect.width / 2 - 5, rect.height);

            //Rect rectLH = new Rect(rect.x, rect.y, rect.width / 2, rect.height).Rounded();
            //Rect rectRH = new Rect(rect.x + rect.width / 2, rect.y, rect.width / 2, rect.height).Rounded();

            Listing_Standard optionsLH = new Listing_Standard();
            Listing_Standard optionsRH = new Listing_Standard();
            optionsLH.Begin(rectLH);
            
            optionsLH.CheckboxLabeled(Text_Option_EnemyDetectionViaDesignation, ref PowerSwitch_ModSettings.switchEnemyDetectionViaDesignation, ToolTip_Option_EnemyDetectionViaDesignation);
            optionsLH.Gap();
            optionsLH.Label(Text_Option_EnemyDetectionRangePercentofMap + "  " + (PowerSwitch_ModSettings.enemyDetectionRangePercentofMap).ToStringPercent());
            //optionsLH.GapLine();


            optionsLH.End();
            //mcp.GetDefPackagesInFolder("ThingDefs").First().RemoveDef();

            optionsRH.Begin(rectRH);
            optionsRH.Gap();
            optionsRH.Gap();
            optionsRH.Gap();
            PowerSwitch_ModSettings.enemyDetectionRangePercentofMap = optionsRH.Slider(PowerSwitch_ModSettings.enemyDetectionRangePercentofMap, 0.05f, 1.0f);
            //optionsRH.GapLine();

            optionsRH.End();
        }

        public override void WriteSettings()
        {
            base.WriteSettings();
        }

    }
}
