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

namespace bargainBot.View.frmUsers
{
    public partial class frmAllOpenBag : Form
    {
        public frmAllOpenBag()
        {
            InitializeComponent();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
            utility.UtilityRepository utility = new utility.UtilityRepository();
            DateTime dateTime_Start_Org = utility.ShamsiTOMiladi(txtDateStart.Value.ToString("yyyy/MM/dd"));
            DateTime dateTime_End_Org = utility.ShamsiTOMiladi(txtDateEnd.Value.ToString("yyyy/MM/dd"));
            DateTime dStart = new DateTime(dateTime_Start_Org.Year, dateTime_Start_Org.Month, dateTime_Start_Org.Day, 0, 0, 0);
            DateTime dEnd = new DateTime(dateTime_End_Org.Year, dateTime_End_Org.Month, dateTime_End_Org.Day, 23, 59, 59);

             List < BargainSuccessViewModel > successViewModels = bargainSuccessRepository.GetAllOpenSellBuy(dStart, dEnd);

            lblSum.Text = $"جمع مبالغ معاملات باز : {(successViewModels.Sum(x => x.Price) * 1000).ToString("N0")} تومان";
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = successViewModels;

        }

        private void FrmAllOpenBag_Load(object sender, EventArgs e)
        {
        }

        private async void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show($"آیا برای حذف معامله با سند {dgv.CurrentRow.Cells["Id1"].Value.ToString()} موافق هستید ؟ ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (MessageBox.Show($"حذف انجام شود ؟  ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    BargainSuccessRepository bargainSuccessRepository = new BargainSuccessRepository();
                    if (await bargainSuccessRepository.Delete(long.Parse(dgv.CurrentRow.Cells["Id1"].Value.ToString())))
                    {
                        MessageBox.Show("حذف معامله مورد نظر با موفقیت انجام شد");
                        BtnSearch_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("متاسفانه امکان حذف معامله وجودندارد");

                    }
                }
            }
        }
    }
}
