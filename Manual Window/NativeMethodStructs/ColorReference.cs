using System.Diagnostics;

namespace ManualWindow.NativeMethodStructs
{
    /// <summary>The COLORREF value is used to specify an RGB color.</summary>
    /// <remarks>
    /// <para>When specifying an explicit [RGB](/windows/desktop/api/Wingdi/nf-wingdi-rgb) color, the **COLORREF** value has the following hexadecimal form: `0x00bbggrr` The low-order byte contains a value for the relative intensity of red; the second byte contains a value for green; and the third byte contains a value for blue. The high-order byte must be zero. The maximum value for a single byte is 0xFF. To create a **COLORREF** color value, use the [RGB](/windows/desktop/api/Wingdi/nf-wingdi-rgb) macro. To extract the individual values for the red, green, and blue components of a color value, use the [**GetRValue**](/windows/desktop/api/Wingdi/nf-wingdi-getrvalue), [GetGValue](/windows/desktop/api/Wingdi/nf-wingdi-getgvalue), and [GetBValue](/windows/desktop/api/Wingdi/nf-wingdi-getbvalue) macros, respectively.</para>
    /// <para><see href="https://learn.microsoft.com/windows/win32/gdi/colorref#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    public readonly struct ColorReference
        : IEquatable<ColorReference>
    {
        internal readonly uint Value;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public ColorReference() => throw new InvalidOperationException("You may not use the parameterless constructor.");

        internal ColorReference(uint value)
        {
            Value = value;
        }

        public ColorReference(byte r, byte g, byte b)
        {
            Value = (uint)(b << 16) + (uint)(g << 8) + r;
        }

        public (byte r, byte g, byte b) ToRGB()
        {
            return ((byte)Value, (byte)((Value & 0xff00) >> 8), (byte)((Value & 0xff0000) >> 16));
        }

        public static implicit operator uint(ColorReference value) => value.Value;

        public static explicit operator ColorReference(uint value) => new(value);

        public static bool operator ==(ColorReference left, ColorReference right) => left.Value == right.Value;

        public static bool operator !=(ColorReference left, ColorReference right) => !(left == right);

        public bool Equals(ColorReference other)
        {
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is ColorReference other && Equals(other);
        }

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString()
        {
            var (r, g, b) = ToRGB();
            return $"r: {r}, g: {g}, b: {b}";
        }
    }
}
