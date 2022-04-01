using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HaberinOlsun.Yonetici.K
{
    public partial class Yonetici : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["yonetici"]!=null)
            {
                DataAccesLayer.Yonetici yon = (DataAccesLayer.Yonetici)Session["yonetici"];
                lbl_yonetici.Text = yon.Isim + " " + yon.Soyisim;
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }

        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("Giris.aspx");

        }
    }
}