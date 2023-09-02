using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ConsoleApp3
{
    class Program
    {
        [DllImport("user32.dll")]
        static extern bool SetWindowPos(
            IntPtr hWnd,
            IntPtr hWndInsertAfter,
            int X,
            int Y,
            int cx,
            int cy,
            uint uFlags
        );

        const uint SWP_SHOWWINDOW = 0x0040;

        static void Main()
        {
            for (int i = 0; i < 10; i++)
            {
                Process notepadProcess = new Process();
                notepadProcess.StartInfo.FileName = "notepad.exe";

                try
                {
                    notepadProcess.Start();
                    notepadProcess.WaitForInputIdle(); // Wait for Notepad to start
                    IntPtr hWnd = notepadProcess.MainWindowHandle;

                    // Calculate window positions in a grid (adjust X, Y, width, and height as needed)
                    int X = (i % 5) * 300;
                    int Y = (i / 5) * 200;
                    int width = 300;
                    int height = 200;

                    // Set the window position
                    SetWindowPos(hWnd, IntPtr.Zero, X, Y, width, height, SWP_SHOWWINDOW);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
