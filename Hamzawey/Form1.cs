using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Hamzawey
{
    public partial class Form1 : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        string imagepath, newpath;
        public Form1()
        {
            InitializeComponent();
            panel1.Visible = false;
        }

        private void pic_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                imagepath = ofd.FileName;
                pic.ImageLocation = ofd.FileName;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
             try {
                string name = comboBox1.GetItemText(comboBox1.SelectedItem);
                 user user = ham.users.SingleOrDefault(x => x.name.Contains(name));
                 var result = ham.users.Where(x => x.name.Contains(name)).ToList();
                 if (result.Count > 0)
                 {
                     txtname.Text = user.name;
                     txtphone.Text = user.phone.ToString();
                     txtusername.Text = user.username;
                     txtpass.Text = user.pass;
                     pic.ImageLocation = user.image;
                     panel1.Visible = false;
                 }
                 else
                 {
                     MessageBox.Show("هذا المستخدم غير موجود");
                 }
             }
             catch (Exception ex) {
                 MessageBox.Show(ex.Message);
             }
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login log = new Login();
            log.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                 comboBox1.DataSource = ham.users.ToList();
                 comboBox1.DisplayMember = "name";
                 comboBox1.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("هل تريد تأكيد الخروج", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user user = new user();
            user.name = txtname.Text;

            user.phone = int.Parse(txtphone.Text);
            user.username = txtusername.Text;
            user.pass = txtpass.Text;
            ham.users.Add(user);
            ham.SaveChanges();
            MessageBox.Show("تم حفظ بيانات المستخدم بنجاح");
            newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\users\\" + user.id + ".jpg";

            File.Copy(imagepath, newpath);
            user.image = newpath;
            ham.SaveChanges();
            txtusername.Text = "";
            txtpass.Text = "";
            pic.Image = null;
            comboBox1.DataSource = ham.users.ToList();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
        }
    }
 
    }

