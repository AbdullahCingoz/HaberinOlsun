<%@ Page Title="" Language="C#" MasterPageFile="~/Yonetici.K/Yonetici.Master" AutoEventWireup="true" CodeBehind="HaberListele.aspx.cs" Inherits="HaberinOlsun.Yonetici.K.HaberListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Css/SayfaGorunus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="formContainer">
       <div class="formtitle">
           <h3>Haberler</h3>
       </div>
       <div class="formContent">
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizMesaj" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
           <asp:ListView ID="lv_haberler" runat="server" OnItemCommand="lv_haberler_ItemCommand">
               <LayoutTemplate>
                    <table class="listTable">
                       <tr>
                           <th>Resim</th>
                           <th>ID</th>
                           <th>Baslik</th>
                           <th>Kategori</th>
                           <th>Yazar</th>
                           <th>Ekleme Tarihi</th>
                           <th>Görüntülenme Sayısı</th>
                           <th>Durum</th>
                           <th>Seçenekler</th>
                       </tr>
                       <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                   </table>
               </LayoutTemplate>
               <ItemTemplate>
                   <tr>
                       <td> <img src='../HaberResimleri/ <%# Eval("KapakResim") %>' /></td>
                       <td> <%# Eval("ID") %></td>
                       <td> <%# Eval("Baslik") %></td>
                       <td> <%# Eval("Kategori") %></td>
                       <td> <%# Eval("Yazar") %></td>
                       <td> <%# Eval("EklemeTarih") %></td>
                       <td> <%# Eval("GoruntulemeSayisi") %></td>
                       <td> <%# Eval("Durum") %></td>
                    <td>
                           <asp:LinkButton ID="lbtn_durumdegistir" runat="server" CommandName="Durum" CommandArgument=' <%# Eval("ID") %>' CssClass="tablebutton status"> Durum </asp:LinkButton>
                            <a href='HaberGuncelle.aspx?guncelle=<%# Eval("ID") %>' class="tablebutton update">Güncelle</a>
                           <asp:LinkButton ID="lbtn_sil" runat="server" CommandName="sil" CommandArgument='<%# Eval("ID") %>' CssClass="tablebutton delete">Sil</asp:LinkButton>
                       </td>
                   </tr>
               </ItemTemplate>
           </asp:ListView> 
           </div>
         </div>
</asp:Content>
