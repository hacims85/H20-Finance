using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H20_Finance.AdminPanel
{
    public partial class CoinSil : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_coinsil.DataSource = dm.coinListele();
            lv_coinsil.DataBind();
        }

        protected void lv_coinsil_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.coinSil(id);
                lv_coinsil.DataSource = dm.coinListele();
                lv_coinsil.DataBind();
            }
        }
    }
}