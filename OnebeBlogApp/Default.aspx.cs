using System;
using VeriErisimKatmani;

namespace OnebeBlogApp
{
    public partial class Default : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Makaleler.DataSource = db.MakaleListele(false);
            lv_Makaleler.DataBind();
        }
    }
}