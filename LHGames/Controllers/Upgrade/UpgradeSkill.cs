using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{

    public class UpgradeSkill : Upgrade
    {

        UpgradeTypes nextUpgrade_;



        uint attackWeight_;

        uint protectionWeight_;

        uint gatherWeight_;
        UpgradeTypes nextGather;




   Upgrade(Player ourPlayer)
        {
            ourPlayer_ = ourPlayer;
            updateNext();

        }

        public Tuple<UpgradeTypes, uint> getNext() { return new Tuple<UpgradeTypes, uint>(nextUpgrade_, cost_); }

        public void updateNext()
        {
            Upgrade.updateNext();
            if (attackWeight_ > protectionWeight_ && attackWeight_ > gatherWeight_)
            {
                nextUpgrade_
            }

        }

        void updateAllWeight() { }



        void updateAttackDefenceWeight(uint totalAttackDefence, uint attackDefenceLevel)
        {

            uint prix;

            switch (attackLevel)
            {
                case 0:
                    prix = 15000;
                case 1:
                    prix = 40000;
                case 2:
                    prix = 100000;
                case 3:
                    prix = 250000;
                case 4:
                    prix = 500000;


            }

            attackWeight = (2 / (totalAttack * prix));


        }

    }

}

}