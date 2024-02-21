namespace ManualWindow
{
    public enum WindowActivateDeactivateDisplayOptionsPart : uint
    {
        /// <summary>
        /// Show the composition window by user interface window.
        /// </summary>
        SHOW_UI_COMPOSITION_WINDOW = 0b1000_0000_0000_0000_0000_0000_0000_0000,
        /// <summary>
        /// Show the guide window by user interface window.
        /// </summary>
        SHOW_UI_GUIDE_WINDOW = 0b0100_0000_0000_0000_0000_0000_0000_0000,
        /// <summary>
        /// Show the soft keyboard by user interface window.<br/>
        /// The value for this option is unknown.
        /// </summary>
		SHOW_UI_SOFTKBD = 0b0000_0000_0000_0000_0000_0000_0000_0000,
        /// <summary>
        /// Show the candidate window of index 0 by user interface window.
        /// </summary>
        SHOW_UI_CANDIDATE_WINDOW_0 = 0b0000_0000_0000_0000_0000_0000_0000_0001,
        /// <summary>
        /// Show the candidate window of index 1 by user interface window.
        /// </summary>
        SHOW_UI_CANDIDATE_WINDOW_1 = 0b0000_0000_0000_0000_0000_0000_0000_0010,
        /// <summary>
        /// Show the candidate window of index 2 by user interface window.
        /// </summary>
        SHOW_UI_CANDIDATE_WINDOW_2 = 0b0000_0000_0000_0000_0000_0000_0000_0100,
        /// <summary>
        /// Show the candidate window of index 3 by user interface window.
        /// </summary>
        SHOW_UI_CANDIDATE_WINDOW_3 = 0b0000_0000_0000_0000_0000_0000_0000_1000,
        /// <summary>
        /// Show all candidate windows by user interface window.<br/>
        /// This is a composite of other values.
        /// </summary>
        SHOW_UI_ALL_CANDIDATE_WINDOW = 0b0000_0000_0000_0000_0000_0000_0000_1111,
        /// <summary>
        /// Show all by user interface window.<br/>
        /// This is a composite of other values.
        /// </summary>
        SHOW_UI_ALL = 0b1100_0000_0000_0000_0000_0000_0000_1111,
    }
}
