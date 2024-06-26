namespace ManualWindow.NativeMethodStructs
{
    public readonly struct IconHandle
        : IEquatable<IconHandle>
    {
        internal readonly IntPtr Value;

        internal IconHandle(IntPtr value) => Value = value;

        internal static IconHandle Null => default;

        internal readonly bool IsNull => Value == default;

        public static implicit operator IntPtr(IconHandle value) => value.Value;

        public static explicit operator IconHandle(IntPtr value) => new(value);

        public static bool operator ==(IconHandle left, IconHandle right) => left.Value == right.Value;

        public static bool operator !=(IconHandle left, IconHandle right) => !(left == right);

        public bool Equals(IconHandle other) => Value == other.Value;

        public override bool Equals(object obj) => obj is IconHandle other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"0x{Value:x}";
    }
}
