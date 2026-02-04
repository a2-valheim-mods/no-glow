using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class JotunBane
    {
        public const string Name = "Jotun Bane";
        public const string PrefabName = "AxeJotunBane";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.JotunBane, Modify, nameof(JotunBane), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.JotunBane, Restore, nameof(JotunBane), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light", "Glow", "poison drip", "poison splat") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light", "Glow", "poison drip", "poison splat") && result;
            return result;
        }
    }
}
