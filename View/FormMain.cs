using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
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

namespace DO_AN_CUA_HAN.View
{
    
    public partial class FormMain : Form
    {
        private Staff loginStaff { get; set; }

        private Timer timer;
        private int objectX;
        private int targetX;
        public FormMain()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }
        public FormMain(Staff staff)
        {
            InitializeComponent();
            loginStaff = staff;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Di chuyển đối tượng
            objectX -= 30;
            bunifuShadowPanel3.Location = new Point(objectX, bunifuShadowPanel3.Location.Y);

            // Kiểm tra nếu đối tượng đã đạt đến vị trí đích
            if (objectX <= targetX)
            {
                timer.Stop(); // Dừng Timer khi đạt đến vị trí đích
            }
        }

       
        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel3.Controls.Add(formMainMedicine);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainPatient formMainPatient = new FormMainPatient();
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainStaff formMainStaff = new FormMainStaff();

            bunifuShadowPanel3.Controls.Add(formMainStaff);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }


        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainHF formMainHF = new FormMainHF();

            bunifuShadowPanel3.Controls.Add(formMainHF);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainEC formMainEC = new FormMainEC();

            bunifuShadowPanel3.Controls.Add(formMainEC);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainBill formMainBill = new FormMainBill();

            bunifuShadowPanel3.Controls.Add(formMainBill);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainAssignment formMainAS = new FormMainAssignment();

            bunifuShadowPanel3.Controls.Add(formMainAS);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainDeptMajor formMainMajor = new FormMainDeptMajor();

            bunifuShadowPanel3.Controls.Add(formMainMajor);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Remove(this);
            FormMainSurgery formMainSurgery = new FormMainSurgery();

            bunifuShadowPanel3.Controls.Add(formMainSurgery);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

    }
}
    