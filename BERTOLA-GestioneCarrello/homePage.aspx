<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="homePage.aspx.cs" Inherits="BERTOLA_GestioneCarrello.homePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Home - Carrello ASP</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <script type="text/javascript" src="js/bootstrap.js"></script>
    <script type="text/javascript">
    function showAlert(message) {
        alert(message);
    }
    </script>
    <style>
       body{
            -webkit-user-select: none; /* Safari */        
            -moz-user-select: none; /* Firefox */
            -ms-user-select: none; /* IE10+/Edge */
            user-select: none; /* Standard */
            background-color: #537188;
       }

       button{
            padding: 12.5px 30px;
            border: 0;
            border-radius: 100px;
            color: #ffffff;
            font-weight: Bold;
            transition: all 0.5s;
            -webkit-transition: all 0.5s;
        }
             
        button:hover {
            box-shadow: 0 0 20px #537188;
            transform: scale(1.1);
        }

        button:active {
            transition: all 0.25s;
            -webkit-transition: all 0.25s;
            box-shadow: none;
            transform: scale(0.98);
        }

        .card:hover{
         transform: scale(1.05);
         box-shadow: 0 10px 20px rgba(0,0,0,.12), 0 4px 8px rgba(0,0,0,.06);
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light text-white text-center">
            <div class="container-fluid">
                <asp:HyperLink CssClass="navbar-brand text-white" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode'" ID="lblNavBrand" runat="server" ForeColor="White">[lblNavBrand]</asp:HyperLink>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item mx-3">
                            <asp:button ID="btnHome" runat="server" class="nav-link active btn btn-info text-white" BorderStyle="None" aria-current="page" href="#" Text="Home" OnClick="btnHome_Click"/>
                        </li>
                        <li class="nav-item dropdown mx-3">
                            <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                                Categorie
                            </a>
                            <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                                <asp:PlaceHolder ID="phElencoCategorie" runat="server"></asp:PlaceHolder>
                            </ul>
                        </li>
                        <li class="nav-item mx-3">
                        </li>
                        <li class="nav-item mx-3">
                            <asp:Button ID="btnLogout" CssClass="btn btn-danger" Text="Logout" runat="server" OnClick="btnLogout_Click"/>
                        </li>
                        <li class="nav-item mx-3">
                            <asp:Button ID="btnCronologiaOrdini" CssClass="btn btn-primary mx-1" Text="I miei Ordini" runat="server" OnClick="btnCronologiaOrdini_Click"/>
                        </li>
                    </ul>
                    <div class="d-flemx-3x">
                        <asp:Button ID="btnCart" CssClass="btn btn-success" Text="Carrello" runat="server" OnClick="btnCart_Click"/>
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
