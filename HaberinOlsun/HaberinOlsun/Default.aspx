<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HaberinOlsun.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/Gorunum.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="lv_haberler" runat="server">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="haberr">
                <div class="title">
                    <h2><%# Eval("Baslik")%></h2>
                </div>
                <div class="image">
                    <img src ="HaberResimleri/<%# Eval("KapakResim") %>"/>
                </div>
                <div class="subcontent">
                    Kategori: <%# Eval("Kategori") %> | Yazar: <%# Eval("Yazar") %>
                </div>
                <div class="summary">
                    <%# Eval("Ozet") %>
                </div>
                <div class="button">
                    <a href="HaberDetay.aspx?hid=<%# Eval("ID") %>">Haberin Devamı</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
