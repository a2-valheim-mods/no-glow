using System;
using System.Linq;
using UnityEngine;

namespace A2.NoGlow.Unity
{
    /// <summary>
    /// Provides extension methods for <see cref="GameObject"/> to enable or disable
    /// children, sub-children, and shader keywords by name.
    /// </summary>
    internal static class GameObjectExtensions
    {
        /// <summary>
        /// Deactivates the immediate children of the given <paramref name="prefab"/>
        /// whose names match any of the specified <paramref name="names"/>.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/> whose children will be modified.</param>
        /// <param name="names">The names of children to deactivate (case-insensitive).</param>
        /// <returns>
        /// <c>true</c> if at least one child was deactivated; otherwise, <c>false</c>.
        /// </returns>
        public static bool SetChildrenInactive(this GameObject prefab, params string[] names)
        {
            if (prefab == null) return false;

            var updated = 0;
            var children = prefab.GetComponentsInChildren<Transform>(false);
            foreach (var child in children)
            {
                if (child != null && names.Contains(child.name, StringComparer.InvariantCultureIgnoreCase))
                {
                    var gameObject = child.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                        updated++;
                    }
                }
            }
            return updated > 0;
        }
        /// <summary>
        /// Deactivates the children of a specific sub-parent within the given <paramref name="prefab"/>.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/>.</param>
        /// <param name="subParent">The name of the sub-parent whose children will be processed.</param>
        /// <param name="names">The names of children to deactivate (case-insensitive).</param>
        /// <returns>
        /// <c>true</c> if at least one sub-child was deactivated; otherwise, <c>false</c>.
        /// </returns>
        public static bool SetSubChildrenInactive(this GameObject prefab, string subParent, params string[] names)
        {
            if (prefab == null) return false;

            var subParentPrefab = prefab.GetComponentsInChildren<Transform>(true)?.FirstOrDefault(x => string.Compare(x.name, subParent, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (subParentPrefab == null) return false;

            var updated = 0;
            var children = subParentPrefab.GetComponentsInChildren<Transform>(false);
            foreach (var child in children)
            {
                if (child != null && names.Contains(child.name, StringComparer.InvariantCultureIgnoreCase))
                {
                    var gameObject = child.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.SetActive(false);
                        updated++;
                    }
                }
            }
            return updated > 0;
        }
        /// <summary>
        /// Activates the immediate children of the given <paramref name="prefab"/>
        /// whose names match any of the specified <paramref name="names"/>.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/> whose children will be modified.</param>
        /// <param name="names">The names of children to activate (case-insensitive).</param>
        /// <returns>
        /// <c>true</c> if at least one child was activated; otherwise, <c>false</c>.
        /// </returns>
        public static bool SetChildrenActive(this GameObject prefab, params string[] names)
        {
            if (prefab == null) return false;

            var updated = 0;
            var children = prefab.GetComponentsInChildren<Transform>(true);
            foreach (var child in children)
            {
                if (child != null && names.Contains(child.name, StringComparer.InvariantCultureIgnoreCase))
                {
                    var gameObject = child.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.SetActive(true);
                        updated++;
                    }
                }
            }
            return updated > 0;
        }
        /// <summary>
        /// Activates the children of a specific sub-parent within the given <paramref name="prefab"/>.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/>.</param>
        /// <param name="subParent">The name of the sub-parent whose children will be processed.</param>
        /// <param name="names">The names of children to activate (case-insensitive).</param>
        /// <returns>
        /// <c>true</c> if at least one sub-child was activated; otherwise, <c>false</c>.
        /// </returns>
        public static bool SetSubChildrenActive(this GameObject prefab, string subParent, params string[] names)
        {
            if (prefab == null) return false;

            var subParentPrefab = prefab.GetComponentsInChildren<Transform>(true)?.FirstOrDefault(x => string.Compare(x.name, subParent, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (subParentPrefab == null) return false;

            var updated = 0;
            var children = subParentPrefab.GetComponentsInChildren<Transform>(true);
            foreach (var child in children)
            {
                if (child != null && names.Contains(child.name, StringComparer.InvariantCultureIgnoreCase))
                {
                    var gameObject = child.gameObject;
                    if (gameObject != null)
                    {
                        gameObject.SetActive(true);
                        updated++;
                    }
                }
            }
            return updated > 0;
        }
        /// <summary>
        /// Disables a shader keyword on the <see cref="Renderer"/> of the specified child.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/> containing the renderer.</param>
        /// <param name="rendererName">The name of the child <see cref="Renderer"/> to modify (case-insensitive).</param>
        /// <param name="keyword">The shader keyword to disable.</param>
        /// <returns>
        /// <c>true</c> if the keyword was successfully disabled; otherwise, <c>false</c>
        /// (e.g. if prefab, renderer, or material is null).
        /// </returns>
        public static bool DisableShaderKeyword(this GameObject prefab, string rendererName, string keyword)
        {
            if (prefab == null) return false;

            var renderer = prefab?.GetComponentsInChildren<Renderer>()?.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.name, rendererName) == 0);
            if (renderer == null) return false;

            var material = renderer.sharedMaterial;
            if (material == null) return false;

            material.DisableKeyword(keyword);
            return true;
        }
        /// <summary>
        /// Enables a shader keyword on the <see cref="Renderer"/> of the specified child.
        /// </summary>
        /// <param name="prefab">The parent <see cref="GameObject"/> containing the renderer.</param>
        /// <param name="rendererName">The name of the child <see cref="Renderer"/> to modify (case-insensitive).</param>
        /// <param name="keyword">The shader keyword to enable.</param>
        /// <returns>
        /// <c>true</c> if the keyword was successfully enabled; otherwise, <c>false</c>
        /// (e.g. if prefab, renderer, or material is null).
        /// </returns>
        public static bool EnableShaderKeyword(this GameObject prefab, string rendererName, string keyword)
        {
            if (prefab == null) return false;

            var renderer = prefab?.GetComponentsInChildren<Renderer>()?.FirstOrDefault(x => StringComparer.InvariantCultureIgnoreCase.Compare(x.name, rendererName) == 0);
            if (renderer == null) return false;

            var material = renderer.sharedMaterial;
            if (material == null) return false;

            material.EnableKeyword(keyword);
            return true;
        }
    }
}
