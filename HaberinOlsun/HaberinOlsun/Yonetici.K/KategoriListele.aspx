<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.K/Yonetici.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="HaberinOlsun.Yonetici.K.KategoriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/SayfaGorunus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formcontainer">
        <div class="formtittle">
            <h3>Kategoriler</h3>
        </div>
        <div class="formcontent contenttable">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:ListView ID="lv_kategoriler" runat="server" OnItemCommand="lv_kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table class="listTable" cellspacing="0" cellpadding="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Seçenekler</th>
                        </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td><%# Eval("Isim") %></td>
                        <td>
                            <a href='KategoriGuncelle.aspx?kid=<%# Eval("ID")%>' class="tablebutton update">Güncelle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="Sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
