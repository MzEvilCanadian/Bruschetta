﻿using KitchenData;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bruschetta.Dishes
{
    class BruschettaDish : ModDish
    {
        public override string UniqueNameID => "Bruschetta";
        public override DishType Type => DishType.Starter;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallDecrease;
        public override CardType CardType => CardType.Default;
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Small;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = Main.PlatedBruschetta,
                Phase = MenuPhase.Starter,
                Weight = 1
            }
        };
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>
        {
            Main.Flour,
            Main.Tomato,
            Main.Onion,
            Main.Oil,
            Main.ServingBoard
        };
        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            Main.Cook,
            Main.Chop,
            Main.Knead
        };

        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Put oil on a bread slice then toast. Add chopped tomato then chopped onion. Place on Serving Board. Serves multiple Customers" }
        };
        public override IDictionary<Locale, UnlockInfo> LocalisedInfo => new Dictionary<Locale, UnlockInfo>
        {
            { Locale.English, LocalisationUtils.CreateUnlockInfo("Bruschetta", "Adds Bruschetta as a Starter", "Broo - skeh - tuh") }
        };
    }
}
