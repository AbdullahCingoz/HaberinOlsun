<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="HaberinOlsun.Yonetici.K.Giris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/YonGiris.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="box">
            <div class="baslik">
                <h3>Yönetici Giriş</h3>
            </div>
            <div class="contentcontainer">
                <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div>
                    <label>Mail</label> <br />
                    <asp:TextBox ID="tb_mail" runat="server" CssClass="metinkutu" placeholder="Mail"></asp:TextBox>
                </div>
                <div>
                    <label>Şifre</label> <br />
                    <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinkutu" placeholder="şifre" TextMode="Password"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btn_giris" runat="server" Text="Giriş Yap" OnClick="btn_giris_Click" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>
