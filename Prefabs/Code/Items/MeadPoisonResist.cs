using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class MeadPoisonResist
    {
        public const string Name = "Poison resistance mead";
        public const string PrefabName = "MeadPoisonResist";

        public static bool Modify(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (!PluginConfig.DisableGlowOnMeadPoisonResist.Value) return true;
                if (Flags.MeadPoisonResist != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadPoisonResist)}.{nameof(Modify)}: modifying state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadPoisonResist)}.{nameof(Modify)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenInactive("Point Light") && result;

                if (result) Flags.MeadPoisonResist = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadPoisonResist)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(IReadOnlyDictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.MeadPoisonResist != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(MeadPoisonResist)}.{nameof(Restore)}: restoring state of the prefab {PrefabName}");
#endif
                if (!prefabs.TryGetValue(PrefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{nameof(MeadPoisonResist)}.{nameof(Restore)}: Prefab {PrefabName} not found.");
                    return false;
                }

                var result = true;
                result = prefab.SetChildrenActive("Point Light") && result;

                if (result) Flags.MeadPoisonResist = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(MeadPoisonResist)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
