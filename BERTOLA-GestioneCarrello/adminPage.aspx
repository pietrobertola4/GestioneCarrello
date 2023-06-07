<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="BERTOLA_GestioneCarrello.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin</title>
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

       button{
           color:white;
       }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light text-white">
            <div class="container-fluid">
                <asp:HyperLink CssClass="navbar-brand text-white" style="font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode'" ID="lblNavBrand" runat="server"></asp:HyperLink>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <asp:Button ID="btnHome" runat="server" CssClass="nav-link active btn btn-info m-1 text-white" Text="Home" OnClick="btnHome_Click" />
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="btnLogout" CssClass="btn btn-danger m-1" Text="Logout" runat="server" OnClick="btnLogout_Click"/>
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="btnCategorie" CssClass="btn btn-secondary m-1" Text="Categorie" runat="server" OnClick="btnCategorie_Click"/>
                        </li>
                        <li class="nav-item">
                            <asp:Button ID="btnProdotti" CssClass="btn btn-secondary m-1" Text="Prodotti" runat="server" OnClick="btnProdotti_Click"/>
                        </li>
                        <li class="nav-item">
                        <asp:Button ID="btnAggiungiFornitori" CssClass="btn btn-secondary  m-1" Text="Fornitori" runat="server" OnClick="btnAggiungiFornitore_Click" />
                        </li>
                    </ul>
                    <div class="d-flex">
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

