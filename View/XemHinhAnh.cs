using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUA_HAN.View
{
    public partial class XemHinhAnh : UserControl
    {
        public XemHinhAnh(string hinhanh)
        {
            InitializeComponent();
            Image img = Image.FromFile(hinhanh);
            pictureBox1.Image= img;

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
