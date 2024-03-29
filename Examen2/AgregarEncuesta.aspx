<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarEncuesta.aspx.cs" Inherits="Examen2.VistaEncuesta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Formulario de Encuesta</title>
    <link rel="stylesheet" type="text/css" />
    <link href="Agregar.css" rel="stylesheet" />
    <link href="fondo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Formulario de Encuesta</h1>
            <label for="txtNombre">Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" required></asp:TextBox>

            <label for="txtApellido">Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" required></asp:TextBox>

            <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" type="date" required></asp:TextBox>

            <label for="txtCorreo">Correo Electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" type="email" required></asp:TextBox>

            <label for="cmbCarroPropio">¿Tiene carro propio?</label>
            <asp:DropDownList ID="cmbCarroPropio" runat="server" required>
                <asp:ListItem Text="Seleccione" Value="" />
                <asp:ListItem Text="Si" Value="Si" />
                <asp:ListItem Text="No" Value="No" />
            </asp:DropDownList>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Encuesta" OnClick="btnGuardar_Click" />

            <br /><br />

            <asp:GridView ID="gvDatos" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="carro_propio" HeaderText="Presenta carro propio" />
                </Columns>
            </asp:GridView>

            <br /><br />

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>

        </div>
        
        <!-- Botón Volver al Menú -->
        <a href="Menu.aspx" class="boton-volver-menu">Volver al Menú</a>
    </form>
</body>
</html>






