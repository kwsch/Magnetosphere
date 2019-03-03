namespace Magnetosphere
{
    /// <summary>
    /// TODO -- THIS IS A COPY FROM NTR WITH MINOR REPLACEMENTS
    /// THIS IS PLACEHOLDER
    /// </summary>
    public enum AMSCommand : uint
    {
        /// <summary>
        /// Sent every 1,000 ms (1 second) to check in, a response contains the AMS device's debugBuf (if any data is present)
        /// </summary>
        Heartbeat = 0_00,

        /// <summary>
        /// Sends a file from the client to the AMS device. Payload is a null-terminated UTF8 filename, followed by the file data.
        /// </summary>
        WriteFile = 0_01,

        /// <summary>
        /// Requests a file to be sent to the client from the AMS device. Payload is filename, followed by the file data.
        /// </summary>
        ReadFile = 0_02, // **not implemented**

        /// <summary>
        /// Echo Request command.
        /// </summary>
        /// <example>
        /// No arguments used.
        /// The AMS Device will display Hello on the screen.
        /// Response string "hello" is dumped into <see cref="Heartbeat"/> buffer.
        /// </example>
        Hello = 0_03,

        /// <summary>
        /// Force relaunches the AMS device wireless service by calling nsHandleReload.
        /// </summary>
        Reload = 0_04, // no args

        ListProcess = 0_05, // no args
        AttachProcess = 0_06, // [pid, patch-address]
        ListThread = 0_07, // no args
        MemLayout = 0_08, // [pid]

        /// <summary>
        /// Requests a sized chunk of the AMS device's memory.
        /// </summary>
        Read = 0_09, // [pid address size]

        /// <summary>
        /// Writes a sized chunk to the AMS device's memory.
        /// </summary>
        Write = 0_10, // [pid address size]

        Breakpoint = 0_11, // [NTRBreakpointArg]

        QueryHandle = 0_12, // [pid]

        RemotePlayer = 9_01,
    }
}