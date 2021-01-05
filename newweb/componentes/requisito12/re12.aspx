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
    <div Class="container-fluid">
        <div>
            <span class="d-block p-2 bg-primary text-white mb-5">Horario de Clases</span>
            <div class="input-group mb-3">
                <asp:Label ID="Label1" runat="server" CssClass="input-group-text" Text="Rut"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="Button1_Click"/>
          </div> 
            <table class="table table-dark">
                <thead>
                <tr>
                <th scope="col">#</th>
                <th scope="col">Url</th>
                </tr>
                </thead>
                <tbody>
                <% int i = 0; foreach (var h in horario) { %> <!-- loop through the list -->
                <tr> 
                <% i++; %>
                <th scope="row">Horario <%= i %></th>
                <td><a type="button" href="<%= h %>" target="_blank" class="btn btn-link">Link</a></td>
                </tr>
                <% } %> <!--End the for loop -->                    
                </tbody>
            </table>
    </div>
</form>
</body>

<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>

</html>
