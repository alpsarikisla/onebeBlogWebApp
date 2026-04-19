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
    }
}
