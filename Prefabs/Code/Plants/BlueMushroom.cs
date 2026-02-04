using A2.NoGlow.Unity;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs.Code
{
    internal static class BlueMushroom
    {
        public const string Name = "Blue mushroom";
        public const string PrefabName1 = "Pickable_Mushroom_blue";
        public const string PrefabName2 = "MushroomBlue";

        public static bool Modify(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.BlueMushroom != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(Modify)}: modifying state of the prefabs {PrefabName1}, {PrefabName2}");
#endif

                var result = true;
                result = ModifyPrefab1(prefabs) && result;
                result = ModifyPrefab2(prefabs) && result;

                if (result) Flags.BlueMushroom = PrefabState.Modified;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(BlueMushroom)}.{nameof(Modify)}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool Restore(Dictionary<string, GameObject> prefabs)
        {
            try
            {
                if (Flags.BlueMushroom != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(Restore)}: restoring state of the prefabs {PrefabName1}, {PrefabName2}");
#endif

                var result = true;
                result = RestorePrefab1(prefabs) && result;
                result = RestorePrefab2(prefabs) && result;

                if (result) Flags.BlueMushroom = PrefabState.Restored;
                return result;
            }
            catch (System.Exception ex)
            {
                Jotunn.Logger.LogError($"{nameof(BlueMushroom)}.{nameof(Restore)}: Exception occurred:\n{ex}");
                return false;
            }
        }

        private static bool ModifyPrefab1(Dictionary<string, GameObject> prefabs)
        {
            if (!prefabs.TryGetValue(PrefabName1, out var prefab))
            {
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(ModifyPrefab1)}: Prefab {PrefabName1} not found.");
                return false;
            }
            var result = true;
            result = prefab.SetChildrenInactive("Point light") && result;
            result = prefab.DisableShaderKeyword("visual", "_EMISSION") && result;
            return result;
        }
        private static bool ModifyPrefab2(Dictionary<string, GameObject> prefabs)
        {
            if (!prefabs.TryGetValue(PrefabName2, out var prefab))
            {
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(ModifyPrefab2)}: Prefab {PrefabName2} not found.");
                return false;
            }
            var result = true;
            result = prefab.SetChildrenInactive("Point light") && result;
            return result;
        }
        private static bool RestorePrefab1(Dictionary<string, GameObject> prefabs)
        {
            if (!prefabs.TryGetValue(PrefabName1, out var prefab))
            {
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(RestorePrefab1)}: Prefab {PrefabName1} not found.");
                return false;
            }
            var result = true;
            result = prefab.SetChildrenActive("Point light") && result;
            result = prefab.EnableShaderKeyword("visual", "_EMISSION") && result;
            return result;
        }
        private static bool RestorePrefab2(Dictionary<string, GameObject> prefabs)
        {
            if (!prefabs.TryGetValue(PrefabName2, out var prefab))
            {
                Jotunn.Logger.LogInfo($"{nameof(BlueMushroom)}.{nameof(RestorePrefab2)}: Prefab {PrefabName2} not found.");
                return false;
            }
            var result = true;
            result = prefab.SetChildrenActive("Point light") && result;
            return result;
        }
    }
}
