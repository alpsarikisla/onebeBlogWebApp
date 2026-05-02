using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeriErisimKatmani
{
    public class VeritabaniIslemleri
    {
        SqlConnection baglanti; SqlCommand komut;

        public VeritabaniIslemleri()
        {
            baglanti = new SqlConnection(BaglantiYollari.baglantiYolu);
            komut = baglanti.CreateCommand();
        }

        #region Yönetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                komut.CommandText = "SELECT COUNT(*) FROM Yonetici WHERE Mail=@m AND Sifre=@s";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@m", mail);
                komut.Parameters.AddWithValue("@s", sifre);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                if (sayi > 0)
                {
                    komut.CommandText = "SELECT Y.ID, Y.YoneticiTurID,YT.Isim, Y.Isim,Y.Soyisim,Y.Mail,Y.Sifre,Y.KayitTarihi,Y.AktifMi,Y.SilindiMi FROM Yonetici AS Y JOIN YoneticiTurleri AS YT ON Y.YoneticiTurID = YT.ID WHERE Mail=@m AND Sifre=@s";
                    komut.Parameters.Clear();
                    komut.Parameters.AddWithValue("@m", mail);
                    komut.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader okuyucu = komut.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (okuyucu.Read())
                    {
                        y.ID = okuyucu.GetInt32(0);
                        y.YoneticiTurID = okuyucu.GetInt32(1);
                        y.YoneticiTur = okuyucu.GetString(2);
                        y.Isim = okuyucu.GetString(3);
                        y.Soyisim = okuyucu.GetString(4);
                        y.Mail = okuyucu.GetString(5);
                        y.Sifre = okuyucu.GetString(6);
                        y.KayitTarihi = okuyucu.GetDateTime(7);
                        y.AktifMi = okuyucu.GetBoolean(8);
                        y.SilindiMi = okuyucu.GetBoolean(9);
                    }
                    return y;
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
                baglanti.Close();
            }
        }

        #endregion


        #region Kategori Metotları

        public bool KategoriEkle(Kategori model)
        {
            try
            {
                komut.CommandText = "INSERT INTO Kategoriler(Isim,KayitTarihi,Aktifmi,SilindiMi) VALUES(@isim, @kayitTarihi, @aktifmi, @silindiMi)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@isim", model.Isim);
                komut.Parameters.AddWithValue("@kayitTarihi", model.KayitTarihi);
                komut.Parameters.AddWithValue("@aktifmi", model.Aktifmi);
                komut.Parameters.AddWithValue("@silindiMi", model.SilindiMi);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally { baglanti.Close(); }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                komut.CommandText = "SELECT ID, Isim, KayitTarihi, Aktifmi, SilindiMi FROM Kategoriler";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while(okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.KayitTarihi = okuyucu.GetDateTime(2);
                    kat.Aktifmi = okuyucu.GetBoolean(3);
                    kat.SilindiMi = okuyucu.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch { return null; }
            finally { baglanti.Close(); }
        }

        public List<Kategori> AktifKategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                komut.CommandText = "SELECT ID, Isim, KayitTarihi, Aktifmi, SilindiMi FROM Kategoriler WHERE Aktifmi = 1";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim = okuyucu.GetString(1);
                    kat.KayitTarihi = okuyucu.GetDateTime(2);
                    kat.Aktifmi = okuyucu.GetBoolean(3);
                    kat.SilindiMi = okuyucu.GetBoolean(4);
                    kategoriler.Add(kat);
                }
                return kategoriler;
            }
            catch { return null; }
            finally { baglanti.Close(); }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT ID, Isim, KayitTarihi, Aktifmi, SilindiMi FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Kategori kat = new Kategori();
                while(okuyucu.Read())
                {
                    kat.ID = okuyucu.GetInt32(0);
                    kat.Isim =okuyucu.GetString(1);
                    kat.KayitTarihi = okuyucu.GetDateTime(2);
                    kat.Aktifmi = okuyucu.GetBoolean(3);
                    kat.SilindiMi = okuyucu.GetBoolean(4);
                }
                return kat;
            }
            catch
            { 
                return null;
            }
            finally
            {
                baglanti.Close();
            }
        }

        public bool KategoriGuncelle(Kategori kat)
        {
            try
            {
                komut.CommandText = "UPDATE Kategoriler SET Isim=@i, Aktifmi=@a WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@i", kat.Isim);
                komut.Parameters.AddWithValue("@a", kat.Aktifmi);
                komut.Parameters.AddWithValue("@id", kat.ID);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch{ return false; }
            finally { baglanti.Close(); }
        }

        public void KategoriDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Aktifmi FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE Kategoriler SET Aktifmi=@a WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@a", !durum);
                komut.ExecuteNonQuery();
            }
           finally { baglanti.Close(); }
        }

        public void KategoriSil(int id)
        {
            try
            {
                komut.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally
            {  baglanti.Close(); }
        }

        #endregion

        #region Makale İşlemleri

        public bool MakaleEkle(Makale mak)
        {
            try 
            {
                komut.CommandText = "INSERT INTO Makaleler(KategoriID, YoneticiID, Baslik, Ozet, Icerik, KapakResmi, OkunmaSayisi, BegeniSayisi, YayinTarihi, AktifMi, SilindiMi) VALUES(@kategoriID, @yoneticiID, @baslik, @ozet, @icerik, @kapakResim, @okumaSayisi, @begeniSayisi, @yayinTarihi, @aktifMi, @silindiMi)";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@kategoriID", mak.KategoriID);
                komut.Parameters.AddWithValue("@yoneticiID", mak.YazarID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                komut.Parameters.AddWithValue("@okumaSayisi", mak.OkumaSayisi);
                komut.Parameters.AddWithValue("@begeniSayisi", mak.BegeniSayisi);
                komut.Parameters.AddWithValue("@yayinTarihi", mak.YayinTarihi);
                komut.Parameters.AddWithValue("@aktifMi", mak.AktifMi);
                komut.Parameters.AddWithValue("@silindiMi", mak.SilindiMi);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex) { return false;  }
            finally { baglanti.Close(); }
        }

        public List<Makale> MakaleListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try 
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YoneticiID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.OkunmaSayisi, M.BegeniSayisi, M.YayinTarihi, M.AktifMi, M.SilindiMi FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yonetici AS Y ON M.YoneticiID = Y.ID";
                komut.Parameters.Clear();
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while(okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.OkumaSayisi = okuyucu.GetInt32(9);
                    mak.BegeniSayisi = okuyucu.GetInt32(10);
                    mak.YayinTarihi = okuyucu.GetDateTime(11);
                    mak.AktifMi = okuyucu.GetBoolean(12);
                    mak.SilindiMi = okuyucu.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch 
            {
                return null;
            }
            finally { baglanti.Close(); }
        }

        public List<Makale> MakaleListele(bool silinmedurum)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YoneticiID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.OkunmaSayisi, M.BegeniSayisi, M.YayinTarihi, M.AktifMi, M.SilindiMi FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yonetici AS Y ON M.YoneticiID = Y.ID WHERE M.SilindiMi = @durum";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", silinmedurum);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.OkumaSayisi = okuyucu.GetInt32(9);
                    mak.BegeniSayisi = okuyucu.GetInt32(10);
                    mak.YayinTarihi = okuyucu.GetDateTime(11);
                    mak.AktifMi = okuyucu.GetBoolean(12);
                    mak.SilindiMi = okuyucu.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally { baglanti.Close(); }
        }
        public List<Makale> MakaleListele(bool silinmedurum, bool aktifdurum)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YoneticiID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.OkunmaSayisi, M.BegeniSayisi, M.YayinTarihi, M.AktifMi, M.SilindiMi FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yonetici AS Y ON M.YoneticiID = Y.ID WHERE M.SilindiMi = @durum AND M.Aktifmi = @aktifmi";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", silinmedurum);
                komut.Parameters.AddWithValue("@aktifmi", aktifdurum);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.OkumaSayisi = okuyucu.GetInt32(9);
                    mak.BegeniSayisi = okuyucu.GetInt32(10);
                    mak.YayinTarihi = okuyucu.GetDateTime(11);
                    mak.AktifMi = okuyucu.GetBoolean(12);
                    mak.SilindiMi = okuyucu.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally { baglanti.Close(); }
        }
        public List<Makale> MakaleListele(string id, bool silinmedurum, bool aktifdurum)
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YoneticiID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.OkunmaSayisi, M.BegeniSayisi, M.YayinTarihi, M.AktifMi, M.SilindiMi FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yonetici AS Y ON M.YoneticiID = Y.ID WHERE M.SilindiMi = @durum AND M.Aktifmi = @aktifmi AND M.KategoriID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@durum", silinmedurum);
                komut.Parameters.AddWithValue("@aktifmi", aktifdurum);
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                while (okuyucu.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.OkumaSayisi = okuyucu.GetInt32(9);
                    mak.BegeniSayisi = okuyucu.GetInt32(10);
                    mak.YayinTarihi = okuyucu.GetDateTime(11);
                    mak.AktifMi = okuyucu.GetBoolean(12);
                    mak.SilindiMi = okuyucu.GetBoolean(13);
                    makaleler.Add(mak);
                }
                return makaleler;
            }
            catch
            {
                return null;
            }
            finally { baglanti.Close(); }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                komut.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YoneticiID, Y.Isim + ' ' + Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.OkunmaSayisi, M.BegeniSayisi, M.YayinTarihi, M.AktifMi, M.SilindiMi FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yonetici AS Y ON M.YoneticiID = Y.ID WHERE M.ID = @id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                SqlDataReader okuyucu = komut.ExecuteReader();
                Makale mak = new Makale();
                while (okuyucu.Read())
                {
                    mak.ID = okuyucu.GetInt32(0);
                    mak.KategoriID = okuyucu.GetInt32(1);
                    mak.Kategori = okuyucu.GetString(2);
                    mak.YazarID = okuyucu.GetInt32(3);
                    mak.Yazar = okuyucu.GetString(4);
                    mak.Baslik = okuyucu.GetString(5);
                    mak.Ozet = okuyucu.GetString(6);
                    mak.Icerik = okuyucu.GetString(7);
                    mak.KapakResim = okuyucu.GetString(8);
                    mak.OkumaSayisi = okuyucu.GetInt32(9);
                    mak.BegeniSayisi = okuyucu.GetInt32(10);
                    mak.YayinTarihi = okuyucu.GetDateTime(11);
                    mak.AktifMi = okuyucu.GetBoolean(12);
                    mak.SilindiMi = okuyucu.GetBoolean(13);
                }
                return mak;
            }
            catch { return null;  }
            finally { baglanti.Close(); }
        }

        public bool MakaleGuncelle(Makale mak)
        {
            try 
            {
                komut.CommandText = "UPDATE Makaleler SET Baslik = @baslik, KategoriID=@kategoriId, Ozet=@ozet, Icerik=@icerik, KapakResmi=@kapakresmi, AktifMi=@aktifmi WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", mak.ID);
                komut.Parameters.AddWithValue("@baslik", mak.Baslik);
                komut.Parameters.AddWithValue("@kategoriId", mak.KategoriID);
                komut.Parameters.AddWithValue("@ozet", mak.Ozet);
                komut.Parameters.AddWithValue("@icerik", mak.Icerik);
                komut.Parameters.AddWithValue("@kapakresmi", mak.KapakResim);
                komut.Parameters.AddWithValue("@aktifmi", mak.AktifMi);
                baglanti.Open();
                komut.ExecuteNonQuery();
                return true;
            }
            catch { return false; }
            finally { baglanti.Close(); }
        }

        public void MakaleDurumDegistir(int id)
        {
            try
            {
                komut.CommandText = "SELECT Aktifmi FROM Makaleler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                bool durum = Convert.ToBoolean(komut.ExecuteScalar());
                komut.CommandText = "UPDATE Makaleler SET Aktifmi=@a WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@a", !durum);
                komut.ExecuteNonQuery();
            }
            finally { baglanti.Close(); }
        }

        public void MakaleSil(int id)//SoftDelete
        {
            try
            {
                komut.CommandText = "UPDATE Makaleler SET SilindiMi=1 WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                komut.ExecuteNonQuery();
            }
            finally { baglanti.Close(); }
        }

        public void OkumaArttir(int id)
        {
            try
            {
                komut.CommandText = "SELECT OkunmaSayisi FROM Makaleler WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                int sayi = Convert.ToInt32(komut.ExecuteScalar());
                int yenisayi = sayi + 1;
                komut.CommandText = "UPDATE Makaleler SET OkunmaSayisi=@yenisayi WHERE ID=@id";
                komut.Parameters.Clear();
                komut.Parameters.AddWithValue("@id", id);
                komut.Parameters.AddWithValue("@yenisayi", yenisayi);
                komut.ExecuteNonQuery();
            }
            finally
            {
                baglanti.Close();
            }
        }

        #endregion
    }
}
