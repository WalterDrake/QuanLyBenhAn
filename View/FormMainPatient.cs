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
        public FormMainPatient()
        {
            InitializeComponent();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            //Hàm này dùng để hiện ra thông tin cái form FormPatientDetail
            // và show Dialog()
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
            if(e.KeyCode == Keys.Enter)
            {
                searchPatient();
            }
        }


        //Thuat toan tim kiem cua Patient
        private void searchPatient()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = bunifuDataGridViewPatient.DataSource;
            string filterExpression;
            //Neu cai o text box chua nhap
            if (bunifuTextBoxPatientSearch.Text !="")
            {
                // O day dung setfilerstring
               

                 filterExpression = "[Họ tên] LIKE '*" + bunifuDataGridViewPatient.Text.Trim() + "*'"
                        + " OR [Mã bệnh nhân] LIKE '*" + bunifuDataGridViewPatient.Text.Trim() + "*'"
                        + " OR [CMND] LIKE '*" + bunifuDataGridViewPatient.Text.Trim() + "*'";
                bindingSource.Filter = filterExpression;

                // Gán lại BindingSource cho BunifuDataGridView
                bunifuDataGridViewPatient.DataSource = bindingSource;
            }
            else
            {
                filterExpression = "";
                bindingSource.Filter = filterExpression;

                // Gán lại BindingSource cho BunifuDataGridView
                bunifuDataGridViewPatient.DataSource = bindingSource;
            }
        }

        private void bunifuButtonPrescription_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewPatient.SelectedRows.Count > 0)
            {
                int patientID = Convert.ToInt32(bunifuDataGridViewPatient.SelectedRows[0].Cells[0].Value);
                //Current user
                int staffID = 10000000;

                // Xuat file Prescription
                /*FormPrescriptionDetail formPD = new FormPrescriptionDetail(staffID, patientID);
                formPD.ShowDialog();*/
            }
        }
    }
}
