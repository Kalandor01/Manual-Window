using System.Diagnostics;

namespace ManualWindow.NativeMethodStructs
{
    [DebuggerDisplay("{Value}")]
    public readonly struct BrushHandle
        : IEquatable<BrushHandle>
    {
        internal readonly IntPtr Value;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public BrushHandle() => throw new InvalidOperationException("You may not use the parameterless constructor.");
        
        internal BrushHandle(IntPtr value) => Value = value;

        internal static BrushHandle Null => default;

        internal bool IsNull => Value == default;

        public static implicit operator IntPtr(BrushHandle value) => value.Value;

        public static explicit operator BrushHandle(IntPtr value) => new BrushHandle(value);

        public static bool operator ==(BrushHandle left, BrushHandle right) => left.Value == right.Value;

        public static bool operator !=(BrushHandle left, BrushHandle right) => !(left == right);

        public bool Equals(BrushHandle other) => Value == other.Value;

        public override bool Equals(object obj) => obj is BrushHandle other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"0x{Value:x}";
    }
}
