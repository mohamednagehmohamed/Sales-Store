using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace Hamzawey
{
    public partial class client : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        string imagepath, newpath = "";
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        public client()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            getdata();
            /*    comboBox1.DataSource = ham.clientstbl.ToList();
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
                cmbadd.DataSource = ham.clientstbl.ToList();
                cmbadd.DisplayMember = "name";
                cmbadd.ValueMember = "id";*/
            //combdata();
            lblname.Text = "مرحبا بك:" + getname.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "" || txtaddress.Text.Trim() == "" || txtphone.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                try
                {


                    clientstbl cli = new clientstbl();
                    cli.name = txtname.Text;
                    cli.address = txtaddress.Text;
                    cli.phone = int.Parse(txtphone.Text);
                    ham.clientstbls.Add(cli);
                    ham.SaveChanges();
                    MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\clients\\" + cli.id + ".jpg";

                    File.Copy(imagepath, newpath);
                    cli.image = newpath;
                    ham.SaveChanges();
                    txtname.Text = "";
                    txtaddress.Text = "";
                    txtphone.Text = "";
                    pic.Image = null;
                    getdata();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                if (txtname.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل اسم العميل الذي تريد حذفه", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {

                    string name = txtname.Text;
                    var result = ham.clientstbls.Where(x => x.name == name).ToList();
                    clientstbl cli = ham.clientstbls.SingleOrDefault(x => x.name == name);
                    if (result.Count() > 0)
                    {
                        ham.clientstbls.Remove(cli);
                        ham.SaveChanges();
                        MessageBox.Show("تم الحذف بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        txtname.Text = "";
                        txtaddress.Text = "";
                        txtphone.Text = "";
                        pic.Image = null;
                        getdata();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل اسم العميل الذي تريد تعديله", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    string name = txtname.Text;
                    var result = ham.clientstbls.Where(x => x.name == name).ToList();
                    clientstbl cli = ham.clientstbls.SingleOrDefault(x => x.name == name);
                    if (result.Count > 0)
                    {

                        cli.name = txtname.Text;
                        cli.address = txtaddress.Text;
                        cli.phone = int.Parse(txtphone.Text);
                        ham.SaveChanges();
                        MessageBox.Show("تم التعديل بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (imagepath != "")
                        {
                            newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\clients\\" + cli.id + ".jpg";
                            File.Copy(imagepath, newpath, true);
                            cli.image = newpath;
                            ham.SaveChanges();
                            txtname.Text = "";
                            txtaddress.Text = "";
                            txtphone.Text = "";
                            pic.Image = null;
                            getdata();
                        }
                        // txtid.Enabled = false;
                        //  txtid.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("هذا العميل غير موجود", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            testexel te = new testexel();
            te.Show();
            getname.pagename = "client";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtname.Text = "";
            txtphone.Text = "";
            txtaddress.Text = "";
            pic.Image = null;
            getdata();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //int y = this.Top;
           // this.Top = Screen.PrimaryScreen.Bounds.Height + 1000;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(0,0,0,0,bmp.Size);
            bmp.Save("ss.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
            System.Diagnostics.Process.Start("ss.jpg");
           // this.Top = y;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtaddress.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtphone.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            pic.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        void getdata()
        {

            var result = from data in ham.clientstbls select new { المسلسل = data.id, الاسم = data.name, العنوان = data.address, التليفون = data.phone, الصورة = data.image };
            dataGridView1.DataSource = result.ToList();
        }
    }

}
