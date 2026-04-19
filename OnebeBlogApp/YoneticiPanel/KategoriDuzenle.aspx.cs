using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
               if(!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
                    Kategori kat = db.KategoriGetir(id);
                    tb_isim.Text = kat.Isim;
                    cb_aktif.Checked = kat.Aktifmi;
                }
            }
            else
            {
                Response.Redirect("KategoriListeleListView.aspx");
            }
        }

        protected void btn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kategoriid"]);
            Kategori kat = new Kategori();
            kat.ID = id;
            kat.Isim = tb_isim.Text;
            kat.Aktifmi = cb_aktif.Checked;

            if (db.KategoriGuncelle(kat))
            {
                pnl_basarili.Visible = true;
                pnl_basarisiz.Visible = false;
            }
            else
            {
                pnl_basarisiz.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Kategori güncellenirken bir hata oluştu";
            }
        }
    }
}