using bargainBot.Models;
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
    public partial class FrmEditUser : Form
    {
        UserBargain UserBargain = new UserBargain();
        public FrmEditUser(long id)
        {
            using (UserBargainRepository UserBargainRepository = new UserBargainRepository())
            {

                UserBargain = UserBargainRepository.GetUserWithMyID(id);
            }
            InitializeComponent();
        }

        private void FrmEditUser_Load(object sender, EventArgs e)
        {
            if (UserBargain.Id > 0)
            {
                Text = "ویرایش اطلاعات کاربر : " + UserBargain.Name + " " + UserBargain.Family;
                txtName.Text = UserBargain.Name;
                txtFamily.Text = UserBargain.Family;
                txtCard.Text = UserBargain.BankCard;
                txtMobile.Text = UserBargain.Mobile;
                chkVerify.Checked = UserBargain.Verify;
                chkIsAdmin.Checked = UserBargain.IsAdmin;
                txtAliasName.Text = UserBargain.AliasNames;

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            using (UserBargainRepository UserBargainRepository = new UserBargainRepository())
            {
                UserBargain.Name = txtName.Text;
                UserBargain.Family = txtFamily.Text;
                UserBargain.BankCard = txtCard.Text;
                UserBargain.Mobile = txtMobile.Text;
                UserBargain.Verify = chkVerify.Checked;
                UserBargain.IsAdmin = chkIsAdmin.Checked;
                UserBargain.AliasNames = txtAliasName.Text;
                UserBargainRepository.Update(UserBargain);
            }
            DialogResult = DialogResult.Yes;
        }

    }
}
