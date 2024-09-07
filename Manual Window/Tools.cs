using ManualWindow.NativeMethodStructs;

namespace ManualWindow
{
    public static class Tools
    {
        /// <summary>
        /// Utility function for getting screen position from <paramref name="lParam"/>.
        /// </summary>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public static Point PointFromLParam(nint lParam)
        {
            return new Point((int)lParam & 0xFFFF, ((int)lParam >> 16) & 0xFFFF);
        }

        public static ushort GetLowerHalf(nint param)
        {
            return (ushort)param;
        }

        public static ushort GetUpperHalf(nint param)
        {
            return (ushort)(param >> 16);
        }

        public static bool GetBit(nint num, int bitNumber)
        {
            return (num & (1 << bitNumber)) != 0;
        }

        public static void GetKeystrokeMessageFlags(
            nint keyStrokeParam,
            out short repeatCount,
            out byte scanCode,
            out bool isExtendedKey,
            out bool[] reserved,
            out bool contextCode,
            out bool isPreviouslyDown,
            out bool transitionState
        )
        {
            repeatCount = (short)keyStrokeParam;
            scanCode = (byte)(keyStrokeParam >> 16);
            isExtendedKey = GetBit(keyStrokeParam, 24);
            reserved = [GetBit(keyStrokeParam, 25), GetBit(keyStrokeParam, 26), GetBit(keyStrokeParam, 27), GetBit(keyStrokeParam, 28)];
            contextCode = GetBit(keyStrokeParam, 29);
            isPreviouslyDown = GetBit(keyStrokeParam, 30);
            transitionState = GetBit(keyStrokeParam, 31);
        }
    }
}
