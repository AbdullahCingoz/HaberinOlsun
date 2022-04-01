using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun.Yonetici.K
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel db=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                string mail = tb_mail.Text;
                string sifre = tb_sifre.Text;

                DataAccesLayer.Yonetici y = db.YoneticiGiris(mail, sifre);
                if(y != null)
                {
                    Session["yonetici"]=y;
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbl_mesaj.Text = "Kullanıcı bulunamadı";
                    pnl_hata.Visible = true;
                }
            }
            else
            {
                lbl_mesaj.Text = "Mail ve şifre boş bırakılamaz";
                pnl_hata.Visible= true;
            }
        }
    }
}