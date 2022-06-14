namespace CyberBlight.input_device
{
    using Microsoft.Win32.SafeHandles;
    using System;
    using System.Text;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using CyberBlight.engine;

    public class ConsoleMouse
    {
        public static void listen()
        {
            var handle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);

            int mode = 0;
            if (!(NativeMethods.GetConsoleMode(handle, ref mode))) { throw new Win32Exception(); }

            mode |= NativeMethods.ENABLE_MOUSE_INPUT;
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
            mode |= NativeMethods.ENABLE_EXTENDED_FLAGS;

            if (!(NativeMethods.SetConsoleMode(handle, mode))) { throw new Win32Exception(); }

            var record = new NativeMethods.INPUT_RECORD();
            uint recordLen = 0;
            while (true)
            {
                if (!(NativeMethods.ReadConsoleInput(handle, ref record, 1, ref recordLen))) { throw new Win32Exception(); }
                Console.SetCursorPosition(0, 0);
                switch (record.EventType)
                {
                    case NativeMethods.MOUSE_EVENT:
                    {
                            Console.WriteLine("Mouse event");
                            Console.WriteLine(string.Format("    X ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.X));
                            Console.WriteLine(string.Format("    Y ...............:   {0,4:0}  ", record.MouseEvent.dwMousePosition.Y));
                            Console.WriteLine(string.Format("    dwButtonState ...: 0x{0:X4}  ", record.MouseEvent.dwButtonState));
                            Console.WriteLine(string.Format("    dwControlKeyState: 0x{0:X4}  ", record.MouseEvent.dwControlKeyState));
                            Console.WriteLine(string.Format("    dwEventFlags ....: 0x{0:X4}  ", record.MouseEvent.dwEventFlags));
                            Console.WriteLine($"    Z ...............:   {Screen.ReadCharacterAt(record.MouseEvent.dwMousePosition.X, record.MouseEvent.dwMousePosition.Y)}  ");
                    } break;

                    case NativeMethods.KEY_EVENT:
                    {
                        Console.WriteLine("Key event  ");
                        Console.WriteLine(string.Format("    bKeyDown  .......:  {0,5}  ", record.KeyEvent.bKeyDown));
                        Console.WriteLine(string.Format("    wRepeatCount ....:   {0,4:0}  ", record.KeyEvent.wRepeatCount));
                        Console.WriteLine(string.Format("    wVirtualKeyCode .:   {0,4:0}  ", record.KeyEvent.wVirtualKeyCode));
                        Console.WriteLine(string.Format("    uChar ...........:      {0}  ", record.KeyEvent.UnicodeChar));
                        Console.WriteLine(string.Format("    dwControlKeyState: 0x{0:X4}  ", record.KeyEvent.dwControlKeyState));

                        if (record.KeyEvent.wVirtualKeyCode == (int)ConsoleKey.Escape) { return; }
                    } break;
                }
            }
        }

        public static bool wordHeld=false;
        public static int wordLength=0;
        public static string getOption()
        {
            var handle = NativeMethods.GetStdHandle(NativeMethods.STD_INPUT_HANDLE);
            int mode = 0;
            if (!(NativeMethods.GetConsoleMode(handle, ref mode))) { throw new Win32Exception(); }
            mode |= NativeMethods.ENABLE_MOUSE_INPUT;
            mode &= ~NativeMethods.ENABLE_QUICK_EDIT_MODE;
            mode |= NativeMethods.ENABLE_EXTENDED_FLAGS;
            if (!(NativeMethods.SetConsoleMode(handle, mode))) { throw new Win32Exception(); }
            var record = new NativeMethods.INPUT_RECORD();
            uint recordLen = 0;
            if (!(NativeMethods.ReadConsoleInput(handle, ref record, 1, ref recordLen))) { throw new Win32Exception(); }
            if (record.EventType==NativeMethods.MOUSE_EVENT && record.MouseEvent.dwButtonState==1)
            {
                StringBuilder word = new StringBuilder();
                char letterAtMouse = Screen.ReadCharacterAt(record.MouseEvent.dwMousePosition.X, record.MouseEvent.dwMousePosition.Y);
                if (letterAtMouse !=' ')
                {
                    if (wordHeld){
                        wordHeld=false;
                        wordLength=0;}
                    int _x = record.MouseEvent.dwMousePosition.X;
                    int _y = record.MouseEvent.dwMousePosition.Y;
                    char wordStart=letterAtMouse;
                    char wordEnd=letterAtMouse;
                    while (wordStart !=' ') {
                        if (_x>0){--_x;}
                        else{break;}
                        wordStart=Screen.ReadCharacterAt(_x, _y);}
                        //word.Insert(0,wordStart);}
                    while (wordEnd !=' ') {
                        if (_x==0){ word.Append( wordEnd=Screen.ReadCharacterAt(_x, _y));}
                        if (_x<Console.WindowWidth){++_x;}
                        else{break;}
                        wordEnd=Screen.ReadCharacterAt(_x, _y);
                        if (wordEnd !=' '){word.Append(wordEnd);}}
                    wordHeld=true;
                    return word.ToString();
                }
            }
            return "nada";
        }
        private class NativeMethods
        {

            public const Int32 STD_INPUT_HANDLE = -10;

            public const Int32 ENABLE_MOUSE_INPUT = 0x0010;
            public const Int32 ENABLE_QUICK_EDIT_MODE = 0x0040;
            public const Int32 ENABLE_EXTENDED_FLAGS = 0x0080;

            public const Int32 KEY_EVENT = 1;
            public const Int32 MOUSE_EVENT = 2;


            [DebuggerDisplay("EventType: {EventType}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT_RECORD {
                [FieldOffset(0)]
                public Int16 EventType;
                [FieldOffset(4)]
                public KEY_EVENT_RECORD KeyEvent;
                [FieldOffset(4)]
                public MOUSE_EVENT_RECORD MouseEvent;
            }

            [DebuggerDisplay("{dwMousePosition.X}, {dwMousePosition.Y}")]
            public struct MOUSE_EVENT_RECORD {
                public COORD dwMousePosition;
                public Int32 dwButtonState;
                public Int32 dwControlKeyState;
                public Int32 dwEventFlags;
            }

            [DebuggerDisplay("{X}, {Y}")]
            public struct COORD {
                public UInt16 X;
                public UInt16 Y;
            }

            [DebuggerDisplay("KeyCode: {wVirtualKeyCode}")]
            [StructLayout(LayoutKind.Explicit)]
            public struct KEY_EVENT_RECORD {
                [FieldOffset(0)]
                [MarshalAsAttribute(UnmanagedType.Bool)]
                public Boolean bKeyDown;
                [FieldOffset(4)]
                public UInt16 wRepeatCount;
                [FieldOffset(6)]
                public UInt16 wVirtualKeyCode;
                [FieldOffset(8)]
                public UInt16 wVirtualScanCode;
                [FieldOffset(10)]
                public Char UnicodeChar;
                [FieldOffset(10)]
                public Byte AsciiChar;
                [FieldOffset(12)]
                public Int32 dwControlKeyState;
            };


            public class ConsoleHandle : SafeHandleMinusOneIsInvalid
            {
                public ConsoleHandle() : base(false) { }

                protected override bool ReleaseHandle()
                {
                    return true; //releasing console handle is not our business
                }
            }


            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean GetConsoleMode(ConsoleHandle hConsoleHandle, ref Int32 lpMode);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            public static extern ConsoleHandle GetStdHandle(Int32 nStdHandle);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean ReadConsoleInput(ConsoleHandle hConsoleInput, ref INPUT_RECORD lpBuffer, UInt32 nLength, ref UInt32 lpNumberOfEventsRead);

            [DllImportAttribute("kernel32.dll", SetLastError = true)]
            [return: MarshalAsAttribute(UnmanagedType.Bool)]
            public static extern Boolean SetConsoleMode(ConsoleHandle hConsoleHandle, Int32 dwMode);

        }
        public static class Screen
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            static extern IntPtr GetStdHandle(int nStdHandle);

            [DllImport("kernel32.dll", SetLastError = true)]
            static extern bool ReadConsoleOutputCharacter(
                IntPtr hConsoleOutput,
                [Out] StringBuilder lpCharacter,
                uint length,
                COORD bufferCoord,
                out uint lpNumberOfCharactersRead);

            [StructLayout(LayoutKind.Sequential)]
            public struct COORD
            {
                public short X;
                public short Y;
            }

            public static char ReadCharacterAt(int x, int y)
            {
                IntPtr consoleHandle = GetStdHandle(-11);
                if (consoleHandle == IntPtr.Zero)
                {
                    return '\0';
                }
                COORD position = new COORD
                {
                    X = (short)x,
                    Y = (short)y
                };
                StringBuilder result = new StringBuilder(1);
                uint read = 0;
                if (ReadConsoleOutputCharacter(consoleHandle, result, 1, position, out read))
                {
                    return result[0];
                }
                else
                {
                    return '\0';
                }
            }
        }

    }
}