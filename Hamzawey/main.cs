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
    public partial class main : Form
    {
        SpeechSynthesizer ssynthize = new SpeechSynthesizer();
        int lblspeed = 5;
        public main()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblmove.Left -= lblspeed;
            if (lblmove.Bounds.IntersectsWith(left.Bounds)||lblmove.Bounds.IntersectsWith(right.Bounds)) {
                lblspeed = -lblspeed;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            store s = new store();
            s.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("هل تريد تأكيد الخروج","برنامج ادارة مخازن الأقمشة",MessageBoxButtons.YesNo,MessageBoxIcon.Question) ;
            if (exit==DialogResult.Yes) {
                Application.Exit();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls) {
                if (c is PictureBox&&c.Tag== "ice") {
                    c.Top += 5;
                    if (c.Top>this.ClientSize.Height) {
                        c.Top = 0;
                    }
                }
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            lblname.Text ="مرحبا بك:"+ getname.name;
            ssynthize.SelectVoiceByHints(VoiceGender.Male);
            ssynthize.SpeakAsync("You can from this page to access to users page to register or to access to products page enjoy sir");
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Hide();
            client cl = new client();
            cl.Show();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Hide();
            supplier s = new supplier();
            s.Show();
        }
    }
}
