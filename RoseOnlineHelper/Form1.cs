using Memory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using AutoItX3Lib;
using System.Runtime.InteropServices;





namespace RoseOnlineHelper
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern ushort GetAsyncKeyState(int vKey);

        Mem mem = new Mem();
        AutoItX3 au3= new AutoItX3();
        int gamepid;
        string gamename = "ROSE Online (Early Access)";
        


        public Form1()
        {
            InitializeComponent();
            
        }
        #region Func

        private void label()
        {
            while (true)
            {
                string nick = mem.ReadString(Addresses.Nick);
                if (nick == "")
                {
                    label4.Text = "NULL";
                }
                else
                {
                    label4.Text = nick;
                }

                string healt = mem.ReadInt(Addresses.Healt).ToString();
                if (healt == "0")
                {
                    label5.Text = "NULL";
                }
                else
                {
                    label5.Text = healt;
                }

                string mana = mem.ReadInt(Addresses.Mana).ToString();
                if (mana == "0")
                {
                    label6.Text = "NULL";
                }
                else
                {
                    label6.Text = mana;
                }
                Thread.Sleep(100);
            }
            
        }
        #endregion
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string cname = guna2TextBox1.Text;
            gamepid=mem.GetProcIdFromName(cname);
            bool handle=mem.OpenProcess(gamepid);
            if (handle)
            {
                MessageBox.Show("Succes.Game Pid: "+gamepid.ToString());
                Control.CheckForIllegalCrossThreadCalls = false;
                Thread tlabel = new Thread(label);
                
                tlabel.Start();
                
                au3.AutoItSetOption("SendKeyDelay", 55);
                au3.AutoItSetOption("SendKeyDownDelay", 25);


            }
            else
            { MessageBox.Show("Failed"); }
        }
        #region timer

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = Convert.ToInt32(box1.Text);
            au3.ControlSend(gamename, "", "", "1");
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = Convert.ToInt32(box2.Text);
            au3.ControlSend(gamename, "", "", "2");
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Interval = Convert.ToInt32(box3.Text);
            au3.ControlSend(gamename, "", "", "3");
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Interval = Convert.ToInt32(box4.Text);
            au3.ControlSend(gamename, "", "", "4");
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer5.Interval = Convert.ToInt32(box5.Text);
            au3.ControlSend(gamename, "", "", "5");
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            timer6.Interval = Convert.ToInt32(box6.Text);
            au3.ControlSend(gamename, "", "", "6");
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer7.Interval = Convert.ToInt32(box7.Text);
            au3.ControlSend(gamename, "", "", "7");
        }

        private void timer8_Tick(object sender, EventArgs e)
        {
            timer8.Interval = Convert.ToInt32(box8.Text);
            au3.ControlSend(gamename, "", "", "8");
        }

        private void timer9_Tick(object sender, EventArgs e)
        {
            timer9.Interval = 20000;
            int healt = mem.ReadInt(Addresses.Healt);
            if (healt != 0)
            {
                if (Convert.ToInt32(box9.Text) > healt)
                {
                    au3.ControlSend(gamename, "", "", "9");
                }


            }


        }

        private void timer10_Tick(object sender, EventArgs e)
        {
            timer10.Interval = 20000;
            int mana = mem.ReadInt(Addresses.Mana);
            if (mana!=0)
            {
                if (Convert.ToInt32(box9.Text) > mana)
                {
                    au3.ControlSend(gamename, "", "", "0");
                }
                

            }
        }

        #endregion

        private void buttonstart_Click(object sender, EventArgs e)
        {
            buttonstart.Enabled = false;
            buttonstop.Enabled = true;
            if (CheckBox1.Checked==true)
            {
                timer1.Enabled = true;
            }
            if (CheckBox2.Checked == true)
            {
                timer2.Enabled = true;
            }
            if (CheckBox3.Checked == true)
            {
                timer3.Enabled = true;
            }
            if (CheckBox4.Checked == true)
            {
                timer4.Enabled = true;
            }
            if (CheckBox5.Checked == true)
            {
                timer5.Enabled = true;

            }
            if (CheckBox6.Checked == true)
            {
                timer6.Enabled = true;
            }
            if (CheckBox7.Checked == true)
            {
                timer7.Enabled = true;
            }

            if (CheckBox8.Checked == true)
            {
                timer8.Enabled = true;
            }
            if (CheckBox9.Checked == true)
            {
                timer9.Enabled = true;
            }

            if (CheckBox10.Checked == true)
            {
                timer10.Enabled = true;
            }
        }

        private void buttonstop_Click(object sender, EventArgs e)
        {
            buttonstart.Enabled = true;
            buttonstop.Enabled = false;

            timer1.Enabled=false;
            timer2.Enabled=false;
            timer3.Enabled=false;   
            timer4.Enabled=false;  
            timer5.Enabled=false;
            timer6.Enabled=false;
            timer7.Enabled=false;
            timer8.Enabled=false;
            timer9.Enabled=false;
            timer10.Enabled=false;
        }

      
    }
}
