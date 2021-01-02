<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re5.aspx.cs" Inherits="newweb.componentes.requisito5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form5" runat="server">
        <div style="height: 692px; width: 1184px;">
             <span class="d-block p-2 bg-primary text-white mb-3">Aprobación de syllabus</span>

                 <div style="width: 1077px; height: 484px; margin-left: 65px; margin-top: 26px">                   

                     <asp:Label ID="Label1" runat="server" Text="Lista de Syllabus cargados en el sistema"></asp:Label>
                     <br />
                     <br />
                     <br />
                     <asp:BulletedList ID="BulletedList1" runat="server" Height="364px" OnClick="BulletedList1_Click" Width="313px" style ="float: left" >
                     </asp:BulletedList>

                 <div style="margin-left: 420px; margin-top: 0px; height: 295px; background-color:#A3A7A9; width: 616px" >

                     <div style="background-color: #5FC0F1; height: 89px; font-size: xx-large;">
                         <asp:Label ID="Label2" runat="server" Text="Syllabus" style="font-size: xx-large; color: #000000"></asp:Label>
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
</html>
