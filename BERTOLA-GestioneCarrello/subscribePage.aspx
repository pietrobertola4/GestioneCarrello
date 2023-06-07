<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="subscribePage.aspx.cs" Inherits="BERTOLA_GestioneCarrello.subscribePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>SUBSCRIBE-PAGE</title>
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

       h1 {
            cursor: pointer;
            font-weight: bold;
            font-family: Arial, sans-serif;
            color: #537188;
            margin-bottom: 2rem;
            }

        h1:hover{
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

         input[type="text"], input[type="password"], input[type="email"], input[type="tel"] {
        font-size: 1.2rem;
        font-family: Arial, sans-serif;
        border-radius: 0.5rem;
        padding: 1rem;
        border: none;
        border-bottom: 2px solid #537188;
    }

    input[type="text"]:focus, input[type="password"]:focus, input[type="email"]:focus, input[type="tel"]:focus {
        outline: none;
        border-bottom: 2px solid #2e4053;
    }

    .btn {
        border-radius: 0.5rem;
        font-size: 1.2rem;
        font-family: Arial, sans-serif;
        padding: 1rem;
        border: none;
        background-color: #537188;
        color: white;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <div class="container py-5 h-100">
                <div class="row d-flex justify-content-center align-items-center h-100">
                    <div class="col-12 col-md-8 col-lg-6 col-xl-5">
                        <div class="card shadow-2-strong" style="border-radius: 1rem; width: 550px">
                            <div class="card-body p-5 text-center">
                                <h1 class="mb-5">Subscribe</h1>
                                <div class="form-outline mb-4">
                                    <asp:TextBox placeholder="username" CssClass="form-control form-control-lg" ID="txtUsername" runat="server" AutoPostBack="True"></asp:TextBox>
                                </div>
                                <hr class="my-4" background-color="#537188" />
                                <div class="form-outline input-group mb-4">
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtCognome" runat="server" placeholder="cognome"></asp:TextBox>
                                    <div class="mx-2"></div>                              
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtNome" runat="server" placeholder="nome"></asp:TextBox>
                                </div>
                                <div class="form-outline mb-4">
                                    <hr class="my-4" background-color="#537188" />
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtIndirizzo" runat="server" placeholder="Via Roma 1, 12041, Carrù(CN)"></asp:TextBox>
                                </div>
                                <div class="form-outline mb-4">
                                    <hr class="my-4" background-color="#537188" />
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtMail" runat="server" TextMode="Email" placeholder="pietro123@vallauri.edu" AutoPostBack="True"></asp:TextBox>
                                </div>
                                <div class="form-outline mb-4">
                                    <hr class="my-4" background-color="#537188" />
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtTelefono" MaxLength="10" MinLenght="10" runat="server" TextMode="Phone" placeholder="0123456789"></asp:TextBox>
                                </div>
                                <hr class="my-4" background-color="#537188" />
                                <div class="form-outline input-group mb-4">
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtPassword" runat="server" TextMode="Password" placeholder="password"></asp:TextBox>
                                    <div class="mx-2"></div>
                                    <asp:TextBox CssClass="form-control form-control-lg" ID="txtConfermaPassword" runat="server" TextMode="Password" placeholder="conferma pwd"></asp:TextBox>
                                </div>
                                <asp:Button CssClass="btn btn-primary btn-lg btn-block" ID="btnLogin" runat="server" Text="Iscriviti" OnClick="btnLogin_Click" />
                                <br />
                                <asp:Label ID="lblErrore" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <hr class="my-4" background-color="#537188" />
                                <span>You have already an accoount? <a href="default.aspx">Sign In</a></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
