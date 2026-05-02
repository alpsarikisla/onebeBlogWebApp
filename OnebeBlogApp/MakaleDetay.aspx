<%@ Page Title="" Language="C#" MasterPageFile="~/ArayuzMaster.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="OnebeBlogApp.MakaleDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="makaledetay">
     <div class="resim">
         <asp:Image ID="img_resim" runat="server" Width="100%" />
     </div>
     <div class="baslik" style="text-align:left;">
         <h2>
             <asp:Label ID="lbl_baslik" runat="server"></asp:Label>
         </h2>
     </div>
     <div class="kategoriveyazar">
         kategori = <asp:Label ID="lbl_kategori" runat="server"></asp:Label> | Yazar = <asp:Label ID="lbl_yazar" runat="server"></asp:Label>
     </div>
     <div class="begeniveGoruntuleme">
          Beğeni Sayı = <asp:Label ID="lbl_begeni" runat="server"></asp:Label> | Görüntüleme Sayı = <asp:Label ID="lbl_goruntuleme" runat="server"></asp:Label>
     </div>
     <div class="ozet">
         <asp:literal ID="ltrl_icerik" runat="server"></asp:literal>
     </div>
 </div>
 <div class="yorumAlani">
     <asp:Panel ID="pnl_girisVar" runat="server"></asp:Panel>
      <asp:Panel ID="pnl_girisYok" runat="server"></asp:Panel>
 </div>
</asp:Content>
