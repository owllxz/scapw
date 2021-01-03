<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="requisito2.aspx.cs" Inherits="newweb.componentes.requisito1.requisito2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>

        <link href="//netdna.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
        <script src="//netdna.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
        <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
        <!------ Include the above in your HEAD tag ---------->

        <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.1.0/css/font-awesome.min.css" rel="stylesheet">

        <div  class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    
                    <h4 class="modal-title" >RESTABLECER CONTRASEÑA</h4>
                </div>

                <div class="modal-body">
                    <div class="row">
                        <div class="col-xs-6">
                            <div >
                                <form id="form1" runat="server">
                                    
                                    <div class="form-group">
                                        <label class="lead">Correo</label>
                                        <asp:TextBox ID="TextBox1" type="text" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>

                                    <div>
                                        <asp:Button ID="Button1" runat="server" class="btn btn-default btn-block" Text="Restablecer" OnClick="Button1_Click" />
                                    </div>
                                </form>
                            </div>
                        </div>

                        <div class="col-xs-6">
                            <p class="lead">Instrucciones </p>
                            <ul class="list-unstyled" style="line-height: 2">
                                <li><span class="fa fa-check text-success"></span> Ingrese el correo asociado a su cuenta</li>
                                <li><span class="fa fa-check text-success"></span> Recibira su contraseña en un email</li>

                                <li><a href="/read-more/"><u>Contacta con nosotros si necesitas ayuda</u></a></li>
                            </ul>

                        </div>
                    </div>
                </div>
            </div>
        </div>
</body>
</html>
