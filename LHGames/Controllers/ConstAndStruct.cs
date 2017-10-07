using System;
using System.Collections.Generic;
using StarterProject.Web.Api;

namespace Harembis
{

    public static class Constantes
    {
       public const uint ATTACK_MODIFIER = 10;
       public const uint PROTECTION_MODIFIER = 30;
        public const uint GATHER_MODIFIER = 60;
       public const uint WEIGHT_FACTOR = 100;
        public const uint COST_ADJUSTEMENT = 1000;
    }
    public struct HeldItems{

        public HeldItems(bool sword, bool shield, bool backpack, bool pickaxe, int potions)
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
        public int HealthPotion;
    }

    public struct StatLevels{

        public StatLevels(int capacity, int attack, int defence, int health, int speed) {
            CarryingCapacity = capacity;
            AttackPower = attack;
            Defence = defence;
            MaximumHealth = health;
            CollectingSpeed = speed;
            }

        public int CarryingCapacity,
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