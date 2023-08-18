using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace Hamzawey
{
    public partial class load : Form
    {
        SpeechSynthesizer ssynthize = new SpeechSynthesizer();
        int startpoint = 0;
        public load()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {/. 
            startpoint++;
            prog.Value = startpoint;
            if (startpoint==100) {
                startpoint = 0;
                timer1.Enabled = false;
                timer1.Stop();
                this.Hide();
                Login log = new Login();
                log.Show();
                ssynthize.SelectVoiceByHints(VoiceGender.Male);
                ssynthize.SpeakAsync("Welcome sir");
            }
        }
    }
}
