using Bunifu.UI.WinForms;
using DevComponents.DotNetBar.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUA_HAN.View
{
    public partial class FormDatabase : Form
    {
        private SqlConnectionStringBuilder connectionBuilder;
        public FormDatabase()
        {
            InitializeComponent();
            connectionBuilder = new SqlConnectionStringBuilder();

        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(bunifuTextBoxUsername.Text))
            {
                bunifuSnackbar1.Show(this, "Nhập tài khoản", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);

            }
            if (string.IsNullOrEmpty(bunifuTextBoxPassword.Text))
            {
                bunifuSnackbar1.Show(this, "Nhập mật khẩu", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Warning, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);

            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings["Hospital.Properties.Settings.eHospital"].ConnectionString = getConnectionString();
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

            bunifuSnackbar1.Show(this, "Khởi động lại chương trình để kết nối mới có hiệu lực!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
            this.Close();
        }
        private string getConnectionString() //
        {
                connectionBuilder.IntegratedSecurity = true;
                connectionBuilder.UserID = bunifuTextBoxUsername.Text;
                connectionBuilder.Password = bunifuTextBoxPassword.Text;
            return connectionBuilder.ConnectionString;
        }
    }
}
