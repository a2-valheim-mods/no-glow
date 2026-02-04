using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class StaffOfFrost
    {
        public const string Name = "Staff of Frost";
        public const string PrefabName = "StaffIceShards";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.StaffOfFrost, Modify, nameof(StaffOfFrost), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.StaffOfFrost, Restore, nameof(StaffOfFrost), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light", "flare", "embers (1)") && result;
            result = prefab.DisableShaderKeyword("default (1)", "_EMISSION") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light", "flare", "embers (1)") && result;
            result = prefab.EnableShaderKeyword("default (1)", "_EMISSION") && result;
            return result;
        }
    }
}
