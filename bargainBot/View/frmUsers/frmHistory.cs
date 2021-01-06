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
    public partial class frmHistory : Form
    {
        long _user_id = -1;
        public frmHistory(long user_id)
        {
            _user_id = user_id;
            InitializeComponent();
        }

        private void TabPage1_Enter(object sender, EventArgs e)
        {
            if (_user_id > 0)
            {
                using (Repository.ComisonRepository comisonRepository = new Repository.ComisonRepository())
                {
                    dgvCommision.AutoGenerateColumns = false;
                    List<Models.Consion> _list = comisonRepository.GetAll(_user_id);
                    dgvCommision.DataSource = _list;
                    tabPage1.Text = $"کمسیون ها  (جمع :  {_list.Sum(x => x.Price)} تومان)";
                }
            }
        }

        private void TabPage2_Enter(object sender, EventArgs e)
        {
            using (Repository.TransactionRepository transactionRepository = new Repository.TransactionRepository())
            {
                List<Models.Transaction> transactions_list = transactionRepository.GetAll(_user_id);


                dgvTransaction.AutoGenerateColumns = false;

                long SumVariz = transactions_list.Where(x => x.TransactionType_Id == 1).Sum(x => x.Price);
                long SumBardasht = transactions_list.Where(x => x.TransactionType_Id == 2).Sum(x => x.Price);


                lblSumVariz.Text = "جمع واریز ها : " + SumVariz.ToString("N0");
                lblSumBardasht.Text = "جمع برداشت ها : " + SumBardasht.ToString("N0");

                lblSumAllVariz.Text = "جمع کل  : " + (SumVariz - SumBardasht).ToString("N0");
                if (UserBargain != null)
                {
                    lblSumGarantyPrice.Text = "وجه تضمین جاری : " + UserBargain.PriceGarranty.ToString("N0");
                }

                dgvTransaction.DataSource = transactions_list;




                //int i = 0;
                //foreach (DataGridViewRow item in dgvTransaction.Rows)
                //{
                //    if(item.Cells[3].Value.ToString()=="1")
                //    {
                //        dgvTransaction[4, i].Value = "واریز";
                //    }
                //    else
                //    {
                //        dgvTransaction[4, i].Value = "برداشت";

                //    }
                //    i++;
                //}
                //dgvTransaction.Refresh();

            }

        }
        Models.UserBargain UserBargain;
        private void FrmHistory_Load(object sender, EventArgs e)
        {
            try
            {
                Repository.UserBargainRepository userBargainRepository = new Repository.UserBargainRepository();
                UserBargain = userBargainRepository.GetUserWithMyID(_user_id);
                if (UserBargain != null)
                {
                    Text = "سوابق : " + UserBargain.Name + " " + UserBargain.Family;
                }
            }
            catch { }
        }

        private void TabPageOpenSellBuy_Enter(object sender, EventArgs e)
        {
            Repository.BargainSuccessRepository bargainSuccessRepository = new Repository.BargainSuccessRepository();
           
                dgvOpenSellBuy.AutoGenerateColumns = false;
                dgvOpenSellBuy.DataSource = bargainSuccessRepository.GetAllOpenSellBuy(_user_id);

            
        }

        private void TabPageCloseBarg_Enter(object sender, EventArgs e)
        {
            Repository.BargainSuccessRepository bargainSuccessRepository = new Repository.BargainSuccessRepository();
            
                dgvCloseBag.AutoGenerateColumns = false;
                List<ViewModels.BargainSuccessViewModel> bargainSuccessViewModels = bargainSuccessRepository.GetAllCloseBag(_user_id);
                lblCountBag.Text = "تعداد معامله : " + bargainSuccessViewModels.Count.ToString();
                lblSumSood.Text = $"مجموع سود / ضرر : {bargainSuccessViewModels.Sum(x => x.Sod).ToString("N0")} تومان";
                dgvCloseBag.DataSource = bargainSuccessViewModels;

            
        }
    }
}
