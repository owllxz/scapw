<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re12.aspx.cs" Inherits="newweb.componentes.requisito12.WebForm1" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title></title>

</head>
<body>

    <form id="form1" runat="server">
            <div Class="container">
             <div>
                <span class="d-block p-2 bg-primary text-white mb-5">Horario de Clases</span>
                <div class ="input-group mb-5">
                    <asp:DropDownList ID="rolgrupo" CssClass="mx-auto btn btn-secondary dropdown-toggle mb-3" runat="server" OnSelectedIndexChanged="rolgrupo_SelectedIndexChanged">
                    <asp:ListItem Text="curso 1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="curso 2" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary mx-auto" Text="Mostrar Horario" OnClick="Button1_Click"/>
                </div>

                <div class ="input-group mb-3">
                    <asp:Image ID="Image1" CssClass="mx-auto" runat="server"/>
                </div>
                
            </div>
        </div>
    </form>
</body>

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</html>
