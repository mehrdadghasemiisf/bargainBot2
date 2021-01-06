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
    public partial class frmAddTransaction : Form
    {
        long _user_id = -1;
        public frmAddTransaction(long user_id)
        {
            _user_id = user_id;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
                if (!chkVariz.Checked && !chkBardasht.Checked)
                {
                    MessageBox.Show("لطفاً نوع واریز یا برداشت را مشخص کنید");

                }
                else
                {
                    using (Repository.TransactionRepository transactionRepository = new Repository.TransactionRepository())
                    {
                        Models.Transaction transaction = new Models.Transaction();
                        transaction.DateTime = DateTime.Now;
                        transaction.Disc = txtDisc.Text;
                        transaction.Price = int.Parse(txtPrice.Text);
                        if (chkVariz.Checked)
                        {
                            transaction.TransactionType_Id = 1;
                        }
                        else
                        {
                            transaction.TransactionType_Id = 2;
                        }
                        transaction.UserBargain_Id = _user_id;
                        transactionRepository.Add(transaction);
                        DialogResult = DialogResult.Yes;
                    }
                }
            
        }

        private void FrmAddTransaction_Load(object sender, EventArgs e)
        {
            txtDisc.SelectedIndex = 0;
        }

        private void ChkVariz_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVariz.Checked)
                txtDisc.SelectedIndex = 0;

        }

        private void ChkBardasht_CheckedChanged(object sender, EventArgs e)
        {
            if(chkBardasht.Checked)
                txtDisc.SelectedIndex = 1;

        }
    }
}
