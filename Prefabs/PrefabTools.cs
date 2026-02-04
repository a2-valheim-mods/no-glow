using System;
using System.Collections.Generic;
using UnityEngine;

namespace A2.NoGlow.Prefabs
{
    internal static class PrefabTools
    {
        public static bool TryModify(
            IReadOnlyDictionary<string, GameObject> prefabs,
            IReadOnlyDictionary<string, GameObject[]> clones,
            string prefabName,
            ref PrefabState state,
            Func<GameObject, bool> modifyFunc,
            string callerClassName,
            string callerMethodName)
        {
            try
            {
                if (state != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: modifying state of the prefab {prefabName}");
#endif
                if (!prefabs.TryGetValue(prefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName} not found.");
                    return false;
                }

                var result = true;
                if (clones.TryGetValue(prefabName, out var prefabClones))
                {
                    foreach (var clone in prefabClones)
                    {
                        result = modifyFunc(clone) || result;
                    }
                }
                result = modifyFunc(prefab) && result;

                if (result) state = PrefabState.Modified;
                return result;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"{callerClassName}.{callerMethodName}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool TryModify(
            IReadOnlyDictionary<string, GameObject> prefabs,
            IReadOnlyDictionary<string, GameObject[]> clones,
            string prefabName1, string prefabName2,
            ref PrefabState state,
            Func<GameObject, bool> modifyFunc1, Func<GameObject, bool> modifyFunc2,
            string callerClassName,
            string callerMethodName)
        {
            try
            {
                if (state != PrefabState.ToModify) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: modifying state of the prefabs {prefabName1} and {prefabName2}");
#endif
                if (!prefabs.TryGetValue(prefabName1, out var prefab1))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName1} not found.");
                    return false;
                }
                if (!prefabs.TryGetValue(prefabName2, out var prefab2))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName2} not found.");
                    return false;
                }

                var result = true;
                if (clones.TryGetValue(prefabName1, out var prefab1Clones))
                {
                    foreach (var clone in prefab1Clones)
                    {
                        result = modifyFunc1(clone) || result;
                    }
                }
                if (clones.TryGetValue(prefabName2, out var prefab2Clones))
                {
                    foreach (var clone in prefab2Clones)
                    {
                        result = modifyFunc2(clone) || result;
                    }
                }
                result = modifyFunc1(prefab1) && result;
                result = modifyFunc2(prefab2) && result;

                if (result) state = PrefabState.Modified;
                return result;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"{callerClassName}.{callerMethodName}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool TryRestore(
            IReadOnlyDictionary<string, GameObject> prefabs,
            IReadOnlyDictionary<string, GameObject[]> clones,
            string prefabName,
            ref PrefabState state,
            Func<GameObject, bool> restoreFunc,
            string callerClassName,
            string callerMethodName)
        {
            try
            {
                if (state != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: restoring state of the prefab {prefabName}");
#endif
                if (!prefabs.TryGetValue(prefabName, out var prefab))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName} not found.");
                    return false;
                }

                var result = true;
                if (clones.TryGetValue(prefabName, out var prefabClones))
                {
                    foreach (var clone in prefabClones)
                    {
                        result = restoreFunc(clone) || result;
                    }
                }
                result = restoreFunc(prefab) && result;

                if (result) state = PrefabState.Restored;
                return result;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"{callerClassName}.{callerMethodName}: Exception occurred:\n{ex}");
                return false;
            }
        }
        public static bool TryRestore(
            IReadOnlyDictionary<string, GameObject> prefabs,
            IReadOnlyDictionary<string, GameObject[]> clones,
            string prefabName1, string prefabName2,
            ref PrefabState state,
            Func<GameObject, bool> restoreFunc1, Func<GameObject, bool> restoreFunc2,
            string callerClassName,
            string callerMethodName)
        {
            try
            {
                if (state != PrefabState.ToRestore) return false;
#if DEBUG
                Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: restoring state of the prefab {prefabName1} and {prefabName2}");
#endif
                if (!prefabs.TryGetValue(prefabName1, out var prefab1))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName1} not found.");
                    return false;
                }
                if (!prefabs.TryGetValue(prefabName2, out var prefab2))
                {
                    Jotunn.Logger.LogInfo($"{callerClassName}.{callerMethodName}: Prefab {prefabName2} not found.");
                    return false;
                }

                var result = true;
                if (clones.TryGetValue(prefabName1, out var prefab1Clones))
                {
                    foreach (var clone in prefab1Clones)
                    {
                        result = restoreFunc1(clone) || result;
                    }
                }
                if (clones.TryGetValue(prefabName2, out var prefab2Clones))
                {
                    foreach (var clone in prefab2Clones)
                    {
                        result = restoreFunc2(clone) || result;
                    }
                }
                result = restoreFunc1(prefab1) && result;
                result = restoreFunc2(prefab2) && result;

                if (result) state = PrefabState.Restored;
                return result;
            }
            catch (Exception ex)
            {
                Jotunn.Logger.LogError($"{callerClassName}.{callerMethodName}: Exception occurred:\n{ex}");
                return false;
            }
        }
    }
}
