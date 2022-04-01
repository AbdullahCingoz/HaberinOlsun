using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun.Yonetici.K
{
    public partial class HaberListele : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_haberler.DataSource = dm.HaberListele();
            lv_haberler.DataBind();
        }

        protected void lv_haberler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.HaberSil(id);
            }
            if (e.CommandName == "durum")
            {
                dm.HaberDurumDegistir(id);
            }
            lv_haberler.DataSource = dm.HaberListele();
            lv_haberler.DataBind();
        }
    }
}