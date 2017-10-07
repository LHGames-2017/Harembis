using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{
    
    public class ExtendedInfo{

        Player ourPlayer_;

        static int protection_;
        static int defence_;
        static int attack_;
       static int gatherSpeed_;

       static HeldItems items_;

        static StatLevels levels_;

        const int DEFENCE_WEIGHT = 5;

        public ExtendedInfo(Player ourPlayer, StartingState state){
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

        public int nextUpgradeCost(UpgradeType stat)
        {
            int cost=1000000000;
            switch (stat) {
                case UpgradeType.AttackPower:
                    cost = upgradeCostPerLevel(levels_.AttackPower, true);
                    break;
                case UpgradeType.CarryingCapacity:
                    cost = upgradeCostPerLevel(levels_.CarryingCapacity, true);
                    break;
                case UpgradeType.CollectingSpeed:
                    cost = upgradeCostPerLevel(levels_.CollectingSpeed, true);
                    break;
                case UpgradeType.Defence:
                    cost = upgradeCostPerLevel(levels_.Defence, true);
                    break;
                case UpgradeType.MaximumHealth:
                    cost = upgradeCostPerLevel(levels_.MaximumHealth, false);
                    break;
            }
            return cost;
        }

        int upgradeCostPerLevel(int level, bool type) {

            
            if (type)
            {
                switch (level)
                {
                    case 0:
                        return 15000;
                    case 1:
                        return 50000;
                    case 2:
                        return 100000;
                    case 3:
                        return 250000;
                    default:
                        return 500000;

                }
            }else
            {
                switch (level)
                {
                    case 0:
                        return 10000;
                    case 1:
                        return 20000;
                    case 2:
                        return 30000;
                    case 3:
                        return 50000;
                    default:
                        return 100000;

                }
            }
           
        }

        public void buyItem(PurchasableItem item) {

            switch (item){
                case PurchasableItem.MicrosoftSword:
                    items_.MicrosoftSword = true;
                    break;
                case PurchasableItem.UbisoftShield:
                    items_.UbisoftShield = true;
                    break;
                case PurchasableItem.DevolutionsBackpack:
                    items_.DevolutionsBackpack = true;
                    break;
                case PurchasableItem.DevolutionsPickaxe:
                    items_.DevolutionsPickaxe = true;
                    break;
                case PurchasableItem.HealthPotion:
                    items_.HealthPotion +=1;
                    break;
            }
        }

        public void upgradeStat(UpgradeType stat) {

            switch (stat)
            {
                case UpgradeType.AttackPower:
                    levels_.AttackPower++;
                    break;
                case UpgradeType.CarryingCapacity:
                    levels_.CarryingCapacity++;
                    break;
                case UpgradeType.CollectingSpeed:
                    levels_.CollectingSpeed++;
                    break;
                case UpgradeType.Defence:
                    levels_.Defence++;
                    break;
                case UpgradeType.MaximumHealth:
                    levels_.MaximumHealth++;
                    break;

            }



        }

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