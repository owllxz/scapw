<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="roles.aspx.cs" Inherits="newweb.componentes.requisito1.roles" %>
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
        <div class ="container-fluid">
            <span class="d-block p-2 bg-primary text-white">Asignar rol a usuario</span>
            <span class="d-block p-2 bg-secondary text-white mb-3">Usuarios sin roles</span>
            <asp:GridView ID="GridView1" runat="server" CssClass="table" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:DropDownList ID="rolgrupo" CssClass="btn btn-secondary dropdown-toggle mb-3" runat="server">
                <asp:ListItem Text="Administrador" Value="1"></asp:ListItem>
                <asp:ListItem Text="Alumnos" Value="2"></asp:ListItem>
                <asp:ListItem Text="Apoderado" Value="3"></asp:ListItem>
                <asp:ListItem Text="Director" Value="4"></asp:ListItem>
                <asp:ListItem Text="Profesor" Value="5"></asp:ListItem>
                <asp:ListItem Text="Secretario" Value="6"></asp:ListItem>
            </asp:DropDownList>
            <div class="input-group mb-3">
                <asp:Label ID="Label1" runat="server" CssClass="input-group-text" Text="ID"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
                <asp:Label ID="Label2" runat="server" CssClass="input-group-text" Text="Año Ingreso"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="input-group mb-3">
                <asp:Label ID="Label3" runat="server" CssClass="input-group-text" Text="Apoderado ID"></asp:Label>
                <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button7" runat="server" CssClass="btn btn-primary" Text="Asignar" OnClick="Button7_Click" />
            <br />
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
