using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class BlueMushroom
    {
        public const string Name = "Blue mushroom";
        public const string PrefabName1 = "Pickable_Mushroom_blue";
        public const string PrefabName2 = "MushroomBlue";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName1, PrefabName2, ref Flags.BlueMushroom, ModifyPrefab1, ModifyPrefab2, nameof(BlueMushroom), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName1, PrefabName2, ref Flags.BlueMushroom, RestorePrefab1, RestorePrefab2, nameof(BlueMushroom), nameof(Restore));

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
