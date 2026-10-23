using GorillaNetworking;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ForeverCosmetx.Patches
{
    [HarmonyPatch(typeof(VRRig), "IsItemAllowed")]
    internal class AllowedPatch
    {
        private static bool Prefix(ref bool __result)
        {
            __result = true;
            return false; // skip the original method
        }
    }
}
