<%@ Page Title="" Language="C#" MasterPageFile="~/ArayuzMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnebeBlogApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_Makaleler" runat="server">
        <LayoutTemplate>
            <h3>En Çok Okunanlar</h3>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="makale">
                <div class="resim">
                     <a href="MakaleDetay.aspx?mid=<%# Eval("ID") %>" class="devamLink"><img src='MakaleResimleri/<%# Eval("KapakResim") %>' style="width: 100%" /></a>
                </div>
                <div class="baslik">
                     <a href="MakaleDetay.aspx?mid=<%# Eval("ID") %>" class="devamLink"><h3><%# Eval("Baslik") %></h3></a>
                </div>
                <div class="kategoriveyazar">
                    Kategori = <%# Eval("Kategori") %> | Yazar = <%# Eval("Yazar") %>
                </div>
                <div class="begeniveGoruntuleme">
                    Görüntüleme Sayı = <%# Eval("OkumaSayisi") %> | Beğeni Sayısı = <%# Eval("BegeniSayisi") %>
                </div>
                <div class="ozet">
                    <%# Eval("Ozet") %>
                </div> 
                <a href='MakaleDetay.aspx?mid=<%# Eval("ID") %>' class="devamLink">Yazının Devamı =></a>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
