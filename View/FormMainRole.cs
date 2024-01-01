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
    public partial class FormMainRole : UserControl
    {
        public FormMainRole()
        {
            InitializeComponent();
        }
        public void tabItemRole_Click()
        {
            refreshDataViewRole();
            refreshDataViewRoleDetail();
        }

        private void bunifuButtonMajorAdd_Click(object sender, EventArgs e)
        {
            FormRoleDetail formRoleDetail = new FormRoleDetail();
            formRoleDetail.ShowDialog();

            refreshDataViewRole();
            refreshDataViewRoleDetail();
        }

        private void bunifuButtonMajorDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phân quyền", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (RoleDetail.DeleteRoleDetail(roleID) > 0 && Role.DeleteRole(roleID) > 0)
                            MessageBox.Show("Xóa phân quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                refreshDataViewRole();
                refreshDataViewRoleDetail();
            }
        }

        private void bunifuDataGridViewRole_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                FormRoleDetail formRoleDetail = new FormRoleDetail(Role.GetRole(roleID), "edit");
                formRoleDetail.ShowDialog();

                refreshDataViewRole();
                refreshDataViewRoleDetail();
            }
        }

        private void bunifuButtonMajorEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                FormRoleDetail formRoleDetail = new FormRoleDetail(Role.GetRole(roleID), "edit");
                formRoleDetail.ShowDialog();

                refreshDataViewRole();
                refreshDataViewRoleDetail();
            }
        }
        private void refreshDataViewRole()
        {
            try
            {
                // Get Role's datatable
                DataTable roleTable = Role.GetListRole();

                // Add Vietnamese column's name
                roleTable.Columns.Add("Mã phân quyền", typeof(string), "[ROLEID]");
                roleTable.Columns.Add("Tên phân quyền", typeof(string), "[ROLENAME]");

                // Set data source to dataview for searching
                bunifuDataGridViewRole.DataSource = roleTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 2; i++)
                {
                    bunifuDataGridViewRole.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxPrescriptionSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < roleTable.Rows.Count; i++)
                {
                    String strRoleName = roleTable.Rows[i][1].ToString();
                    bunifuTextBoxPrescriptionSearch.AutoCompleteCustomSource.Add(strRoleName);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void refreshDataViewRoleDetail()
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                try
                {
                    // Get RoleDetail's datatable
                    int roleID = Convert.ToInt16(bunifuDataGridViewRole.Rows[0].Cells[0].Value);
                    DataTable roleDetailTable = RoleDetail.GetListStaffFunction(roleID);

                    // Set data source to dataview for searching
                    bunifuDataGridViewRoleDetail.DataSource = roleDetailTable;
                }
                catch
                {
                    MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Search in datagridview
        private void searchRole()
        {
            // Not search it search string is empty
            if (bunifuTextBoxPrescriptionSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewRole.DataSource).RowFilter = "[Tên phân quyền] LIKE '*" + bunifuTextBoxPrescriptionSearch.Text.Trim() + "*'"
                                                                + "OR [Mã phân quyền] LIKE '*" + bunifuTextBoxPrescriptionSearch.Text.Trim() + "*'";
                refreshDataViewRoleDetail();
            }
            else
            {
                ((DataView)bunifuDataGridViewRole.DataSource).RowFilter = "";
            }
        }

        private void bunifuDataGridViewRole_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewRole.SelectedRows.Count > 0)
            {
                // Get RoleDetail's datatable
                int roleID = Convert.ToInt16(bunifuDataGridViewRole.SelectedRows[0].Cells[0].Value);
                DataTable roleDetailTable = RoleDetail.GetListStaffFunction(roleID);

                // Set data source to dataview for searching
                bunifuDataGridViewRoleDetail.DataSource = roleDetailTable;
            }
        }

        private void bunifuTextBoxPrescriptionSearch_TextChange(object sender, EventArgs e)
        {
            searchRole();
        }

        private void bunifubuttonPrescriptionDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxPrescriptionSearch.Text = "";
            searchRole();
        }

        private void bunifuTextBoxPrescriptionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchRole();
            }
        }
    }
}
