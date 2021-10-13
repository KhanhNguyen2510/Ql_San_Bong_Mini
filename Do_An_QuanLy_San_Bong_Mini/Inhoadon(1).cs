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
    public partial class Inhoadon : Form
    {
        public Inhoadon()
        {
            InitializeComponent();
        }

        private void Inhoadon_Load(object sender, EventArgs e)
        {
            CrystalReport1 d = new CrystalReport1();
            crystalReportViewer1.ReportSource = d;
        }
    }
}
