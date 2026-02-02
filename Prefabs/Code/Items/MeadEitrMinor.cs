using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class MeadEitrMinor
    {
        public const string Name = "Minor eitr mead";
        public const string PrefabName = "MeadEitrMinor";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnMeadEitrMinor.Value) return true;
                if (Flags.MeadEitrMinor != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadEitrMinor)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadEitrMinor)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Point Light") && result;

                if (result) Flags.MeadEitrMinor = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadEitrMinor)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.MeadEitrMinor != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadEitrMinor)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadEitrMinor)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Point Light") && result;

                if (result) Flags.MeadEitrMinor = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadEitrMinor)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
