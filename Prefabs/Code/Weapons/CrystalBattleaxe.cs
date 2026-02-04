using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;
using static A2.NoGlow.Prefabs.PrefabTools;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class CrystalBattleaxe
    {
        public const string Name = "Crystal battleaxe";
        public const string PrefabName = "BattleaxeCrystal";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryModify(prefabs, clones, PrefabName, ref Flags.CrystalBattleaxe, Modify, nameof(CrystalBattleaxe), nameof(Modify));
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs, IReadOnlyDictionary<string, GameObject[]> clones)
            => TryRestore(prefabs, clones, PrefabName, ref Flags.CrystalBattleaxe, Restore, nameof(CrystalBattleaxe), nameof(Restore));

        private static bool Modify(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenInactive("Point Light", "flare") && result;
            result = prefab.DisableShaderKeyword("default", "_EMISSION") && result;
            return result;
        }
        private static bool Restore(GameObject prefab)
        {
            var result = true;
            result = prefab.SetChildrenActive("Point Light", "flare") && result;
            result = prefab.EnableShaderKeyword("default", "_EMISSION") && result;
            return result;
        }
    }
}
