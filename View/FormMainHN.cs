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
    public partial class FormMainHN : UserControl
    {
        public FormMainHN()
        {
            InitializeComponent();
        }
        public void tabItemMonitor_Click()
        {
            refreshDataViewHeathNote();
        }
        //Refresh datagridview in monitor tab
        private void refreshDataViewHeathNote()
        {
            try
            {
                // Get heath note's datatable
                DataTable heathNoteTable = HeathMonitoringNote.GetListHN();

                // Add Vietnamese column's name
                heathNoteTable.Columns.Add("Mã phiếu theo dõi", typeof(string), "[HNID]");
                heathNoteTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");
                heathNoteTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                heathNoteTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                heathNoteTable.Columns.Add("Cân nặng", typeof(string), "[WEIGHT]");
                heathNoteTable.Columns.Add("Huyết áp", typeof(string), "[BLOODPRESSURE]");
                heathNoteTable.Columns.Add("Tình trạng bệnh nhân", typeof(string), "[PATIENTSTATE]");
                // Set data source to dataview for searching
                bunifuDataGridViewHN.DataSource = heathNoteTable.DefaultView;

                // Hide English columns'name
                for (int i = 0; i < 7; i++)
                {
                    bunifuDataGridViewHN.Columns[i].Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Search in datagridview
        private void searchHeathNote()
        {
            // Not search it search string is empty
            if (bunifuTextBoxHNSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewHN.DataSource).RowFilter = "[Mã bệnh nhân] LIKE '*" + bunifuTextBoxHNSearch.Text.Trim() + "*'"
                                                                + "OR [Mã phiếu theo dõi] LIKE '*" + bunifuTextBoxHNSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewHN.DataSource).RowFilter = "";
            }
        }

        private void bunifuTextBoxHNSearch_TextChange(object sender, EventArgs e)
        {
            searchHeathNote();
        }

        private void bunifuTextBoxHNSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchHeathNote();
            }
        }

        private void bunifubuttonHFDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxHNSearch.Text = "";
            searchHeathNote();
        }

        private void bunifuButtonHNDelete_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHN.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHN.SelectedRows[0].Cells[0].Value);
                DialogResult dialogResult = MessageBox.Show("Xác nhận xóa phiếu theo dõi", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        if (HeathMonitoringNote.DeleteHN(heathNoteID) > 0)
                            MessageBox.Show("Xóa phiếu theo dõi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Không xóa phiếu theo dõi này", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                refreshDataViewHeathNote();
            }
        }

        private void bunifuButtonHNEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewHN.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHN.SelectedRows[0].Cells[0].Value);
                FormHNDetail formHNDetail = new FormHNDetail(HeathMonitoringNote.GetHN(heathNoteID), "edit");
                formHNDetail.ShowDialog();

                refreshDataViewHeathNote();
            }
        }

        private void bunifuDataGridViewHN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (bunifuDataGridViewHN.SelectedRows.Count > 0)
            {
                int heathNoteID = Convert.ToInt32(bunifuDataGridViewHN.SelectedRows[0].Cells[0].Value);
                FormHNDetail formHNDetail = new FormHNDetail(HeathMonitoringNote.GetHN(heathNoteID), "edit");
                formHNDetail.ShowDialog();

                refreshDataViewHeathNote();
            }
        }
    }
}
