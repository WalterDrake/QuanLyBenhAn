using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DO_AN_CUA_HAN.Model;

namespace DO_AN_CUA_HAN.View
{
    public partial class FormAssignDetail : Form
    {
        public Assignment AssignDetail { get; set; }
        public String UserAction { get; set; }
        private static List<Staff> listStaff = new List<Staff>();
        private static List<AssignmentDetail> listAD = new List<AssignmentDetail>();
        public FormAssignDetail()
        {
            InitializeComponent();
        }
        //This constructor for insert feature
        public FormAssignDetail(int patientID)
        {
            InitializeComponent();
            SetADForInsert(patientID);
        }
        //This contructor for update feature
        public FormAssignDetail(Assignment assignDetail, String userAction)
        {
            InitializeComponent();
            this.AssignDetail = assignDetail;
            this.UserAction = userAction;
            SetADForUpdate(assignDetail);
        }
        private void SetADForUpdate(Assignment assignDetail)
        {
            textBoxAssignID.Text = assignDetail.AssignID.ToString();
            textBoxPatientID.Text = assignDetail.PatientID.ToString();
            dateCreate.Value = assignDetail.Date;
            dateDischarge.Value = assignDetail.DischargedDate;
            dateHospitalize.Value = assignDetail.HospitalizateDate;

            dateHospitalize.Enabled = false;

            DataTable dtStaff = Staff.GetListStaff();
            for (int i = 0; i < dtStaff.Rows.Count; i++)
            {
                String staffName = dtStaff.Rows[i][6].ToString() + " " + dtStaff.Rows[i][5].ToString();
                Staff newStaff = Staff.GetStaff(Convert.ToInt32(dtStaff.Rows[i][0]));
                listStaff.Add(newStaff);
                listBoxSystemStaff.Items.Add(staffName);
            }
            listBoxSystemStaff.SelectedIndex = 0;

            DataTable dtAD = AssignmentDetail.GetListAssignmentDetails(assignDetail.AssignID);
            for (int i = 0; i < dtAD.Rows.Count; i++)
            {
                String staffName = dtAD.Rows[i][2].ToString() + " " + dtAD.Rows[i][3].ToString();
                AssignmentDetail newAD = new AssignmentDetail();
                newAD.AssignID = Convert.ToInt32(dtAD.Rows[i][0]);
                newAD.StaffID = Convert.ToInt32(dtAD.Rows[i][1]);
                listAD.Add(newAD);
                listBoxCurrentStaff.Items.Add(staffName);
            }
            if (listBoxCurrentStaff.Items.Count > 0)
                listBoxCurrentStaff.SelectedIndex = 0;
        }
        private void SetADForInsert(int patientID)
        {
            HospitalizationCertificate newHC = HospitalizationCertificate.GetHC(Convert.ToDecimal(patientID));
            textBoxPatientID.Text = patientID.ToString();
            dateDischarge.Value = DateTime.Today;
            dateCreate.Value = DateTime.Today;
            dateHospitalize.Value = newHC.Date;
            dateHospitalize.Enabled = false;
            dateCreate.Enabled = false;

            DataTable dtStaff = Staff.GetListStaff();
            for (int i = 0; i < dtStaff.Rows.Count; i++)
            {
                String staffName = dtStaff.Rows[i][6].ToString() + " " + dtStaff.Rows[i][5].ToString();
                Staff newStaff = Staff.GetStaff(Convert.ToInt32(dtStaff.Rows[i][0]));
                listStaff.Add(newStaff);
                listBoxSystemStaff.Items.Add(staffName);
            }
            listBoxSystemStaff.SelectedIndex = 0;
        }
        private void buttonRemoveFunction_Click(object sender, EventArgs e)
        {
            if (listBoxCurrentStaff.SelectedIndex != -1)
            {
                int selectedStaff = listBoxCurrentStaff.SelectedIndex;
                listAD.RemoveAt(selectedStaff);
                listBoxCurrentStaff.Items.RemoveAt(selectedStaff);
                listBoxCurrentStaff.SelectedIndex = listBoxCurrentStaff.Items.Count - 1;
            }
        }

        private void buttonInsertFunction_Click(object sender, EventArgs e)
        {
            int selectedStaff = listBoxSystemStaff.SelectedIndex;
            if (CheckStaffInAssign(listStaff[selectedStaff].StaffID))
            {
                MessageBox.Show("Nhân viên đã có trong danh sách phân công chăm sóc bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AssignmentDetail newAD = new AssignmentDetail(0, listStaff[selectedStaff].StaffID);
                listAD.Add(newAD);
                listBoxCurrentStaff.Items.Add(listBoxSystemStaff.Items[selectedStaff].ToString());
                listBoxCurrentStaff.SelectedIndex = 0;
            }
        }
        private Boolean CheckStaffInAssign(int staffID)
        {
            for (int i = 0; i < listAD.Count; i++)
            {
                if (staffID == listAD[i].StaffID)
                    return true;
            }
            return false;
        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (listBoxCurrentStaff.Items.Count > 0)
            {
                if (dateDischarge.Value > dateHospitalize.Value)
                {
                    try
                    {
                        Assignment newAssign = new Assignment();
                        newAssign.PatientID = Convert.ToInt32(textBoxPatientID.Text);
                        newAssign.DischargedDate = dateDischarge.Value;
                        newAssign.HospitalizateDate = dateHospitalize.Value;
                        newAssign.Date = dateCreate.Value;
                        if (this.UserAction == "edit")
                        {
                            newAssign.AssignID = Convert.ToInt32(textBoxAssignID.Text);
                            DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bản phân công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (Assignment.UpdateAssignment(newAssign) > 0)
                                {
                                    AssignmentDetail.DeleteAssignmentDetails(newAssign.AssignID);
                                    for (int i = 0; i < listAD.Count; i++)
                                    {
                                        AssignmentDetail newAD = listAD[i];
                                        newAD.AssignID = newAssign.AssignID;
                                        AssignmentDetail.InsertAssignmentDetails(newAD);
                                    }
                                    listAD.Clear();
                                    MessageBox.Show("Cập nhập thông tin bảng phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        else
                        {
                            newAssign.AssignID = 0;
                            if (Assignment.InsertAssignment(newAssign) > 0)
                            {
                                int curAssignID = Assignment.GetCurrentIdentity();
                                for (int i = 0; i < listAD.Count; i++)
                                {
                                    listAD[i].AssignID = curAssignID;
                                    AssignmentDetail.InsertAssignmentDetails(listAD[i]);
                                }
                                MessageBox.Show("Thêm bảng phân công thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    listAD.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ngày xuất viện phải sau ngày nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Chưa có nhân viên nào tham gia phân công chăm sóc bệnh nhân", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAssignDetail_Load(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxAssignID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
