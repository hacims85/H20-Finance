<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="nft_Ekle.aspx.cs" Inherits="H20_Finance.AdminPanel.nft_Ekle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="ekle_Container">
        <div class="ekle_Title">
            <h2>NFT Ekle</h2>
        </div>
        <div class="ekle_content">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                NFT Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>

            <asp:TextBox ID="tb_isim" runat="server" placeholder="Nft Adı Giriniz" CssClass="textbox"></asp:TextBox>
            <asp:TextBox ID="tb_fiyat" runat="server" placeholder="Fiyat Giriniz" CssClass="textbox"></asp:TextBox>
            <label>Resim Ekle</label>
            <br />
            <asp:FileUpload ID="fu_resim" runat="server" CssClass="resimekle"></asp:FileUpload>
            <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click">EKLE</asp:LinkButton>
        </div>
</asp:Content>
