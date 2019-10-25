using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CmdPC
{

    //Link to the list of available keys
    //https://msdn.microsoft.com/en-us/library/dd375731%28v=vs.85%29.aspx
    public static class VirtualKeyboard
    {
        const int VK_MEDIA_PLAY_PAUSE = 0xB3;
        const int VK_MEDIA_STOP = 0xB2;
        const int VK_MEDIA_PREV_TRACK = 0xB1;
        const int VK_MEDIA_NEXT_TRACK = 0xB0;
        const int VK_VOLUME_UP = 0xAF;
        const int VK_VOLUME_DOWN = 0xAE;
        const int VK_VOLUME_MUTE=0xAD;
        const int VK_SLEEP = 0x5F;

        const int VK_UP = 0x26; //up key
        const int VK_DOWN = 0x28;  //down key
        const int VK_LEFT = 0x25;
        const int VK_RIGHT = 0x27;
        const uint KEYEVENTF_KEYUP = 0x0002;
        const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);

        public static void MediaStop()
        {
            keybd_event((byte)VK_MEDIA_STOP, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

        public static void MediaPlayPause()
        {
            keybd_event((byte)VK_MEDIA_PLAY_PAUSE, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

        public static void MediaPreviousTrack()
        {
            keybd_event((byte)VK_MEDIA_PREV_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

        public static void MediaNextTrack()
        {
            keybd_event((byte)VK_MEDIA_NEXT_TRACK, 0, KEYEVENTF_EXTENDEDKEY | 0, 0);
        }

    }
}
