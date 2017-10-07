using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace namespace Harembis
{
    
    public class ExtendedInfo{

        Player ourPlayer_;

        uint protection_;
        uint defence_;
        uint attack_;

        HeldItems items_;

        StatLevels levels_;

        const uint DEFENCE_WEIGHT = 5;

        ExtendedInfo(Player ourPlayer, StartingState state){
            ourPlayer_=ourPlayer;
            updateAll();

        }


       public uint getProtection(){

            updateProtection();
            return protection_;

        }

        

        public void updateProtection(){

            protection_= ourPlayer_.MaxHealth +

        }

        void updateAll(){
            updateProtection();
        };
    }
}