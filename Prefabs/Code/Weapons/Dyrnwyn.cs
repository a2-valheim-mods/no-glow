using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class Dyrnwyn
    {
        public const string Name = "Dyrnwyn";
        public const string PrefabName1 = "SwordIronFire";
        public const string PrefabName2 = "SwordDyrnwyn";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName1, PrefabName2, ref Flags.Dyrnwyn, ModifyPrefab1, ModifyPrefab2, nameof(Dyrnwyn), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName1, PrefabName2, ref Flags.Dyrnwyn, RestorePrefab1, RestorePrefab2, nameof(Dyrnwyn), nameof(Restore));

        private static bool ModifyPrefab1(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light", "sfx_fire_loop", "flames (1)", "embers", "flames_local", "flames", "smoke (1)") && result;
            result = prefab.DisableShaderKeyword("Viking_Sword (1)", "_EMISSION") && result;
            return result;
        }
        private static bool ModifyPrefab2(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light", "Burny vfx") && result;
            result = prefab.DisableShaderKeyword("default", "_EMISSION") && result;
            return result;
        }
        private static bool RestorePrefab1(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light", "sfx_fire_loop", "flames (1)", "embers", "flames_local", "flames", "smoke (1)") && result;
            result = prefab.EnableShaderKeyword("Viking_Sword (1)", "_EMISSION") && result;
            return result;
        }
        private static bool RestorePrefab2(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light", "Burny vfx") && result;
            result = prefab.EnableShaderKeyword("default", "_EMISSION") && result;
            return result;
        }
    }
}
