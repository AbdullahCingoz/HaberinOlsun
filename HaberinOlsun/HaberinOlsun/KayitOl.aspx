<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="KayitOl.aspx.cs" Inherits="HaberinOlsun.KayitOl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Gorunum.css" rel="stylesheet" />
    <link href="css/Giris.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTitle">
        <h3>Kayıt Ol</h3>
    </div>
    <div class="girisForm form">
        <div class="row" style="text-align:center">
            <img src="Images/instagram-g2cf3718fa_640.png" class="loginpanelimage" />
        </div>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basariliMesaj" Visible="false">
            <label>Kayıt işlemi başarılı</label>
        </asp:Panel>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
          <div class="row">
            <asp:TextBox ID="tb_isim" runat="server" CssClass="textbox" placeholder="İsim"></asp:TextBox>
        </div>
          <div class="row">
            <asp:TextBox ID="tb_soyad" runat="server" CssClass="textbox" placeholder="Soyisim"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_kullaniciad" runat="server" CssClass="textbox" placeholder="Kullanıcı Adı"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_mail" TextMode="Email" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row">
            <asp:LinkButton ID="lbtn_kayit" runat="server" OnClick="lbtn_kayit_Click" CssClass="formbutton">Kayıt Ol</asp:LinkButton>
        </div>
    </div>
</asp:Content>
