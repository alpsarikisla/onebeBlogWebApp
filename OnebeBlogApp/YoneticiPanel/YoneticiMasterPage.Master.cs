using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class YoneticiMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yonetici"] != null) 
            {
                Yonetici yon = (Yonetici)Session["yonetici"];//Unboxing
                lbl_kullanici.Text = yon.Isim + " " + yon.Soyisim + " (" + yon.YoneticiTur + ")";
            }
            else
            {
                Response.Redirect("YoneticiGiris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yonetici"] = null;
            Response.Redirect("YoneticiGiris.aspx");
        }
    }
}