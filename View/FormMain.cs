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
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           /* // Di chuyển đối tượng
            objectX -= 30;
            bunifuShadowPanel3.Location = new Point(objectX, bunifuShadowPanel3.Location.Y);

            // Kiểm tra nếu đối tượng đã đạt đến vị trí đích
            if (objectX <= targetX)
            {
                timer.Stop(); // Dừng Timer khi đạt đến vị trí đích
            }*/
            int newObjectX = objectX - 30;

            // Only move and redraw if the position changes
            if (newObjectX != bunifuShadowPanel3.Location.X)
            {
                bunifuShadowPanel3.Location = new Point(newObjectX, bunifuShadowPanel3.Location.Y);
                bunifuShadowPanel3.Refresh();  // Explicitly request a redraw
            }

            // Update objectX after moving
            objectX = newObjectX;

            // Kiểm tra nếu đối tượng đã đạt đến vị trí đích
            if (objectX <= targetX)
            {
                timer.Stop(); // Dừng Timer khi đạt đến vị trí đích
            }
        }


        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel3.Controls.Add(formMainMedicine);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainMedicine.tabItemMedicine_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainPatient.tabItemPatient();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainStaff formMainStaff = new FormMainStaff();

            bunifuShadowPanel3.Controls.Add(formMainStaff);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainStaff.tabItemStaff_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }


        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHF formMainHF = new FormMainHF();
            bunifuShadowPanel3.Controls.Add(formMainHF);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainHF.tabItemHealthFile_Click();

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainEC formMainEC = new FormMainEC(loginStaff);

            bunifuShadowPanel3.Controls.Add(formMainEC);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainEC.tabItemExamination_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainBill formMainBill = new FormMainBill();

            bunifuShadowPanel3.Controls.Add(formMainBill);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainBill.tabPanelBill();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainAssignment formMainAS = new FormMainAssignment();

            bunifuShadowPanel3.Controls.Add(formMainAS);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainAS.tabItemAssignment_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDeptMajor formMainMajor = new FormMainDeptMajor();

            bunifuShadowPanel3.Controls.Add(formMainMajor);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainMajor.tabItemDeptMajor_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel13_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainSurgery formMainSurgery = new FormMainSurgery();

            bunifuShadowPanel3.Controls.Add(formMainSurgery);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainSurgery.tabItemSurgery_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDisease formMainDisease = new FormMainDisease();

            bunifuShadowPanel3.Controls.Add(formMainDisease);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainDisease.tabItemDisease_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel9_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHospitalization formMainHospitalization = new FormMainHospitalization();

            bunifuShadowPanel3.Controls.Add(formMainHospitalization);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainHospitalization.tabItemHospitalization_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel15_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainTest formMainTest = new FormMainTest();

            bunifuShadowPanel3.Controls.Add(formMainTest);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainTest.tabItemTest_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel16_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDischarged formMainDischarged = new FormMainDischarged();

            bunifuShadowPanel3.Controls.Add(formMainDischarged);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1148;
            targetX = 280;
            formMainDischarged.tabItemDischarged_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }
    }
}
    