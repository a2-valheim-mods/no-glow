using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class GaldrTable
    {
        public const string Name = "Galdr table";
        public const string PrefabName = "piece_magetable";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.GaldrTable, Modify, nameof(GaldrTable), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.GaldrTable, Restore, nameof(GaldrTable), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Effects") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Effects") && result;
            return result;
        }
    }
}
