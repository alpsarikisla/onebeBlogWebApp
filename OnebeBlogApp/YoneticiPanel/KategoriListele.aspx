<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            Kategoriler
        </div>
        <div class="formIcerik">
            <asp:GridView ID="gv_kategoriler" runat="server" CssClass="tablo"></asp:GridView>
        </div>
    </div>
</asp:Content>
