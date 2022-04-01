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
    public partial class HaberEkle : System.Web.UI.Page
    {
        DataModel dm=new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Haber hbr = new Haber();
            hbr.Baslik=tb_baslik.Text;
            hbr.Ozet=tb_ozet.Text;
            hbr.Icerik=tb_icerik.Text;
            hbr.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            hbr.Durum = cb_yayınla.Checked;
            DataAccesLayer.Yonetici y = (DataAccesLayer.Yonetici)Session["yonetici"];
            hbr.EklemeTarih=DateTime.Now;
            hbr.Yazar_ID =y.ID;

            if(fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                if(uzanti ==".jpg"|| uzanti ==".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/HaberResimleri/" + resimadi));
                    hbr.KapakResim = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                hbr.KapakResim = "none.jpg";
            }
            if(resimformat)
            {
                if(dm.HaberEkle(hbr))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible=true;
                    lbl_mesaj.Text = "Haber eklenemedi";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya uzantısı .jpg veya .png olmalıdır";
            }
        }
    }
}