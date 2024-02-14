<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Cinema.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Lnome" runat="server" Text="">Nome</asp:Label>
            <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Lcognome" runat="server" Text="">Cognome</asp:Label>
            <asp:TextBox ID="TxtCognome" runat="server"></asp:TextBox>
            <br />
            Scegli la sala:
            <asp:RadioButtonList ID="RBSala" runat="server">
                <asp:ListItem Value="SalaNord">Sala Nord</asp:ListItem>
                <asp:ListItem Value="SalaEst">Sala Est</asp:ListItem>
                <asp:ListItem Value="SalaSud">Sala Sud</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            Tipo biglietto:
            <asp:RadioButtonList ID="RBTipoBiglietto" runat="server">
                <asp:ListItem Value="ridotto">Ridotto</asp:ListItem>
                <asp:ListItem Value="intero">Intero</asp:ListItem>
            </asp:RadioButtonList>
            <br />

            <asp:Button ID="btnCompra" runat="server" Text="Compra Biglietti" OnClick="btnCompra_Click" />
            <br />

            Totale Biglietti venduti
            <br />
            Sala Nord: <asp:Label ID="LNord" runat="server" Text=""></asp:Label>
            <br />
            Totale Ridotti:<asp:Label ID="LRidottiNord" runat="server" Text=""></asp:Label>
            <br />
            Sala Est:<asp:Label ID="LEst" runat="server" Text=""></asp:Label>
            <br />
            Totale Ridotti:<asp:Label ID="LRidottiEst" runat="server" Text=""></asp:Label>
            <br />
            Sala Sud:<asp:Label ID="LSud" runat="server" Text=""></asp:Label>
            <br />
            Totale Ridotti:<asp:Label ID="LRidottiSud" runat="server" Text=""></asp:Label>
            <br />
        </div>
    </form>
</body>
</html>
