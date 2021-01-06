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
    public partial class frmAllCloseBag : Form
    {
        public frmAllCloseBag()
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

            List<BargainSuccessViewModel> successViewModels = bargainSuccessRepository.GetAllCloseBag(dStart, dEnd);

            long _myCommision = successViewModels.Sum(x => x.Comision);

            long _mySood = successViewModels.Where(x => x.Sod >= 0).Sum(x => x.Sod);
            long _myzarar = successViewModels.Where(x => x.Sod < 0).Sum(x => x.Sod);



            lblSumOpen.Text = $"جمع مبالغ باز شدن : {(successViewModels.Sum(x => x.Price) * 1000).ToString("N0")} تومان";
            lblSumClose.Text = $"جمع مبالغ بسته شدن  : {(successViewModels.Sum(x => x.Price2) * 1000).ToString("N0")} تومان";

            lblSumSood.Text = $"جمع مبالغ سود با احتساب کارمزد  : {(_mySood).ToString("N0")} تومان";
            lblSumZarar.Text = $"جمع مبالغ ضرر با احتساب کارمزد  : {(_myzarar).ToString("N0")} تومان";

            lblSumSoodOutCommision.Text = $"جمع مبالغ سود بدون احتساب کارمزد  : {(_mySood-_myCommision).ToString("N0")} تومان";
            lblSumZararOutCommision.Text = $"جمع مبالغ ضرر بدون احتساب کارمزد  : {(_myCommision+_myzarar).ToString("N0")} تومان";



            lblCountBuy.Text = $"تعداد خرید   : {(successViewModels.Where(x=>x.TypeID==2).Count()).ToString("N0")}";
            lblCountSell.Text = $"تعداد فروش   : {(successViewModels.Where(x=>x.TypeID==1).Count()).ToString("N0")}";
            lblCountAll.Text = $"تعداد کل   : {(successViewModels.Count()).ToString("N0")}";



            lblSumCommision.Text = $"جمع کارمزدها : {_myCommision.ToString("N0")} تومان";

            dgv.AutoGenerateColumns = false;
            dgv.DataSource = successViewModels;
        }

        private void FrmAllCloseBag_Load(object sender, EventArgs e)
        {

        }
    }
}
