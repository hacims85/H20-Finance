<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="CoinSil.aspx.cs" Inherits="H20_Finance.AdminPanel.CoinSil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="coinSilContainer">
        <asp:ListView ID="lv_coinsil" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Coin No</th>
                        <th>Coin Adı</th>
                        <th>Coin Kısaltması</th>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:ListView>
    </div>
</asp:Content>
