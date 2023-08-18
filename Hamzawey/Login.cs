using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hamzawey
{
    public partial class Login : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();

        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            user user = new user();
            user u = ham.users.SingleOrDefault(x=>x.username==txtusername.Text&&x.pass==txtpass.Text);
            var result = ham.users.Where(x=>x.username==txtusername.Text&&x.pass==txtpass.Text);
            if (result.Count() > 0)
            {
                getname.name = u.name;
                this.Hide();
                main m = new main();
                m.Show();
            }
            else {
                MessageBox.Show("هذا المستخدم غير موجود من فضلك قم بإضافة المستخدم أولا ","برنامج ادارة المخازن",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("هل تريد تأكيد الخروج", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    public static class getname
    {
      public  static string name = "";
        public static string pagename = "";
    }
}
