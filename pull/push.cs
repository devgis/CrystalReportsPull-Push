using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace pull
{
    public partial class push : Form
    {
        public push()
        {
            InitializeComponent();
        }

        private void push_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=yafei;Initial Catalog=db_CRM;Persist Security Info=True;User ID=sa;Password=123456";
            SqlConnection con = new SqlConnection(constr);
            string selectstr = "select * from tb_User";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(selectstr, con);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            con.Close();

            CrystalReport2 report = new CrystalReport2();
            report.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = report;
        }
    }
}