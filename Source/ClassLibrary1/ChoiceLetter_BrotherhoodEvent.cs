using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using RimWorld;

namespace ProtonCorp
{
    public class ChoiceLetter_OfferofBrotherhood : ChoiceLetter
    {
        private Faction playerFaction = Faction.OfPlayer;

        private Faction protonCorp = Find.FactionManager.FirstFactionOfDef(FactionDef.Named("ProtonCorp"));

        public override IEnumerable<DiaOption> Choices
        {
            get
            {
                DiaOption AcceptBrotherhood = new DiaOption("Accept the Offer");
                AcceptBrotherhood.action = () =>
                {
                    if (protonCorp != null && protonCorp != playerFaction)
                    {
                        protonCorp.TryAffectGoodwillWith(playerFaction, 200);
                        Messages.Message("Goodwill with the Proton Corp has increased by 200.", MessageTypeDefOf.PositiveEvent, false);
                        Find.LetterStack.RemoveLetter(this);
                    }
                };
                AcceptBrotherhood.resolveTree = true;

                DiaOption RejectBrotherhood = new DiaOption("Reject the Offer");
                RejectBrotherhood.action = () =>
                {
                    Messages.Message("Your response has been noted by the proton corp.", MessageTypeDefOf.NegativeEvent, false);
                    Find.LetterStack.RemoveLetter(this);
                };
                yield return AcceptBrotherhood;
                yield return RejectBrotherhood;
                yield return base.Option_Postpone;
            }
        }
        public override void ExposeData()
        {
            base.ExposeData();
        }

    }
}

