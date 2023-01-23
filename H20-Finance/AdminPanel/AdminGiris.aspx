<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminGiris.aspx.cs" Inherits="H20_Finance.AdminPanel.AdminGiris" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Giriş</title>
    <link href="https://fonts.googleapis.com/css2?family=Unbounded&display=swap" rel="stylesheet">
    <link href="Style/MainCss.css" rel="stylesheet" />
    <link href="Style/AdminGirisCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="height: 100%">
        <div class="giris">
            <div class="container silver">

                <div class="content">
                    <img src="Image/H2oDamlaLogo.png" /><br />
                    <asp:TextBox ID="tb_mail" runat="server" placeholder="Mail Adresi Giriniz" CssClass="textbox"></asp:TextBox><br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" placeholder="Şifre Giriniz" CssClass="textbox"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş" OnClick="lbtn_giris_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
