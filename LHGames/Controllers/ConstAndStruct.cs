using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{
    
    
    static const uint ATTACK_MODIFIER = 10;
    static const uint PROTECTION_MODIFIER = 30;
    static const uint GATHER_MODIFIER = 60;
    static const uint WEIGHT_FACTOR = 100;
    static const uint COST_ADJUSTEMENT = 1000;
    
    public struct HeldItems{

        public HeldItems(bool sword, bool shield, bool backpack, bool pickaxe, uint potions)
        {
            MicrosoftSword = sword;
            UbisoftShield = shield;
            DevolutionsBackpack = backpack;
            DevolutionsPickaxe = pickaxe;
            HealthPotion = potions;

    }
        public bool MicrosoftSword,
        UbisoftShield,
        DevolutionsBackpack,
        DevolutionsPickaxe;
        public uint HealthPotion;
    }

    public struct StatLevels{


        CarryingCapacity
           AttackPower
            Defence
            MaximumHealth,
            CollectingSpeed
        public uint CarryingCapacity,
        AttackPower,
        Defence,
        MaximumHealth,
        CollectingSpeed;
    }

    public struct StartingState
    {
        public HeldItems items;
        public StatLevels levels;
    }
}