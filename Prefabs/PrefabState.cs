namespace A2.NoGlow.Prefabs
{
    /// <summary>
    /// Represents the current lifecycle state of a prefab regarding glow modifications.
    /// 
    /// Each prefab tracked by <see cref="Flags"/> can be in one of these states
    /// to indicate whether it should be modified, restored, or is already in a final state.
    /// </summary>
    internal enum PrefabState
    {
        /// <summary>
        /// The state of the prefab is unknown. This is the default starting state.
        /// </summary>
        Unknown,
        /// <summary>
        /// The prefab has been flagged to be modified (for glow to be disabled) 
        /// but the modification has not yet been applied.
        /// </summary>
        ToModify,
        /// <summary>
        /// The prefab has already been modified (glow disabled).
        /// </summary>
        Modified,
        /// <summary>
        /// The prefab has been flagged for restoration to its original state 
        /// glow should be re-enabled) but the restoration has not yet been applied.
        /// </summary>
        ToRestore,
        /// <summary>
        /// The prefab has been restored to its original state.
        /// </summary>
        Restored,
    }
}
