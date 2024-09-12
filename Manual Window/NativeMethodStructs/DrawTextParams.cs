using System.Runtime.InteropServices;

namespace ManualWindow.NativeMethodStructs
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DrawTextParams
    {
        /// <summary>
        /// The size of the struct.
        /// </summary>
        uint size;
        /// <summary>
        /// The size of each tab stop, in units equal to the average character width.
        /// </summary>
        int tabLength;
        /// <summary>
        /// The left margin, in units equal to the average character width.
        /// </summary>
        int leftMargin;
        /// <summary>
        /// The right margin, in units equal to the average character width.
        /// </summary>
        int rightMargin;
        /// <summary>
        /// Receives the number of characters processed by DrawTextEx, including white-space characters. The number can be the length of the string or the index of the first line that falls below the drawing area. Note that DrawTextEx always processes the entire string if the DT_NOCLIP formatting flag is specified.
        /// </summary>
        uint lengthDrawn;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public DrawTextParams() => throw new InvalidOperationException("You may not use the parameterless constructor.");
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tabLength"><inheritdoc cref="tabLength" path="//summary"/></param>
        /// <param name="leftMargin"><inheritdoc cref="leftMargin" path="//summary"/></param>
        /// <param name="rightMargin"><inheritdoc cref="rightMargin" path="//summary"/></param>
        /// <param name="lengthDrawn"><inheritdoc cref="lengthDrawn" path="//summary"/></param>
        public DrawTextParams(int tabLength, int leftMargin, int rightMargin, uint lengthDrawn)
        {
            var intSize = 0;
            unsafe
            {
                intSize = sizeof(DrawTextParams);
            }
            if (intSize == 0)
            {
                throw new ArgumentException("Struct size is invalid.");
            }
            size = (uint)intSize;
            this.tabLength = tabLength;
            this.leftMargin = leftMargin;
            this.rightMargin = rightMargin;
            this.lengthDrawn = lengthDrawn;
        }
    }
}
