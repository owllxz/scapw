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
        <div style="padding-bottom:50px">
            <asp:label runat="server" id="Alumno"></asp:label>
            <asp:DropDownList ID="DropDownList1" runat="server" Height="55px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="204px" AutoPostBack="True" style="margin-left:182px; margin-top:30px">
            </asp:DropDownList>
        </div>
        <hr />
        <div style="padding-bottom:30px; margin-left:10px">
             <asp:label runat="server" id="Asignatura" style="margin-left:41px; width: 197px;"></asp:label>
                 </div>
        <div style="padding-bottom:25px">
            <asp:label runat="server"  style="margin-left:100px" id="Actividad">Actividad</asp:label>
            <asp:label runat="server" style="margin-left:225px; width: 185px;" id="Ponderación">Ponderación</asp:label>
            <asp:label runat="server"  style="margin-left:105px; width: 186px;" id="Nota">Nota</asp:label>

        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox style="margin-left:100px" ID="Text1" placeholder="Nota 1" type="text" readonly="True" runat="server"></asp:Textbox>
            <asp:Textbox runat="server"  style="margin-left:100px" id="Text2" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text3" placeholder="Nota 1" type="text" readonly="True" />

        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text4" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text5" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text6" placeholder="Nota 1" type="text" readonly="True" />
        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text7" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text8" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text9" placeholder="Nota 1" type="text" readonly="True" />
        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text10" placeholder="Nota 1" type="text" readonly="True"/>
            <asp:Textbox runat="server" style="margin-left:100px" id="Text11" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text12" placeholder="Nota 1" type="text" readonly="True" />
        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text13" placeholder="Nota 1" type="text" readonly="True"/>
            <asp:Textbox runat="server" style="margin-left:100px" id="Text14" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text15" placeholder="Nota 1" type="text" readonly="True" />
        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text16" placeholder="Nota 1" type="text" readonly="True"/>
            <asp:Textbox runat="server" style="margin-left:100px" id="Text17" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text18" placeholder="Nota 1" type="text" readonly="True" />
        </div>
        <div style="padding-bottom:25px">
            <asp:Textbox runat="server" style="margin-left:100px" id="Text19" placeholder="Nota 1" type="text" readonly="True"/>
            <asp:Textbox runat="server" style="margin-left:100px" id="Text20" placeholder="Nota 1" type="text" readonly="True" />
            <asp:Textbox runat="server" style="margin-left:100px" id="Text21" placeholder="Nota 1" type="text" readonly="True" />
        </div>

        <hr />
    </form>
</body>
</html>
