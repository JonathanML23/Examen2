<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaModificar.aspx.cs" Inherits="Examen2.EncuestaModificar" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Modificar Encuesta</title>
    <link rel="stylesheet" type="text/css" href="Modificar.css"/>
    <link href="fondo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Modificar Encuesta</h1>

            <label for="txtID">ID:</label>
            <asp:TextBox ID="txtID" runat="server" required></asp:TextBox><br /><br />

            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" required></asp:TextBox><br /><br />

            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" required></asp:TextBox><br /><br />

            <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" type="date" required></asp:TextBox><br /><br />

            <label for="txtCorreo">Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" type="email" required></asp:TextBox><br /><br />

            <label for="cmbCarroPropio">¿Tiene carro propio?</label>
            <asp:DropDownList ID="cmbCarroPropio" runat="server" required>
                <asp:ListItem Text="Seleccione" Value="" />
                <asp:ListItem Text="Si" Value="Si" />
                <asp:ListItem Text="No" Value="No" />
            </asp:DropDownList><br /><br />

            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            
            <br /><br />

            <asp:GridView ID="gvDatosModificar" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="carro_propio" HeaderText="Presenta carro propio" />
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
        </div>

        <!-- Enlace Volver al Menú -->
        <a href="Menu.aspx" class="boton-volver-menu">Volver al Menú</a>
    </form>
</body>
</html>







