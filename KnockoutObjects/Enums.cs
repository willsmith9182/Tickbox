// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enums.cs" company="TickBox Inc.">
//   Copyright 2013 William J J Smith
// </copyright>
// <summary>
//   The model update type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace KnockoutObjects
{
    /// <summary>
    /// The enums.
    /// </summary>
    public static class Enums
    {
        /// <summary>
        /// The model update type.
        /// </summary>
        public enum ModelUpdateType
        {
            /// <summary>
            /// The update values and validate.
            /// </summary>
            UpdateValuesAndValidate = 0,

            /// <summary>
            /// The cancel any changes.
            /// </summary>
            CancelAnyChanges = 1,

            /// <summary>
            /// The set saved state.
            /// </summary>
            SetSavedState = 2,

            /// <summary>
            /// The edit mode.
            /// </summary>
            EnterEditMode = 4,

            /// <summary>
            /// The exit edit mode.
            /// </summary>
            ExitEditMode = 5,

            /// <summary>
            /// The refresh state.
            /// </summary>
            RefreshState = 6
        }
    }
}
