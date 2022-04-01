<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.K/Yonetici.Master" AutoEventWireup="true" CodeBehind="HaberEkle.aspx.cs" Inherits="HaberinOlsun.Yonetici.K.HaberEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/SayfaGorunus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formcontainer">
        <div class="formtittle">Haber Ekle</div>
        <div class="formcontent">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
                <label>Haber eklendi</label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div style="width:500px; float:left">
                <div class="row">
                    <label>Haber Başlık</label><br />
                    <asp:TextBox ID="tb_baslik" runat="server" CssClass="formInput"></asp:TextBox>
                </div>
                <div class="row">
                    <label>Kategori</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="formInput" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>
                <div class="row">
                    <label>Kapak Resmi</label><br />
                    Seç : <asp:FileUpload ID="fu_resim" runat="server" />
                </div>
                <div class="row">
                    <label>Haberi Yayınla</label>
                    <asp:CheckBox ID="cb_yayınla" runat="server" />
                </div>
            </div>
            <div style="width:500px; float:left ">
                <div class="row">
                    <label>Özet</label><br />
                    <asp:TextBox ID="tb_ozet" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
                 <div class="row">
                    <label>İçerik</label><br />
                    <asp:TextBox ID="tb_icerik" runat="server" CssClass="formInput" TextMode="MultiLine"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click" CssClass="formButton">Haber Ekle</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
