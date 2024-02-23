using System.Runtime.InteropServices;

namespace CleanWpfApp
{
    internal static unsafe class ManifestEtw
    {
        internal unsafe delegate void EtwEnableCallback(
            [In] ref Guid sourceId,
            [In] int isEnabled,
            [In] byte level,
            [In] long matchAnyKeywords,
            [In] long matchAllKeywords,
            [In] EVENT_FILTER_DESCRIPTOR* filterData,
            [In] void* callbackContext
            );

        //
        // Registration APIs
        //
        [DllImport("Advapi32.dll", ExactSpelling = true, EntryPoint = "EventRegister", CharSet = CharSet.Unicode)]
        internal static extern unsafe uint EventRegister(
                    [In] ref Guid providerId,
                    [In] EtwEnableCallback enableCallback,
                    [In] void* callbackContext,
                    [In][Out] ref ulong registrationHandle
                    );

        [DllImport("Advapi32.dll", ExactSpelling = true, EntryPoint = "EventUnregister", CharSet = CharSet.Unicode)]
        internal static extern uint EventUnregister([In] ulong registrationHandle);

        //
        // Writing (Publishing/Logging) APIs
        //
        [DllImport("Advapi32.dll", ExactSpelling = true, EntryPoint = "EventWrite", CharSet = CharSet.Unicode)]
        internal static extern unsafe uint EventWrite(
                [In] ulong registrationHandle,
                [In] ref EventDescriptor eventDescriptor,
                [In] uint userDataCount,
                [In] EventData* userData
                );

        [StructLayout(LayoutKind.Sequential)]
        unsafe internal struct EVENT_FILTER_DESCRIPTOR
        {
            public long Ptr;
            public int Size;
            public int Type;
        };


        [StructLayout(LayoutKind.Explicit, Size = 16)]
        internal struct EventDescriptor
        {
            [FieldOffset(0)]
            internal ushort Id;
            [FieldOffset(2)]
            internal byte Version;
            [FieldOffset(3)]
            internal byte Channel;
            [FieldOffset(4)]
            internal byte Level;
            [FieldOffset(5)]
            internal byte Opcode;
            [FieldOffset(6)]
            internal ushort Task;
            [FieldOffset(8)]
            internal long Keywords;
        }
    }
}
