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

namespace bargainBot.View
{
    public partial class frmTelorans : Form
    {
        public frmTelorans()
        {
            InitializeComponent();
        }



        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SettingBotRepository settingBotRepository = new SettingBotRepository();
                SettingsBot settings = settingBotRepository.GetSetting();
                settings.Telorans = int.Parse(txtTelorans.Text);
                settings.OnSaleTelorans= int.Parse(txtOnSale.Text);
                settingBotRepository.Save();
                MessageBox.Show("با موفقیت انجام شد");
            }
            catch
            {
                MessageBox.Show("اطلاعات صحیح نیست");
            }
        }

        private void FrmTelorans_Load(object sender, EventArgs e)
        {
           

            SettingBotRepository settingBotRepository = new SettingBotRepository();
            SettingsBot settings = settingBotRepository.GetSetting();
            txtTelorans.Text = settings.Telorans.ToString();
           txtOnSale.Text = settings.OnSaleTelorans.ToString();
        }
    }
}
