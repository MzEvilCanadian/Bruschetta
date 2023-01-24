﻿using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Bruschetta.Customs.BruschettaProcess
{
    class PlatedBruschetta : CustomItemGroup
    {
        public override string UniqueNameID => "Plated Bruschetta";
        public override GameObject Prefab => Mod.bundle.LoadAsset<GameObject>("BruschettaPlated");
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override Item DirtiesTo => Mod.ServingBoard;
        public override Item DisposesTo => Mod.ServingBoard;
        public override int MaxOrderSharers => 2;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.AssembledBruschettaStage2
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>
                {
                    Mod.ServingBoard
                }
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Bread - Inside"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Bread - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Tomato");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (2)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Onion - Cooked");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (3)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Wood 1 - Dim");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (4)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Olive Oil Bottle");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (5)", materials);
        }
    }
}
