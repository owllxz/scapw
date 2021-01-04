<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu.aspx.cs" Inherits="newweb.componentes.requisito1.WebForm1" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mx-auto mb-2">
            <span class="d-block p-2 bg-primary text-white mb-3">Menu de requisitos:</span>
            <div class="btn-group-vertical float-left">
                <asp:Button ID="Button1" CssClass="btn btn-danger mb-2" runat="server" Text="Recuperación de clave de acceso" OnClick="Button1_Click" />
                <asp:Button ID="Button2" CssClass="btn btn-secondary mb-2" runat="server" Text="Carga de syllabus en el sistema" OnClick="Button2_Click" />
                <asp:Button ID="Button3" CssClass="btn btn-success mb-2" runat="server" Text="Aprobación del syllabus" OnClick="Button3_Click" />
                <asp:Button ID="Button4" CssClass="btn btn-primary mb-2" runat="server" Text="Entrega trabajos de alumnos" OnClick="Button4_Click" />
                <asp:Button ID="Button5" CssClass="btn btn-warning mb-2" runat="server" Text="Button" />
                <asp:Button ID="Button6" CssClass="btn btn-info mb-2" runat="server" Text="Button" />
                <asp:Button ID="Button7" CssClass="btn btn-light mb-2" runat="server" Text="Button" />
            </div>
            <div class = "float-lg-right">
                <div class="card" style="width: 18rem;">
                  <div class="card-header">
                    Datos de usuario:
                  </div>
                  <ul class="list-group list-group-flush">
                    <li class="list-group-item">Correo: <%= myList[0] %></li>
                    <li class="list-group-item">ID: <%= myList[1] %></li>
                    <li class="list-group-item">Rol: <%= myList[2] %></li>
                    <li class="list-group-item">Rol ID: <%= myList[3] %></li>
                  </ul>
                </div>
            </div>
        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
