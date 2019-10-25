﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace CmdPC
{
    public class Volume
    {

        private const int APPCOMMAND_VOLUME_MUTE = 0x80000;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);


        public static void Mute()
        {
            SendMessageW(Process.GetCurrentProcess().MainWindowHandle, WM_APPCOMMAND, 
                Process.GetCurrentProcess().MainWindowHandle,(IntPtr)APPCOMMAND_VOLUME_MUTE);
        }

        public static void VolDown()
        {
            SendMessageW(Process.GetCurrentProcess().MainWindowHandle, WM_APPCOMMAND, 
                Process.GetCurrentProcess().MainWindowHandle,(IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        public static void VolUp()
        {
            SendMessageW(Process.GetCurrentProcess().MainWindowHandle, WM_APPCOMMAND,
                Process.GetCurrentProcess().MainWindowHandle, (IntPtr)APPCOMMAND_VOLUME_UP);
        }
    }
}
