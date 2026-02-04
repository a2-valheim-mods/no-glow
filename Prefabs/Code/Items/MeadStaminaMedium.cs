using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class MeadStaminaMedium
    {
        public const string Name = "Medium stamina mead";
        public const string PrefabName = "MeadStaminaMedium";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.MeadStaminaMedium, Modify, nameof(MeadStaminaMedium), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.MeadStaminaMedium, Restore, nameof(MeadStaminaMedium), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point Light") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point Light") && result;
            return result;
        }
    }
}