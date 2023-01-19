using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace Bruschetta.Customs.BruschettaProcess
{
    class BurntBruschetta : CustomItem
    {
        public override string UniqueNameID => "BurntBruschetta";
        public override GameObject Prefab => Mod.Oil.Prefab;
        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.OutsideRubbish;

        /*
        public override void OnRegister(GameDataObject gameDataObject)
        {
            var materials = new Material[]
            {
                MaterialUtils.GetExistingMaterial("Burned"),
             };
            MaterialUtils.ApplyMaterial(Prefab, "GameObject", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (1)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (2)", materials);
            materials[0] = MaterialUtils.GetExistingMaterial("Burned - Light");
            MaterialUtils.ApplyMaterial(Prefab, "GameObject (3)", materials);

            // MaterialUtils.ApplyMaterial([object], [name], [material list]
        }
        */
    }
}
