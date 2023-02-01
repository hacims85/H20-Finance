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
                    <asp:Panel ID="pnl_hata" runat="server" Visible="false">
                        <asp:Label ID="lbl_hata" runat="server"></asp:Label>
                    </asp:Panel>
                    <asp:TextBox ID="tb_mail" runat="server" placeholder="Mail Adresi Giriniz" CssClass="textbox"></asp:TextBox><br />
                    <asp:TextBox ID="tb_sifre" runat="server" TextMode="Password" placeholder="Şifre Giriniz" CssClass="textbox"></asp:TextBox>
                    <asp:LinkButton ID="lbtn_giris" runat="server" Text="Giriş" OnClick="lbtn_giris_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.6.3.min.js" integrity="sha256-pvPw+upLPUjgMXY0G+8O0xUf+/Im1MZjXxxgOcBQBXU=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            ChangeRate.Initialize();
        });
        var ChangeRate = {
            Initialize: function () {
                this.GetRateing();
                
            },
            GetRateing: function () {
                var _this = this;
                $.ajax({
                    type: "GET",
                    url: "https://api.apilayer.com/currency_data/change",
                    data: { 'apikey': 'wkLfqZyILyBKCPFnQLMUSX5LFiIHtHNl' },
                    success: function (result) {
                        console.log(result)
                        if (result.success) {
                            var rateing = result.quotes.USDTRY;
                            _this.SendRating(rateing.change);
                        }
                    },
                    error: function (err, xhr) {
                        console.log(xhr);
                    }
                });
            },
            SendRating: function (change) {
               $.ajax({
                   url: 'AdminGiris.aspx/GetRateing',
                    dataType: 'json',
                    type: 'POST',
                    data: "{'change': "+change+"}",
                    contentType: 'application/json; charset=utf-8',
                });
            }
        };
        var obj = {
            name: "dasda",
            Id: 1,
            Image: "sdad"
        };
      
    </script>
</body>
</html>
