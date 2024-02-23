using System.Runtime.InteropServices;

namespace CleanWpfApp
{
    internal static unsafe class ClassicEtw
    {
        #region RegisterTraceGuidsW()
        // Support structs for RegisterTraceGuidsW
        [StructLayout(LayoutKind.Sequential)]
        internal struct TRACE_GUID_REGISTRATION
        {
            internal unsafe Guid* Guid;

            internal unsafe void* RegHandle;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WNODE_HEADER
        {
            public uint BufferSize;
            public uint ProviderId;
            public ulong HistoricalContext;
            public ulong TimeStamp;
            public Guid Guid;
            public uint ClientContext;
            public uint Flags;
        };


        internal enum WMIDPREQUESTCODE
        {
            GetAllData = 0,
            GetSingleInstance = 1,
            SetSingleInstance = 2,
            SetSingleItem = 3,
            EnableEvents = 4,
            DisableEvents = 5,
            EnableCollection = 6,
            DisableCollection = 7,
            RegInfo = 8,
            ExecuteMethod = 9,
        };

        internal unsafe delegate uint ControlCallback(WMIDPREQUESTCODE requestCode, IntPtr requestContext, IntPtr reserved, WNODE_HEADER* data);

        [DllImport("Advapi32.dll", CharSet = CharSet.Unicode)]
        internal static extern uint RegisterTraceGuidsW(
            [In] ControlCallback cbFunc,
            [In] IntPtr context,
            [In] ref Guid providerGuid,
            [In] int taskGuidCount,
            [In, Out] ref TRACE_GUID_REGISTRATION taskGuids,
            [In] string mofImagePath,
            [In] string mofResourceName,
            out ulong regHandle
        );
        #endregion

        [DllImport("Advapi32.dll")]
        internal static extern uint UnregisterTraceGuids(ulong regHandle);

        [DllImport("Advapi32.dll")]
        internal static extern int GetTraceEnableFlags(ulong traceHandle);

        [DllImport("Advapi32.dll")]
        internal static extern byte GetTraceEnableLevel(ulong traceHandle);

        [DllImport("Advapi32.dll")]
        internal static extern long GetTraceLoggerHandle(WNODE_HEADER* data);

        #region TraceEvent()
        // Structures for TraceEvent API.

        // Constants for flags field.
        internal const int WNODE_FLAG_TRACED_GUID = 0x00020000;
        internal const int WNODE_FLAG_USE_MOF_PTR = 0x00100000;

        // Size is 48 = 0x30 bytes;
        [StructLayout(LayoutKind.Sequential)]
        internal struct EVENT_TRACE_HEADER
        {
            public ushort Size;
            public ushort FieldTypeFlags;   // holds our MarkerFlags too
            public byte Type;               // This is now called opcode.
            public byte Level;
            public ushort Version;
            public int ThreadId;
            public int ProcessId;
            public long TimeStamp;          // Offset 0x10
            public Guid Guid;               // Offset 0x18
            public uint ClientContext;      // Offset 0x28
            public uint Flags;              // Offset 0x2C
        }

        internal const int MAX_MOF_FIELDS = 16;
        [StructLayout(LayoutKind.Explicit, Size = 48 + 16 * MAX_MOF_FIELDS)]
        internal struct EVENT_HEADER
        {
            [FieldOffset(0)]
            public EVENT_TRACE_HEADER Header;
            [FieldOffset(48)]
            public EventData Data;         // Actually variable sized;
        }

        [DllImport("Advapi32.dll")]
        internal static extern unsafe uint TraceEvent(ulong traceHandle, EVENT_HEADER* header);
        #endregion
    }
}
