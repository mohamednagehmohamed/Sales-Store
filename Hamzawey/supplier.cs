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
    public partial class supplier : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        string imagepath, newpath = "";
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        public supplier()
        {
            InitializeComponent();
        }
        void getdata()
        {

            var result = from data in ham.supplierstbls select new { المسلسل = data.id, الاسم = data.name, العنوان = data.address, التليفون = data.phone, الصورة = data.image };
            dataGridView1.DataSource = result.ToList();
        }
        private void supplier_Load(object sender, EventArgs e)
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


                    supplierstbl sp = new supplierstbl();
                    sp.name = txtname.Text;
                    sp.address = txtaddress.Text;
                    sp.phone = int.Parse(txtphone.Text);
                    ham.supplierstbls.Add(sp);
                    ham.SaveChanges();
                    MessageBox.Show("تم حفظ بيانات المورد بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\suppliers\\" + sp.id + ".jpg";

                    File.Copy(imagepath, newpath);
                    sp.image = newpath;
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل اسم المورد الذي تريد حذفه", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {

                    string name = txtname.Text;
                    var result = ham.supplierstbls.Where(x => x.name == name).ToList();
                    supplierstbl sp = ham.supplierstbls.SingleOrDefault(x => x.name == name);
                    if (result.Count() > 0)
                    {
                        ham.supplierstbls.Remove(sp);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtname.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل اسم المورد الذي تريد تعديله", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    string name = txtname.Text;
                    var result = ham.clientstbls.Where(x => x.name == name).ToList();
                    supplierstbl sp = ham.supplierstbls.SingleOrDefault(x => x.name == name);
                    if (result.Count > 0)
                    {

                        sp.name = txtname.Text;
                        sp.address = txtaddress.Text;
                        sp.phone = int.Parse(txtphone.Text);
                        ham.SaveChanges();
                        MessageBox.Show("تم التعديل بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (imagepath != "")
                        {
                            newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\suppliers\\" + sp.id + ".jpg";
                            File.Copy(imagepath, newpath, true);
                            sp.image = newpath;
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
                        MessageBox.Show("هذا المورد غير موجود", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            //int y = this.Top;
          //  this.Top = Screen.PrimaryScreen.Bounds.Height + 1000;
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graph = Graphics.FromImage(bmp);
            graph.CopyFromScreen(0, 0, 0, 0, bmp.Size);
            bmp.Save("ss.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            System.Diagnostics.Process.Start("ss.jpg");
           // this.Top = y;
        }

        private void pic_Click(object sender, EventArgs e)
        {

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

        private void pic_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog()==DialogResult.OK) {
                imagepath = ofd.FileName;
                pic.ImageLocation = ofd.FileName;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            testexel te = new testexel();
            te.Show();
            getname.pagename ="supplier";
        }
    }

}
