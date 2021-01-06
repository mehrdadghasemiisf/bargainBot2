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
    public partial class frmAllTransaction : Form
    {
        public frmAllTransaction()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            utility.UtilityRepository utility = new utility.UtilityRepository();
            DateTime dateTime_Start_Org = utility.ShamsiTOMiladi(txtDateStart.Value.ToString("yyyy/MM/dd"));
            DateTime dateTime_End_Org = utility.ShamsiTOMiladi(txtDateEnd.Value.ToString("yyyy/MM/dd"));
            DateTime dStart = new DateTime(dateTime_Start_Org.Year, dateTime_Start_Org.Month, dateTime_Start_Org.Day, 0, 0, 0);
            DateTime dEnd = new DateTime(dateTime_End_Org.Year, dateTime_End_Org.Month, dateTime_End_Org.Day, 23, 59, 59);

            Repository.TransactionRepository transactionRepository = new Repository.TransactionRepository();

            var tmp = transactionRepository.Search(dStart, dEnd).OrderByDescending(x=>x.Id);

            List<ViewModels.TransactionViewModel> TransactionViewModel_list = new List<ViewModels.TransactionViewModel>();

            long _variz = 0, _bardasht = 0;
            foreach (var item in tmp)
            {
                ViewModels.TransactionViewModel model_tr = new ViewModels.TransactionViewModel();
                model_tr.DateTime = utility.Convert2Shamsi(item.DateTime);
                model_tr.Disc = item.Disc;
                model_tr.Price = item.Price;
                model_tr.Name = item.UserBargain.Name + " " + item.UserBargain.Family;
                if (item.TransactionType_Id == 1)
                {
                    model_tr.TypeName = "واریز";
                    _variz += item.Price;
                }
                else
                {
                    model_tr.TypeName = "برداشت";
                    _bardasht += item.Price;
                }
                TransactionViewModel_list.Add(model_tr);
            }// end for

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = TransactionViewModel_list;
            lblVariz.Text = "جمع واریزی : " + _variz.ToString("N0");
            lblBardasht.Text = "جمع برداشتی : " + _bardasht.ToString("N0");
            lblTotal.Text = "جمع کل  : " + (_variz - _bardasht).ToString("N0");


        }
    }
}
