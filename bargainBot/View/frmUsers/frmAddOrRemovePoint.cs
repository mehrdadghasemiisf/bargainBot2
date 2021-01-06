using bargainBot.Models;
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
    public partial class frmAddOrRemovePoint : Form
    {
        long _userid;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">ای دی داخلی</param>
        public frmAddOrRemovePoint(long userid)
        {
            _userid = userid;
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            Repository.UserPointRepository userPointRepository = new Repository.UserPointRepository();
            if (rbAdd.Checked)
            {
                Repository.UserBargainRepository userBargainRepository = new Repository.UserBargainRepository();
                UserBargain userBargain = userBargainRepository.GetFirstAdmin();
                for (int i = 1; i <= numericUpDown1.Value; i++)
                {
                    userPointRepository.Add(new UserPoint
                    {
                        Date = DateTime.Now,
                        IsVerify = true,
                        UserBargain_Id_1 = _userid,
                        UserBargain_Id_2 = userBargain.Id
                    });
                    userPointRepository.Save2();

                }

            }
            else if (rbRemo.Checked)
            {
                for (int i = 1; i <= numericUpDown1.Value; i++)
                {
                    userPointRepository.DeleteFirst(_userid);
                    userPointRepository.Save2();

                }


            }
            MessageBox.Show("امتیاز ها با موفقیت ثبت شد");
            lblPointsTest.Text = $"مجموع امتیازات : {userPointRepository.CountPoint(_userid)*10} امتیاز ";
        }

        private void FrmAddOrRemovePoint_Load(object sender, EventArgs e)
        {
            Repository.UserPointRepository userPointRepository = new Repository.UserPointRepository();
            lblPointsTest.Text = $"مجموع امتیازات : {userPointRepository.CountPoint(_userid)*10} امتیاز ";
        }
    }
}
