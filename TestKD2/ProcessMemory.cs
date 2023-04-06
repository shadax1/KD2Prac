using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKD2
{
    class ProcessMemory
    {
        #region process & address
        //function imports
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);

        //access values
        const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        const int PROCESS_WM_READ = 0x0010;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_OPERATION = 0x0008;

        //process handle
        static Process p = Process.GetProcessesByName("koumajou2")[0];
        IntPtr processHandle = OpenProcess(PROCESS_ALL_ACCESS, false, p.Id);
        public static int FirstProcessModuleMemorySize;

        //amount of bytes written/read
        private int bytesWritten = 0;
        private int bytesRead = 0;
        private IntPtr ThreadStack0;
        #endregion

        public ProcessMemory()
        {
            new Thread(ProcessRun) { IsBackground = true }.Start(); //starts thread with method ProcessRun
            asyncThreadStack0();
            ProcessModule pm = p.Modules[0];
            FirstProcessModuleMemorySize = pm.ModuleMemorySize;
            Console.WriteLine("ModuleMemorySize: " + pm.ModuleMemorySize);
        }

        private async void asyncThreadStack0()
        {
            ThreadStack0 = (IntPtr)await getThread0Address(); //retrieves the base address of THREADSTACK0
        }

        private Task<int> getThread0Address()
        {
            var proc = new Process //starts a new process of threadstack.exe 
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "threadstack.exe",
                    Arguments = p.Id + "", //passing kd2's PID
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine(); //reading each line of threadstack.exe's output
                if (line.Contains("THREADSTACK 0 BASE ADDRESS: ")) //when found then we get the base address
                {
                    line = line.Substring(line.LastIndexOf(":") + 2);
                    return Task.FromResult(int.Parse(line.Substring(2), System.Globalization.NumberStyles.HexNumber));
                }
            }
            return Task.FromResult(0);
        }

        

        void ProcessRun() //checks if program is running
        {
            while (true)
            {
                if (p.HasExited)
                    Environment.Exit(1);
                Thread.Sleep(50);
            }
        }

        public void Write(int[] first_off, int last_off, int value)
        {
            byte[] buffer = new byte[4];
            byte[] bufferValue = new byte[4];
            bufferValue = BitConverter.GetBytes(value);

            //read address pointed by Threadstack - the first initial offset 0x268
            ReadProcessMemory((int)processHandle, (int)ThreadStack0 - first_off[0], buffer, buffer.Length, ref bytesRead);
            IntPtr curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);

            //read address pointed by new pointer address + the second initial offset 0xA0
            ReadProcessMemory((int)processHandle, (int)curAdd + first_off[1], buffer, buffer.Length, ref bytesRead);
            curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);

            //offsetting new pointer
            curAdd = curAdd + last_off;

            //writing value in new pointer address
            WriteProcessMemory((int)processHandle, (int)curAdd, bufferValue, bufferValue.Length, ref bytesWritten);
        }

        public int Read(int[] first_off, int last_off)
        {
            byte[] buffer = new byte[4];

            //read address pointed by Threadstack - the first initial offset 0x268
            ReadProcessMemory((int)processHandle, (int)ThreadStack0 - first_off[0], buffer, buffer.Length, ref bytesRead);
            IntPtr curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);

            //read address pointed by new pointer address + the second initial offset 0xA0
            ReadProcessMemory((int)processHandle, (int)curAdd + first_off[1], buffer, buffer.Length, ref bytesRead);
            curAdd = (IntPtr)BitConverter.ToInt32(buffer, 0);

            //read address pointed by new pointer address + specific offset
            curAdd = curAdd + last_off;
            ReadProcessMemory((int)processHandle, (int)curAdd, buffer, buffer.Length, ref bytesRead);

            //return read value
            return BitConverter.ToInt32(buffer, 0);
        }

        public int ReadStatic(int address)
        {
            byte[] buffer = new byte[4];

            ReadProcessMemory((int)processHandle, (int)p.Modules[0].BaseAddress + address, buffer, buffer.Length, ref bytesRead);

            return BitConverter.ToInt16(buffer, 0);
        }
    }
}
