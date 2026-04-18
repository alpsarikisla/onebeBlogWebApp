using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VeriErisimKatmani;

namespace OnebeBlogApp.YoneticiPanel
{
    public partial class YoneticiGiris : System.Web.UI.Page
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            #region Basic Way

            //if(!string.IsNullOrEmpty(tb_mail.Text))
            //{
            //    if(!string.IsNullOrEmpty(tb_sifre.Text))
            //    {

            //    }
            //    else
            //    {
            //        pnl_mesaj.Visible = true;
            //        lbl_mesaj.Text = "Şifre boş bırakılamaz";
            //    }
            //}
            //else
            //{
            //    pnl_mesaj.Visible = true;
            //    lbl_mesaj.Text = "Mail adresi boş bırakılamaz";
            //}

            #endregion

            #region Advence Way

            bool durum = true;
            string mesaj = "";
            if (string.IsNullOrEmpty(tb_mail.Text))
            {
                mesaj = "mail adresi ";
                durum = false;
            }
            if (string.IsNullOrEmpty(tb_sifre.Text))
            {
                mesaj += "şifre ";
                durum = false;
            }

            if (!durum)
            {
                pnl_mesaj.Visible = true;
                lbl_mesaj.Text = mesaj + " boş bırakılamaz";
            }
            else
            {
                Yonetici yon = db.YoneticiGiris(tb_mail.Text, tb_sifre.Text);
                if (yon != null) {
                    if (yon.AktifMi)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        pnl_mesaj.Visible = true;
                        lbl_mesaj.Text = "Hesabınız sistem yöneticisi tarafından kapatılmış";
                    }
                }
                else
                {
                    pnl_mesaj.Visible = true;
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı. Mail ve şifrenizi kontrol ediniz";
                }
            }

            #endregion
        }
    }
}