using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class LargeGlowingMushroom
    {
        public const string Name = "Large glowing mushroom";
        public const string PrefabName = "GlowingMushroom";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.LargeGlowingMushroom, Modify, nameof(LargeGlowingMushroom), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.LargeGlowingMushroom, Restore, nameof(LargeGlowingMushroom), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light") && result;
            result = prefab.DisableShaderKeyword("Cube", "_EMISSION") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light") && result;
            result = prefab.EnableShaderKeyword("Cube", "_EMISSION") && result;
            return result;
        }
    }
}
