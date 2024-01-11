using DO_AN_CUA_HAN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUA_HAN.Barcode
{
    public partial class Form2 : Form
    {
        public Form2(int decode)
        {
            InitializeComponent();
            Patient patient = Patient.GetPatient(decode);
            string ten = patient.FirstName + patient.LastName;
            label1.Text = ten;
        }
    }
}
