using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar.Validator;
using DO_AN_CUA_HAN.Model;
using System.Windows.Forms.VisualStyles;

namespace DO_AN_CUA_HAN .View
{
    public partial class FormStaffDetail : Form
    {
        // Property to store staffdetail and useraction
        private Staff StaffDetail { get; set; }
        private string UserAction { get; set; }

        // Cannot call default constructor
        public FormStaffDetail()
        {
            InitializeComponent();
        }

        // Constructor with useraction and staffdetail
        public FormStaffDetail(string userAction, Staff staff)
        {
            InitializeComponent();

            // Set useraction and staff
            this.StaffDetail = staff;
            this.UserAction = userAction;

            // Set default gender
            dropDownGender.SelectedIndex = 0;
            dropDownState.SelectedIndex = 0;

            // Get department list and set it to dropDown
            dropDownDepartment.DataSource = Department.GetListDepartment();
            dropDownDepartment.ValueMember = "DEPARTMENTID";
            dropDownDepartment.DisplayMember = "DEPARTMENTNAME";

            // Get major list and set it to dropDown
            dropDownMajor.DataSource = Major.GetListMajor();
            dropDownMajor.ValueMember = "MAJORID";
            dropDownMajor.DisplayMember = "MAJORNAME";

            dropDownRole.DataSource = Role.GetListRole();
            dropDownRole.ValueMember = "ROLEID";
            dropDownRole.DisplayMember = "ROLENAME";

            // If useraction is edit then set staffdetail to staffdetail form
            if ("edit".Equals(userAction))
            {
                setStaffDetail(staff);
            }
            else if ("personalEdit".Equals(userAction))
            {
                SetPersonalDetail(staff);
            }
            else
            {
                textBoxPassword.ReadOnly = true;
                textBoxPasswordCheck.ReadOnly = true;
            }
        }

        // Handle event ok button click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            decimal tempDecimal;

            // If fields is not validated then do nothing
           /* if (!superValidator1.Validate())
            {
                return;
            }*/

            // Set StaffDetail property with value in staffdetail form            
            StaffDetail.DepartmentID = Convert.ToInt32(dropDownDepartment.SelectedValue.ToString());
            StaffDetail.MajorID = Convert.ToInt32(dropDownMajor.SelectedValue.ToString());
            StaffDetail.RoleID = Convert.ToInt32(dropDownRole.SelectedValue.ToString());
            //StaffDetail.Password = textBoxPassword.Text;
            StaffDetail.FirstName = textBoxFirstName.Text;
            StaffDetail.LastName = textBoxLastName.Text;
            StaffDetail.BirthDay = dateBirthday.Value;

            if (Decimal.TryParse(textBoxIdentityCard.Text, out tempDecimal))
            {
                StaffDetail.ICN = Convert.ToDecimal(textBoxIdentityCard.Text);
            }

            if ("Nam".Equals(dropDownGender.SelectedItem.ToString()))
            {
                StaffDetail.Gender = Staff.GENDER_MALE;
            }
            else
            {
                StaffDetail.Gender = Staff.GENDER_FEMALE;
            }

            StaffDetail.Address = textBoxAddress.Text;

            if (dropDownState.SelectedIndex == 0)
            {
                StaffDetail.State = 0;
            }
            else
            {
                StaffDetail.State = 1;
            }

            // Process useraction
            try
            {
                // If useraction is add then insert to database else update
                if ("add".Equals(this.UserAction))
                {
                    StaffDetail.Password = StaffDetail.ICN.ToString();
                    Staff.InsertStaff(StaffDetail);
                }
                else if ("edit".Equals(this.UserAction))
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Staff.UpdateStaff(StaffDetail);
                    }
                }
                else if ("personalEdit".Equals(this.UserAction))
                {
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin tài khoản cá nhân", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (textBoxPassword.Text != "")
                        {
                            StaffDetail.Password = textBoxPassword.Text;
                        }
                        Staff.UpdateStaff(StaffDetail);
                    }
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
            }

            // After process then close this form
            this.Close();
        }

        // Close form when click close button
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetPersonalDetail(Staff staff)
        {
            this.StaffDetail = staff;
            textBoxStaffID.Text = staff.StaffID.ToString();
            textBoxFirstName.Text = staff.FirstName;
            textBoxLastName.Text = staff.LastName;
            dateBirthday.Value = staff.BirthDay;
            if (staff.ICN != 0)
            {
                textBoxIdentityCard.Text = staff.ICN.ToString();
            }

            if (Staff.GENDER_MALE.Equals(staff.Gender))
            {
                dropDownGender.SelectedIndex = Staff.GENDER_MALE;
            }
            else
            {
                dropDownGender.SelectedIndex = Staff.GENDER_FEMALE;
            }

            textBoxAddress.Text = staff.Address;

            if (staff.State == 0)
            {
                dropDownState.Text = "Đã thôi việc";
            }
            else
            {
                dropDownState.Text = "Đang làm việc";
            }

            dropDownDepartment.SelectedValue = (object)staff.DepartmentID;
            dropDownMajor.SelectedValue = (object)staff.MajorID;
            dropDownRole.SelectedValue = (object)staff.RoleID;

            dropDownDepartment.Enabled = false;
            dropDownMajor.Enabled = false;
            dropDownRole.Enabled = false;
            dropDownState.Enabled = false;
            textBoxFirstName.ReadOnly = true;
            textBoxLastName.ReadOnly = true;
            textBoxIdentityCard.ReadOnly = true;
            dropDownGender.Enabled = false;
            dateBirthday.Enabled = false;
        }
        // Set staffdetail to staffdetail form
        public void setStaffDetail(Staff staff)
        {
            this.StaffDetail = staff;
            textBoxStaffID.Text = staff.StaffID.ToString();
            textBoxFirstName.Text = staff.FirstName;
            textBoxLastName.Text = staff.LastName;
            dateBirthday.Value = staff.BirthDay;
            if (staff.ICN != 0)
            {
                textBoxIdentityCard.Text = staff.ICN.ToString();
            }

            if (Staff.GENDER_MALE.Equals(staff.Gender))
            {
                dropDownGender.SelectedIndex = Staff.GENDER_MALE;
            }
            else
            {
                dropDownGender.SelectedIndex = Staff.GENDER_FEMALE;
            }

            textBoxAddress.Text = staff.Address;

            if (staff.State == 0)
            {
                dropDownState.Text = "Đã thôi việc";
            }
            else
            {
                dropDownState.Text = "Đang làm việc";
            }

            dropDownDepartment.SelectedValue = (object)staff.DepartmentID;
            dropDownMajor.SelectedValue = (object)staff.MajorID;
            dropDownRole.SelectedValue = (object)staff.RoleID;

            textBoxPassword.ReadOnly = true;
            textBoxPasswordCheck.ReadOnly = true;


        }
    }
}
