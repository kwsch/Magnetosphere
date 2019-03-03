namespace Magnetosphere
{
    public enum NTRCommand : uint
    {
        /// <summary>
        /// Sent every 1,000 ms (1 second) to check in, a response contains the NTR device's debugBuf (if any data is present)
        /// </summary>
        /// <example>
        /// No arguments used.
        /// </example>
        /// <remarks>
        /// https://en.wikipedia.org/wiki/Heartbeat_(computing)
        /// </remarks>
        Heartbeat = 0_00,

        /// <summary>
        /// Sends a file from the client to the NTR device. Payload is a null-terminated UTF8 filename, followed by the file data.
        /// </summary>
        /// <example>
        /// No arguments used.
        /// <see cref="NTRCommandType.BigData"/> should be set when using <see cref="WriteFile"/>; however, the NTR device doesn't ever use the value!
        /// </example>
        WriteFile = 0_01,

        /// <summary>
        /// Requests a file to be sent to the client from the NTR device. Payload is filename, followed by the file data.
        /// </summary>
        /// <example>
        /// <see cref="NTRCommandType.BigData"/> should be set when using <see cref="ReadFile"/>; however, the NTR device doesn't ever use the value!
        /// No arguments used. File path is a null-terminated UTF8 string, used to place the file on the NTR device's filesystem.
        /// NOT IMPLEMENTED IN NTR DEVICE
        /// </example>
        ReadFile = 0_02, // **not implemented**

        /// <summary>
        /// Echo Request command.
        /// </summary>
        /// <example>
        /// No arguments used.
        /// The NTR Device will display Hello on the screen.
        /// Response string "hello" is dumped into <see cref="Heartbeat"/> buffer.
        /// </example>
        Hello = 0_03,

        /// <summary>
        /// Force relaunches the NTR device wireless service by calling nsHandleReload.
        /// </summary>
        /// <example>
        /// No arguments used.
        /// Assumed to be used for remotely updating the NTR process (reloads arm11.bin)
        /// </example>
        Reload = 0_04, // no args

        ListProcess     = 0_05, // no args
        AttachProcess   = 0_06, // [pid, patch-address]
        ListThread      = 0_07, // no args
        MemLayout       = 0_08, // [pid]

        /// <summary>
        /// Requests a sized chunk of the NTR device's memory.
        /// </summary>
        /// <remarks>
        /// Arguments: pid, address, size
        /// Sanity checks the offset if less than 0x20000000.
        /// If the pid is -1, it will get the current process' memory.
        /// Response packet is: Header, data (in 0x1000 byte chunks)
        /// </remarks>
        Read = 0_09, // [pid address size]

        /// <summary>
        /// Writes a sized chunk to the NTR device's memory.
        /// </summary>
        /// <remarks>
        /// Arguments: pid, address, size
        /// Sanity checks the offset if less than 0x20000000.
        /// If the pid is -1, it will get the current process' memory.
        /// </remarks>
        Write = 0_10, // [pid address size]

        Breakpoint      = 0_11, // [NTRBreakpointArg]

        QueryHandle     = 0_12, // [pid]

        RemotePlayer    = 9_01,
    }

    public enum NTRCommandType : uint
    {
        Normal = 0,
        BigData = 1,
    }

    public enum NTRBreakpointType
    {
        Unused = 0,
        Code,
        Code_Once, // Code One-shot
    }

    public enum NTRBreakpointArg
    {
        Unused = 0,
        Add = 1,
        Enable = 2,
        Disable = 3,
        Resume = 4,
        Delete = 5, // Not in NTR, there's no way to delete a bp.
    }
}