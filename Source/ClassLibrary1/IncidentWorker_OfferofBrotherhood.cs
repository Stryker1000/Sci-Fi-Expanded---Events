using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using RimWorld;

namespace ProtonCorp
{

    public class IncidentWorker_OfferofBrotherhood : IncidentWorker
    {

        public Faction protonCorp = Find.FactionManager.FirstFactionOfDef(FactionDef.Named("ProtonCorp"));

        protected override bool TryExecuteWorker(IncidentParms parms)
        {

            SendStandardLetter(def.letterLabel, def.letterText, def.letterDef, parms, null);
            return true;

        }
    }

}