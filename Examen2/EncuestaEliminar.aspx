<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EncuestaEliminar.aspx.cs" Inherits="Examen2.EliminarEncuesta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Encuesta</title>
    <link rel="stylesheet" type="text/css" href="Agregar.css"/>
    <link href="fondo.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Eliminar Encuesta</h1>

            <asp:GridView ID="gvEncuestas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="fecha_nacimiento" HeaderText="Fecha de Nacimiento" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo Electrónico" />
                    <asp:BoundField DataField="carro_propio" HeaderText="Presenta carro propio" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandArgument='<%# Eval("Id") %>' OnClick="btnEliminar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje"></asp:Label>
        </div>

        <div class="button-container">
            <asp:Button ID="btnVolverMenu" runat="server" Text="Volver al Menú" OnClick="btnVolverMenu_Click" CssClass="boton-volver-menu" />
        </div>
    </form>
</body>
</html>



