using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace pull
{
    public partial class pull : Form
    {
        ReportDocument ReportDoc;
        public pull()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ReportDoc =new ReportDocument();

            ReportDoc.Load("D:\\pull\\pull\\CrystalReport1.rpt");//报表文件所在绝对路径
            /****************************************************
             * 解决pull模式不能登陆问题
             * ****************************************************/
            TableLogOnInfo logonInfo=new TableLogOnInfo();
            foreach(CrystalDecisions.CrystalReports.Engine.Table tb in ReportDoc.Database.Tables)
            {
                logonInfo=tb.LogOnInfo;
                logonInfo.ConnectionInfo.ServerName = "yafei"; //主机名
                logonInfo.ConnectionInfo.DatabaseName = "db_CRM";//数据库名
                logonInfo.ConnectionInfo.UserID = "sa";//数据库用户名   
                logonInfo.ConnectionInfo.Password="123456";//密码
                tb.ApplyLogOnInfo(logonInfo);
            }
            crystalReportViewer2.ReportSource = ReportDoc;
        }
    }
}