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

        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(Staff staff)
        {
            InitializeComponent();
            loginStaff = staff;
            bunifuSnackbar1.Show(this, "Đăng nhập thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
        }


        private void tabItemMedicine_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel3.Controls.Add(formMainMedicine);            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích
            formMainMedicine.tabItemMedicine_Click();

        }

        private void tabItemPatient_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            formMainPatient.tabItemPatient();

        }

        private void tabItemStaff_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainStaff formMainStaff = new FormMainStaff();

            bunifuShadowPanel3.Controls.Add(formMainStaff);
            formMainStaff.tabItemStaff_Click();

        }


        private void tabItemHealthFile_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHF formMainHF = new FormMainHF();
            bunifuShadowPanel3.Controls.Add(formMainHF);
            formMainHF.tabItemHealthFile_Click();


        }

        private void tabItemExamination_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainEC formMainEC = new FormMainEC(loginStaff);

            bunifuShadowPanel3.Controls.Add(formMainEC);
            formMainEC.tabItemExamination_Click();

        }

        private void tabItemBill_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainBill formMainBill = new FormMainBill();

            bunifuShadowPanel3.Controls.Add(formMainBill);
            formMainBill.tabPanelBill();

        }

        private void tabItemAssignment_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainAssignment formMainAS = new FormMainAssignment();

            bunifuShadowPanel3.Controls.Add(formMainAS);
            formMainAS.tabItemAssignment_Click();

        }

        private void tabItemDeptMajor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDeptMajor formMainMajor = new FormMainDeptMajor();

            bunifuShadowPanel3.Controls.Add(formMainMajor);
            formMainMajor.tabItemDeptMajor_Click();

        }

        private void tabItemSurgery_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainSurgery formMainSurgery = new FormMainSurgery();

            bunifuShadowPanel3.Controls.Add(formMainSurgery);
            formMainSurgery.tabItemSurgery_Click();

        }
        
        private void tabItemDisease_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDisease formMainDisease = new FormMainDisease();

            bunifuShadowPanel3.Controls.Add(formMainDisease);
            formMainDisease.tabItemDisease_Click();

        }

        private void tabItemHospitalization_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainHospitalization formMainHospitalization = new FormMainHospitalization();

            bunifuShadowPanel3.Controls.Add(formMainHospitalization);
           formMainHospitalization.tabItemHospitalization_Click();

        }

        private void tabItemMonitor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMonitor formMainMonitor = new FormMainMonitor();

            bunifuShadowPanel3.Controls.Add(formMainMonitor);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích


            formMainMonitor.tabItemMonitor_Click();

        }



        private void tabItemTest_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainTest formMainTest = new FormMainTest();

            bunifuShadowPanel3.Controls.Add(formMainTest);
            formMainTest.tabItemTest_Click();

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
            formMainRoleFunction.tabItemFunction_Click();

        }

        private void tabItemBed_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainBed formMainBed = new FormMainBed();

            bunifuShadowPanel3.Controls.Add(formMainBed);
            formMainBed.tabItemBed_Click();

        }

        private void tabItemService_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainService formMainService = new FormMainService();

            bunifuShadowPanel3.Controls.Add(formMainService);
            // Thiết lập vị trí ban đầu của đối tượng và vị trí đích


            formMainService.tabItemService_Click();

        }

        private void tabItemPrescpition_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainPrescription formMainPrescription = new FormMainPrescription();

            bunifuShadowPanel3.Controls.Add(formMainPrescription);
            formMainPrescription.tabItemPrescpition_Click();

        }

        private void tabItemMaterial_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainMaterial formMainMaterial= new FormMainMaterial();

            bunifuShadowPanel3.Controls.Add(formMainMaterial);
            formMainMaterial.tabItemMaterial_Click();

        }
        private void tabItemDischarged_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Controls.Clear();
            FormMainDischarged formMainDischarged = new FormMainDischarged();

            bunifuShadowPanel3.Controls.Add(formMainDischarged);
            formMainDischarged.tabItemDischarged_Click();

        }

        private void tabItemRole_Click(object sender, EventArgs e)
        {

            bunifuShadowPanel3.Controls.Clear();
            FormMainRole formMainRole = new FormMainRole();

            bunifuShadowPanel3.Controls.Add(formMainRole);
            formMainRole.tabItemRole_Click();

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

        private void FormMain_Load(object sender, EventArgs e)
        {
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            formMainPatient.tabItemPatient();
            GrantRole();
        }
        private void GrantRole()
        {
            DataTable dtRoleDetail = RoleDetail.GetListStaffFunction(loginStaff.RoleID);

            for (int i = 0; i < dtRoleDetail.Rows.Count; i++)
            {
                string tabName = dtRoleDetail.Rows[i][2].ToString();

                foreach (Control panel in tabMain.Controls)
                {
                    if (panel.Name == tabName)
                    {
                        // Set the visibility of the panel based on your condition (e.g., role)
                        panel.Visible = true;
                    }
                }
            }
        }
    }
}
    