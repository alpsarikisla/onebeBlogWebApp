using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                db.OkumaArttir(id);
                Makale m = db.MakaleGetir(id);
                lbl_baslik.Text = m.Baslik.ToString();
                lbl_begeni.Text = m.BegeniSayisi.ToString();
                lbl_goruntuleme.Text = m.OkumaSayisi.ToString();
                lbl_kategori.Text = m.Kategori;
                lbl_yazar.Text = m.Yazar;
                ltrl_icerik.Text = m.Icerik;
                img_resim.ImageUrl = "MakaleResimleri/" + m.KapakResim;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}