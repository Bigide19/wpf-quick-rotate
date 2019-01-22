namespace Display
{
    enum DisplayChangeResult
    {
        /// <summary>
        /// Windows XP: The settings change was unsuccessful because system is DualView capable.
        /// </summary>
        BadDualView = -6,
        /// <summary>
        /// An invalid parameter was passed in. This can include an invalid flag or combination of flags.
        /// </summary>
        BadParam = -5,
        /// <summary>
        /// An invalid set of flags was passed in.
        /// </summary>
        BadFlags = -4,
        /// <summary>
        /// Windows NT/2000/XP: Unable to write settings to the registry.
        /// </summary>
        NotUpdated = -3,
        /// <summary>
        /// The graphics mode is not supported.
        /// </summary>
        BadMode = -2,
        /// <summary>
        /// The display driver failed the specified graphics mode.
        /// </summary>
        Failed = -1,
        /// <summary>
        /// The settings change was successful.
        /// </summary>
        Successful = 0,
        /// <summary>
        /// The computer must be restarted in order for the graphics mode to work.
        /// </summary>
        Restart = 1
    }
}