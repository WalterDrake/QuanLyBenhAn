using Bunifu.Framework.UI;
using Bunifu.UI.WinForm.BunifuShadowPanel;
using Bunifu.UI.WinForms;
using DO_AN_CUA_HAN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
            timer.Interval = 1;
            timer.Tick += Timer_Tick;
            bunifuSnackbar1.Show(this, "Đăng nhập thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
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
            int newObjectX = objectX - 25;

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


        private void tabItemMedicine_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel3.Controls.Add(formMainMedicine);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainMedicine.tabItemMedicine_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemPatient_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainPatient.tabItemPatient();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemStaff_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainStaff formMainStaff = new FormMainStaff();

            bunifuShadowPanel3.Controls.Add(formMainStaff);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainStaff.tabItemStaff_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }


        private void tabItemHealthFile_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHF formMainHF = new FormMainHF();
            bunifuShadowPanel3.Controls.Add(formMainHF);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainHF.tabItemHealthFile_Click();

            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemExamination_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainEC formMainEC = new FormMainEC(loginStaff);

            bunifuShadowPanel3.Controls.Add(formMainEC);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainEC.tabItemExamination_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemBill_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainBill formMainBill = new FormMainBill();

            bunifuShadowPanel3.Controls.Add(formMainBill);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainBill.tabPanelBill();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemAssignment_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainAssignment formMainAS = new FormMainAssignment();

            bunifuShadowPanel3.Controls.Add(formMainAS);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainAS.tabItemAssignment_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemDeptMajor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDeptMajor formMainMajor = new FormMainDeptMajor();

            bunifuShadowPanel3.Controls.Add(formMainMajor);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainMajor.tabItemDeptMajor_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemSurgery_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainSurgery formMainSurgery = new FormMainSurgery();

            bunifuShadowPanel3.Controls.Add(formMainSurgery);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainSurgery.tabItemSurgery_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }
        
        private void tabItemDisease_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDisease formMainDisease = new FormMainDisease();

            bunifuShadowPanel3.Controls.Add(formMainDisease);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainDisease.tabItemDisease_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemHospitalization_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHospitalization formMainHospitalization = new FormMainHospitalization();

            bunifuShadowPanel3.Controls.Add(formMainHospitalization);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainHospitalization.tabItemHospitalization_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemMonitor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMonitor formMainMonitor = new FormMainMonitor();

            bunifuShadowPanel3.Controls.Add(formMainMonitor);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainMonitor.tabItemMonitor_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }



        private void tabItemTest_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainTest formMainTest = new FormMainTest();

            bunifuShadowPanel3.Controls.Add(formMainTest);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainTest.tabItemTest_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabItemFunction_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainRoleFunction formMainRoleFunction = new FormMainRoleFunction();

            bunifuShadowPanel3.Controls.Add(formMainRoleFunction);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainRoleFunction.tabItemFunction_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemBed_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainBed formMainBed = new FormMainBed();

            bunifuShadowPanel3.Controls.Add(formMainBed);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainBed.tabItemBed_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemService_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainService formMainService = new FormMainService();

            bunifuShadowPanel3.Controls.Add(formMainService);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainService.tabItemService_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemPrescpition_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainPrescription formMainPrescription = new FormMainPrescription();

            bunifuShadowPanel3.Controls.Add(formMainPrescription);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainPrescription.tabItemPrescpition_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemMaterial_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMaterial formMainMaterial= new FormMainMaterial();

            bunifuShadowPanel3.Controls.Add(formMainMaterial);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainMaterial.tabItemMaterial_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }
        private void tabItemDischarged_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDischarged formMainDischarged = new FormMainDischarged();

            bunifuShadowPanel3.Controls.Add(formMainDischarged);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainDischarged.tabItemDischarged_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void tabItemRole_Click(object sender, EventArgs e)
        {

            bunifuShadowPanel3.Controls.Clear();
            FormMainRole formMainRole = new FormMainRole();

            bunifuShadowPanel3.Controls.Add(formMainRole);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            objectX = 1300;
            targetX = 320;
            formMainRole.tabItemRole_Click();
            timer.Start(); // Bắt đầu Timer để bắt đầu di chuyển đối tượng
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuLogOut_Click(object sender, EventArgs e)
        {
            FormLogin_SignUp formLogin = new FormLogin_SignUp();
            formLogin.FormClosed += new FormClosedEventHandler(Exit_Click);
            formLogin.Show();
            this.Hide();
        }

        private void bunifuAccount_Click(object sender, EventArgs e)
        {
            FormStaffDetail formSD = new FormStaffDetail("personalEdit", loginStaff);
            formSD.ShowDialog();
        }
        private void tabItemStatistics_Click(object sender, EventArgs e)
        {

        }

       
    }
}
    