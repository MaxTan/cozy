﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CozyDitto.Utils
{
    public static partial class Util
    {
        public const int WM_HOTKEY = 0x0312;

        public enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            WindowsKey = 8
        }

        // void(CALLBACK*HotKeyCallback)(WPARAM wParam, LPARAM lParam);
        public delegate bool HotKeyCallback(uint wParam, uint lParam);
    }
}
