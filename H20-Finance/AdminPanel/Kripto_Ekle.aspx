<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPanel/AdminPanelMasterPage.Master" AutoEventWireup="true" CodeBehind="Kripto_Ekle.aspx.cs" Inherits="H20_Finance.AdminPanel.Kripto_Ekle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ekle_Container">
        <div class="ekle_Title">
            <h2>Kripto Ekle</h2>
        </div>
        <div class="ekle_content">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kripto Ekleme Başarılı
            </asp:Panel>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>

            <asp:TextBox ID="tb_isim" runat="server" placeholder="İsim Giriniz" CssClass="textbox"></asp:TextBox>
            <asp:TextBox ID="tb_nick" runat="server" placeholder="Kısaltma Giriniz" CssClass="textbox"></asp:TextBox>
            <asp:TextBox ID="tb_arz" runat="server" placeholder="Max Arz Değerini Giriniz" CssClass="textbox"></asp:TextBox>
            <asp:TextBox ID="tb_fiyat" runat="server" placeholder="Fiyat Giriniz" CssClass="textbox"></asp:TextBox>
            <label>Resim Ekle</label>
            <br />
            <asp:FileUpload ID="fu_resim" runat="server" CssClass="resimekle"></asp:FileUpload>
            <div class="check">
                <label style="text-align: center">Aktif</label><br />
                <asp:CheckBox ID="cb_aktif" runat="server"></asp:CheckBox>
            </div>
            <asp:LinkButton ID="lbtn_ekle" runat="server" OnClick="lbtn_ekle_Click">EKLE</asp:LinkButton>
        </div>
    </div>
</asp:Content>
