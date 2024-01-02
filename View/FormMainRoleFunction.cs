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
    public partial class FormMainRoleFunction : UserControl
    {
        public FormMainRoleFunction()
        {
            InitializeComponent();
        }
        public void tabItemFunction_Click()
        {
            refreshDataViewFunction();
        }

        private void bunifuTextBoxRoleFunctionSearch_TextChange(object sender, EventArgs e)
        {
            searchFunction();
        }

        private void bunifuTextBoxRoleFunctionSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchFunction();
            }
        }

        private void bunifubuttonRFDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxRoleFunctionSearch.Text = "";
            searchFunction();
        }

        private void bunifuButtonRFDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRoleFunction.SelectedRows.Count > 0)
            {
                int funtionlID = Convert.ToInt16(bunifuDataGridViewRoleFunction.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa chức năng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (RoleFunction.DeleteFunction(funtionlID) > 0)
                            MessageBox.Show("Xóa chức năng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Chức năng này đang được sử dụng", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                refreshDataViewFunction();
            }
        }

        private void bunifuDataGridViewRoleFunction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewRoleFunction.SelectedRows.Count > 0)
            {
                int funtionlID = Convert.ToInt16(bunifuDataGridViewRoleFunction.SelectedRows[0].Cells[0].Value);
                RoleFunction updateFunction = RoleFunction.GetFunction(funtionlID);
                FormRoleFunctionDetail formRFD = new FormRoleFunctionDetail(updateFunction, "edit");
                formRFD.ShowDialog();

                refreshDataViewFunction();
            }
        }

        private void bunifuButtonRFEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewRoleFunction.SelectedRows.Count > 0)
            {
                int funtionlID = Convert.ToInt16(bunifuDataGridViewRoleFunction.SelectedRows[0].Cells[0].Value);
                RoleFunction updateFunction = RoleFunction.GetFunction(funtionlID);
                FormRoleFunctionDetail formRFD = new FormRoleFunctionDetail(updateFunction, "edit");
                formRFD.ShowDialog();

                refreshDataViewFunction();
            }
        }

        private void bunifuButtonRFAdd_Click(object sender, EventArgs e)
        {
            FormRoleFunctionDetail formRFD = new FormRoleFunctionDetail();
            formRFD.ShowDialog();

            refreshDataViewFunction();
        }
        //Refresh datagridview in function tab
        private void refreshDataViewFunction()
        {
            try
            {
                // Get function's datatable
                DataTable functionTable = RoleFunction.GetListFunction();

                // Add Vietnamese column's name
                functionTable.Columns.Add("Mã chức năng", typeof(string), "[FUNCTIONID]");
                functionTable.Columns.Add("Tên chức năng", typeof(string), "[FUNCTIONNAME]");
                functionTable.Columns.Add("Nút kích hoạt", typeof(string), "[BUTTON]");
                // Set data source to dataview for searching
                bunifuDataGridViewRoleFunction.DataSource = functionTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 3; i++)
                {
                    bunifuDataGridViewRoleFunction.Columns[i].Visible = false;
                }

                //Add auto complete datasource to textbox
                bunifuTextBoxRoleFunctionSearch.AutoCompleteCustomSource.Clear();
                for (int i = 0; i < functionTable.Rows.Count; i++)
                {
                    String strFunctionName = functionTable.Rows[i][1].ToString();
                    bunifuTextBoxRoleFunctionSearch.AutoCompleteCustomSource.Add(strFunctionName);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //Search in datagridview
        private void searchFunction()
        {
            // Not search it search string is empty
            if (bunifuTextBoxRoleFunctionSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewRoleFunction.DataSource).RowFilter = "[Mã chức năng] LIKE '*" + bunifuTextBoxRoleFunctionSearch.Text.Trim() + "*'"
                                                                + "OR [Tên chức năng] LIKE '*" + bunifuTextBoxRoleFunctionSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewRoleFunction.DataSource).RowFilter = "";
            }
        }
    }
}
