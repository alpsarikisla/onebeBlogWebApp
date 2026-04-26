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
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["makaleid"]);
                if(!IsPostBack)
                {
                    ddl_kategoriler.DataTextField = "Isim";
                    ddl_kategoriler.DataValueField = "ID";
                    ddl_kategoriler.DataSource = db.KategoriListele();
                    ddl_kategoriler.DataBind();
                    Makale mak = db.MakaleGetir(id);
                    if (mak != null)
                    {
                        tb_baslik.Text = mak.Baslik;
                        tb_icerik.Text = mak.Icerik;
                        tb_ozet.Text = mak.Ozet;
                        ddl_kategoriler.SelectedValue = mak.KategoriID.ToString();
                        cb_aktif.Checked = mak.AktifMi;
                        img_resim.ImageUrl = "../MakaleResimleri/" + mak.KapakResim;
                    }
                    else
                    {
                        Response.Redirect("MakaleListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void btn_duzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_baslik.Text)) 
            {
                int id = Convert.ToInt32(Request.QueryString["makaleid"]);
                Makale mak = db.MakaleGetir(id);
                mak.Baslik = tb_baslik.Text;
                mak.KategoriID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                mak.AktifMi = cb_aktif.Checked;
                mak.Ozet = tb_ozet.Text;
                mak.Icerik = tb_icerik.Text;
                bool uzantiOnay = true;

                if (fu_resim.HasFile)//file upload'ta resim seçilmiş ise
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
                if(uzantiOnay)
                {
                    if(db.MakaleGuncelle(mak))
                    {
                        pnl_basarili.Visible = true;
                        pnl_basarisiz.Visible = false;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Makale düzenlenirken bir hata oluştu";
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