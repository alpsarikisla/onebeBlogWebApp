<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.MakaleListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makaleler</h3>
        </div>
        <div class="formTabloIcerik">
            <marquee scrollamount="10">Al Sana Kayan Yazı</marquee>
            <asp:ListView ID="lv_makaleler" runat="server" OnItemCommand="lv_makaleler_ItemCommand">
                <LayoutTemplate>
                    <table class="tablo" cellpadding="0" cellspacing="0">
                        <tr>
                            <th>MakaleResim</th>
                            <th>Başlık</th>
                            <th>Kategori</th>
                            <th>Yazar</th>
                            <th>Yayın Tarihi</th>
                            <th>Okunma Sayı</th>
                            <th>Görüntüleme Sayı</th>
                            <th>Yayın Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <img src='../MakaleResimleri/<%# Eval("KapakResim") %>' width="80" />
                        </td>
                        <td><%# Eval("Baslik") %></td>
                        <td><%# Eval("Kategori") %></td>
                        <td><%# Eval("Yazar") %></td>
                        <td><%# Eval("YayinTarihi") %></td>
                        <td><%# Eval("OkumaSayisi") %></td>
                        <td><%# Eval("BegeniSayisi") %></td>
                        <td><%# Eval("AktifMi") %></td>
                        <td>
                            <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="tablebutton durum" CommandName="durum" CommandArgument='<%# Eval("ID") %>'>Durum Değiştir</asp:LinkButton>
                            <a href='MakaleDuzenle.aspx?makaleid=<%# Eval("ID") %>' class="tablebutton duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablebutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
