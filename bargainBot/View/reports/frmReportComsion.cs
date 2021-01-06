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
    public partial class frmReportComsion : Form
    {
        public frmReportComsion()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (Repository.ComisonRepository comisonRepository = new Repository.ComisonRepository())
            {
                utility.UtilityRepository utility = new utility.UtilityRepository();
                DateTime dateTime_Start_Org = utility.ShamsiTOMiladi(txtDateStart.Value.ToString("yyyy/MM/dd"));
                DateTime dateTime_End_Org = utility.ShamsiTOMiladi(txtDateEnd.Value.ToString("yyyy/MM/dd"));
                DateTime dStart = new DateTime(dateTime_Start_Org.Year, dateTime_Start_Org.Month, dateTime_Start_Org.Day, 0, 0, 0);
                DateTime dEnd = new DateTime(dateTime_End_Org.Year, dateTime_End_Org.Month, dateTime_End_Org.Day, 23, 59, 59);



                List<Models.Consion> consions = comisonRepository.Search(dStart, dEnd);
                dataGridView1.AutoGenerateColumns = false;

                dataGridView1.DataSource = consions;
                label1.Text = $"جمع کل کمسیون ها : {consions.Sum(x => x.Price).ToString("N0")} تومان";
            }
        }
    }
}
