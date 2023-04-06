using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKD2
{
    public partial class TestKD2 : Form
    {
        #region misc
        static ProcessMemory pm = new ProcessMemory();
        //int resultHearts, resultStamina, resultHP, resultLives, resultFramecount, resultFramecount2, resultFramecountTemp;
        int resultMusicID = -1;
        int[] FIRST_OFFSETS_WIN10_102A = { 0x268, 0xA0 };
        int[] FIRST_OFFSETS_WIN10_102 = { 0x278, 0xA0 };
        int[] FIRST_OFFSETS_WIN7_102A = { 0x260, 0xA0 };
        int[] FIRST_OFFSETS_WIN7_102 = { 0x270, 0xA0 };
        int[] FIRST_OFFSETS;
        int MusicIDAddr;

        static string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string path = appdata + @"\KD2Prac\config.cfg";

        private KeyHandler ghk;

        public TestKD2()
        {
            InitializeComponent();
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

            foreach (Keys k in Enum.GetValues(typeof(Keys)))
                comboHotkeys.Items.Add(k);
        }

        private void TestKD2_Load(object sender, EventArgs e)
        {
            int OS = checkWindows();
            int KD2 = checkKD2();

            try
            {
                if (OS == 7) //if Windows7
                {
                    if (KD2 == 1022) //if ver 1.02a
                    {
                        FIRST_OFFSETS = FIRST_OFFSETS_WIN7_102A;
                        MusicIDAddr = 0x28EE98;
                    }
                    else if (KD2 == 102) //if ver 1.02
                    {
                        FIRST_OFFSETS = FIRST_OFFSETS_WIN7_102;
                        MusicIDAddr = 0x27E398;
                    } 
                    else throw new Exception("Windows7: There was an error while detecting the game's version. Make sure your game is at least updated to ver 1.02");
                }
                else //if Windows10
                {
                    if (KD2 == 1022) //if ver 1.02a
                    {
                        FIRST_OFFSETS = FIRST_OFFSETS_WIN10_102A;
                        MusicIDAddr = 0x28EE98;
                    }
                    else if (KD2 == 102) //if ver 1.02
                    {
                        FIRST_OFFSETS = FIRST_OFFSETS_WIN10_102;
                        MusicIDAddr = 0x27E398;
                    }
                    else throw new Exception("Windows 10: There was an error while detecting the game's version. Make sure your game is at least updated to ver 1.02");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Version exception");
                Environment.Exit(1);
            }
            
            /*new Thread(Lives) { IsBackground = true }.Start();
            new Thread(HP) { IsBackground = true }.Start();
            new Thread(Stamina) { IsBackground = true }.Start();
            new Thread(Hearts) { IsBackground = true }.Start();
            new Thread(Framecount) { IsBackground = true }.Start();*/

            if (!Directory.Exists(appdata + @"\KD2Prac"))
                Directory.CreateDirectory(appdata + @"\KD2Prac");

            string x, y;
            if (File.Exists(path)) //checks if config.cfg exists
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    x = sr.ReadLine();
                    y = sr.ReadLine();
                    comboHotkeys.SelectedIndex = int.Parse(sr.ReadLine()); //reads the previously used hotkey for instant kill
                }
                Location = new Point(int.Parse(x), int.Parse(y)); //places the app at the same position it was in the last time
            }

            //starting threads
            new Thread(Unlimited) { IsBackground = true }.Start();
            new Thread(MusicID) { IsBackground = true }.Start();
        }

        private void TestKD2_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter sw = File.CreateText(path)) //saving application's position upon closing
            {
                sw.WriteLine(Location.X);
                sw.WriteLine(Location.Y);
                sw.WriteLine(comboHotkeys.SelectedIndex); //saving selected hotkey
            }
        }

        private int checkWindows() //checks if Windows 10 or Windows 7 is the current OS
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string productName = (string)reg.GetValue("ProductName");
            if (productName.StartsWith("Windows 7")) return 7;
            else return 10;
        }

        private int checkKD2() //checks if ver 1.02 or 1.02a
        {
            if (ProcessMemory.FirstProcessModuleMemorySize == 0x677000) //if ver 1.02a
                return 1022;
            else if (ProcessMemory.FirstProcessModuleMemorySize == 0x665000) //if ver 1.02
                return 102;
            else
                return 0;
        }
        #endregion

        #region global hotkey
        private void HandleHotkey()
        {
            int LAST_OFFSET = 0x13EF;
            pm.Write(FIRST_OFFSETS, LAST_OFFSET, 0);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Constants.WM_HOTKEY_MSG_ID)
                HandleHotkey();
            base.WndProc(ref m);
        }
        #endregion

        #region thread_labels
        /*private void Framecount()
        {
            var timespan = new TimeSpan();
            while (true)
            {
                if(resultMusicID > 0 && resultMusicID < 32) //checks if in stage or not
                {
                    resultFramecount2 = resultFramecount; //framecount runs even when not in a stage, saving its value to substract later on
                    while (suku.ReadStatic(0x391898) == 0) //while the game isn't loading
                    {
                        resultFramecount = suku.ReadStatic(0x6221A4); //read framecount
                        resultFramecountTemp = resultFramecount - resultFramecount2; //subtract with old value
                        timespan = TimeSpan.FromSeconds(resultFramecountTemp); //create timespan object for time display
                        labelFramecount.Invoke((MethodInvoker)delegate () { labelFramecount.Text = timespan.ToString(@"hh\:mm\.ss"); });
                        Thread.Sleep(1);
                    }
                    if(suku.ReadStatic(0x391898) == 1 && resultHP > 0) //if the game is loading and sakuya not dead - save the latest framecount
                    {
                        labelFramecountPrevious.Invoke((MethodInvoker)delegate () { labelFramecountPrevious.Text = timespan.ToString(@"hh\:mm\.ss"); });
                        Thread.Sleep(100);
                    }
                }
                else
                    labelFramecount.Invoke((MethodInvoker)delegate () { labelFramecount.Text = "00:00.00"; });
                Thread.Sleep(1);
            }
        }

        private void Hearts()
        {
            int LAST_OFFSET = 0x1400;
            while (true)
            {
                if (resultMusicID > 0 && resultMusicID < 32)
                {
                    resultHearts = suku.Read(FIRST_OFFSETS, LAST_OFFSET);
                    labelHearts.Invoke((MethodInvoker)delegate () { labelHearts.Text = resultHearts.ToString(); });
                }
                else
                    labelHearts.Invoke((MethodInvoker)delegate () { labelHearts.Text = "0"; });
                Thread.Sleep(100);
            }
        }

        private void Stamina()
        {
            int LAST_OFFSET = 0x13FC;
            while (true)
            {
                if (resultMusicID > 0 && resultMusicID < 32)
                {
                    resultStamina = suku.Read(FIRST_OFFSETS, LAST_OFFSET);
                    labelStamina.Invoke((MethodInvoker)delegate () { labelStamina.Text = resultStamina.ToString(); });
                }
                else
                    labelStamina.Invoke((MethodInvoker)delegate () { labelStamina.Text = "0"; });
                Thread.Sleep(100);
            }
        }

        private void HP()
        {
            int LAST_OFFSET = 0x13F0;
            while (true)
            {
                if (resultMusicID > 0 && resultMusicID < 32)
                {
                    resultHP = suku.Read(FIRST_OFFSETS, LAST_OFFSET);
                    labelHP.Invoke((MethodInvoker)delegate () { labelHP.Text = resultHP.ToString(); });
                }
                else
                    labelHP.Invoke((MethodInvoker)delegate () { labelHP.Text = "0"; });
                Thread.Sleep(100);
            }
        }

        private void Lives()
        {
            int LAST_OFFSET = 0x13EC;
            while (true)
            {
                if (resultMusicID > 0 && resultMusicID < 32)
                {
                    resultLives = suku.Read(FIRST_OFFSETS, LAST_OFFSET);
                    labelLives.Invoke((MethodInvoker)delegate () { labelLives.Text = resultLives.ToString(); });
                }
                else
                    labelLives.Invoke((MethodInvoker)delegate () { labelLives.Text = "0"; });
                Thread.Sleep(100);
            }
        }*/
        #endregion

        #region utils
        private void Unlimited()
        {
            int HEARTS_OFFSET = 0x1400;
            int LIVES_OFFSET = 0x13EC;
            int STAMINA_OFFSET = 0x13FC;
            int HP_OFFSET = 0x13F0;

            while (true)
            {
                if (resultMusicID > 0 && resultMusicID < 32)
                {
                    if (checkLives.Checked)
                        pm.Write(FIRST_OFFSETS, LIVES_OFFSET, 6);

                    if (checkHearts.Checked)
                        pm.Write(FIRST_OFFSETS, HEARTS_OFFSET, 200);

                    if (checkStamina.Checked)
                        pm.Write(FIRST_OFFSETS, STAMINA_OFFSET, 1000);

                    if (checkHP.Checked)
                        pm.Write(FIRST_OFFSETS, HP_OFFSET, 100);
                }
                Thread.Sleep(100);
            }
        }

        private void MusicID()
        {
            while (true)
            {
                resultMusicID = pm.ReadStatic(MusicIDAddr);
                Thread.Sleep(100);
            }
        }

        private void comboHotkeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ghk != null)
                ghk.Unregister();
            ghk = new KeyHandler((Keys)comboHotkeys.SelectedItem, this);
            ghk.Register();
        }
        #endregion
    }
}
