using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp
{
    public partial class ArayuzMaster : System.Web.UI.MasterPage
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = db.AktifKategoriListele();
            rp_kategoriler.DataBind();
        }
    }
}