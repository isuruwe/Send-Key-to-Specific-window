using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using WindowsInput;
using WindowsInput.Native;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System;
using WinFormsApp1.Controls;

namespace WinFormsApp1
{
    public partial class Form1 : WinFormsApp1.NoActivate.NoActivateWindow
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);


        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        [DllImport("user32.dll")]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        // Callback function for EnumChildWindows
        private delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);


        List<IntPtr> childWindowHandles = new List<IntPtr>();
        const int WM_COMMAND = 0x0111;
        const int BN_CLICKED = 0;
        const int ButtonId = 0x67;
        const int SW_HIDE = 9;
        const int SWP_NOMOVE = 0x0002;
        const int SWP_NOSIZE = 0x0001;
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int HWND_TOPMOST = -1;
        const int SWP_SHOWWINDOW = 0x0040;
        static void SetWindowTopMost(IntPtr hWnd)
        {
            SetWindowPos(hWnd, new IntPtr(HWND_TOPMOST), 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // SendKeysToApplication("%");


        }

        public void SendKeysToApplication(string txt)
        {
            try
            {


                string selectedItemText = listView1.SelectedItems[0].Text;
                IntPtr targetWindow = FindWindow(null, "Form1");

                SetWindowTopMost(targetWindow);

                string hexValue = "00050614";

                int intValue = Convert.ToInt32(hexValue, 16);
                IntPtr hWnd = new IntPtr(intValue);

                //  IntPtr hWnd = FindWindow(null, selectedItemText);

                //  foreach (IntPtr hWnd in childWindowHandles)
                //  {

                if (hWnd != IntPtr.Zero)
                {
                    SetForegroundWindow(hWnd);
                    //ShowWindow(hWnd, SW_HIDE);
                    const int VK_MENU = 0x12;
                    const int KEYEVENTF_KEYDOWN = 0x0000;
                    const int KEYEVENTF_KEYUP = 0x0002;
                    SendMessage(hWnd, WM_KEYDOWN, (IntPtr)VK_MENU, IntPtr.Zero);
                    Thread.Sleep(1);
                    SendMessage(hWnd, KEYEVENTF_KEYUP, (IntPtr)VK_MENU, IntPtr.Zero);
                    Thread.Sleep(50);

                    // SendKeys.SendWait(txt);

                    // Thread.Sleep(100);
                    //ShowWindow(hWnd, SW_HIDE);
                    // SetForegroundWindow(targetWindow);
                }
                else
                {
                    Console.WriteLine("Window not found.");
                }
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Select window from list first");
            }

        }
        //static void SimulateAltKeyPress(IntPtr hwnd)
        //{
        //    uint foregroundThreadId = GetWindowThreadProcessId(GetForegroundWindow(), out _);
        //    uint targetThreadId = GetWindowThreadProcessId(hwnd, out _);

        //    AttachThreadInput(foregroundThreadId, targetThreadId, true);

        //    try
        //    {
        //        INPUT[] inputs = new INPUT[2];

        //        // Press Alt key
        //        inputs[0] = new INPUT
        //        {
        //            Type = INPUT_KEYBOARD,
        //            Ki = new KEYBDINPUT
        //            {
        //                Vk = 0x12,  // VK_MENU (Alt key)
        //                Scan = 0,
        //                Flags = KEYEVENTF_EXTENDEDKEY,
        //                Time = 0,
        //                ExtraInfo = IntPtr.Zero,
        //            },
        //        };

        //        // Release Alt key
        //        inputs[1] = new INPUT
        //        {
        //            Type = INPUT_KEYBOARD,
        //            Ki = new KEYBDINPUT
        //            {
        //                Vk = 0x12,  // VK_MENU (Alt key)
        //                Scan = 0,
        //                Flags = KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
        //                Time = 0,
        //                ExtraInfo = IntPtr.Zero,
        //            },
        //        };

        //        SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
        //    }
        //    finally
        //    {
        //        AttachThreadInput(foregroundThreadId, targetThreadId, false);
        //    }
        //}

        IEnumerable<KeyButton> keyButtonList = null;
        IEnumerable<KeyButton> KeyButtonList
        {
            get
            {
                if (keyButtonList == null)
                {
                    keyButtonList = this.Controls.OfType<KeyButton>();
                }
                return keyButtonList;
            }
        }
        List<int> pressedModifierKeyCodes = null;

        List<int> PressedModifierKeyCodes
        {
            get
            {
                if (pressedModifierKeyCodes == null)
                {
                    pressedModifierKeyCodes = new List<int>();
                }
                return pressedModifierKeyCodes;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            Process[] processlist = Process.GetProcesses();

            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {

                    listView1.Items.Add(process.MainWindowTitle);

                }
            }
            foreach (KeyButton btn in this.KeyButtonList)
            {
                btn.Click += new EventHandler(KeyButton_Click);
            }

            this.Activate();
        }

        void KeyButton_Click(object sender, EventArgs e)
        {
            KeyButton btn = sender as KeyButton;
            if (btn == null)
            {
                return;
            }
            int btnKeyCode = btn.KeyCode;

            if (btn.IsModifierKey)
            {
                // The modifier key is pressed twice.
                PressedModifierKeyCodes.Add(btn.KeyCode);
                UserInteraction.KeyboardInput.SendToggledKey(btn.KeyCode);
                Thread.Sleep(200);
                // Clear the pressed state of all the modifier key buttons.
                ResetModifierKeyButtons();
                UserInteraction.KeyboardInput.SendToggledKey(btn.KeyCode);

            }

            else
            {
                if (btnKeyCode == 17)
                {
                    UserInteraction.KeyboardInput.SendToggledKey(btnKeyCode);
                    UserInteraction.KeyboardInput.SendToggledKey(btnKeyCode);


                }
                else if (btnKeyCode == 18)
                {
                    UserInteraction.KeyboardInput.SendToggledKey(btnKeyCode);
                    UserInteraction.KeyboardInput.SendToggledKey(btnKeyCode);

                }
                else
                {
                    UserInteraction.KeyboardInput.SendKey(PressedModifierKeyCodes, btnKeyCode);

                }
            }
        }
        void ResetModifierKeyButtons()
        {
            PressedModifierKeyCodes.Clear();

           
        }
        private static List<IntPtr> GetChildWindows(IntPtr parentHandle)
        {
            List<IntPtr> childWindows = new List<IntPtr>();

            EnumWindowsProc childProc = (IntPtr hWnd, IntPtr lParam) =>
            {
                childWindows.Add(hWnd);
                return true; // continue enumeration
            };

            EnumChildWindows(parentHandle, childProc, IntPtr.Zero);

            return childWindows;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();
            listView1.Items.Clear();
            foreach (Process process in processlist)
            {
                if (!String.IsNullOrEmpty(process.MainWindowTitle))
                {

                    listView1.Items.Add(process.MainWindowTitle);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {




            }
            catch (Exception ex)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // SendKeysToApplication("{LEFT}");


        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //UserInteraction.KeyboardInput.SendKey(PressedModifierKeyCodes, 18);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
