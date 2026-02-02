using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class GaldrTable
    {
        public const string Name = "Galdr table";
        public const string PrefabName = "piece_magetable";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnGaldrTable.Value) return true;
                if (Flags.GaldrTable != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(GaldrTable)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(GaldrTable)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Effects") && result;

                if (result) Flags.GaldrTable = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(GaldrTable)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.GaldrTable != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(GaldrTable)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(GaldrTable)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Effects") && result;

                if (result) Flags.GaldrTable = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(GaldrTable)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
