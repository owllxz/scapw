<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="newweb.componentes.Requisito13.Notas" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

    <form id="form10" runat="server">
        <div class="container mx-auto mb-2">
            <asp:label runat="server" id="Alumno"></asp:label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="55px" Width="204px" AutoPostBack="True" style="margin-left:182px; margin-top:30px">
            </asp:DropDownList>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar" CssClass="btn btn-dark" />
        <hr />
        <div style="padding-bottom:30px; margin-left:10px">
                 </div>
        <div style="padding-bottom:25px">

        </div>
            <table class="table">
            <thead class="thead-dark">
            <tr>
            <th scope="col">Actividad</th>
            <th scope="col">Ponderacion</th>
            <th scope="col">Nota</th>
            </tr>
            </thead>
            <tbody>
            <% foreach (List<string> subList in myList) { %> <!-- loop through the list -->
            <tr>
            <td><%= subList[0] %></td>
            <td><%= subList[1] %></td>
            <td><%= subList[2] %></td>
            </tr>
            <% } %> <!--End the for loop -->                    
            </tbody>
            </table>
        <hr />
        <div class="input-group mb-3">
            <asp:Label ID="Label1" runat="server" CssClass="input-group-text" Text="Rut"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="Button2_Click"/>
            <table class="table">
            <thead class="thead-dark">
            <tr>
            <th scope="col">Asignatura</th>
            <th scope="col">Actividad</th>
            <th scope="col">Ponderacion</th>
            <th scope="col">Nota</th>
            </tr>
            </thead>
            <tbody>
            <% foreach (List<string> subList2 in myList2) { %> <!-- loop through the list -->
            <tr>
            <td><%= subList2[0] %></td>
            <td><%= subList2[1] %></td>
            <td><%= subList2[2] %></td>
            <td><%= subList2[3] %></td>
            </tr>
            <% } %> <!--End the for loop -->                    
            </tbody>
            </table>
        </div>
    </form>
</body>
</html>
