using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H20_Finance.AdminPanel
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                Yoneticiler y = dm.YoneticiGiris(tb_mail.Text, tb_sifre.Text);
                if (y != null)
                {


                    Session["yonetici"] = y;
                    Response.Redirect("AdminPanelHomePage.aspx");

                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Kullanıcı Adı Veya Şifre Hatalı";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı Veya Şifre Boş Bırakılamaz";
            }
        }

        [System.Web.Services.WebMethod]
        public static void GetRateing(decimal change) {

            DataModel dm2 = new DataModel();
            dm2.UpdateCoinPrice(change);
        }
      
    }
}