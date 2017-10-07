using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{
    
public class Upgrade{


    Player ourPlayer_;

    uint attackWeight_;

    uint protectionWeight_;

    uint gatherWeight_;

   Upgrade(Player ourPlayer){
       ourPlayer_=ourPlayer;
       updateNext();

   } 

   public void updateNext()=0;

   void updateAllWeight(){

        updateAttack();
        updateGather();
        updateProtection();
    };

    void updateAttack()=0;

    void updateGather()=0;

    void updateProtection()=0;

    uint calculateWeight(uint bonus, uint total, uint cost)
    {
        return WEIGHT_FACTOR*(bonus/(total*(cost/COST_ADJUSTEMENT))
    }


}
 
}

}