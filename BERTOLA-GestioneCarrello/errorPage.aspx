<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="errorPage.aspx.cs" Inherits="BERTOLA_GestioneCarrello.errorPage" %>

<!DOCTYPE html>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Errore</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.0.2/css/bootstrap.min.css" integrity="sha512-QYRepc2vJ8uYov26Z4bUxZyGdU2IEXQ+Y5LjSt5uWmD02hKqXKjvksvgr9gA7M5rpF2B2+JeRYb32kFt8tWvCQ==" crossorigin="anonymous" referrerpolicy="no-referrer" />
    <style>
        body {
            background-color: #537188;
            font-family: Arial, sans-serif;
            display: flex;
            align-items: center;
            justify-content: center;
            height: 100vh;
        }

        .card {
            width: 400px;
            box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2);
            transition: 0.3s;
            border-radius: 5px;
            background-color: #fff;
            padding: 20px;
            text-align: center;
        }

        .card:hover {
            box-shadow: 0 8px 16px 0 rgba(0, 0, 0, 0.2);
        }

        h1 {
            color: #f00;
        }

        #btnContinua{
            padding: 12.5px 30px;
          border: 0;
          border-radius: 100px;
          background-color: #537188;
          color: #ffffff;
          font-weight: Bold;
          transition: all 0.5s;
          -webkit-transition: all 0.5s;
        }

        #btnContinua:hover {
          background-color: #537188;
          box-shadow: 0 0 20px #537188;
          transform: scale(1.1);
        }

        #btnContinua:active {
          background-color: #537188;
          transition: all 0.25s;
          -webkit-transition: all 0.25s;
          box-shadow: none;
          transform: scale(0.98);
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="card">
            <h1>Errore</h1>
            <asp:Label ID="lblErrore" runat="server" CssClass="text-danger text-center" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnContinua" runat="server" Text="Continua" CssClass="btn btn-primary btn-block" OnClick="btnContinua_Click" />
        </div>
    </form>
</body>
</html>
