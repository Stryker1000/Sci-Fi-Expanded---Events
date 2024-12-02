using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;


namespace ProtonCorp
{
    [StaticConstructorOnStartup]
    public static class ResearchCompletionPatch
    {
        static ResearchCompletionPatch()
        {
            var harmony = new Harmony("com.ProtonCorp.researchcompletion");
            harmony.Patch(original: AccessTools.Method(typeof(ResearchManager), "FinishProject"), postfix: new HarmonyMethod(typeof(ResearchCompletionPatch), nameof(Postfix_FinishProject)));
        }

        public static void Postfix_FinishProject(ResearchProjectDef proj, bool doCompletionDialog)
        {
            if (proj.defName == "ProtonTechnology")
            {
                IncidentDef offerOfBrotherhood = DefDatabase<IncidentDef>.GetNamed("OfferofBrotherhood");

                IncidentParms parms = StorytellerUtility.DefaultParmsNow(IncidentCategoryDefOf.Special, Find.CurrentMap);
                offerOfBrotherhood.Worker.TryExecute(parms);
            }
        }
    }

  
}
