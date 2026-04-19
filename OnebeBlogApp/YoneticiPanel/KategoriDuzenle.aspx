<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formTasiyici">
     <div class="formBaslik">
         <h3>Kategori Düzenle</h3>
     </div>
     <div class="formIcerik">
         <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
             <label>Kategori başarıyla düzenlendi</label>
         </asp:Panel>
         <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
             <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
         </asp:Panel>
         <div class="satir">
             <label>Kategori Adı</label><br />
             <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
         </div>
         <div class="satir">
             <asp:CheckBox ID="cb_aktif" runat="server" Text="Aktif Kategori" />
         </div>
         <div class="satir">
             <asp:Button ID="btn_duzenle" runat="server" Text="Kategori Düzenle" OnClick="btn_duzenle_Click" CssClass="button" />
         </div>
     </div>
 </div>
</asp:Content>
