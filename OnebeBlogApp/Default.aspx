<%@ Page Title="" Language="C#" MasterPageFile="~/ArayuzMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="OnebeBlogApp.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_Makaleler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="makale">
                <div class="resim">
                    <img src='MakaleResimleri/<%# Eval("KapakResim") %>' style="width:100%" />
                </div>
                <div class="baslik">
                    <h3><%# Eval("Baslik") %></h3>
                </div>
                <div class="kategoriveyazar">
                    Kategori = <%# Eval("Kategori") %> | Yazar = <%# Eval("Yazar") %>
                </div>
                <div class="ozet">
                    <%# Eval("Ozet") %>
                    <a href="#">Yazının Devamı =></a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
