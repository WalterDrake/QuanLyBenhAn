﻿using DevComponents.DotNetBar.Validator;
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
    public partial class FormDepartmentDetail : Form
    {
        public Department DepartmentDetail { get; set; }
        public String UserAction { get; set; }
        public FormDepartmentDetail()
        {
            InitializeComponent();
        }
        public FormDepartmentDetail(Department departmentDetail, String userAction)
        {
            InitializeComponent();
            this.DepartmentDetail = departmentDetail;
            this.UserAction = userAction;
            if (this.UserAction == "edit")
                SetDepartmentDetail(departmentDetail);
        }
        private void SetDepartmentDetail(Department departmentDetail)
        {
            bunifuTextBoxDepartmentID.Text = departmentDetail.DepartmentID.ToString();
            bunifuTextBoxDepartmentName.Text = departmentDetail.DepartmentName;
        }

        private void bunifuButtonOK_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(bunifuTextBoxDepartmentName.Text))
            {
                bunifuSnackbar1.Show(this, "Thiếu tên phòng ban", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);

            }
            try
            {
                if (UserAction == "edit")
                {
                    DepartmentDetail.DepartmentName = bunifuTextBoxDepartmentName.Text;
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin phòng ban", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Department.UpdateDepartment(DepartmentDetail) > 0)
                        bunifuSnackbar1.Show(this, "Cập nhật thông tin phòng ban thành công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                    }

                }
                else
                {
                    Department newDepartment = new Department(0, bunifuTextBoxDepartmentName.Text);
                    if (Department.InsertDepartment(newDepartment) > 0)
                    bunifuSnackbar1.Show(this, "Thêm phòng ban thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);

                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);

            }

            this.Close();
        }

        private void bunifuButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
