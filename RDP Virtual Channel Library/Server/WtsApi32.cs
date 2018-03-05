using System;
using System.Runtime.InteropServices;

namespace FieldEffect.VCL.Server
{
    internal static class WtsApi32
    {
        public const uint INFINITE = 0xFFFFFFFF;

        [DllImport("Wtsapi32.dll")]
        public static extern IntPtr WTSVirtualChannelOpen(IntPtr server,
        int sessionId, [MarshalAs(UnmanagedType.LPStr)] string virtualName);

        [DllImport("Wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSVirtualChannelWrite(IntPtr channelHandle,
               byte[] buffer, int length, ref int bytesWritten);

        [DllImport("Wtsapi32.dll", SetLastError = true)]
        public static extern bool WTSVirtualChannelRead(IntPtr channelHandle,
               uint timeOut, byte[] buffer, int length, ref int bytesReaded);

        [DllImport("Wtsapi32.dll")]
        public static extern bool WTSVirtualChannelClose(IntPtr channelHandle);
    }
}
