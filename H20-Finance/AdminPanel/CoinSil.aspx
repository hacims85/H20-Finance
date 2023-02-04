<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="CoinSil.aspx.cs" Inherits="H20_Finance.AdminPanel.CoinSil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="talepcontainer">
        <div class="liste">
            <asp:ListView ID="lv_coinsil" runat="server" OnItemCommand="lv_coinsil_ItemCommand">
                <LayoutTemplate>
                    <table border="1" class="taleptable">
                        <tr>
                            <th>Coin No</th>
                            <th>Coin Adı</th>
                            <th>Coin Kısaltması</th>
                            <th colspan="2">Fiyatı</th>
                        </tr>
                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <td><%# Eval("ID") %></td>
                    <td><%# Eval("Isim") %></td>
                    <td><%# Eval("CoinNick") %></td>
                    <td><%# Eval("Fiyat") %></td>
                    <td>
                        <asp:LinkButton ID="coinSil" runat="server" CommandArgument='<%# Eval("ID") %>' CommandName="sil">SİL</asp:LinkButton>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
