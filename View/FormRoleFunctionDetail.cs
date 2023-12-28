using Bunifu.UI.WinForms;
using DevComponents.DotNetBar.Validator;
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
    public partial class FormRoleFunctionDetail : Form
    {
        public RoleFunction Function { get; set; }
        public String UserAction { get; set; }
        public FormRoleFunctionDetail()
        {
            InitializeComponent();
        }
        public FormRoleFunctionDetail(RoleFunction function, String usertAction)
        {
            InitializeComponent();
            this.Function = function;
            this.UserAction = usertAction;
            if (UserAction == "edit")
                SetRoleFunctionDetail(function);
        }
        private void SetRoleFunctionDetail(RoleFunction function)
        {
            bunifuTextBoxFunctionID.Text = function.FunctionID.ToString();
            bunifuTextBoxFunctionName.Text = function.FucntionName;
            bunifuTextBoxButton.Text = function.Button;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBoxFunctionName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên chức năng", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
            if (string.IsNullOrEmpty(bunifuTextBoxButton.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu nút", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }
            try
            {
                if (UserAction == "edit")
                {
                    Function.FucntionName = bunifuTextBoxFunctionName.Text;
                    Function.Button = bunifuTextBoxButton.Text;
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin chức năng này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (RoleFunction.UpdateFunction(Function) > 0)
                            bunifuSnackbar1.Show(this, "Cập nhật chức năng thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }

                }
                else
                {
                    RoleFunction newFunction = new RoleFunction(0, bunifuTextBoxFunctionName.Text, bunifuTextBoxButton.Text);
                    if (RoleFunction.InsertFunction(newFunction) > 0)
                        bunifuSnackbar1.Show(this, "Thêm chức năng thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

            }

            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
