using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class SpineSnap
    {
        public const string Name = "Spinesnap";
        public const string PrefabName = "BowSpineSnap";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.SpineSnap, Modify, nameof(SpineSnap), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.SpineSnap, Restore, nameof(SpineSnap), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point light", "Particle System") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point light", "Particle System") && result;
            return result;
        }
    }
}
