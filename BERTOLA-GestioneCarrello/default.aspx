<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="BERTOLA_GestioneCarrello._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <script type="text/javascript" src="js/jquery.js"></script>
        <link rel="stylesheet" href="css/bootstrap.css" />
        <link rel="stylesheet" href="css/style.css" />
        <title>HOME-PAGE</title>
        <style>
           body{
                -webkit-user-select: none; /* Safari */        
                -moz-user-select: none; /* Firefox */
                -ms-user-select: none; /* IE10+/Edge */
                user-select: none; /* Standard */
                background-color: #537188;
           }

           .card-body h1 {
            cursor: pointer;
            font-weight: bold;
            font-family: Arial, sans-serif;
            color: #537188;
            margin-bottom: 2rem;
            }

            .card-body h1:hover{
            font-size: 2.7rem;
            transition: font-size 0.3s ease-in-out;
            }

             .btn{
            padding: 12.5px 30px;
              border: 0;
              border-radius: 100px;
              background-color: #537188;
              color: #ffffff;
              font-weight: Bold;
              transition: all 0.5s;
              -webkit-transition: all 0.5s;
            }
             
            .btn:hover {
              background-color: #537188;
              box-shadow: 0 0 20px #537188;
              transform: scale(1.1);
            }

            .btn:active {
              background-color: #537188;
              transition: all 0.25s;
              -webkit-transition: all 0.25s;
              box-shadow: none;
              transform: scale(0.98);
            }

            a{
                text-decoration: none;
                color: #537188;
                font-weight: bold;
                cursor: pointer;
            }
           
        </style>
    </head>
    <body>
        <form id="form1" runat="server">
            <section class="vh-100">
                <div class="container py-5 h-100">
                    <div class="row d-flex justify-content-center align-items-center h-100">
                        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                            <div class="card shadow-2-strong" style="border-radius: 1rem;">
                                <div class="card-body p-5 text-center">
                                    <h1 class="mb-5">Sign Up</h1>
                                    <div class="form-outline mb-4">
                                        <asp:TextBox placeholder="email o username" CssClass="form-control form-control-lg" ID="txtUserMail" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="form-outline mb-4">
                                        <asp:TextBox placeholder="password" CssClass="form-control form-control-lg" ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    </div>
                                    <asp:Button CssClass="btn btn-primary btn-lg btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                                    <br />
                                    <asp:Label ID="lblErrore" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    <hr class="my-4" background-color="#537188" />
                                    <span>You don't have an account? <a href="subscribePage.aspx">Subscribe</a></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </form>
    </body>
</html>
