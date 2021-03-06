﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Winkelmandje.aspx.cs" Inherits="WebshopSneakersgip.Winkelmandje" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            width: 169px;
        }
        .auto-style3 {
            width: 800px;
        }
        .auto-style4 {
            text-align: right;
        }
        .auto-style5 {
            text-align: center;
        }
        .auto-style6 {
            text-align: right;
            height: 23px;
        }
        .auto-style7 {
            text-align: right;
            height: 23px;
            width: 648px;
        }
        .auto-style8 {
            text-align: right;
            width: 648px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop -Winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">Klantnummer: </td>
                    <td>
                        <asp:Label ID="lblKlantID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Naam:</td>
                    <td>
                        <asp:Label ID="lblNaam" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Adres:</td>
                    <td>
                        <asp:Label ID="lblAdres" runat="server"></asp:Label>
                        <br />
                        <asp:Label ID="lblPcGe" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Besteldatum:</td>
                    <td>
                        <asp:Label ID="lblDatum" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <asp:GridView ID="gvWinkelmand" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvWinkelmand_SelectedIndexChanged">
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/Files/btnDelete.jpg" ShowSelectButton="True">
                    <ControlStyle Height="45px" Width="45px" />
                    <ItemStyle Width="50px" />
                    </asp:CommandField>
                    <asp:ImageField DataImageUrlField="Foto" DataImageUrlFormatString="~\Files\{0}" HeaderText="Foto">
                        <ControlStyle Height="225px" Width="225px" />
                        <ItemStyle Width="250px" />
                    </asp:ImageField>
                    <asp:BoundField DataField="ProductID" HeaderText="ArtNr">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Naam" HeaderText="Naam">
                    <ItemStyle Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Aantal" DataField="Aantal">
                    <ItemStyle Width="50px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Prijs" HeaderText="Prijs">
                    <ItemStyle Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Totaal" DataField="Totaal" />
                </Columns>
            </asp:GridView>
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style7">Totaal excl. BTW:</td>
                    <td class="auto-style6">
                        <asp:Label ID="lblExclBTW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">BTW:</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblBTW" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Totaal incl. BTW:</td>
                    <td class="auto-style4">
                        <asp:Label ID="lblInclBTW" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <br />
            <table class="auto-style3">
                <tr>
                    <td class="auto-style5">
                        <asp:Button ID="btnBestellen" runat="server" Text="Bestellen..." OnClick="btnBestellen_Click" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
