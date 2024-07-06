﻿namespace ManualWindow.NativeMethodEnums
{
    public enum WindowStyle : uint
    {
        OVERLAPPED = 0x00000000,
        TILED = 0x00000000,
        ACTIVECAPTION = 0x00000001,
        TABSTOP = 0x00010000,
        MAXIMIZEBOX = 0x00010000,
        GROUP = 0x00020000,
        MINIMIZEBOX = 0x00020000,
        THICKFRAME = 0x00040000,
        SIZEBOX = 0x00040000,
        SYSMENU = 0x00080000,
        POPUP = 0x80000000,
        CHILD = 0x40000000,
        CHILDWINDOW = 0x40000000,
        MINIMIZE = 0x20000000,
        VISIBLE = 0x10000000,
        DISABLED = 0x08000000,
        CLIPSIBLINGS = 0x04000000,
        CLIPCHILDREN = 0x02000000,
        ICONIC = 0x20000000,
        MAXIMIZE = 0x01000000,
        CAPTION = 0x00C00000,
        BORDER = 0x00800000,
        DLGFRAME = 0x00400000,
        VSCROLL = 0x00200000,
        HSCROLL = 0x00100000,
        TILEDWINDOW = 0x00CF0000,
        OVERLAPPEDWINDOW = 0x00CF0000,
        POPUPWINDOW = 0x80880000,
    }
}
