using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class StaffOfTheWild
    {
        public const string Name = "Staff of the Wild";
        public const string PrefabName = "StaffGreenRoots";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.StaffOfTheWild, Modify, nameof(StaffOfTheWild), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.StaffOfTheWild, Restore, nameof(StaffOfTheWild), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenInactive("effects", "Point light", "flare", "embers (1)") && result;
            result = prefab.SetSubChildrenInactive("glow", "Point light", "flare") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenActive("effects", "Point light", "flare", "embers (1)") && result;
            result = prefab.SetSubChildrenActive("glow", "Point light", "flare") && result;
            return result;
        }
    }
}
