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
    public partial class FormMainPatient : UserControl
    {
        Staff loginStaff = new Staff();
        public void tabItemPatient()
        {
            refreshDataViewPatient();
        }
        public FormMainPatient()
        {
            InitializeComponent();
        }
        public FormMainPatient( Staff LoginStaff)
        {
            InitializeComponent();
            this.loginStaff = LoginStaff;

        }

        private void bunifuButtonAdd_Click(object sender, EventArgs e)
        {
            // Open patientdetail form for add
            FormPatientDetail patientDetailForm = new FormPatientDetail("add", new Patient());
            patientDetailForm.ShowDialog();

            // Refresh datagridview after add
            refreshDataViewPatient();
        }


        // Phương thức xóa bệnh nhân 
        private void bunifuButtonPatientDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID;

                try
                {
                    // Warning before delete
                    if (MessageBox.Show("Xác nhận xóa bệnh nhân", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        == DialogResult.Yes)
                    {
                        // Get patientid for delete
                        if (int.TryParse(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value.ToString(), out patientID))
                        {
                            Patient.DeletePatient(patientID);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Refresh datagridview after delete
                refreshDataViewPatient();
            }
        }

        // Refresh laij datagridview sau khi thao tac voi benh nhan

        private void refreshDataViewPatient()
        {
            try
            {
                // Get Patient's datatable
                DataTable patientTable = Patient.GetListPatient();

                // Add Vietnamese column's name
                patientTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                patientTable.Columns.Add("Họ tên", typeof(string), "[LASTNAME] + ' ' + [FIRSTNAME]");
                patientTable.Columns.Add("CMND", typeof(string), "[ICN]");
                patientTable.Columns.Add("Giới tính", typeof(string), "IIF([GENDER] = 0, 'Nam', 'Nữ')");
                patientTable.Columns.Add("Ngày sinh", typeof(DateTime), "[BIRTHDAY]");
                patientTable.Columns.Add("Nghề nghiệp", typeof(string), "PROFESSION");
                patientTable.Columns.Add("Địa chỉ", typeof(string), "[ADDRESS]");
                patientTable.Columns.Add("Tiền đặt cọc", typeof(string), "[DEPOSIT]");
                patientTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Ngoại trú', 'Nội trú')");

                // Set data source to dataview for searching
                bunifuDataGridViewPatient.DataSource = patientTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 10; i++)
                {
                    bunifuDataGridViewPatient.Columns[i].Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phuong thuc xoa du lieu cua thanh textbox
        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuTextBoxPatientSearch.Text = "";
            searchPatient();
        }


        //Phuong thuc tim kiem cua thanh textboxserach
        private void bunifuTextBoxPatientSearch_TextChanged(object sender, EventArgs e)
        {
            searchPatient();
        }

        //Phuong thuc bat dau tim kiem sau khi nhan phim enter
        private void bunifuTextBoxPatientSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchPatient();
            }
        }


        //Thuat toan tim kiem cua Patient
        private void searchPatient()
        {
            // Not search it search string is empty
            if (bunifuTextBoxPatientSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewPatient.DataSource).RowFilter = "[Họ tên] LIKE '*" + bunifuTextBoxPatientSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxPatientSearch.Text.Trim() + "*'"
                                                                + "OR [CMND] LIKE '*" + bunifuTextBoxPatientSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewPatient.DataSource).RowFilter = "";
            }
        }

        private void bunifuButtonPrescription_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = 10000000;

                FormPrescriptionDetail formPD = new FormPrescriptionDetail(staffID, patientID);
                formPD.ShowDialog();
            }
        }

        private void bunifuButtonHealthFile_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                int state = Patient.GetPatient(patientID).State;

                if (state == 1)
                {
                    if (!HeathFile.DidPatientHaveHF(patientID))
                    {
                        FormHFDetail formHFD = new FormHFDetail(patientID);
                        formHFD.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Bệnh nhân đã có bệnh án", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonHealthMonitor_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                int state = Patient.GetPatient(patientID).State;
                //Current user
                int staffID = loginStaff.StaffID;

                if (state == 1)
                {
                    FormHNDetail formHND = new FormHNDetail(staffID, patientID);
                    formHND.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonPatientExamination_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = loginStaff.StaffID;

                FormECDetail formECD = new FormECDetail(staffID, patientID);
                formECD.LoginStaff = this.loginStaff;
                formECD.ShowDialog();
            }
        }

        private void bunifuButtonHospitalizationCert_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = loginStaff.StaffID;
                if (HospitalizationCertificate.IsPatientHadHC(patientID))
                {
                    MessageBox.Show("Bệnh nhân đã có giấy nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    FormHCDetail formHCD = new FormHCDetail(staffID, patientID);
                    formHCD.ShowDialog();
                }
            }
        }

        private void bunifuButtonDischargeCert_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = loginStaff.StaffID;

                if (HospitalizationCertificate.IsPatientHadHC(patientID))
                {
                    FormDCDetail formDCD = new FormDCDetail(staffID, patientID);
                    formDCD.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonPatientSurgery_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);

                if (Patient.GetPatient(patientID).State == 1)
                {
                    FormSurgicalDetail formSD = new FormSurgicalDetail(patientID);
                    formSD.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện nên không thể thực hiện phẩu thuật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonAssign_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                if (HospitalizationCertificate.IsPatientHadHC(patientID))
                {
                    if (Assignment.IsPatientHadAssignment(patientID))
                    {
                        MessageBox.Show("Bệnh nhân đã được phân công chăm sóc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        FormAssignDetail formAD = new FormAssignDetail(patientID);
                        formAD.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonPatientTest_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = loginStaff.StaffID;

                FormTestDetail formTD = new FormTestDetail(staffID, patientID);
                formTD.ShowDialog();
            }
        }

        private void bunifuButtonPatientMaterial_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                if (Patient.GetPatient(patientID).State == 1)
                {
                    //Current user
                    int staffID = loginStaff.StaffID;

                    Bill newBill = new Bill(Bill.MATERIALBILL, patientID, staffID);
                    FormBillDetail billDetailForm = new FormBillDetail("insert", newBill);
                    billDetailForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bệnh nhân chưa nhập viện nên không được phép mượn vật tư", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonPatientService_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = loginStaff.StaffID;

                Bill newBill = new Bill(Bill.SERVICEBILL, patientID, staffID);
                FormBillDetail billDetailForm = new FormBillDetail("insert", newBill);
                billDetailForm.ShowDialog();
            }
        }

        private void bunifuDataGridViewPatient_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                // Get patient for edit
                Patient PatientDetail = Patient.GetPatient(Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value.ToString()));

                // Open patientdetail form for edit
                FormPatientDetail patientDetailForm = new FormPatientDetail("edit", PatientDetail);
                patientDetailForm.ShowDialog();

                // Refresh datagridview after edit
                refreshDataViewPatient();
            }
        }

        private void bunifuButtonHIC_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                if (HIC.CheckHIC(patientID))
                {
                    HIC newHIC = HIC.GetPatientHIC(patientID);
                    FormHICDetail formHICD = new FormHICDetail(newHIC, "edit");

                    formHICD.ShowDialog();
                }
                else
                {
                    FormHICDetail formHICD = new FormHICDetail(patientID);

                    formHICD.ShowDialog();
                }
            }
        }

        private void bunifuButtonPatientPay_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int state = Patient.GetPatient(Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value)).State;
                if (state == 1)
                {
                    FormPayment paymentform = new FormPayment();
                    paymentform.patient = Patient.GetPatient(Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value));
                    paymentform.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Chỉ thanh toán viện phí cho bệnh nhân nhập viện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void bunifuButtonPatientEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                // Get patient for edit
                Patient PatientDetail = Patient.GetPatient(Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value.ToString()));

                // Open patientdetail form for edit
                FormPatientDetail patientDetailForm = new FormPatientDetail("edit", PatientDetail);
                patientDetailForm.ShowDialog();

                // Refresh datagridview after edit
                refreshDataViewPatient();
            }
        }
    }
}
