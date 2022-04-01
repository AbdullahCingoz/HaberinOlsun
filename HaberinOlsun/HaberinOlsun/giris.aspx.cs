using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun
{
    public partial class giris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
         DataAccesLayer.Uye u =dm.UyeGiris(tb_mail.Text, tb_sifre.Text);
            if(u != null)
            {
                if(u.Durum)
                {
                    Session["uye"] = u;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Uyeliğiniz aktif değildir";

                }
            }
            else
            {
                pnl_basarisiz.Visible=true;
                lbl_mesaj.Text = "Kullanıcı bulunamadı";
            }
        }
    }
}