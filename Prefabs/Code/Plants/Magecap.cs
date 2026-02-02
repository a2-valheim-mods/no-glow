using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class Magecap
    {
        public const string Name = "Magecap";
        public const string PrefabName = "Pickable_Mushroom_Magecap";

        public static bool Modify(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnMagecap.Value) return true;
                if (Flags.Magecap != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(Magecap)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Magecap)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Point Light", "Particle System") && result;

                if (result) Flags.Magecap = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(Magecap)}.{nameof(Modify)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.Magecap != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(Magecap)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(Magecap)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Point Light", "Particle System") && result;

                if (result) Flags.Magecap = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(Magecap)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
