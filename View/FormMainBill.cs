﻿using Bunifu.UI.WinForms;
using DO_AN_CUA_HAN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_CUA_HAN.View
{
    public partial class FormMainBill : UserControl
    {
        public FormMainBill()
        {
            InitializeComponent();
        }
        public void tabPanelBill()
        {
            refreshbunifuDataGridViewBill();
        }
        private void bunifuButtonEdit_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewBill.SelectedRows.Count > 0)
            {
                // Get bill for edit
                Bill billDetail = Bill.GetBill(Convert.ToInt32(bunifuDataGridViewBill.SelectedRows[0].Cells[0].Value.ToString()));

                // Open billdetail form for edit
                FormBillDetail billDetailForm = new FormBillDetail("edit", billDetail);
                billDetailForm.ShowDialog();

                // Refresh datagridview after edit
                refreshbunifuDataGridViewBill();
            }
        }

        private void bunifubuttonBillDeleteSearch_Click(object sender, EventArgs e)
        {
            bunifuTextBoxBillSearch.Text = "";
        }
        private void refreshbunifuDataGridViewBill()
        {
            try
            {
                // Get Bill's datatable
                DataTable billTable = Bill.GetListBill();

                // Add Vietnamese column's name
                billTable.Columns.Add("Mã hóa đơn", typeof(string), "[BILLID]");
                billTable.Columns.Add("Loại hóa đơn", typeof(string), @"IIF([BILLTYPEID] = 100, 'Thuốc',
                                                                            IIF([BILLTYPEID] = 101, 'Dịch vụ', 'Đồ dùng'))");
                billTable.Columns.Add("Họ tên bệnh nhân", typeof(string), "[PATIENTLASTNAME] + ' ' + [PATIENTFIRSTNAME]");
                billTable.Columns.Add("Ngày lập", typeof(DateTime), "[DATE]");
                billTable.Columns.Add("Tổng tiền", typeof(decimal), "[TOTALPRICE]");
                billTable.Columns.Add("Trạng thái", typeof(string), "IIF([STATE] = 0, 'Chưa thanh toán', 'Đã thanh toán')");
                billTable.Columns.Add("Mã nhân viên", typeof(string), "[STAFFID]");
                billTable.Columns.Add("Họ tên nhân viên", typeof(string), "[STAFFLASTNAME] + ' ' + [STAFFFIRSTNAME]");
                billTable.Columns.Add("Mã bệnh nhân", typeof(string), "[PATIENTID]");

                // Set data source to dataview for searching
                bunifuDataGridViewBill.DataSource = billTable.DefaultView;

                //Hide English columns'name
                for (int i = 0; i < 12; i++)
                {
                    bunifuDataGridViewBill.Columns[i].Visible = false;
                }
            }
            catch (SqlException exception)
            {
                bunifuSnackbar1.Show(Form.ActiveForm,exception.Message, Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, "Thông báo", Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                
            }
        }

        private void bunifuTextBoxBillSearch_TextChange(object sender, EventArgs e)
        {
            searchBill();
        }

        private void bunifuTextBoxBillSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchBill();
            }
        }
        private void searchBill()
        {
            // Not search it search string is empty
            if (bunifuTextBoxBillSearch.Text != "")
            {
                // Search with RowFilter
                ((DataView)bunifuDataGridViewBill.DataSource).RowFilter = "[Họ tên bệnh nhân] LIKE '*" + bunifuTextBoxBillSearch.Text.Trim() + "*'"
                                                                + "OR [Mã bệnh nhân] LIKE '*" + bunifuTextBoxBillSearch.Text.Trim() + "*'"
                                                                + "OR [Họ tên nhân viên] LIKE '*" + bunifuTextBoxBillSearch.Text.Trim() + "*'"
                                                                + "OR [Mã nhân viên] LIKE '*" + bunifuTextBoxBillSearch.Text.Trim() + "*'";
            }
            else
            {
                ((DataView)bunifuDataGridViewBill.DataSource).RowFilter = "";
            }
        }

        private void bunifuButtonBillPrint_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridViewBill.SelectedRows.Count > 0)
            {
                // Get bill for print
                Bill billDetail = Bill.GetBill(Convert.ToInt32(bunifuDataGridViewBill.SelectedRows[0].Cells[0].Value.ToString()));

                FormReport reportForm = new FormReport();

                switch (billDetail.BillTypeID)
                {
                    case Bill.MEDICINEBILL:
                        reportForm.ReportType = "MEDICINEBILL";
                        reportForm.ObjectID = billDetail.BillID;
                        break;
                    case Bill.SERVICEBILL:
                        reportForm.ReportType = "SERVICEBILL";
                        reportForm.ObjectID = billDetail.BillID;
                        break;
                    case Bill.MATERIALBILL:
                        reportForm.ReportType = "MATERIALBILL";
                        reportForm.ObjectID = billDetail.BillID;
                        break;
                    default:
                        bunifuSnackbar1.Show(Form.ActiveForm, "Vui lòng chọn hóa đơn để in!", Bunifu.UI.WinForms.BunifuSnackbar.MessageTypes.Error, 3000, null, Bunifu.UI.WinForms.BunifuSnackbar.Positions.TopCenter);
                        break;
                }

                reportForm.Show();

            }
        }
    }
}
