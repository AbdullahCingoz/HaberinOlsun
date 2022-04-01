using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;

namespace HaberinOlsun
{
   
    public partial class KayitOl : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kayit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tb_isim.Text) && !string.IsNullOrEmpty(tb_soyad.Text) && !string.IsNullOrEmpty(tb_kullaniciad.Text) && !string.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                DataAccesLayer.Uye u = new DataAccesLayer.Uye();
                u.Isim = tb_isim.Text;
                u.Soyisim= tb_soyad.Text;
                u.KullaniciAdi = tb_kullaniciad.Text;
                u.Mail= tb_mail.Text;
                u.Sifre = tb_sifre.Text;
                u.UyelikTarihi=DateTime.Now;
                u.Durum = true;
                if(dm.Kayıt(u))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;

                    tb_isim.Text = "";
                    tb_soyad.Text = "";
                    tb_kullaniciad.Text = "";
                    tb_mail.Text = "";
                    tb_sifre.Text = "";
                }
                else
                {
                    pnl_basarisiz.Visible=true;
                    pnl_basarili.Visible=false;
                    lbl_mesaj.Text = "Kayıt işlemi yapılırken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Yukarıdaki alanlar boş bırakılamaz";
            }
        }
    }
}