<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.K/Yonetici.Master" AutoEventWireup="true" CodeBehind="HaberGuncelle.aspx.cs" Inherits="HaberinOlsun.Yonetici.K.HaberGuncelle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/SayfaGorunus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formcontainer">
        <div class="formtittle">
            <h3>Haber Güncelle</h3>
        </div>
        <div class="formcontent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Haber güncellendi</label>
            </asp:Panel>
             <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Haber Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Kapak Resim</label><br /><br />
                    <asp:Image ID="img_resim" runat="server" Width="400" /><br />
                    Seçiniz : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row">
                    <label>Haberi Yayınla</label> 
                    <asp:CheckBox ID="cb_yayinla" runat="server"/>
                </div>
            </div>
            <div style="width:650px; float:left">
                <div class="row">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row" style="clear:both">
                <asp:LinkButton ID="lbtn_guncelle" runat="server" OnClick="lbtn_guncelle_Click">Haber Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
