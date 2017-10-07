using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{

    public class UpgradeSkill : Upgrade
    {
        public UpgradeSkill(Player ourPlayer, ExtendedInfo infos) : base(ourPlayer, infos){}

		public Tuple<UpgradeType, int, int> getNextSkill(){
            UpgradeType type;
            int cost, weight;

            if (attackWeight_ > defenceWeight_ && attackWeight_ > healthWeight_ && attackWeight_ > capacityWeight_ && attackWeight_ > collectingWeight_){
                type = UpgradeType.AttackPower;
                cost = infos_.nextUpgradeCost(UpgradeType.AttackPower);
                weight = attackWeight_;
            }
            else if(defenceWeight_ > healthWeight_ && defenceWeight_ > capacityWeight_ && defenceWeight_ > collectingWeight_){
				type = UpgradeType.Defence;
				cost = infos_.nextUpgradeCost(UpgradeType.Defence);
				weight = defenceWeight_;
            }
            else if(healthWeight_ > capacityWeight_ && healthWeight_ > collectingWeight_) {
                type = UpgradeType.MaximumHealth;
                cost = infos_.nextUpgradeCost(UpgradeType.MaximumHealth);
				weight = healthWeight_;
            }
            else if(capacityWeight_ > collectingWeight_) {
                type = UpgradeType.CarryingCapacity;
                cost = infos_.nextUpgradeCost(UpgradeType.CarryingCapacity);
				weight = capacityWeight_;
            }
            else {
                type = UpgradeType.CollectingSpeed;
                cost = infos_.nextUpgradeCost(UpgradeType.CollectingSpeed);
				weight = collectingWeight_;
            }

            return new Tuple<UpgradeType, int, int>(type, cost, weight);
        }

        protected override void updateAttack(){
            attackWeight_ = Constantes.ATTACK_MODIFIER * calculateWeight(2, infos_.getAttack(), infos_.nextUpgradeCost(UpgradeType.AttackPower));
        }

        protected override void updateCollecting(){
            double bonus;

            switch (infos_.getLevels().CollectingSpeed){
                case 0 :
                case 1:
                    bonus = 0.25;
                    break;
                case 2:
                case 3:
                    bonus = 0.5;
                    break;
                case 4:
                    bonus = 1;
                    break;
                default:
                    bonus = 0;
                    break;

            }

            collectingWeight_ = Constantes.GATHER_MODIFIER * calculateWeight(bonus, infos_.getGatherSpeed(), infos_.nextUpgradeCost(UpgradeType.CollectingSpeed));
		}

        protected override void updateDefence(){
            defenceWeight_ = Constantes.DEFENCE_MODIFIER * calculateWeight(2, infos_.getDefence(), infos_.nextUpgradeCost(UpgradeType.Defence));

		}

        protected override void updateHealth(){
			double bonus;

            switch (infos_.getLevels().MaximumHealth)
			{
                case 0:
                    bonus = 3;
                    break;
                case 1 :
                    bonus = 2;
                    break;
                case 2:
                case 3:
                    bonus = 5;
                    break;
                case  4:
                    bonus = 10;
                    break;
                default:
                    bonus = 0;
                    break;
			}

            healthWeight_ = Constantes.HEALTH_MODIFIER * calculateWeight(bonus, ourPlayer_.MaxHealth, infos_.nextUpgradeCost(UpgradeType.MaximumHealth));
        }

        protected override void updateCapacity(){
			double bonus;

            switch (infos_.getLevels().CarryingCapacity)
			{
                case 0 :
                    bonus = 500;
                    break;
                case 1 :
                    bonus = 1000;
                    break;
                case 2 :
                    bonus = 2500;
                    break;
                case 3 :
                    bonus = 5000;
                    break;
                case 4 :
                    bonus = 15000;
                    break;
                default:
                    bonus = 0;
                    break;

			}

            capacityWeight_ = Constantes.CAPACITE_MODIFIER * calculateWeight(bonus, ourPlayer_.CarryingCapacity, infos_.nextUpgradeCost(UpgradeType.CarryingCapacity));
        }

    }
}