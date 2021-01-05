<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re11.aspx.cs" Inherits="newweb.componentes.requisito11.WebForm1" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 650px">
    <form id="form1" runat="server">
        <div class="container">

            <span class="d-block p-2 bg-primary text-white mb-3">CARGA DE TAREAS </span>

            <asp:Label ID="Label5" runat="server" Text="Fecha Actual: "></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <br />
            

             <div class ="input-group mb-3">
                   
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            


            <div class ="input-group mb-2">
                <asp:Label ID="Label2" runat="server" Text="ESTADO DE ENTREGA"></asp:Label>
                </div>

            <div class ="input-group mb-2">
                    <asp:Label ID="Label4" runat="server" CssClass="input-group-text" Text="ID ASIGNATURA"></asp:Label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

             <div class ="input-group mb-2">               
                 <div>

                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn btn-secondary" />
 
                </div>
             </div>
                


          

            
        </div>
        
    </form>
</body>

    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
