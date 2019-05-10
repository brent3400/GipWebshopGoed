<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MandjeLeeg.aspx.cs" Inherits="WebshopSneakersgip.MandjeLeeg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td>Het winkelmandje is leeg. Klik op de volgende knop om terug naar de catalogus te gaan</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" OnClick="btnOk_Click" Text="Terug naar catalogus..." />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
