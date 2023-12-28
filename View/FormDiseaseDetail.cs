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
    public partial class FormDiseaseDetail : Form
    {
        public Disease DiseaseDetail { get; set; }
        public String UserAction { get; set; }
        public FormDiseaseDetail()
        {
            InitializeComponent();
        }
        public FormDiseaseDetail(Disease diseaseDetail, String usertAction)
        {
            InitializeComponent();
            this.DiseaseDetail = diseaseDetail;
            this.UserAction = usertAction;
            if (this.UserAction == "edit")
                SetDiseaseDetail(diseaseDetail);
        }
        public void SetDiseaseDetail(Disease diseaseDetail)
        {
            textBoxDiseaseID.Text = diseaseDetail.DiseaseID.ToString();
            textBoxDiseaseName.Text = diseaseDetail.DiseaseName;
            textBoxDiseaseSymptom.Text = diseaseDetail.Symptom;
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
                if (this.UserAction == "edit")
                {
                    DiseaseDetail.DiseaseName = textBoxDiseaseName.Text;
                    DiseaseDetail.Symptom = textBoxDiseaseSymptom.Text;
                    DialogResult dialogResult = MessageBox.Show("Xác nhận cập nhập thông tin bệnh", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (Disease.UpdateDisease(DiseaseDetail) > 0)
                        {
                            bunifuSnackbar1.Show(this, "Cập nhập thông tin bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                        }
                    }
                }
                else
                {
                    Disease newDisease = new Disease(0, textBoxDiseaseName.Text, textBoxDiseaseSymptom.Text);
                    if (Disease.InsertDisease(newDisease) > 0)
                    {
                        bunifuSnackbar1.Show(this, "Thêm bệnh thành công", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Success, 1000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopLeft);
                    }
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
