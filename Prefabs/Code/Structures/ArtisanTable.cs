using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class ArtisanTable
    {
        public const string Name = "Artisan table";
        public const string PrefabName = "piece_artisanstation";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.ArtisanTable, Modify, nameof(ArtisanTable), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.ArtisanTable, Restore, nameof(ArtisanTable), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenInactive("Tear", "flare", "smoke_expl", "pixel flakes", "Point light") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetSubChildrenActive("Tear", "flare", "smoke_expl", "pixel flakes", "Point light") && result;
            return result;
        }
    }
}
