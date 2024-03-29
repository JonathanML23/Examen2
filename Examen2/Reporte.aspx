<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Examen2.Reporte" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reporte de Encuestas</title>
    <link rel="stylesheet" type="text/css" href="Reporte.css"/>
    <link href="fondo.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            margin-left: 10px;
            font-size: xx-large;
        }
        .auto-style2 {
            font-size: xx-large;
        }
    </style>
</head>
<body>
<div class='ripple-background'>
  <div class='circle xxlarge shade1'></div>
  <div class='circle xlarge shade2'></div>
  <div class='circle large shade3'></div>
  <div class='circle mediun shade4'></div>
  <div class='circle small shade5'></div>
</div>
    <form id="form1" runat="server">
        <div class="container">
            <label><span class="auto-style2">Total de Encuestas Realizadas:</span></label>
            <asp:Label ID="lblTotalEncuestas" runat="server" CssClass="auto-style1"></asp:Label>
            <br class="auto-style2" />
            <label><span class="auto-style2">Cantidad de Personas con Carro Propio:</span></label>
            <asp:Label ID="lblCantidadSi" runat="server" CssClass="auto-style1"></asp:Label>
            <br class="auto-style2" />
            <label><span class="auto-style2">Cantidad de Personas sin Carro Propio:</span></label>
            <asp:Label ID="lblCantidadNo" runat="server" CssClass="auto-style1"></asp:Label>
        </div>

        <!-- Etiqueta para mostrar mensajes de error -->
        <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>

        <!-- Botón Volver al Menú -->
        <a href="Menu.aspx" class="boton-volver-menu">Volver al Menú</a>
    </form>
</body>
</html>




