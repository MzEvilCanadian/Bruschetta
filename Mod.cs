using Bruschetta.Customs.BruschettaProcess;
using Bruschetta.Registry;
using Bruschetta.Dishes;
using KitchenData;
using KitchenLib;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenMods;
using KitchenLib.Event;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;
using ItemReference = KitchenLib.References.ItemReferences;

namespace Bruschetta
{
    public class Mod : BaseMod
    {
        internal const string MOD_ID = "Bruschetta";
        internal const string MOD_NAME = "Bruschetta";
        internal const string MOD_VERSION = "0.0.2";
        internal const string MOD_AUTHOR = "MzEvilCanadian";
        internal const string PLATEUP_VERSION = "1.1.2";

      //  public static AssetBundle bundle;

        internal static Item ServingBoard => GetExistingGDO<Item>(ItemReference.ServingBoard);
        internal static Item BreadSlice => GetExistingGDO<Item>(ItemReference.BreadSlice);
        internal static Item Flour => GetExistingGDO<Item>(ItemReference.Flour);
        internal static Item Tomato => GetExistingGDO<Item>(ItemReference.Tomato);
        internal static Item TomatoChopped => GetExistingGDO<Item>(ItemReference.TomatoChopped);
        internal static Item Onion => GetExistingGDO<Item>(ItemReference.Onion);
        internal static Item OnionChopped => GetExistingGDO<Item>(ItemReference.OnionChopped);
        internal static Item Oil => GetExistingGDO<Item>(ItemReference.Oil);
        internal static Item OilIngredient => GetExistingGDO<Item>(ItemReference.OilIngredient);

        internal static Process Cook => GetExistingGDO<Process>(ProcessReferences.Cook);
        internal static Process Chop => GetExistingGDO<Process>(ProcessReferences.Chop);
        internal static Process Knead => GetExistingGDO<Process>(ProcessReferences.Knead);

        internal static Item BurntBruschetta => GetModdedGDO<Item, BurntBruschetta>();
        internal static Item CookedBread => GetModdedGDO<Item, CookedBread>();
        internal static ItemGroup UncookedBruschetta => GetModdedGDO<ItemGroup, UncookedBruschetta>();
        internal static ItemGroup AssembledBruschetta => GetModdedGDO<ItemGroup, AssembledBruschetta>();
        internal static ItemGroup PlatedBruschetta => GetModdedGDO<ItemGroup, PlatedBruschetta>();
        internal static Dish BruschettaDish => GetModdedGDO<Dish, BruschettaDish>();


        internal static bool debug = true;
        public static void LogInfo(string _log) { Debug.Log($"[{MOD_NAME}] " + _log); }
        public static void LogInfo(object _log) { LogInfo(_log.ToString()); }

        public Mod() : base(MOD_ID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, $"{PLATEUP_VERSION}", Assembly.GetExecutingAssembly())
        {
            string bundlePath = Path.Combine(new string[] { Directory.GetParent(Application.dataPath).FullName, "Mods", ModID });

            Debug.Log($"{MOD_NAME} {MOD_VERSION} {MOD_AUTHOR}: Loaded");
            Debug.Log($"Assets Loaded From {bundlePath}");
        }
        public override void PostActivate(KitchenMods.Mod mod)
        {
            base.PostActivate(mod);
            //    bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).ToList()[0];

            AddGameDataObject<BurntBruschetta>();
            AddGameDataObject<CookedBread>();
            AddGameDataObject<UncookedBruschetta>();
            AddGameDataObject<AssembledBruschetta>();
            AddGameDataObject<PlatedBruschetta>();
            AddGameDataObject<BruschettaDish>();

            Events.BuildGameDataEvent += delegate (object s, BuildGameDataEventArgs args)
            {
                ModRegistry.HandleBuildGameDataEvent(args);
            };
        }
        protected override void OnUpdate() { }
        private static T1 GetModdedGDO<T1, T2>() where T1 : GameDataObject
        {
            return (T1)GDOUtils.GetCustomGameDataObject<T2>().GameDataObject;
        }
        private static T GetExistingGDO<T>(int id) where T : GameDataObject
        {
            return (T)GDOUtils.GetExistingGDO(id);
        }
    }
}