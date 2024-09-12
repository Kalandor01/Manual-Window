using System.Diagnostics;

namespace ManualWindow.NativeMethodStructs
{
    [DebuggerDisplay("{Value}")]
    public readonly struct WindowHandle
        : IEquatable<WindowHandle>
    {
        internal readonly IntPtr Value;

        [Obsolete("You may not use the parameterless constructor.", error: true)]
        public WindowHandle() => throw new InvalidOperationException("You may not use the parameterless constructor.");

        internal WindowHandle(IntPtr value)
        {
            Value = value;
        }

        internal static WindowHandle Null => default;

        internal bool IsNull => Value == default;

        public static implicit operator IntPtr(WindowHandle value) => value.Value;

        public static explicit operator WindowHandle(IntPtr value) => new(value);

        public static bool operator ==(WindowHandle left, WindowHandle right) => left.Value == right.Value;

        public static bool operator !=(WindowHandle left, WindowHandle right) => !(left == right);

        public bool Equals(WindowHandle other) => Value == other.Value;

        public override bool Equals(object obj) => obj is WindowHandle other && Equals(other);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => $"0x{Value:x}";

        //public static implicit operator HANDLE(WindowHandle value) => new HANDLE(value.Value);
    }
}
