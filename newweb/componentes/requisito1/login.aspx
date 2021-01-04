<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="newweb.componentes.requisito1.login" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .form-control {
            margin-top: 1px;
        }
        .cuadrosTexto {
            width: 810px;
            margin-top: 34px;
        }
    </style>
</head>
<body style="height: 615px">
    <form id="form1" runat="server">
        <div class ="container">
            <span class="d-block p-2 bg-primary text-white mb-3">Ingreso a Portal de SCAP</span>
            <div>
                <asp:Label ID="Label2" runat="server" CssClass="input-group-text" Text="Correo"></asp:Label><br />
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox><br />

                <asp:Label ID="Label3" runat="server" CssClass="input-group-text" Text="Contraseña"></asp:Label><br />
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox><br />
            </div>
             
            <div>   
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Ingresar" />
                <br />
                <br />
            </div>
            <asp:Label ID="Label1" runat="server" CssClass="mt-2 mb-2 alert alert-success form-control" Text="Se ha iniciado sesion!" Visible="False"></asp:Label>
        </div>
        
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
