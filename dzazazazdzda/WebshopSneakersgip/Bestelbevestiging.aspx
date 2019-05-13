<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bestelbevestiging.aspx.cs" Inherits="WebshopSneakersgip.Bestelbevestiging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Bestelbevestiging</h2>
            <table class="auto-style1">
                <tr>
                    <td>Uw bstelling met ordernummer
                        <asp:Label ID="lblOrderID" runat="server" Font-Bold="True"></asp:Label>
&nbsp;werd door ons goed ontvangen</td>
                </tr>
                <tr>
                    <td>Na betaling van
                        <asp:Label ID="lblTotaal" runat="server" Font-Bold="True"></asp:Label>
&nbsp;op rekeningnummer
                        <asp:Label ID="lblRekeningNr" runat="server" Font-Bold="True" Text="BE91 5612 1236 7895"></asp:Label>
&nbsp;zullen wij overgaan tot de verzending van de sneakers.</td>
                </tr>
                <tr>
                    <td>Gelieve het ordernummer als betalingsreferentie mee te geven.</td>
                </tr>
                <tr>
                    <td>Bedankt voor uw vertrouwen!</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
