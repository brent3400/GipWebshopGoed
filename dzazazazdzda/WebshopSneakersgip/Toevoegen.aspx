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
                    <td class="auto-style2">Aantal te bestellen exemplaren van dit item:&nbsp;
                        <asp:TextBox ID="txtAantal" runat="server" Width="90px"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btnOk" runat="server" Text="Button" OnClick="Button1_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
