using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class StaffOfEmbers
    {
        public const string Name = "Staff of Embers";
        public const string PrefabName = "StaffFireball";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.StaffOfEmbers, Modify, nameof(StaffOfEmbers), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.StaffOfEmbers, Restore, nameof(StaffOfEmbers), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenInactive("equiped", "embers", "flames") && result;
            result = prefab.SetSubChildrenInactive("effects", "Point light", "flare", "embers (1)") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenActive("equiped", "embers", "flames") && result;
            result = prefab.SetSubChildrenActive("effects", "Point light", "flare", "embers (1)") && result;
            return result;
        }
    }
}
