using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class MeadStaminaMedium
    {
        public const string Name = "Medium stamina mead";
        public const string PrefabName = "MeadStaminaMedium";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnMeadStaminaMedium.Value) return true;
                if (Flags.MeadStaminaMedium != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadStaminaMedium)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadStaminaMedium)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Point Light") && result;

                if (result) Flags.MeadStaminaMedium = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadStaminaMedium)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.MeadStaminaMedium != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadStaminaMedium)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadStaminaMedium)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Point Light") && result;

                if (result) Flags.MeadStaminaMedium = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadStaminaMedium)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
