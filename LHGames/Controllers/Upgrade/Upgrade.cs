using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{
    
public abstract class Upgrade{


    protected Player ourPlayer_;

        protected ExtendedInfo infos_;

    protected int attackWeight_;

    protected int defenceWeight_;

        protected int healthWeight_;

        protected int capacityWeight_;

    protected int collectingWeight_;

        public Upgrade(Player ourPlayer, ExtendedInfo infos){
       ourPlayer_=ourPlayer;
            infos_ = infos;

   }

        protected abstract void updateAllWeight();

    protected int calculateWeight(double bonus, int total, int cost)
    {
            return (int)(Constantes.WEIGHT_FACTOR * (bonus / (total * (cost / Constantes.COST_ADJUSTEMENT))));
    }


}
 
}