<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMasterPage.Master" AutoEventWireup="true" CodeBehind="KategoriListeleListView.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.KategoriListeleListView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Kategoriler</h3>
        </div>
        <div class="formTabloIcerik">
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                           <%-- <th>ID</th>--%>
                            <th>Kategori Adı</th>
                            <th>Ekleme Tarihi</th>
                            <th>Aktif Kategori</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                       <%-- <td><%# Eval("ID") %></td>--%>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("KayitTarihi") %></td>
                        <td><%# Eval("Aktifmi") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="tablebutton durum" CommandName="durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='KategoriDuzenle.aspx?kategoriid=<%# Eval("ID") %>' class="tablebutton duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablebutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alt">
                       <%-- <td><%# Eval("ID") %></td>--%>
                        <td><%# Eval("Isim") %></td>
                        <td><%# Eval("KayitTarihi") %></td>
                        <td><%# Eval("Aktifmi") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="tablebutton durum" CommandName="durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='KategoriDuzenle.aspx?kategoriid=<%# Eval("ID") %>' class="tablebutton duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablebutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>sil</asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
