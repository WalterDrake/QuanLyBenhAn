using DO_AN_CUA_HAN.Chart;
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
    public partial class FormMainReport : UserControl
    {
        public FormMainReport()
        {
            InitializeComponent();
        }

        private void bunifuButtonPatient_Click(object sender, EventArgs e)
        {
            FormBarChart chart = new FormBarChart();
            chart.Show();
        }

        private void bunifuButtonMaterial_Click(object sender, EventArgs e)
        {
            FormBubbleChart chart = new FormBubbleChart();
            chart.Show();
        }

        private void bunifuButtonStaff_Click(object sender, EventArgs e)
        {
            FormHorizontal chart = new FormHorizontal();
            chart.Show();
        }

        private void bunifuButtonAmount_Click(object sender, EventArgs e)
        {
            FormLineChart chart = new FormLineChart();
            chart.Show();
        }

        private void bunifuButtonReportPrint_Click(object sender, EventArgs e)
        {
            /*FormReport reportForm = new FormReport();

            switch (comboBoxStatisticsType.SelectedIndex)
            {
                case 0:
                    reportForm.ReportType = "REVENUEBYDAY";
                    break;
                case 1:
                    reportForm.ReportType = "REVENUEBYMONTH";
                    break;
                case 2:
                    reportForm.ReportType = "REVENUEBYYEAR";
                    break;
                default:
                    MessageBox.Show("Chọn loại thống kê!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            reportForm.DATEFROM = dateTimeInputStatisticsDateFrom.Value;
            reportForm.DATETO = dateTimeInputStatisticsDateTo.Value;
            reportForm.Show();*/
        }
    }
}
