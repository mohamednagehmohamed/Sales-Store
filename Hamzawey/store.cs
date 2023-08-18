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
using System.Speech.Synthesis;
using System.Data.SqlClient;
namespace Hamzawey
{
    public partial class store : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        string imagepath, newpath = "";
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt = new DataTable();
        public store()
        {
            InitializeComponent();
            pnlsarf.Visible = false;
            pnladd.Visible = false;
            con= new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Hamzawey;Data Source=DESKTOP-EOHECS5\SQLEXPRESS");
            sda = new SqlDataAdapter("select name from newproduct",con);
            sda.Fill(dt);
            AutoCompleteStringCollection datasource = new AutoCompleteStringCollection();
            for (int i=0;i<dt.Rows.Count;i++) {
                datasource.Add(dt.Rows[i][0].ToString());
            }
            txtname.AutoCompleteCustomSource = datasource;
            txtname.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtname.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }
        void combdata() {
            comboBox1.DataSource = ham.newproducts.ToList();
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            cmbadd.DataSource = ham.newproducts.ToList();
            cmbadd.DisplayMember = "name";
            cmbadd.ValueMember = "id";
            
        }
        void getdata() {
            
            var result = from data in ham.newproducts select new {المسلسل=data.id,الاسم=data.name,الكمية=data.quantity,السعر=data.price,الصورة=data.image};
            dataGridView1.DataSource = result.ToList();
        }
        private void store_Load(object sender, EventArgs e)
        {
            getdata();
            /*    comboBox1.DataSource = ham.newproducts.ToList();
                comboBox1.DisplayMember = "name";
                comboBox1.ValueMember = "id";
                cmbadd.DataSource = ham.newproducts.ToList();
                cmbadd.DisplayMember = "name";
                cmbadd.ValueMember = "id";*/
            combdata();
            lblname.Text = "مرحبا بك:" + getname.name;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main m = new main();
            m.Show();
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

        private void button2_Click(object sender, EventArgs e)
        {

            if (txtname.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل اسم القماش الذي تريد حذفه", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else {
                
                string name = txtname.Text;
                var result = ham.newproducts.Where(x => x.name == name).ToList();
                newproduct pro = ham.newproducts.SingleOrDefault(x => x.name == name);
                if (result.Count() > 0)
                {
                    ham.newproducts.Remove(pro);
                    ham.SaveChanges();
                    MessageBox.Show("تم الحذف بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    txtname.Text = "";
                    txtprice.Text = "";
                    txtquantity.Text = "";
                    pic.Image = null;
                    getdata();
                    combdata();
                }
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                if (txtname.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل اسم القماش الذي تريد تعديله", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    string name = txtname.Text;
                    var result = ham.newproducts.Where(x => x.name == name).ToList();
                    newproduct pro = ham.newproducts.SingleOrDefault(x => x.name == name);
                    if (result.Count > 0)
                    {

                        pro.name = txtname.Text;
                        pro.quantity = int.Parse(txtquantity.Text);
                        pro.price = int.Parse(txtprice.Text);
                        ham.SaveChanges();
                        MessageBox.Show("تم التعديل بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (imagepath != "")
                        {
                            newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\products\\" + pro.id + ".jpg";
                            File.Copy(imagepath, newpath, true);
                            pro.image = newpath;
                            ham.SaveChanges();
                        }
                        else {
                            newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\products\\" + pro.id + ".jpg";
                            File.Copy(imagepath, newpath);
                            pro.image = newpath;
                            ham.SaveChanges();
                        } 
                            txtname.Text = "";
                            txtprice.Text = "";
                            txtquantity.Text = "";
                            pic.Image = null;
                            getdata();
                        
                       
                        // txtid.Enabled = false;
                        //  txtid.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("هذا المنتج غير موجود", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            pnlsarf.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                if (txtquantitysarf.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل الكميه التي تريد صرفها", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else {
                    int quantity = int.Parse(txtquantitysarf.Text);
                    string name = comboBox1.GetItemText(comboBox1.SelectedItem);
                    newproduct pro = ham.newproducts.SingleOrDefault(x => x.name == name);
                    var result = ham.newproducts.Where(x => x.name == name);
                    if (result.Count() > 0)
                    {
                        if (pro.quantity >= int.Parse(txtquantitysarf.Text))
                        {
                            pro.quantity = pro.quantity - int.Parse(txtquantitysarf.Text);
                            ham.SaveChanges();
                            MessageBox.Show("تم صرف الكمية بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            pnlsarf.Visible = false;
                            getdata();
                        }
                        else
                        {
                            MessageBox.Show("المخزن لا يحتوي علي هذه الكميه", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        }
                    }
                }

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pnlsarf.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtquantity.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtprice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
           pic.ImageLocation = dataGridView1.CurrentRow.Cells[4].Value.ToString();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            quantityinfo q = new quantityinfo();
            q.Show();
        }

        private void btnaddquantity_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtquantityadd.Text.Trim() == "")
                {
                    MessageBox.Show("من فضلك أدخل الكميه التي تريد إضافتها", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                else
                {
                    int quantity = int.Parse(txtquantityadd.Text);
                    string name = cmbadd.GetItemText(cmbadd.SelectedItem);
                    newproduct pro = ham.newproducts.SingleOrDefault(x => x.name == name);
                    var result = ham.newproducts.Where(x => x.name == name);
                    if (result.Count() > 0)
                    {
                            pro.quantity = pro.quantity + int.Parse(txtquantityadd.Text);
                            ham.SaveChanges();
                            MessageBox.Show("تم إضافة الكمية بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            pnladd.Visible = false;
                            getdata();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pnladd.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //this.Hide();
            testexel te = new testexel();
            bunifuTransition1.ShowSync(te);
           // te.Show();
           
            //storename.name = "store";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnladd.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls) {
                if (c is MetroFramework.Controls.MetroTextBox) {
                    c.Text = "";
                }
            }
            pic.Image = null;
            getdata();
            combdata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text.Trim() == "" || txtprice.Text.Trim() == "" || txtquantity.Text.Trim() == "")
            {
                MessageBox.Show("من فضلك أدخل جميع البيانات", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else {
                try
                {

                    /* newproduct pro = new newproduct();
                     string name = txtname.Text;
                     pro = ham.newproducts.SingleOrDefault(x=>x.name==name);
                     var result = ham.newproducts.Where(x=>x.name==name);
                     if (result.Count() > 0)
                     {
                         pro.name = txtname.Text;
                         pro.quantity = int.Parse(txtquantity.Text);
                         pro.price = int.Parse(txtprice.Text);
                         ham.SaveChanges();
                         MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                         newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\products\\" + pro.id + ".jpg";
                         File.Copy(imagepath, newpath, true);
                         pro.image = newpath;
                         ham.SaveChanges();
                         txtname.Text = "";
                         txtprice.Text = "";
                         txtquantity.Text = "";
                         pic.Image = null;
                     }
                     else {
                         pro.name = txtname.Text;
                         pro.quantity = int.Parse(txtquantity.Text);
                         pro.price = int.Parse(txtprice.Text);
                         ham.newproducts.Add(pro);
                         ham.SaveChanges();
                         MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                         newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\products\\" + pro.id + ".jpg";

                         File.Copy(imagepath, newpath);
                         pro.image = newpath;
                         ham.SaveChanges();
                         txtname.Text = "";
                         txtprice.Text = "";
                         txtquantity.Text = "";
                         pic.Image = null;
                     }

                     getdata();
                     combdata();*/
                    string checkname = txtname.Text;
                    var checkisfound = ham.newproducts.Where(x=>x.name==checkname).ToList();
                    newproduct checkproductfound = ham.newproducts.SingleOrDefault(x=>x.name==checkname);
                    if (checkisfound.Count() > 0)
                    {
                        MessageBox.Show("هذا المنتج موجود بالفعل في المخزن يمكنك الضغظ علي زرار (اضافة الي نوع للاضافة الي هذا المنتج)", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }
                    else {
                        newproduct pro = new newproduct();
                        pro.name = txtname.Text;
                        pro.quantity = int.Parse(txtquantity.Text);
                        pro.price = int.Parse(txtprice.Text);
                        ham.newproducts.Add(pro);
                        ham.SaveChanges();
                        MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        newpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\photos\\products\\" + pro.id + ".jpg";

                        File.Copy(imagepath, newpath);
                        pro.image = newpath;
                        ham.SaveChanges();
                        txtname.Text = "";
                        txtprice.Text = "";
                        txtquantity.Text = "";
                        pic.Image = null;
                        getdata();
                        combdata();
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
        }
    }
    public static class storename
    {
        public static string name = "";
    }
}
