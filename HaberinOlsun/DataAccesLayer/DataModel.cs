using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccesLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region YoneticiMetotları
        public Yonetici YoneticiGiris(string mail,string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m",mail);
                cmd.Parameters.AddWithValue("@s",sifre);
                con.Open();
                int sayi=Convert.ToInt32(cmd.ExecuteScalar());
                if(sayi>0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,Email,Sifre,Durum FROM Yoneticiler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader=cmd.ExecuteReader();
                    Yonetici y = null;
                    while(reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim=reader.GetString(2);
                        y.Soyisim=reader.GetString(3);
                        y.Email=reader.GetString(4);
                        y.Sifre=reader.GetString(5);
                        y.Durum=reader.GetBoolean(6);
                    }
                    return y;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region KategoriMetotları

        public bool KategoriEkle(Kategori k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }



        }
        public List<Kategori> KategoriListele()
        {
            try 
            {
                List<Kategori> kategoriler = new List<Kategori>();

                cmd.CommandText = "SELECT ID,Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read())
                {
                    Kategori k =new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim=reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategori k = new Kategori();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }



        #endregion

        #region HaberMetotları
        public bool HaberEkle(Haber hbr)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Haberler(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResim, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResim, @goruntulenmeSayisi, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", hbr.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", hbr.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", hbr.Baslik);
                cmd.Parameters.AddWithValue("@ozet", hbr.Ozet);
                cmd.Parameters.AddWithValue("@icerik", hbr.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", hbr.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", hbr.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", hbr.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", hbr.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Haber> HaberListele()
        {
            try
            {
                List<Haber> haberler=new List<Haber>();
                cmd.CommandText = "SELECT H.ID,H.KategoriID,K.Isim,H.YazarID,Y.Isim+' '+Y.Soyisim,H.Baslik,H.Ozet,H.Icerik,H.KapakResim,H.GoruntulenmeSayisi,H.EklemeTarihi,H.Durum FROM Haberler AS H JOIN Kategoriler AS K ON K.ID=H.KategoriID JOIN Yoneticiler AS Y ON Y.ID=H.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                while(reader.Read())
                {
                    Haber h=new Haber();
                    h.ID = reader.GetInt32(0);
                    h.Kategori_ID = reader.GetInt32(1);
                    h.Kategori = reader.GetString(2);
                    h.Yazar_ID = reader.GetInt32(3);
                    h.Yazar = reader.GetString(4);
                    h.Baslik = reader.GetString(5);
                    h.Ozet = reader.GetString(6);
                    h.Icerik = reader.GetString(7);
                    h.KapakResim = reader.GetString(8);
                    h.GoruntulemeSayisi = reader.GetInt32(9);
                    h.EklemeTarih = reader.GetDateTime(10);
                    h.Durum = reader.GetBoolean(11);
                    haberler.Add(h);
                }
                return haberler;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }
        public bool HaberSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Haberler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool HaberDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Haberler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Haberler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public bool HaberGuncelle(Haber hbr)
        {
            try
            {
                cmd.CommandText = "UPDATE Haberler SET KategoriID=@kategoriID, Baslik=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", hbr.ID);
                cmd.Parameters.AddWithValue("@kategoriID", hbr.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", hbr.Baslik);
                cmd.Parameters.AddWithValue("@ozet", hbr.Ozet);
                cmd.Parameters.AddWithValue("@icerik", hbr.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", hbr.KapakResim);
                cmd.Parameters.AddWithValue("@durum", hbr.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public Haber HaberGetir(int id)
        {
            try
            {

                cmd.CommandText = "SELECT H.ID,H.KategoriID,K.Isim,H.YazarID,Y.Isim+' '+Y.Soyisim, H.Baslik, H.Ozet, H.Icerik, H.KapakResim, H.GoruntulenmeSayisi, H.EklemeTarihi, H.Durum FROM Haberler AS H JOIN Kategoriler AS K ON K.ID = H.KategoriID JOIN Yoneticiler AS Y ON Y.ID = H.YazarID WHERE H.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Haber hbr = new Haber();
                while (reader.Read())
                {

                    hbr.ID = reader.GetInt32(0);
                    hbr.Kategori_ID = reader.GetInt32(1);
                    hbr.Kategori = reader.GetString(2);
                    hbr.Yazar_ID = reader.GetInt32(3);
                    hbr.Yazar = reader.GetString(4);
                    hbr.Baslik = reader.GetString(5);
                    hbr.Ozet = reader.GetString(6);
                    hbr.Icerik = reader.GetString(7);
                    hbr.KapakResim = reader.GetString(8);
                    hbr.GoruntulemeSayisi = reader.GetInt32(9);
                    hbr.EklemeTarih = reader.GetDateTime(10);
                    hbr.Durum = reader.GetBoolean(11);
                }
                return hbr;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Haber> HaberListele(int katid)
        {
            try
            {
                List<Haber> haberler = new List<Haber>();
                cmd.CommandText = "SELECT H.ID,H.KategoriID,K.Isim,H.YazarID,Y.Isim+' '+Y.Soyisim,H.Baslik,H.Ozet,H.Icerik,H.KapakResim,H.GoruntulenmeSayisi,H.EklemeTarihi,H.Durum FROM Haberler AS H JOIN Kategoriler AS K ON K.ID = H.KategoriID JOIN Yoneticiler AS Y ON Y.ID = H.YazarID WHERE H.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Haber hbr = new Haber();
                    hbr.ID = reader.GetInt32(0);
                    hbr.Kategori_ID = reader.GetInt32(1);
                    hbr.Kategori = reader.GetString(2);
                    hbr.Yazar_ID = reader.GetInt32(3);
                    hbr.Yazar = reader.GetString(4);
                    hbr.Baslik = reader.GetString(5);
                    hbr.Ozet = reader.GetString(6);
                    hbr.Icerik = reader.GetString(7);
                    hbr.KapakResim = reader.GetString(8);
                    hbr.GoruntulemeSayisi = reader.GetInt32(9);
                    hbr.EklemeTarih = reader.GetDateTime(10);
                    hbr.Durum = reader.GetBoolean(11);
                    haberler.Add(hbr);
                }
                return haberler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region UyeMetotları
        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID,Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyisim = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Mail = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }

            }
            catch
            {
                return null;
            }
            finally 
            {
                con.Close();
            }
        }
        public bool Kayıt(Uye u)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim,Soyisim,KullaniciAdi,Email,Sifre,UyelikTarihi,Durum) VALUES (@Isim,@Soyad,@KullaniciAdi,@Mail,@Sifre,@UyelikTarihi,@Durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isim", u.Isim);
                cmd.Parameters.AddWithValue("@Soyad", u.Soyisim);
                cmd.Parameters.AddWithValue("@KullaniciAdi", u.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Mail", u.Mail);
                cmd.Parameters.AddWithValue("@Sifre", u.Sifre);
                cmd.Parameters.AddWithValue("@UyelikTarihi", u.UyelikTarihi);
                cmd.Parameters.AddWithValue("@Durum", u.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion
        #region YorumMetotları
        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, H.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Haberler AS H ON H.ID=Y.HaberID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.HaberID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele(int Hid)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, H.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Haberler AS H ON H.ID=Y.HaberID WHERE Y.HaberID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Hid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.HaberID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO yorumlar(UyeID, HaberID, Icerik, YorumTarihi, OnayDurum) VALUES(@uyeID, @haberID,@icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@haberID", y.HaberID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.Tarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }
        public List<Yorum> YorumListele(bool onay)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, H.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Haberler AS H ON H.ID=Y.HaberID WHERE Y.OnayDurum = @d";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", onay);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.HaberID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }
        

        #endregion
    }
}
