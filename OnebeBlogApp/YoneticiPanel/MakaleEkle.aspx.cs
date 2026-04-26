using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_kategoriler.DataTextField = "Isim";
            ddl_kategoriler.DataValueField = "ID";
            ddl_kategoriler.DataSource = db.AktifKategoriListele();
            ddl_kategoriler.DataBind();
        }

        protected void btn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text))
            {
                Makale mak = new Makale();
                mak.Baslik = tb_baslik.Text;
                mak.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.Ozet = tb_ozet.Text;
                mak.Icerik = tb_icerik.Text;
                mak.AktifMi = cb_aktif.Checked;
                mak.YayinTarihi = DateTime.Now;
                Yonetici y = (Yonetici)Session["yonetici"];
                mak.YazarID = y.ID;
                mak.SilindiMi = false;
                mak.OkumaSayisi = 0;
                mak.BegeniSayisi = 0;

                bool uzantiOnay = true;

                if(fu_resim.HasFile)//file upload'ta resim seçilmiş ise
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    string uzanti = fi.Extension;//uzantı bilgisi . ile birlikte gelir örn=.txt
                    if (uzanti == ".jpg" || uzanti == ".png" || uzanti == ".jpeg")
                    {
                        string essizIsim = Guid.NewGuid().ToString();
                        string tamisim = essizIsim + uzanti;
                        mak.KapakResim = tamisim;
                        fu_resim.SaveAs(Server.MapPath("../MakaleResimleri/" + tamisim));
                    }
                    else
                    {
                        uzantiOnay = false;
                    }
                }
                else
                {
                    mak.KapakResim = "yog.jpg";
                }

                if(uzantiOnay)
                {
                    if(db.MakaleEkle(mak))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Makale Eklenirken bir hata oluştu";
                    }
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Sadece jpg, jpeg ve png dosyaları kabul edilir";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Makale başlığı boş bırakılamaz";
            }
        }
    }
}