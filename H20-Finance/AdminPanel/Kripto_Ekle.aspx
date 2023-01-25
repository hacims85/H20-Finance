<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Kripto_Ekle.aspx.cs" Inherits="H20_Finance.AdminPanel.Kripto_Ekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="tb_isim" runat="server" placeholder="İsim Giriniz" CssClass="textbox"></asp:TextBox>
    <asp:TextBox ID="tb_nick" runat="server" placeholder="Nick Giriniz" CssClass="textbox"></asp:TextBox>
    <asp:TextBox ID="tb_arz" runat="server" placeholder="Max Arz Değerini Giriniz" CssClass="textbox"></asp:TextBox>
</asp:Content>
