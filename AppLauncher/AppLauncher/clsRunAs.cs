using System;
using System.Runtime.InteropServices;

namespace RunAs
{
    internal class RunAs
    {
        private const UInt32 Infinite = 0xffffffff;
        private const Int32 Startf_UseStdHandles = 0x00000100;
        private const Int32 StdOutputHandle = -11;
        private const Int32 StdErrorHandle = -12;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct StartupInfo
        {
            private int cb;
            internal String reserved;
            private String desktop;
            private String title;
            private int x;
            private int y;
            private int xSize;
            private int ySize;
            private int xCountChars;
            private int yCountChars;
            private int fillAttribute;
            internal int flags;
            private UInt16 showWindow;
            private UInt16 reserved2;
            private byte reserved3;
            private IntPtr stdInput;
            internal IntPtr stdOutput;
            internal IntPtr stdError;
        }

        internal struct ProcessInformation
        {
            internal IntPtr process;
            internal IntPtr thread;
            internal int processId;
            internal int threadId;
        }

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern bool CreateProcessWithLogonW(
            String userName,
            String domain,
            String password,
            UInt32 logonFlags,
            String applicationName,
            String commandLine,
            UInt32 creationFlags,
            UInt32 environment,
            String currentDirectory,
            ref StartupInfo startupInfo,
            out ProcessInformation processInformation);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool GetExitCodeProcess(IntPtr process, ref UInt32 exitCode);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern UInt32 WaitForSingleObject(IntPtr handle, UInt32 milliseconds);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetStdHandle(IntPtr handle);

        [DllImport("Kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        internal bool Run(string user,string password,string path)
        {
            bool res = false;

            try
            {
                StartupInfo startupInfo = new StartupInfo();
                startupInfo.reserved = null;
                startupInfo.flags &= Startf_UseStdHandles;
                startupInfo.stdOutput = (IntPtr)StdOutputHandle;
                startupInfo.stdError = (IntPtr)StdErrorHandle;

                UInt32 exitCode = 123456;
                ProcessInformation processInfo = new ProcessInformation();

                String command = path;
                String domain = System.Environment.MachineName;

                //String currentDirectory = System.IO.Directory.GetCurrentDirectory();
              
                int index = path.LastIndexOf('\\');
                string p = path.Substring(0, index);
                String currentDirectory = p;

                try
                {
                    CreateProcessWithLogonW(
                        user,
                        domain,
                        password,
                        (UInt32)1,
                        command,
                        command,
                        (UInt32)0,
                        (UInt32)0,
                        currentDirectory,
                        ref startupInfo,
                        out processInfo);

                    WaitForSingleObject(processInfo.process, Infinite);
                    GetExitCodeProcess(processInfo.process, ref exitCode);
                    CloseHandle(processInfo.process);
                    CloseHandle(processInfo.thread);
                    res = true;
                }
                catch
                { }
            }
            catch { }
          

            return res;
        }
    }
}
