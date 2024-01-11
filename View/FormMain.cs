using Bunifu.Framework.UI;
using Bunifu.UI.WinForm.BunifuShadowPanel;
using Bunifu.UI.WinForms;
using DO_AN_CUA_HAN.Functional;
using DO_AN_CUA_HAN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace DO_AN_CUA_HAN.View
{
    
    public partial class FormMain : Form
    {

        private Staff loginStaff { get; set; }
        public Point mouseLocation;

        public FormMain()
        {
            InitializeComponent();
        }
        public FormMain(Staff staff)
        {
            InitializeComponent();
            loginStaff = staff;
            bunifuSnackbar1.Show(this, "Đăng nhập thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
            GetStaffInformation();
        }
        private void GetStaffInformation() // Avatar
        {

            DataTable dtb;

            string sqlSelect = @"SELECT STAFF.FIRSTNAME, STAFF.LASTNAME, DEPARTMENT.DEPARTMENTNAME, ROLE.ROLENAME
                                FROM  STAFF JOIN DEPARTMENT ON STAFF.DEPARTMENTID = DEPARTMENT.DEPARTMENTID
                                JOIN  ROLE ON STAFF.ROLEID = ROLE.ROLEID
                                WHERE  STAFF.STAFFID = @Staffid";

            SqlParameter[] sqlParameters = { new SqlParameter("@Staffid", loginStaff.StaffID) };

            dtb = SqlResult.ExecuteQuery(sqlSelect, sqlParameters);


            // If select query have row then set to new patient
            if (dtb.Rows.Count > 0)
            {
                string firstName = dtb.Rows[0]["FIRSTNAME"].ToString();
                string lastName = dtb.Rows[0]["LASTNAME"].ToString();
                string departmentName = dtb.Rows[0]["DEPARTMENTNAME"].ToString();
                string roleName = dtb.Rows[0]["ROLENAME"].ToString();
                string fullName = $"{lastName} {firstName}";
               // string tooltipText = $"<html><b>Họ và tên:</b> {fullName}<br/><b>Chức vụ:</b> {roleName}<br/><b>Khoa:</b> {departmentName}</html>";
                string tooltipText = $"<html> Họ và tên: <i>{fullName}</i> <br/>Chức vụ: <i>{roleName}</i> <br/>Khoa: <i>{departmentName}</i></html>";

                bunifuToolTip1.SetToolTip(pictureBoxInformation, tooltipText);
                // Bạn cũng có thể đặt ToolTip Title hoặc Icon nếu cần.
                bunifuToolTip1.SetToolTipTitle(pictureBoxInformation, fullName);
            }
        }


        private void tabItemMedicine_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
             FormMainMedicine formMainMedicine = new FormMainMedicine();
            bunifuShadowPanel3.Controls.Add(formMainMedicine);
            bunifuShadowPanel3.Show();
            formMainMedicine.tabItemMedicine_Click();
        }

        private void tabItemPatient_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
             bunifuShadowPanel3.Controls.Add(formMainPatient);
            bunifuShadowPanel3.Show();
             formMainPatient.tabItemPatient();

        }

        private void tabItemStaff_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainStaff formMainStaff = new FormMainStaff();
            bunifuShadowPanel3.Controls.Add(formMainStaff);
            bunifuShadowPanel3.Show();
            formMainStaff.tabItemStaff_Click();

        }

        private void tabItemHealthFile_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainHF formMainHF = new FormMainHF();
            bunifuShadowPanel3.Controls.Add(formMainHF);
            bunifuShadowPanel3.Show();
            formMainHF.tabItemHealthFile_Click();
        }

        private void tabItemExamination_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainEC formMainEC = new FormMainEC(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainEC);
            bunifuShadowPanel3.Show();
            formMainEC.tabItemExamination_Click();
        }

        private void tabItemBill_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainBill formMainBill = new FormMainBill();
            bunifuShadowPanel3.Controls.Add(formMainBill);
            bunifuShadowPanel3.Show();
            formMainBill.tabPanelBill();
        }

        private void tabItemAssignment_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainAssignment formMainAS = new FormMainAssignment();
            bunifuShadowPanel3.Controls.Add(formMainAS);
            bunifuShadowPanel3.Show();
            formMainAS.tabItemAssignment_Click();
        }

        private void tabItemDeptMajor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainDeptMajor formMainMajor = new FormMainDeptMajor();
            bunifuShadowPanel3.Controls.Add(formMainMajor);
            bunifuShadowPanel3.Show();
            formMainMajor.tabItemDeptMajor_Click();
        }

        private void tabItemSurgery_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainSurgery formMainSurgery = new FormMainSurgery();
            bunifuShadowPanel3.Controls.Add(formMainSurgery);
            bunifuShadowPanel3.Show();
            formMainSurgery.tabItemSurgery_Click();
        }
        
        private void tabItemDisease_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainDisease formMainDisease = new FormMainDisease();
            bunifuShadowPanel3.Controls.Add(formMainDisease);
            bunifuShadowPanel3.Show();
            formMainDisease.tabItemDisease_Click();
        }

        private void tabItemHospitalization_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainHospitalization formMainHospitalization = new FormMainHospitalization();
            bunifuShadowPanel3.Controls.Add(formMainHospitalization);
            bunifuShadowPanel3.Show();
           formMainHospitalization.tabItemHospitalization_Click();
        }

        private void tabItemMonitor_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainMonitor formMainMonitor = new FormMainMonitor();
            bunifuShadowPanel3.Controls.Add(formMainMonitor);
            bunifuShadowPanel3.Show();
            formMainMonitor.tabItemMonitor_Click();
        }

        private void tabItemTest_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainTest formMainTest = new FormMainTest();
            bunifuShadowPanel3.Controls.Add(formMainTest);
            bunifuShadowPanel3.Show();
            formMainTest.tabItemTest_Click();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabItemFunction_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainRoleFunction formMainRoleFunction = new FormMainRoleFunction();
            bunifuShadowPanel3.Controls.Add(formMainRoleFunction);
            bunifuShadowPanel3.Show();
            formMainRoleFunction.tabItemFunction_Click();
        }

        private void tabItemBed_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainBed formMainBed = new FormMainBed();
            bunifuShadowPanel3.Controls.Add(formMainBed);
            bunifuShadowPanel3.Show();
            formMainBed.tabItemBed_Click();
        }

        private void tabItemService_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainService formMainService = new FormMainService();
            bunifuShadowPanel3.Controls.Add(formMainService);
            bunifuShadowPanel3.Show();
            formMainService.tabItemService_Click();
        }

        private void tabItemPrescpition_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainPrescription formMainPrescription = new FormMainPrescription();
            bunifuShadowPanel3.Controls.Add(formMainPrescription);
            bunifuShadowPanel3.Show();
            formMainPrescription.tabItemPrescpition_Click();
        }

        private void tabItemMaterial_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainMaterial formMainMaterial= new FormMainMaterial();
            bunifuShadowPanel3.Controls.Add(formMainMaterial);
            bunifuShadowPanel3.Show();
            formMainMaterial.tabItemMaterial_Click();
        }
        private void tabItemDischarged_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainDischarged formMainDischarged = new FormMainDischarged();
            bunifuShadowPanel3.Controls.Add(formMainDischarged);
            bunifuShadowPanel3.Show();
            formMainDischarged.tabItemDischarged_Click();
        }

        private void tabItemRole_Click(object sender, EventArgs e)
        {
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainRole formMainRole = new FormMainRole();
            bunifuShadowPanel3.Controls.Add(formMainRole);
            bunifuShadowPanel3.Show();
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
            bunifuShadowPanel3.Hide();
            bunifuShadowPanel3.Controls.Clear();
            FormMainReport formMainReport = new FormMainReport();
            bunifuShadowPanel3.Controls.Add(formMainReport);
            bunifuShadowPanel3.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Creating a list of tuples
            List<Tuple<int, int>> indexlist = new List<Tuple<int, int>>();

            // Adding tuples to the list
            indexlist.Add(Tuple.Create(15, 83));
            indexlist.Add(Tuple.Create(183, 83));
            indexlist.Add(Tuple.Create(15, 139));
            indexlist.Add(Tuple.Create(138, 139));
            indexlist.Add(Tuple.Create(15, 196));
            indexlist.Add(Tuple.Create(138, 196));
            indexlist.Add(Tuple.Create(15, 253));
            indexlist.Add(Tuple.Create(138, 253));
            indexlist.Add(Tuple.Create(15, 305));
            indexlist.Add(Tuple.Create(138, 305));
            indexlist.Add(Tuple.Create(15, 335));
            indexlist.Add(Tuple.Create(143, 354));
            indexlist.Add(Tuple.Create(15, 405));
            indexlist.Add(Tuple.Create(138, 405));
            indexlist.Add(Tuple.Create(18, 454));
            indexlist.Add(Tuple.Create(139, 454));
            indexlist.Add(Tuple.Create(14, 501));
            indexlist.Add(Tuple.Create(141, 501));
            indexlist.Add(Tuple.Create(17, 547));
            indexlist.Add(Tuple.Create(143, 550));
            indexlist.Add(Tuple.Create(75, 602));
            FormMainPatient formMainPatient = new FormMainPatient(loginStaff);
            bunifuShadowPanel3.Controls.Add(formMainPatient);
            formMainPatient.tabItemPatient();
            GrantRole();
        }
        private void GrantRole()
        {
            // Creating a list of tuples
            List<Tuple<int, int>> indexlist = new List<Tuple<int, int>>();

            // Adding tuples to the list
            indexlist.Add(Tuple.Create(15, 83));
            indexlist.Add(Tuple.Create(138, 83));
            indexlist.Add(Tuple.Create(15, 139));
            indexlist.Add(Tuple.Create(138, 139));
            indexlist.Add(Tuple.Create(15, 196));
            indexlist.Add(Tuple.Create(138, 196));
            indexlist.Add(Tuple.Create(15, 253));
            indexlist.Add(Tuple.Create(138, 253));
            indexlist.Add(Tuple.Create(15, 305));
            indexlist.Add(Tuple.Create(138, 305));
            indexlist.Add(Tuple.Create(15, 355));
            indexlist.Add(Tuple.Create(143, 354));
            indexlist.Add(Tuple.Create(15, 405));
            indexlist.Add(Tuple.Create(138, 405));
            indexlist.Add(Tuple.Create(18, 454));
            indexlist.Add(Tuple.Create(139, 454));
            indexlist.Add(Tuple.Create(14, 501));
            indexlist.Add(Tuple.Create(141, 501));
            indexlist.Add(Tuple.Create(17, 547));
            indexlist.Add(Tuple.Create(143, 550));
            indexlist.Add(Tuple.Create(75, 602));

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
                        panel.Location = new Point(indexlist[i].Item1, indexlist[i].Item2);
                    }
                }
            }
        }
       

        private void mouse_Down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_Move(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }
    }
}
    