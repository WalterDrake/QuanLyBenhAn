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
    public partial class FormMainEC : UserControl
    {
        Staff loginStaffs = new Staff();

        public FormMainEC()
        {
            InitializeComponent();
        }
        public void tabItemExamination_Click()
        {
            refreshDataViewExamination();
        }

        public FormMainEC(Staff loginStaff)
        {
            InitializeComponent();
            this.loginStaffs = loginStaff;
            DataTable table = ExaminationCertificate.GetListEC();
            bunifuDataGridViewEC.DataSource = table;

        }
        private void bunifuButtonECEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewEC.SelectedRows.Count > 0)
            {
                int ecID = Convert.ToInt32(bunifuDataGridViewEC.SelectedRows[0].Cells[0].Value);
                ExaminationCertificate updateEC = ExaminationCertificate.GetEC(ecID);
                FormECDetail formECD = new FormECDetail(updateEC, "edit");
                formECD.ShowDialog();

                refreshDataViewExamination();
            }
        }
        private void bunifuButtonECPrint_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewEC.SelectedRows.Count > 0)
            {
                ExaminationCertificate ECPrint = ExaminationCertificate.GetEC(Convert.ToInt32(bunifuDataGridViewEC.SelectedRows[0].Cells[0].Value));

                FormReport reportForm = new FormReport();

                reportForm.ReportType = "EC";
                reportForm.ObjectID = ECPrint.ECID;
                reportForm.Show();
            }
        }

        private void bunifubuttonECDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxECSearch.Text = "";
            searchExamination();
        }
        private void bunifuButtonECResult_Click(object sender, EventArgs e)
        {
            try
            {

                if (bunifuDataGridViewEC.SelectedRows.Count > 0)
                {

                    int ecID = Convert.ToInt32(bunifuDataGridViewEC.SelectedRows[0].Cells[0].Value);
                    ExaminationCertificate updateEC = ExaminationCertificate.GetEC(ecID);
                    //Current user
                    int staffID = loginStaffs.StaffID;
                    FormECDetail formECD = new FormECDetail(updateEC, "updateResult", staffID);
                    formECD.ShowDialog();

                    refreshDataViewExamination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuButtonECDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewEC.SelectedRows.Count > 0)
            {
                int ecID = Convert.ToInt32(bunifuDataGridViewEC.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phiếu khám bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (ExaminationCertificate.GetEC(ecID).State != 1)
                    {
                        if (ExaminationCertificate.DeleteEC(ecID) > 0)
                            MessageBox.Show("Xóa phiếu khám bệnh thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa phiếu khám bệnh này", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                refreshDataViewExamination();
            }
        }

        private void searchExamination()
        {
            try
            {

                // Not search it search string is empty
                if (!string.IsNullOrEmpty(bunifuTextBoxECSearch.Text))
                {
                    ((DataView)bunifuDataGridViewEC.DataSource).RowFilter = "[Mã phiếu khám bệnh] LIKE '*" + bunifuTextBoxECSearch.Text.Trim() + "*' OR "
                                                         + "[Mã bệnh nhân] LIKE '*" + bunifuTextBoxECSearch.Text.Trim() + "*' OR "
                                                         + "[Mã nhân viên] LIKE '*" + bunifuTextBoxECSearch.Text.Trim() + "*' OR "
                                                         + "[Trạng thái] LIKE '*" + bunifuTextBoxECSearch.Text.Trim() + "*'";
                }
                else
                {
                    ((DataView)bunifuDataGridViewEC.DataSource).RowFilter = "";
                }
            }
            catch
            {
                MessageBox.Show("Loiiiii");
            }
        }

        private void textBoxExaminationSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchExamination();
            }
        }

        private void bunifuDataGridViewExamination_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewEC.SelectedRows.Count > 0)
            {
                int ecID = Convert.ToInt32(bunifuDataGridViewEC.SelectedRows[0].Cells[0].Value);
                ExaminationCertificate updateEC = ExaminationCertificate.GetEC(ecID);
                FormECDetail formECD = new FormECDetail(updateEC, "edit");
                formECD.ShowDialog();

                refreshDataViewExamination();
            }
        }

        private void refreshDataViewExamination()
        {
            try
            {
                // Get Examination's datatable
                DataTable examinationTable = ExaminationCertificate.GetListEC();

                // Add Vietnamese column's name
                examinationTable.Columns.Add("Mã phiếu khám bệnh", typeof(string), "[ECID]");
                examinationTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                examinationTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                examinationTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                examinationTable.Columns.Add("Kết quả", typeof(string), "[RESULT]");
                examinationTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa xác nhận', 'Đã xác nhận')");
                // Set data source to dataview for searching
                bunifuDataGridViewEC.DataSource = examinationTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 6; i++)
                {
                    bunifuDataGridViewEC.Columns[i].Visible = false;
                }

            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuTextBoxECSearch_TextChanged(object sender, EventArgs e)
        {
            searchExamination();
        }
    }
}
