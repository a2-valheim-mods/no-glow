using A2.NoGlow;
using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class Dyrnwyn
    {
        public const string Name = "Dyrnwyn";
        public const string PrefabName1 = "SwordIronFire";
        public const string PrefabName2 = "SwordDyrnwyn";

        public static bool Modify(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.Dyrnwyn != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Modify)}: modifying state of the prefabs {PrefabName1}, {PrefabName2}");
#endif
                if (!prefabs.TryGetValue(PrefabName1, out var prefab1))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Modify)}: Prefab {PrefabName1} not found.");
                    return false;
                }
                if (!prefabs.TryGetValue(PrefabName2, out var prefab2))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Modify)}: Prefab {PrefabName2} not found.");
                    return false;
                }

                var result = true;
                result = prefab1.SetChildrenInactive("Point light", "sfx_fire_loop", "flames (1)", "embers", "flames_local", "flames", "smoke (1)") && result;
                result = prefab1.DisableShaderKeyword("Viking_Sword (1)", "_EMISSION") && result;
                result = prefab2.SetChildrenInactive("Point light", "Burny vfx") && result;
                result = prefab2.DisableShaderKeyword("default", "_EMISSION") && result;

                if (result) Flags.Dyrnwyn = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(Dyrnwyn)}.{nameof(Modify)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.Dyrnwyn != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Restore)}: restoring state of the prefabs {PrefabName1}, {PrefabName2}");
#endif
                if (!prefabs.TryGetValue(PrefabName1, out var prefab1))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Modify)}: Prefab {PrefabName1} not found.");
                    return false;
                }
                if (!prefabs.TryGetValue(PrefabName2, out var prefab2))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Dyrnwyn)}.{nameof(Restore)}: Prefab {PrefabName2} not found.");
                    return false;
                }

                var result = true;
                result = prefab1.SetChildrenActive("Point light", "sfx_fire_loop", "flames (1)", "embers", "flames_local", "flames", "smoke (1)") && result;
                result = prefab1.EnableShaderKeyword("Viking_Sword (1)", "_EMISSION") && result;
                result = prefab2.SetChildrenActive("Point light", "Burny vfx") && result;
                result = prefab2.EnableShaderKeyword("default", "_EMISSION") && result;

                if (result) Flags.Dyrnwyn = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(Dyrnwyn)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
