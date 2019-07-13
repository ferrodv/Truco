using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;

namespace Truco
{
    public partial class Form0 : Form
    {
        private int ID;
        private String puerto;

        public void SetID(int i) { this.ID = i; }

        public Form0()
        {
            InitializeComponent();
        }

        private void JugarB_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Hilo();
        }
        private void ConectarseB_Click(object sender, EventArgs e)
        {
            ListaPorts.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            ListaPorts.Items.AddRange(ports);
            ListaPorts.Visible = true;
        }

        private void HostB_Click(object sender, EventArgs e)
        {
            this.ID = 0;
            HostB.Enabled = false;
            JoinB.Enabled = false;
            HostB.Visible = false;
            JoinB.Visible = false;
            ConectarseB.Enabled = true;
            ConectarseB.Visible = true;
            JugarB.Enabled = true;
            ListaPorts.Visible = false;
        }
        private void JoinB_Click(object sender, EventArgs e)
        {
            this.ID = 1;
            HostB.Enabled = false;
            JoinB.Enabled = false;
            HostB.Visible = false;
            JoinB.Visible = false;
            ConectarseB.Enabled = true;
            ConectarseB.Visible = true;
            JugarB.Enabled = true;
            ListaPorts.Visible = false;
        }

        private  void Hilo()
        {
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();
        }
        private void ThreadStart()
        {
            Application.Run(new Form1(this.ID,puerto)); // <-- other form started on its own UI thread
        }

        private void CBoxCOMPORT_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConectarseB.Enabled = false;
            ConectarseB.Visible = false;
            HostB.Enabled = true;
            JoinB.Enabled = true;
            HostB.Visible = true;
            JoinB.Visible = true;
            puerto = ListaPorts.Text;
        }
    }
}
