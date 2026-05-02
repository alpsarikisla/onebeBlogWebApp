<%@ Page Title="" Language="C#" MasterPageFile="~/ArayuzMaster.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="OnebeBlogApp.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="baslik">
            <h1>Üye Ol</h1>
            <label>Üye Olmak için lütfen aşağıdaki alanları eksiksiz doldurunuz.</label>
        </div>
        <div class="icerik">
            <asp:Panel ID="pnl_mesaj" runat="server" class="mesajKutu" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server" Text="Geçici Mesaj"></asp:Label>
            </asp:Panel>
            <div class="satir">
                <label>Adınız</label><br />
                <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Soyadınız</label><br />
                <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Mail Adresiniz</label><br />
                <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Şireniz</label><br />
                <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <label>Şifre Tekrar</label><br />
                <asp:TextBox ID="tb_sifretekrar" runat="server" CssClass="metinKutu"></asp:TextBox>
            </div>
            <div class="satir">
                <asp:Button ID="lbtn_kaydol" runat="server" CssClass="kayitButon" OnClick="lbtn_kaydol_Click" Text="Kayıt Ol" />
            </div>
        </div>
    </div>
</asp:Content>
