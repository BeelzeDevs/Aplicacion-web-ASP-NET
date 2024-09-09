<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adm_altadeProductos.aspx.cs" Inherits="TIF_Grupo_12.adm_altadeProductos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 320px;
        }
        .auto-style2 {
            width: 136px;
            height: 26px;
        }
        .auto-style3 {
            width: 58px;
            height: 26px;
        }
        .auto-style4 {
            width: 133px;
            height: 26px;
        }
        .auto-style10 {
            width: 136px;
            height: 22px;
        }
        .auto-style11 {
            height: 22px;
        }
        .auto-style16 {
            width: 396px;
            height: 26px;
        }
        .auto-style17 {
            width: 396px;
            height: 22px;
        }
        .auto-style25 {
            width: 136px;
            height: 19px;
        }
        .auto-style26 {
            width: 58px;
            height: 19px;
        }
        .auto-style27 {
            width: 133px;
            height: 19px;
        }
        .auto-style28 {
            width: 396px;
            height: 19px;
        }
        .auto-style37 {
            width: 136px;
            height: 35px;
        }
        .auto-style38 {
            width: 58px;
            height: 35px;
        }
        .auto-style39 {
            width: 133px;
            height: 35px;
        }
        .auto-style40 {
            width: 396px;
            height: 35px;
        }
        .auto-style41 {
            width: 136px;
            height: 36px;
        }
        .auto-style42 {
            width: 58px;
            height: 36px;
        }
        .auto-style43 {
            width: 133px;
            height: 36px;
        }
        .auto-style44 {
            width: 396px;
            height: 36px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style10">
                    <asp:Label ID="lbl_nombreusuario" runat="server" Font-Names="Arial" Font-Size="Large" ForeColor="Maroon"></asp:Label>
                </td>
                <td class="auto-style11" colspan="2">
                        <asp:Label ID="lbl_Titulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Alta Productos"></asp:Label>
                    <br />
                </td>
                <td class="auto-style17"></td>
                <td class="auto-style17">
                        <asp:HyperLink ID="hl_CerrarSesión" runat="server" NavigateUrl="~/Ingreso.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
            </tr>
            <tr>
                <td class="auto-style37"></td>
                <td class="auto-style38">Nombre:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txt_Nombre" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="rfv_Nombre" runat="server" ControlToValidate="txt_Nombre" ForeColor="Red">Complete el nombre</asp:RequiredFieldValidator>
                    <br />
                </td>
                <td class="auto-style40"></td>
            </tr>
            <tr>
                <td class="auto-style37"></td>
                <td class="auto-style38">Precio:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txt_Precio" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="rfv_Precio" runat="server" ControlToValidate="txt_Precio" ForeColor="Red">Complete el precio</asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="cv_Precio" runat="server" ControlToValidate="txt_Precio" Operator="GreaterThan" Type="Double" ValueToCompare="0" ForeColor="Red">Numero invalido</asp:CompareValidator>
                </td>
                <td class="auto-style40">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style37"></td>
                <td class="auto-style38">Marca:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtMarca" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="rfvMarca" runat="server" ControlToValidate="txtMarca" ErrorMessage="Complete Marca" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
                <td class="auto-style40">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style38">Categoria:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtCategoria" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="txtCategoria" ErrorMessage="Complete la categoria" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style40">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style37">&nbsp;</td>
                <td class="auto-style38">Stock:</td>
                <td class="auto-style39">
                    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style40">
                    <asp:RequiredFieldValidator ID="rfvStock" runat="server" ControlToValidate="txtStock" ErrorMessage="Complete el stock" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="cvStock" runat="server" ControlToValidate="txtStock" ErrorMessage="Stock mayor a 0" ForeColor="Red" Operator="GreaterThan" ValueToCompare="0"></asp:CompareValidator>
                </td>
                <td class="auto-style40">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style41">&nbsp;</td>
                <td class="auto-style42">Descripción::</td>
                <td class="auto-style43">
                    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style44">
                    <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Complete la descripcion" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                </td>
                <td class="auto-style44">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style41">&nbsp;</td>
                <td class="auto-style42">Imagen:</td>
                <td class="auto-style43">
                    <asp:TextBox ID="txtImagen" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style44">
                    <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="txtImagen" ErrorMessage="Complete la Imagen" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                <td class="auto-style44">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style41"></td>
                <td class="auto-style42"></td>
                <td class="auto-style43">
                    <asp:Label ID="lbl_Mensaje" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td class="auto-style44"></td>
                <td class="auto-style44">
                        </td>
            </tr>
            <tr>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style26">&nbsp;</td>
                <td class="auto-style27">
                    <asp:Button ID="btn_Aceptar" runat="server" Text="Aceptar" OnClick="btn_Aceptar_Click" />
                </td>
                <td class="auto-style28">&nbsp;</td>
                <td class="auto-style28">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style16">
                        <asp:HyperLink ID="hl_Indice" runat="server" NavigateUrl="~/Indice_Administrador.aspx">Ir al indice</asp:HyperLink>
                    </td>
            </tr>
        </table>
    </form>
</body>
</html>
