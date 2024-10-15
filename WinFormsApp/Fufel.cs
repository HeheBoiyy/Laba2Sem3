using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Fufel : Form
    {
        private static System.Windows.Forms.Timer _timer = new ();
        public Fufel()
        {
            _timer.Tick += _timer_Tick;
            _timer.Interval = 7000; // 5 seconds
            _timer.Start();
            InitializeComponent();
            axWindowsMediaPlayer1.URL = @"C:\789535984334.mp4";
            axWindowsMediaPlayer1.settings.volume = 100;
        }

        private void Fufel_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.settings.autoStart = true;
        }

        private void Fufel_Enter(object sender, EventArgs e)
        {
            
        }
        void _timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
