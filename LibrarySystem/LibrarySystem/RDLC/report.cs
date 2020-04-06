using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibrarySystem.RDLC
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }
        Access a = new Access();

        private void report_Load(object sender, EventArgs e)
        {
            //DataSet dsCustomers = GetData();
            //ReportDataSource datasource = new ReportDataSource("Orders", dsCustomers.Tables[0]);
            //this.reportViewer1.LocalReport.DataSources.Clear();
            //this.reportViewer1.LocalReport.DataSources.Add(datasource);
            //this.reportViewer1.RefreshReport();

            a.connection();

            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Orders", a.con);
            DataSet ds = new DataSet();
            dataAdapter.Fill(ds);
            reportViewer1.Reset();
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Value = ds.Tables[0];
            reportDataSource.Name = "DataSetAssetList";
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "AssestsManagementSystem.Report1.rdlc";
            this.reportViewer1.RefreshReport();

            MessageBox.Show("Ok");
            a.Deconnection();

        }

        //private DataSet GetData() 
        //{
           
        //        using (SqlCommand cmd = new SqlCommand("SELECT * FROM orders"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                a.connection();
        //                cmd.Connection = a.con;
        //                sda.SelectCommand = cmd;
        //                using (DataSet dsCustomers = new DataSet())
        //                {
        //                    sda.Fill(dsCustomers, "Orders");
        //                    return dsCustomers;
        //                }
        //                a.Deconnection();
        //            }
        //        }
        //}

    }
}
