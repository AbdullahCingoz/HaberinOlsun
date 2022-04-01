using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun
{
    public partial class Uye : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();
            if(Session["uye"]!=null)
            {
               DataAccesLayer.Uye u = (DataAccesLayer.Uye)Session["uye"];
                pnlGirisVar.Visible = true;
                lbl_uye.Text = u.Isim;
                pnl_girisyok.Visible = false;
            }
            else
            {
                pnlGirisVar.Visible=false;
                pnl_girisyok.Visible=true;
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}