using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnebeBlogApp
{
    public partial class UyeOl : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_kaydol_Click(object sender, EventArgs e)
        {
            if(tb_sifre.Text.Length >= 8)
            {
                if (tb_sifre.Text == tb_sifretekrar.Text)
                {

                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Şifreler uyuşmuyor";
                }
            }
            else
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = "Şifre en az 8 karakter olmalıdır";
            }
        }
    }
}