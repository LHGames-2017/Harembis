using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{
    
    public class ExtendedInfo{

        Player ourPlayer_;

        int protection_;
        int defence_;
        int attack_;
        int gatherSpeed_;

        HeldItems items_;

        StatLevels levels_;

        const int DEFENCE_WEIGHT = 5;

        ExtendedInfo(Player ourPlayer, StartingState state){
            ourPlayer_=ourPlayer;
            items_ = state.items;
            levels_ = state.levels;
            updateAll();
        }


       public int getProtection(){

            updateProtection();
            return protection_;

        }

        public int getDefence()
        {

            updateDefence();
            return defence_;

        }

        public int getAttack() {
            updateAttack();
            return attack_;
        }

        public HeldItems getItems() {
            return items_;
        }

        public StatLevels getLevels() { return levels_; }


        public int getGatherSpeed()
        {
            updateGatherSpeed();
            return gatherSpeed_;
        }

        public void buyItem(PurchasableItem item) {

            switch (item){
                case 
            }
        }

        public void upgradeStat(UpgradeType stat) { }

        public int calculateProtection(int defence)
        {
            return DEFENCE_WEIGHT * defence;
        }

        void updateDefence()
        {
            defence_ = 1 + (2 * levels_.Defence);
            if (items_.UbisoftShield)
            {
                defence_ += 2;
            }
        }

        void updateAttack() {
            defence_ = 1 + (2 * levels_.AttackPower);
            if (items_.MicrosoftSword)
            {
                attack_ += 2;
            }
        }

        void updateProtection()
        {

            protection_ = ourPlayer_.MaxHealth + calculateProtection(defence_);

        }

        void updateGatherSpeed() {

            switch (levels_.CollectingSpeed)
            {
                case 0:
                    gatherSpeed_ = 100;
                    break;
                case 1:
                    gatherSpeed_ = 125;
                    break;
                case 2:
                    gatherSpeed_ = 150;
                    break;
                case 3:
                    gatherSpeed_ = 200;
                    break;
                case 4:
                    gatherSpeed_ = 250;
                    break;
                case 5:
                    gatherSpeed_ = 350;
                    break;
            }

            if (items_.DevolutionsPickaxe)
            {
                gatherSpeed_ += 75;
            }
            
        }

        void updateAll(){
            updateDefence();
            updateAttack();
            updateProtection();
            updateGatherSpeed();
            
        }


    }
}