using System;
using VeriErisimKatmani;

namespace OnebeBlogApp
{
    public partial class Default : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString.Count == 0)
            {
                lv_Makaleler.DataSource = db.MakaleListele(false, true);
                lv_Makaleler.DataBind();
            }
            else
            {
                string id = Request.QueryString["kid"];
                lv_Makaleler.DataSource = db.MakaleListele(id, false, true);
                lv_Makaleler.DataBind();
            }
        }
    }
}