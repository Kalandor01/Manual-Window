namespace ManualWindow.NativeMethodStructs
{
    public readonly struct WindowHandle
        : IEquatable<WindowHandle>
    {
        internal readonly IntPtr Value;

        internal WindowHandle(IntPtr value) => Value = value;

        internal static WindowHandle Null => default;

        internal readonly bool IsNull => Value == default;

        public static implicit operator IntPtr(WindowHandle value) => value.Value;

        public static explicit operator WindowHandle(IntPtr value) => new(value);

        public static bool operator ==(WindowHandle left, WindowHandle right) => left.Value == right.Value;

        public static bool operator !=(WindowHandle left, WindowHandle right) => !(left == right);

        public bool Equals(WindowHandle other) => Value == other.Value;

        public override bool Equals(object obj) => obj is WindowHandle other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"0x{Value:x}";
    }
}
