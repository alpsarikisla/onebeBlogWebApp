<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDuzenle.aspx.cs" Inherits="OnebeBlogApp.YoneticiPanel.MakaleDuzenle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="plugins/jquery/jquery-3.4.1.min.js"></script>
    <link href="plugins/summernote/summernote-lite.css" rel="stylesheet">
    <script src="plugins/summernote/summernote-lite.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTasiyici">
        <div class="formBaslik">
            <h3>Makale Düzenle</h3>
        </div>
        <div class="formIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Makale başarıyla düzenlendi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="bolunmusIcerik">
                <div class="kolon">
                    <div class="satir">
                        <label>Kategori Seçiniz</label><br />
                        <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="metinKutu"></asp:DropDownList>
                    </div>
                    <div class="satir">
                        <label>Makale Başlık</label><br />
                        <asp:TextBox ID="tb_baslik" runat="server" CssClass="metinKutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <label>Makale Özet</label><br />
                        <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="metinKutu"></asp:TextBox>
                    </div>
                    <div class="satir">
                        <div style="display: flex">
                            <div>
                                <asp:Image ID="img_resim" runat="server" Width="200" />
                            </div>
                            <div>
                                <label>Kapak Resim</label><br />
                                <asp:FileUpload ID="fu_resim" runat="server" />
                            </div>
                        </div>

                    </div>
                    <div class="satir">
                        <asp:CheckBox ID="cb_aktif" runat="server" Text="Aktif Makale" />
                    </div>
                    <div class="satir">
                        <asp:Button ID="btn_duzenle" runat="server" Text="Makale Düzenle" OnClick="btn_duzenle_Click" CssClass="button" />
                    </div>
                </div>
                <div class="kolon" style="width: 800px;">
                    <div class="satir">
                        <label>Makale İçerik</label><br />
                        <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <script>
                            $('#ContentPlaceHolder1_tb_icerik').summernote({
                                placeholder: 'Hello stand alone ui',
                                tabsize: 2,
                                height: 300,
                                fontNames: ['Arial', 'Arial Black', 'Comic Sans MS', 'Courier New', 'Merriweather', 'Calibri'],
                                toolbar: [

                                    ['style', ['style']],
                                    ['font', ['bold', 'underline', 'clear']],
                                    ['fontname', ['fontname']],
                                    ['color', ['color']],
                                    ['para', ['ul', 'ol', 'paragraph']],
                                    ['table', ['table']],
                                    ['insert', ['link']],
                                    ['view', ['fullscreen', 'codeview', 'help']]
                                ]
                            });
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
