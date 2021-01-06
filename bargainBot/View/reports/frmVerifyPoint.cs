using bargainBot.Migrations;
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
    public partial class frmVerifyPoint : Form
    {
        public frmVerifyPoint()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            UserPointRepository userPointRepository = new UserPointRepository();
            if (chkVerify.Checked)
            {
                dgv.DataSource = userPointRepository.GetUserPointsTrue();
            }
            else if (chkNotVerify.Checked)
            {
                dgv.DataSource = userPointRepository.GetUserPointsFalse();

            }
            else if (chkAll.Checked)
            {
                dgv.DataSource = userPointRepository.GetUserPointsAll();

            }
        }

        private void تاییدامتیازToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserPointRepository userPointRepository = new UserPointRepository();
            Models.UserPoint userpoint = userPointRepository.GetUserPoint(int.Parse(dgv.CurrentRow.Cells["id"].Value.ToString()));

            if(userpoint!=null)
            {
                userpoint.IsVerify = !userpoint.IsVerify;
                userPointRepository.Update(userpoint);
                userPointRepository.Save();
                MessageBox.Show("تغییر وضعیت امتیاز با موفقیت انجام شد");
            }
        }
    }
}
