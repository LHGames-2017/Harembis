using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{

	public class UpgradeItem : Upgrade
	{
		public UpgradeItem(Player ourPlayer, ExtendedInfo infos) : base(ourPlayer, infos) {
            healthWeight_ = 0;
        }

        public Tuple<PurchasableItem, int, int> getNextItem()
		{
            updateAllWeight();

			PurchasableItem type;
            int weight;

            if (attackWeight_ > defenceWeight_ && attackWeight_ > capacityWeight_ && attackWeight_ > collectingWeight_ && !infos_.getItems().MicrosoftSword){
                type = PurchasableItem.MicrosoftSword;
                weight = attackWeight_;
            }
            else if(defenceWeight_ > capacityWeight_ && defenceWeight_ > collectingWeight_ && !infos_.getItems().UbisoftShield) {
                type = PurchasableItem.UbisoftShield;
                weight = defenceWeight_;
            }
            else if(capacityWeight_ > collectingWeight_ && !infos_.getItems().DevolutionsBackpack) {
                type = PurchasableItem.DevolutionsBackpack;
                weight = capacityWeight_;
            }
            else if (!infos_.getItems().DevolutionsPickaxe){
                type = PurchasableItem.DevolutionsPickaxe;
                weight = collectingWeight_;
            }
            else {
                type = PurchasableItem.DevolutionsPickaxe;
                weight = 0;
            }

            return new Tuple<PurchasableItem, int, int>(type, 40000, weight);
		}

        protected override void updateAllWeight(){
            updateAttack();
            updateDefence();
            updateCapacity();
            updateCollecting();
        }

		void updateCollecting()
		{
			collectingWeight_ = Constantes.GATHER_MODIFIER * calculateWeight(0.75, infos_.getGatherSpeed(), 40000);
		}

		void updateCapacity()
		{
			capacityWeight_ = Constantes.CAPACITE_MODIFIER * calculateWeight(2000, ourPlayer_.CarryingCapacity, 40000);
		}

		void updateAttack()
		{
			attackWeight_ = Constantes.ATTACK_MODIFIER * calculateWeight(2, infos_.getAttack(), 40000);
		}

		void updateDefence()
		{
            defenceWeight_ = Constantes.DEFENCE_MODIFIER * calculateWeight(2, infos_.getDefence(), 40000);

		}

	}
}