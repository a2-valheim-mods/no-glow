using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class YellowMushroom
    {
        public const string Name = "Yellow mushroom";
        public const string PrefabName1 = "Pickable_Mushroom_yellow";
        public const string PrefabName2 = "MushroomYellow";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName1, PrefabName2, ref Flags.YellowMushroom, ModifyPrefab1, ModifyPrefab2, nameof(YellowMushroom), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName1, PrefabName2, ref Flags.YellowMushroom, RestorePrefab1, RestorePrefab2, nameof(YellowMushroom), nameof(Restore));

        private static bool ModifyPrefab1(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light") && result;
            result = prefab.DisableShaderKeyword("visual", "_EMISSION") && result;
            return result;
        }
        private static bool ModifyPrefab2(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light") && result;
            return result;
        }
        private static bool RestorePrefab1(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light") && result;
            result = prefab.EnableShaderKeyword("visual", "_EMISSION") && result;
            return result;
        }
        private static bool RestorePrefab2(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light") && result;
            return result;
        }
    }
}
