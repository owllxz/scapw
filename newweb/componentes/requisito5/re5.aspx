<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re5.aspx.cs" Inherits="newweb.componentes.requisito5.WebForm1" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form5" runat="server">
        <div style="height: 692px; width: 1184px;">
            <asp:Label ID="Label3" runat="server" Text="Revision de syllabus"></asp:Label>

                 <div style="width: 1077px; height: 484px; margin-left: 65px; margin-top: 26px">                   

                     <asp:Label ID="Label1" runat="server" Text="Lista de Syllabus cargados en el sistema"></asp:Label>
                     <br />
                     <br />
                     <br />
                     <asp:ListBox ID="ListBox1" runat="server" Height="313px" Width="271px"></asp:ListBox>

                 <div style="margin-left: 420px; margin-top: 0px; height: 295px; background-color:#A3A7A9; width: 616px" >

                     <div style="background-color: #5FC0F1; height: 89px; font-size: xx-large;">
                         <asp:Label ID="Label2" runat="server" Text="Syllabus" style="font-size: xx-large; color: #000000; float:left"></asp:Label>
                     </div>

                     <p style="height: 144px; margin-top: 25px; margin-left: 39px;">
                     Observaciones:<br />
                         <asp:TextBox ID="TextBox1" runat="server" Height="129px" OnTextChanged="TextBox1_TextChanged" Width="293px" style = "float: left; margin-left: 0px;"></asp:TextBox>
                     
                         <asp:CheckBox ID="APROBADO" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />
                         APROBADO<br /><br /><br />

                         <asp:CheckBox ID="RECHAZADO" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" />RECHAZADO<br /><br /><br />
                     
                         <asp:Button ID="Button" runat="server" OnClick="Button1_Click" Text="ENVIAR" style="margin-left: 124px" Width="91px" />
                     </p>

                 </div>

            </div>

        </div>
    </form>
</body>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
