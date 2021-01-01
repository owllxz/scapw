<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re12.aspx.cs" Inherits="newweb.componentes.requisito12.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        body { background-color: #D4F8FF; }
        #form1 {
            width: 1410px;
            height: 1028px;
            margin-left: 27px;
        }
  </style>
</head>
<body>

    <form id="form1" runat="server">

        <div style="background-color:#FFFFFF; height: 1044px; width: 1415px;">

            <div style="background-color:#FFFFFF; height: 48px; width: 1417px; margin-left: 0px;">
                <asp:Panel ID="Panel1" runat="server" Height="47px" CssClass="colorlineas" Width="1418px">
                </asp:Panel>
            </div>

            &nbsp;&nbsp;&nbsp;
            <div style="background-color:#FFFFFF; height: 74px; width: 427px;">
                <asp:Label ID="Label1" runat="server" Text="SCAP" CssClass="titulo"></asp:Label>
                &nbsp;Sistema de comunicacion alumno-profesor<br />
            </div>

            <div style="background-color:#FFFFFF; height: 47px; width: 219px; margin-left: 523px; margin-top: 11px;">
                <asp:Button ID="Button1" runat="server" Text="Mostrar Horario" CssClass="Boton" OnClick="Button1_Click" Height="37px" Width="216px" />
            </div>

            <div style="background-color:#FFFFFF; height: 621px; width: 660px; margin-left: 314px; margin-top: 86px;">
                 <asp:Image ID="Image1" Visibile="False" ImageUrl="C:\Users\C0DA\Desktop\HORARIO 1.png" runat="server" Visible="False" Height="603px" Width="641px" style="margin-left: 8px; margin-right: 22px; margin-top: 7px;" />
            </div>

            <div style="background-color:#FFFFFF; height: 53px; width: 1422px; margin-left: 0px; margin-top: 96px;">
                 <asp:Panel ID="Panel2" runat="server" Height="39px" style="margin-left: 4px; margin-top: 8px" Width="1411px" CssClass="colorlineas">
                 </asp:Panel>
            </div>
            
        </div>

    </form>

</body>
</html>
