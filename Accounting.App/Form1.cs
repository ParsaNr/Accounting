using Accounting.utility.Convertor;
using Accounting.ViewModels.Accounting;
using Accounting.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frmCustomers = new frmCustomers();
            frmCustomers.ShowDialog();
        }

        private void btnNewAccounting_Click(object sender, EventArgs e)
        {
            frmNewAccounting frmNewAccounting = new frmNewAccounting();
            frmNewAccounting.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeID = 2;
            frmReport.ShowDialog();
        }

        private void btnReportRecive_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeID = 1;
            frmReport.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin fl = new FrmLogin();
            if (fl.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                lblDate.Text = DateConvertor.ToShamsi(DateTime.Now);
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                Application.Exit();
            }
            Report();
        }

        void Report()
        {
            ReportViewModel report = God.rvm();
            lblPay.Text = report.Pay.ToString("#, 0");
            lblRecive.Text = report.Recive.ToString("#, 0");
            lblBalance.Text = report.Balance.ToString("#, 0");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void loginSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin fl = new FrmLogin();
            fl.IsEdit = true;
            fl.ShowDialog();
        }
    }
}
