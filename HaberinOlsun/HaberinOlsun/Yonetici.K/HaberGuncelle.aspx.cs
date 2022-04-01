using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccesLayer;
using System.IO;

namespace HaberinOlsun.Yonetici.K
{
    public partial class HaberGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["guncelle"]);
                    Haber hbr = dm.HaberGetir(id);
                    tb_isim.Text = hbr.Baslik;
                    tb_ozet.Text = hbr.Ozet;
                    tb_icerik.Text = hbr.Icerik;
                    ddl_kategoriler.SelectedValue = Convert.ToString(hbr.Kategori_ID);
                    img_resim.ImageUrl = "../HaberResimleri/" + hbr.KapakResim;
                    cb_yayinla.Checked = hbr.Durum;
                }
            }
            else
            {
                Response.Redirect("HaberListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunMu = true;
            int id = Convert.ToInt32(Request.QueryString["guncelle"]);
            Haber hbr = dm.HaberGetir(id);
            hbr.Baslik = tb_isim.Text;
            hbr.Icerik = tb_icerik.Text;
            hbr.Ozet = tb_ozet.Text;
            hbr.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            hbr.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/HaberResimleri/" + dosyaadi));
                    hbr.KapakResim = dosyaadi;
                }
                else
                {
                    uygunMu = false;
                }
            }
            if (uygunMu)
            {
                if (dm.HaberGuncelle(hbr))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya uzantısı png,jpg veya jpeg olmalıdır";
            }
        }
    }
}