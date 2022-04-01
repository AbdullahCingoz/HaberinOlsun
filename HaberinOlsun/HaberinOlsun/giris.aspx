<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="giris.aspx.cs" Inherits="HaberinOlsun.giris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Giris.css" rel="stylesheet" />
    <link href="css/Gorunum.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formTitle">
        <h3>Üye Giriş</h3>
    </div>
    <div class="girisForm form">
        <div class="row" style="text-align:center">
            <img src="Images/1234.png" class="loginpanelimage"/>
        </div>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="row">
            <asp:TextBox ID="tb_mail" TextMode="Email" runat="server" CssClass="textbox" placeholder="Mail"></asp:TextBox>
        </div>
        <div class="row">
            <asp:TextBox ID="tb_sifre" TextMode="Password" runat="server" CssClass="textbox" placeholder="Şifre"></asp:TextBox>
        </div>
        <div class="row" style="text-align:center">
            <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş Yap" OnClick="lbtn_giris_Click" CssClass="formbutton"></asp:LinkButton>
        </div>
    </div>
</asp:Content>
