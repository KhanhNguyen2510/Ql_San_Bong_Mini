using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Do_An_QuanLy_San_Bong_Mini
{
    public partial class FromGoiDichVu : Form
    {
        public FromGoiDichVu()
        {
            InitializeComponent();
            LoadDichvu();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public void LoadDichvu()
        {

            //var dvs = from dv in db.DICHVUs
            //          select dv;
            //dataGridView1.DataSource = dvs; 


        }
        private void FromGoiDichVu_Load(object sender, EventArgs e)
        {

        }
    }
}
