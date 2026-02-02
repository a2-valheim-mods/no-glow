using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class MeadStaminaLingering
    {
        public const string Name = "Lingering stamina mead";
        public const string PrefabName = "MeadStaminaLingering";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnMeadStaminaLingering.Value) return true;
                if (Flags.MeadStaminaLingering != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadStaminaLingering)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadStaminaLingering)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Point Light") && result;

                if (result) Flags.MeadStaminaLingering = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadStaminaLingering)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.MeadStaminaLingering != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadStaminaLingering)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadStaminaLingering)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Point Light") && result;

                if (result) Flags.MeadStaminaLingering = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadStaminaLingering)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
