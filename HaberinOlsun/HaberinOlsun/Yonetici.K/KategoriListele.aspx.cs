using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun.Yonetici.K
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = dm.KategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Sil")
            {
                int id=Convert.ToInt32(e.CommandArgument);
                if(!dm.KategoriSil(id))
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori silinirken bir hata oluştu";
                }
            }
            lv_kategoriler.DataSource = dm.KategoriListele();
            lv_kategoriler.DataBind();
        }
    }
}