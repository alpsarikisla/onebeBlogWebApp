using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class KategoriListeleListView : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kategoriler.DataSource = db.KategoriListele();
            lv_kategoriler.DataBind();
        }

        protected void lv_kategoriler_ItemCommand(object sender, ListViewCommandEventArgs durtukleyen)
        {
            if (durtukleyen.CommandName == "durum")
            {
                int id = Convert.ToInt32(durtukleyen.CommandArgument);
                db.KategoriDurumDegistir(id);
            }
            if (durtukleyen.CommandName == "sil")
            {
                int id = Convert.ToInt32(durtukleyen.CommandArgument);
                db.KategoriSil(id);
            }
            lv_kategoriler.DataSource = db.KategoriListele();
            lv_kategoriler.DataBind();
        }
    }
}