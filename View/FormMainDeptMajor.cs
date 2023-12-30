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
    public partial class FormMainDeptMajor : UserControl
    {
        public FormMainDeptMajor()
        {
            InitializeComponent();
        }
        public void tabItemDeptMajor_Click()
        {
            refreshDataViewDepartment();
            refreshDataViewMajor();
        }
        private void refreshDataViewDepartment()
        {
            try
            {
                // Get department's datatable
                DataTable departmentTable = Department.GetListDepartment();

                // Add Vietnamese column's name
                departmentTable.Columns.Add("Mã phòng ban", typeof(string), "[DEPARTMENTID]");
                departmentTable.Columns.Add("Tên phòng ban", typeof(string), "[DEPARTMENTNAME]");
                // Set data source to dataview for searching
                bunifuDataGridViewDeparment.DataSource = departmentTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewDeparment.Columns[i].Visible = false;
                }

            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refreshDataViewMajor()
        {
            try
            {
                // Get department's datatable
                DataTable majorTable = Major.GetListMajor();

                // Add Vietnamese column's name
                majorTable.Columns.Add("Mã chuyên ngành", typeof(string), "[MAJORID]");
                majorTable.Columns.Add("Tên chuyên ngành", typeof(string), "[MAJORNAME]");
                // Set data source to dataview for searching
                bunifuDataGridViewMajor.DataSource = majorTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewMajor.Columns[i].Visible = false;
                }

            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bunifuButtonDepartmentDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDeparment.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt16(bunifuDataGridViewDeparment.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phòng ban", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Department.DeleteDepartment(departmentID) > 0)
                            MessageBox.Show("Xóa phòng ban thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("phòng khoa đã hoặc đang có người công tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                refreshDataViewDepartment();
            }
        }

        private void bunifuDataGridViewDeparment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewDeparment.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt16(bunifuDataGridViewDeparment.SelectedRows[0].Cells[0].Value);
                FormDepartmentDetail formDepartmentDetail = new FormDepartmentDetail(Department.GetDepartment(departmentID), "edit");
                formDepartmentDetail.ShowDialog();

                refreshDataViewDepartment();
            }
        }

        private void bunifuButtonDepartmentEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewDeparment.SelectedRows.Count > 0)
            {
                int departmentID = Convert.ToInt16(bunifuDataGridViewDeparment.SelectedRows[0].Cells[0].Value);
                FormDepartmentDetail formDepartmentDetail = new FormDepartmentDetail(Department.GetDepartment(departmentID), "edit");
                formDepartmentDetail.ShowDialog();

                refreshDataViewDepartment();
            }
        }

        private void bunifuButtonDeparmentAdd_Click(object sender, EventArgs e)
        {
            FormDepartmentDetail formDepartmentDetail = new FormDepartmentDetail();
            formDepartmentDetail.ShowDialog();

            refreshDataViewDepartment();
        }

        private void bunifuButtonMajorDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMajor.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt16(bunifuDataGridViewMajor.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa chuyên ngành", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (Major.DeleteMajor(majorID) > 0)
                            MessageBox.Show("Xóa chuyên ngành thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa được chuyên ngành này", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                refreshDataViewMajor();
            }
        }

        private void bunifuDataGridViewMajor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewMajor.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt16(bunifuDataGridViewMajor.SelectedRows[0].Cells[0].Value);
                Major updateMajor = Major.GetMajor(majorID);
                FormMajorDetail formMD = new FormMajorDetail(updateMajor, "edit");
                formMD.ShowDialog();

                refreshDataViewMajor();
            }
        }

        private void bunifuButtonMajorEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewMajor.SelectedRows.Count > 0)
            {
                int majorID = Convert.ToInt16(bunifuDataGridViewMajor.SelectedRows[0].Cells[0].Value);
                Major updateMajor = Major.GetMajor(majorID);
                FormMajorDetail formMD = new FormMajorDetail(updateMajor, "edit");
                formMD.ShowDialog();

                refreshDataViewMajor();
            }
        }

        private void bunifuButtonMajorAdd_Click(object sender, EventArgs e)
        {
            FormMajorDetail formMD = new FormMajorDetail();
            formMD.ShowDialog();

            refreshDataViewMajor();
        }
    }
}
