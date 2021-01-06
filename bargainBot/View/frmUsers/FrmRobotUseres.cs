using bargainBot.Repository;
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
    public partial class FrmRobotUseres : Form
    {
        public FrmRobotUseres()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (UserBargainRepository UserBargainRepository = new UserBargainRepository())
                {
                    List<Models.UserBargain>   users = UserBargainRepository.SearchUsers(textBox1.Text);
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.AllowUserToOrderColumns = true;
                    lblSumPriceGaranty.Text = "جمع کل وجه تضمین : " + users.Sum(x => x.PriceGarranty).ToString("N0") + " تومان ";
                    dataGridView1.DataSource = users;
                }
            }
            catch { }

        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void FrmRobotUseres_Load(object sender, EventArgs e)
        {

        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmEditUser frmEditUser = new FrmEditUser(long.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
                if (frmEditUser.ShowDialog() == DialogResult.Yes)
                {
                    Button1_Click(null, null);
                }
            }
            catch
            {
                MessageBox.Show("لطفاً یک کاربر را انتخا بکنید");
            }
        }

        private void واریزیابرداشتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddTransaction frmAddTransaction = new frmAddTransaction(long.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
                if (frmAddTransaction.ShowDialog() == DialogResult.Yes)
                {
                    MessageBox.Show("واریز یا برداشت با موفقیت ثبت شد");
                    Button1_Click(null, null);
                }
            }
            catch
            {
                MessageBox.Show("لطفاً یک کاربر را انتخاب بکنید");
            }
        }

        private void نمایشکمسیونهایToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHistory frmHistory = new frmHistory(long.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
            frmHistory.ShowDialog();
        }

        private void اضافهکمکردنامتیازToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View.frmUsers.frmAddOrRemovePoint frmHistory = new View.frmUsers.frmAddOrRemovePoint(long.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
            frmHistory.ShowDialog();
        }

        private void حذفکاربرازسیستمToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا برای حذف کامل اطلاعات کاربر مطمئن هستید ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                try
                {
                    using (UserBargainRepository UserBargainRepository = new UserBargainRepository())
                    {
                        if (UserBargainRepository.DeleteUser(long.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString())))
                        {
                         //   users.RemoveAt(dataGridView1.CurrentRow.Index);
                            UserBargainRepository.SaveNotAsync();
                            Button1_Click(null, null);
                            // MessageBox.Show("کاربر انتخاب شده با موفقیت حذف شد");
                        }
                        else
                        {
                            MessageBox.Show("امکان حذف کاربر به دلیل داشتن اطلاعات مالی یا معاملات انجام شده وجود ندارد");

                        }
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("لطفاً یک کاربر را انتخاب بکنید");

                }
                catch { }
            }
        }
    }
}
