using System.Diagnostics;

namespace ManualWindow.NativeMethodStructs
{
    [DebuggerDisplay("{Value}")]
    public readonly struct DeviceContextHandle
        : IEquatable<DeviceContextHandle>
    {
        internal readonly nint Value;

        internal DeviceContextHandle(nint value) => this.Value = value;

        public static implicit operator nint(DeviceContextHandle value) => value.Value;

        public static explicit operator DeviceContextHandle(nint value) => new DeviceContextHandle(value);

        public static bool operator ==(DeviceContextHandle left, DeviceContextHandle right) => left.Value == right.Value;

        public static bool operator !=(DeviceContextHandle left, DeviceContextHandle right) => !(left == right);

        public bool Equals(DeviceContextHandle other) => this.Value == other.Value;

        public override bool Equals(object obj) => obj is DeviceContextHandle other && Equals(other);

        public override int GetHashCode() => this.Value.GetHashCode();

        public override string ToString() => $"0x{this.Value:x}";
    }
}
