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
using Bunifu.UI.WinForms;

namespace DO_AN_CUA_HAN.View
{
    public partial class FormServiceDetail : Form
    {
        public Service ServiceDetail { get; set; }
        public String UserAction { get; set; }
        public FormServiceDetail()
        {
            InitializeComponent();
        }
        public FormServiceDetail(Service serviceDetail, String userAction)
        {
            InitializeComponent();
            this.ServiceDetail = serviceDetail;
            this.UserAction = userAction;
            if (this.UserAction == "edit")
                SetServiceDetail(serviceDetail);
        }
        private void SetServiceDetail(Service serviceDetail)
        {
            textBoxServiceID.Text = ServiceDetail.ServiceID.ToString();
            textBoxServiceName.Text = ServiceDetail.ServiceName;
            textBoxPrice.Text = Convert.ToInt64(ServiceDetail.Price).ToString();
        }
        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            /*if (!superValidator1.Validate())
                return;*/
            try
            {
                if (UserAction == "edit")
                {
                    ServiceDetail.ServiceName = textBoxServiceName.Text;
                    ServiceDetail.Price = decimal.Parse(textBoxPrice.Text);
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin dịch vụ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Service.UpdateService(ServiceDetail) > 0)
                            bunifuSnackbar1.Show(this, "Cập nhập dịch vụ thành công thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                    }

                }
                else
                {
                    Service newService = new Service(0, textBoxServiceName.Text, decimal.Parse(textBoxPrice.Text));
                    if (Service.InsertService(newService) > 0)
                        bunifuSnackbar1.Show(this, "Thêm dịch vụ thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                }
            }
            catch
            {
                bunifuSnackbar1.Show(this, "Lỗi dữ liệu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
            }

            this.Close();
        }
    }
}
