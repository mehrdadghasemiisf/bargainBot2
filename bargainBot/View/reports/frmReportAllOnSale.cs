using bargainBot.Repository;
using bargainBot.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bargainBot.View.reports
{
    public partial class frmReportAllOnSale : Form
    {
        public frmReportAllOnSale()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();

            List<BargainSuccessViewModel> successViewModels = bargainSuccessRepository.GetAllOnSaleReport();

            lblSum.Text = $"جمع مبالغ معاملات حراج باز : {(successViewModels.Sum(x => x.Price) * 1000).ToString("N0")} تومان";
            label1.Text = "تعداد : " + successViewModels.Count;
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = successViewModels;
        }

        private void FrmReportAllOnSale_Load(object sender, EventArgs e)
        {

        }
    }
}
