<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FornitoreView.aspx.cs" Inherits="BERTOLA_GestioneCarrello.FornitoreView" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home Fornitore</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <script type="text/javascript" src="js/bootstrap.js"></script>  
    <style>
       body{
            -webkit-user-select: none; /* Safari */        
            -moz-user-select: none; /* Firefox */
            -ms-user-select: none; /* IE10+/Edge */
            user-select: none; /* Standard */
            background-color: #537188;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light ">
            <div class="container-fluid">
                <asp:HyperLink CssClass="navbar-brand text-white" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode'" ID="lblNavBrand" runat="server"></asp:HyperLink>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <asp:Button ID="btnHome" runat="server"  CssClass="nav-link mx-5 active btn btn-info text-white" Text="Home" OnClick="btnHome_Click" />
                        </li>
                        <li class="nav-item">
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="btnLogout" CssClass="btn btn-danger text-white" Text="Logout" runat="server" OnClick="btnLogout_Click"/>
                        </li>
                    </ul>
                    <div class="d-flex">
                        <asp:Button ID="btnAggiungiProdotto" CssClass="btn btn-success text-white" Text="Aggiungi Prodotto" runat="server" OnClick="btnAggiungiProdotto_Click" />
                    </div>
                </div>
            </div>
        </nav>
        <div class="container-fluid">
            <asp:PlaceHolder ID="container" runat="server">
                
            </asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
