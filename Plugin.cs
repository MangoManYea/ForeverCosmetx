using BepInEx;
using GorillaNetworking;
using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

/*
 * I'm tired of the 4000 different Cosmetx "Fixes".
 * Some of them even have MALWARE in them.
 * To get this stressed out over cosmetics is terrible.
 * And the fact that they are all unoptimized and terrible puts salt in the wound.
 * 
 * This Cosmetx mod should work FOREVER unless CosmeticsController gets severely updated in a bad way.
 */

namespace ForeverCosmetx
{
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public static Plugin instance;
        void Awake()
        {
            instance = this;
            HarmonyPatches.ApplyHarmonyPatches();
        }

        public void UnlockCosmetics()
        {
            var cosmeticsconcat = String.Concat(VRRig.LocalRig._playerOwnedCosmetics);
            foreach (CosmeticsController.CosmeticItem cosmeticItem in CosmeticsController.instance.allCosmetics)
            {
                if (!cosmeticsconcat.Contains(cosmeticItem.itemName))
                {
                    try
                    {
                        CosmeticsController.instance.UnlockItem(cosmeticItem.itemName, false);
                    } catch { }
                }
            }

            CosmeticsController.instance.OnCosmeticsUpdated.Invoke();
        }
    }
}
