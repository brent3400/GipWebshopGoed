<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Toevoegen.aspx.cs" Inherits="WebshopSneakersgip.Toevoegen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 850px;
        }
        .auto-style2 {
            width: 500px;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 500px;
            height: 34px;
        }
        .auto-style5 {
            height: 34px;
        }
        .auto-style6 {
            width: 600px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Item toevoegen aan het winkelmandje</h2>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <asp:Image ID="imgProduct" runat="server" Height="300px" Width="450px" />
                    </td>
                    <td>
                        <table class="auto-style3">
                            <tr>
                                <td>ArtNr:</td>
                                <td>
                                    <asp:Label ID="lblProductID" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Naam:</td>
                                <td>
                                    <asp:Label ID="lblNaam" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Verkoopprijs:</td>
                                <td>
                                    <asp:Label ID="lblVerkoopprijs" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Voorraad:</td>
                                <td>
                                    <asp:Label ID="lblVoorraad" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;
                        <asp:Label ID="lblText" runat="server" Text="Aantal te bestellen exemplaren van dit item:"></asp:Label>
                        <asp:TextBox ID="txtAantal" runat="server" Width="90px"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btnOk" runat="server" Text="Toevoegen..." OnClick="Button1_Click" />
                    </td>
                    <td class="auto-style5"></td>
                </tr>
            </table>
            <br />
            <table class="auto-style6">
                <tr>
                    <td>
                        <asp:Label ID="lblFouttext" runat="server" ForeColor="Maroon" Text="Dit product zit al in het winkelmandje. Als u het aantal wil wijzigen, verwijder het dan uit het winkelmandje en voeg het correcte aantal toe." Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnCatalogus" runat="server" OnClick="btnCatalogus_Click" Text="Terug naar catalogus..." Visible="False" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
