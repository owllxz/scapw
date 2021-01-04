<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Req_4.aspx.cs" Inherits="newweb.componentes.Req_4.Req_4" %>
<link href="https://stackpath.bootstrapcdn.com/bootswatch/4.3.1/flatly/bootstrap.min.css" rel="stylesheet" integrity="sha384-T5jhQKMh96HMkXwqVMSjF3CmLcL1nT9//tCqu9By5XSdj7CwR0r+F3LTzUdfkkQf" crossorigin="anonymous"/>
<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.2/css/all.css" integrity="sha384-oS3vJWv+0UjzBfQzYUhtDYW+Pj2yciDJxpsK1OYPAYjqT085Qq/1cq5FLXAZQ7Ay" crossorigin="anonymous"/>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .nuevoEstilo1 {
            font-family: Calibri;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="container">
            <div>
            <span class="d-block p-2 bg-primary text-white mb-3">Subir Syllabus</span>
                <div class ="input-group mb-3">
                        <asp:Label ID="label_vacio" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>
            <div class="row">
                <div class="col-sm">
                    <div class="p-3 mb-1 bg-light text-black">
                        <asp:Label ID="Label4" runat="server"  Text="<strong>Seleccione la asignatura:</strong>"></asp:Label>
                    </div>
                    <div class ="input-group mb-4">
                        <asp:ListBox ID="Lista_Materias" runat="server" Width="169px"></asp:ListBox>
                        <div class ="input-group mb-4">
                            <asp:Button ID="Button2" runat="server" Text="Seleccionar" CssClass ="btn btn-info" OnClick="Button2_Click" />
                            <div class="d-flex p-2">
                                <asp:Label ID="texto_prueba" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="p-3 mb-1 bg-light text-black">
                        <asp:Label ID="Label3" runat="server" Text="<strong>Subir archivo:</strong>"></asp:Label>
                    </div>
                    <div class ="input-group mb-5">
                        <asp:FileUpload ID="Archivo_Syllabus" runat="server"/>
                    </div>
                </div>

                <div class="col-sm">
                    <div class="d-flex p-2"">
                         <div class="p-3 mb-2 bg-warning text-white">
                             <span class="text-justify">
                                <strong>Intrucciones:</strong><br/>Seleccione la asignatura correspondiente del Syllabus a subir, confirme esta eleccion con el boton "Seleccionar". Posteriormente suba su archivo Syllabus haciendo click en &quot;seleccionar archivo&quot;, cuando todo este listo y revisado, hacer click en "Subir" para finalizar la operacion.
                            </span>
                        </div>
                    </div>
               </div>
            </div>
            <div style="text-align:center;">
                <asp:Button ID="Boton_Subir" runat="server" OnClick="Button1_Click" Text="Subir" CssClass ="btn btn-success"/>
            </div>
            <div class ="input-group mb-5">
                <asp:Label ID="Conex" runat="server" Text="Label" Visible="False"></asp:Label>
            </div>
        </div>
    </form>
</body>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
</html>
