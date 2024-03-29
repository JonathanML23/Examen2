<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Examen2.Menu" %>

<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>Menu</title>
<link rel="stylesheet" href="MenuCss.css">
<link rel="stylesheet" media="all" href="fondo.css" /> <!-- Agregamos el estilo del fondo animado -->

<style>
    body {
        margin: 0;
        padding: 0;
    }

    nav {
        width: 116%;
        position: fixed;
        top: 1px;
        left: -279px;
        background-color: #fff; 
        z-index: 999; 
    }

    .hList {
        list-style-type: none;
        margin: 0;
        padding: 0;
        display: flex; 
    }

    .hList > li {
        flex-grow: 1;
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
<nav>
    <ul class="hList">
        <li>
            <a href="AgregarEncuesta.aspx" class="menu"> 
                <h2 class="menu-title">Encuesta</h2>
                <ul class="menu-dropdown">
                    <li>Crear Encuesta</li>
                </ul>
            </a>
        </li>
        <li>
            <a href="EncuestaModificar.aspx" class="menu"> 
                <h2 class="menu-title menu-title_2nd">Modificar</h2>
                <ul class="menu-dropdown">
                    <li>Modificar Encuesta</li>
                </ul>
            </a>
        </li>
        <li>
            <a href="EncuestaEliminar.aspx" class="menu"> 
                <h2 class="menu-title menu-title_3rd">Eliminar</h2>
                <ul class="menu-dropdown">
                    <li>Eliminar Encuesta</li>
                </ul>
            </a>
        </li>
        <li>
            <a href="Reporte.aspx" class="menu"> 
                <h2 class="menu-title menu-title_4th">Reporte</h2>
                <ul class="menu-dropdown">
                    <li>Reporte de Encuestas</li>
                </ul>
            </a>
        </li>
    </ul>
</nav>
</body>
</html>

