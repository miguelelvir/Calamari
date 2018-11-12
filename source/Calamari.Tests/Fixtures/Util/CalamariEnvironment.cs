﻿using System;
using System.Runtime.InteropServices;

namespace Calamari.Tests.Fixtures.Util
{
    public static class CalamariEnvironment
    {
        /// <summary>
        /// If/When we try executing this on another runtime we can 'tweak' this logic.
        /// The reccomended way to determine at runtime if executing within the mono framework
        /// http://www.mono-project.com/docs/gui/winforms/porting-winforms-applications/#runtime-conditionals
        /// </summary>
        public static readonly bool IsRunningOnMono = Type.GetType("Mono.Runtime") != null;


        /// <summary>
        /// Based on some internal methods used my mono itself
        /// https://github.com/mono/mono/blob/master/mcs/class/corlib/System/Environment.cs
        /// </summary>
        internal static bool IsRunningOnNix
        {
            get
            {
#if NET40
                return (Environment.OSVersion.Platform == PlatformID.Unix) && !IsRunningOnMac;
#else
                return RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
#endif
            }
        }

        public static bool IsRunningOnWindows
        {
            get
            {
#if NET40
                return Environment.OSVersion.Platform == PlatformID.Win32NT ||
                       Environment.OSVersion.Platform == PlatformID.Win32S ||
                       Environment.OSVersion.Platform == PlatformID.Win32Windows ||
                       Environment.OSVersion.Platform == PlatformID.WinCE;
#else
                return RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
#endif
            }
        }

#if NET40
        //from https://github.com/jpobst/Pinta/blob/master/Pinta.Core/Managers/SystemManager.cs#L162
        //(MIT license)
        [DllImport("libc")]//From Managed.Windows.Forms/XplatUI
        static extern int uname(IntPtr buf);

        public static bool IsRunningOnMac
        {
            get
            {
                if (Environment.OSVersion.Platform == PlatformID.MacOSX)
                    return true;
                if (Environment.OSVersion.Platform != PlatformID.Unix)
                    return false;

                var buf = IntPtr.Zero;
                try
                {
                    buf = Marshal.AllocHGlobal(8192);
                    // Get sysname from uname ()
                    if (uname(buf) == 0)
                    {
                        var os = Marshal.PtrToStringAnsi(buf);
                        if (os == "Darwin")
                            return true;
                    }
                }
                catch
                {
                    // ignored
                }
                finally
                {
                    if (buf != IntPtr.Zero)
                        Marshal.FreeHGlobal(buf);
                }
                return false;
            }
        }
#else

        public static bool IsRunningOnMac
        {
            get
            {

                return RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
            }
        }
#endif
    }
}