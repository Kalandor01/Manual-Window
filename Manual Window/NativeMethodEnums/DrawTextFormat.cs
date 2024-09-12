namespace ManualWindow.NativeMethodEnums
{
    public enum DrawTextFormat : uint
    {
        /// <summary>
        /// Text is not vertically snapped to pixel boundaries. This setting is recommended for text that is being animated.
        /// </summary>
        NO_SNAP = 1,
        /// <summary>
        /// Text is clipped to the layout rectangle.
        /// </summary>
        CLIP = 2,
        /// <summary>
        /// In Windows 8.1 and later, text is rendered using color versions of glyphs, if defined by the font.
        /// </summary>
        ENABLE_COLOR_FONT = 4,
        /// <summary>
        /// Bitmap origins of color glyph bitmaps are not snapped.
        /// </summary>
        DISABLE_COLOR_BITMAP_SNAPPING = 8,
        /// <summary>
        /// Text is vertically snapped to pixel boundaries and is not clipped to the layout rectangle.
        /// </summary>
        NONE = 0,
        /// <summary>
        /// 
        /// </summary>
        FORCE_DWORD = 4294967295,
    }
}
