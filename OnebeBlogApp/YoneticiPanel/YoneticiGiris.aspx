<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YoneticiGiris.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.YoneticiGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yönetici Giriş</title>
    <link href="css/GirisStil.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="anaTasiyici golgelik">
            <div class="baslikTasiyici">
                <h1 class="baslik">Yönetici Giriş</h1>
                <p class="altBaslik">Hesabınıza giriş yapabilmek için lütfen sizden istenen giriş bilgilerini eksiszsiz giriniz.</p>
            </div>
            <div class="icerik">
                <asp:Panel ID="pnl_mesaj" runat="server" class="mesajKutu" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server" Text="Geçici Mesaj"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <asp:TextBox ID="tb_mail" runat="server" TextMode="Email" CssClass="metinKutu" placeholder="Mail Adresiniz"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" CssClass="metinKutu" placeholder="Şifreniz"></asp:TextBox>
                </div>
                <div class="satir" style="text-align:right">
                    <a href="#" class="sifreUnuttum">Şifremi unuttum</a>
                </div>
                <div class="satir">
                    <asp:Button ID="btn_giris" runat="server" CssClass="girisButton" Text="Giriş Yap" OnClick="btn_giris_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
