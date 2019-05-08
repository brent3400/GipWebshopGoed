<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebshopSneakersgip.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalogus</title>
    <style type="text/css">
        .auto-style1 {
            width: 800px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Online Sneakershop - Catalogus</h2>
            <table class="auto-style1">
                <tr>
                    <td>
                        <asp:GridView ID="gvCatalogus" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvCatalogus_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="ProductID" HeaderText="ProductID">
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Naam" HeaderText="Naam">
                                <ItemStyle Width="250px" />
                                </asp:BoundField>
                                <asp:ImageField DataImageUrlField="Foto" DataImageUrlFormatString="~\Files\{0}" HeaderText="Foto">
                                    <ControlStyle Height="225px" Width="225px" />
                                    <ItemStyle Width="250px" />
                                </asp:ImageField>
                                <asp:BoundField DataField="Prijs" HeaderText="Verkoopprijs" DataFormatString="{0:c}">
                                <ItemStyle Width="100px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Voorraad" HeaderText="Voorraad">
                                <ItemStyle Width="50px" />
                                </asp:BoundField>
                                <asp:CommandField SelectText="Voeg toe aan winkelmandje..." ShowSelectButton="True" >
                                <ItemStyle Width="150px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnOk" runat="server" Text="Bekijk de inhoud van het winkelmandje..." Width="794px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server">Afmelden</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
