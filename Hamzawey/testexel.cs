using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Hamzawey
{
    public partial class testexel : Form
    {
        OleDbConnection oledb;
        OleDbDataAdapter da;
        DataTable dt;
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        SqlConnection con = new SqlConnection(@"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Hamzawey;Data Source=DESKTOP-EOHECS5\SQLEXPRESS");
        
        public testexel()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ALL Files |*.*| Excel Files |*.XLSX";
                if (ofd.ShowDialog()==DialogResult.OK) {
                    oledb = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ofd.FileName + ";Extended Properties=Excel 12.0 ");
                    da = new OleDbDataAdapter("Select * from [product$]",oledb);
                    dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (getname.pagename == "client")
            {
                this.Hide();
                client c = new client();
                c.Show();
            }
            else if (getname.pagename == "supplier")
            {
                this.Hide();
                supplier sp = new supplier();
                sp.Show();
            }
            else {
                this.Hide();
                store s = new store();
                s.Show();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void testexel_Load(object sender, EventArgs e)
        {

        }

        private void btn_Click(object sender, EventArgs e)
        {
            /* try {
                 con.Open();
                 if (getname.pagename == "client")
                 {
                     string query = "insert into clientstbl values('" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";
                     SqlCommand cmd = new SqlCommand(query, con);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("تم حفظ بيانات العميل بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                 }
                 else if (getname.pagename == "supplier")
                 {
                     string query = "insert into supplierstbl values('" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";
                     SqlCommand cmd = new SqlCommand(query, con);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("تم حفظ بيانات المورد بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                 }
                 else {
                     string query = "insert into newproduct values('" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";
                     SqlCommand cmd = new SqlCommand(query, con);
                     cmd.ExecuteNonQuery();
                     MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                 }

                 con.Close();
             }

             catch (Exception ex) {
                 MessageBox.Show(ex.Message);
             }*/
            try
            {
                con.Open();
                if (getname.pagename == "client")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string query = "insert into clientstbl values('" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[0].Value + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم حفظ بيانات العميل بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }

                }
                else if (getname.pagename == "supplier")
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                        string query = "insert into supplierstbl values('" + dataGridView1.Rows[i].Cells[3].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[0].Value + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم حفظ بيانات المورد بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    for (int i=0;i<dataGridView1.Rows.Count;i++) {
                        string query = "insert into newproduct values('" + dataGridView1.CurrentRow.Cells[3].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "','" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("تم حفظ بيانات المنتج بنجاح", "برنامج ادارة مخازن الأقمشة", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    }

                }

                con.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }

