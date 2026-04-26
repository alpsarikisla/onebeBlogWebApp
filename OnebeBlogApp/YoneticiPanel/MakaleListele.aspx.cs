using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            gridDoldur();
        }

        protected void lv_makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                db.MakaleDurumDegistir(id);
            }
            if (e.CommandName =="sil")
            {
                db.MakaleSil(id);
            }
            gridDoldur();
        }

        private void gridDoldur()
        {
            lv_makaleler.DataSource = db.MakaleListele(false);
            lv_makaleler.DataBind();
        }
    }
}