using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class StaffOfTheWild
    {
        public const string Name = "Staff of the Wild";
        public const string PrefabName = "StaffGreenRoots";

        public static bool Modify(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnStaffOfTheWild.Value) return true;
                if (Flags.StaffOfTheWild != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(StaffOfTheWild)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(StaffOfTheWild)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetSubChildrenInactive("effects", "Point light", "flare", "embers (1)") && result;
                result = prefab.SetSubChildrenInactive("glow", "Point light", "flare") && result;

                if (result) Flags.StaffOfTheWild = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(StaffOfTheWild)}.{nameof(Modify)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.StaffOfTheWild != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(StaffOfTheWild)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(StaffOfTheWild)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetSubChildrenActive("effects", "Point light", "flare", "embers (1)") && result;
                result = prefab.SetSubChildrenActive("glow", "Point light", "flare") && result;

                if (result) Flags.StaffOfTheWild = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(StaffOfTheWild)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
