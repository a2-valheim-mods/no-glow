using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class StaffOfEmbers
    {
        public const string Name = "Staff of Embers";
        public const string PrefabName = "StaffFireball";

        public static bool Modify(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnStaffOfEmbers.Value) return true;
                if (Flags.StaffOfEmbers != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(StaffOfEmbers)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(StaffOfEmbers)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetSubChildrenInactive("equiped", "embers", "flames") && result;
                result = prefab.SetSubChildrenInactive("effects", "Point light", "flare", "embers (1)") && result;

                if (result) Flags.StaffOfEmbers = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(StaffOfEmbers)}.{nameof(Modify)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.StaffOfEmbers != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(StaffOfEmbers)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(StaffOfEmbers)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetSubChildrenActive("equiped", "embers", "flames") && result;
                result = prefab.SetSubChildrenActive("effects", "Point light", "flare", "embers (1)") && result;

                if (result) Flags.StaffOfEmbers = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(StaffOfEmbers)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
