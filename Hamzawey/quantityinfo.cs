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
    public partial class quantityinfo : Form
    {
        HamzaweyEntities1 ham = new HamzaweyEntities1();
        Color[] lblcolor = {Color.Red,Color.Green,Color.Black,Color.Blue,Color.Brown,Color.Chartreuse };
        public quantityinfo()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int x = rand.Next(lblcolor.Length);
            lbl.ForeColor = lblcolor[x];
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Hide();
            store s = new store();
            s.Show();
        }

        private void quantityinfo_Load(object sender, EventArgs e)
        {
            var resulttype = ham.newproducts.ToList().Count();
            lbltype.Text = resulttype.ToString();
            var resultquantity = ham.newproducts.Sum(x=>x.quantity);
            lblquantity.Text = resultquantity.ToString();
            lblname.Text = "مرحبا بك:" + getname.name;
        }
    }
}
