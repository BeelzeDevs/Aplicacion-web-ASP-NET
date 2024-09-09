<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Us_ComprarProductos.aspx.cs" Inherits="TIF_Grupo_12.Indice_usuario.Us_ComprarProdcutos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style5 {
            width: 178px;
        }
        .auto-style6 {
            height: 23px;
            width: 178px;
        }
        .auto-style7 {
            width: 178px;
            height: 24px;
        }
        .auto-style8 {
            height: 24px;
        }
        .auto-style11 {
            width: 457px;
        }
        .auto-style12 {
            height: 23px;
            width: 457px;
        }
        .auto-style13 {
            width: 397px;
        }
        .auto-style14 {
            height: 23px;
            width: 397px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style7"></td>
                    <td class="auto-style8" colspan="2">
                        <asp:Label ID="lbl_Titulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Comprar Productos"></asp:Label>
                    </td>
                    <td class="auto-style8">
                        <asp:HyperLink ID="hl_CerrarSesión" runat="server" NavigateUrl="~/Ingreso.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style13">Busqueda por nombre:</td>
                    <td class="auto-style11">
                        <asp:TextBox ID="txt_BusquedaxNombre" runat="server" Width="136px"></asp:TextBox>
                    &nbsp;
                        <asp:Button ID="btn_Filtro" runat="server" Text="Buscar" Width="55px" />
                    </td>
                    <td>
                        <asp:ImageButton ID="imgbtnCarrito" runat="server" OnClick="imgbtnCarrito_Click" Width="32px" Height="36px" ImageUrl="~/img/carrito.png" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td colspan="2">
                        
                        <asp:ListView ID="lvProductos" runat="server" DataKeyNames="Legajo_Producto" GroupItemCount="3" OnItemCommand="lvProductos_ItemCommand" OnPagePropertiesChanging="lvProductos_PagePropertiesChanging">
                            
                            
                            <EmptyDataTemplate>
                                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                                    <tr>
                                        <td>No se han devuelto datos.</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <EmptyItemTemplate>
                                <td runat="server" />
                            </EmptyItemTemplate>
                            <GroupTemplate>
                                <tr id="itemPlaceholderContainer" runat="server">
                                    <td id="itemPlaceholder" runat="server"></td>
                                </tr>
                            </GroupTemplate>

                            <ItemTemplate>
                                <td runat="server" style="background-color: #E0FFFF;color: #333333;">&nbsp;<span style="">
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Imagen") %>' Width="100px" />
                                    <br />
                                    <asp:Label ID="lblLegajoProducto" runat="server" Text='<%# Eval("Legajo_Producto") %>' Visible="False" />
                                    <br />
                                    Nombre:
                                    <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>' />
                                    <br />
                                    PU:
                                    <asp:Label ID="lblPU" runat="server" Text='<%# Eval("PU") %>' />
                                    <br />
                                    Marca:
                                    <asp:Label ID="lblMarca" runat="server" Text='<%# Eval("Marca") %>' />
                                    <br />
                                    Categoria:
                                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria") %>' />
                                    <br />
                                    Stock:
                                    <asp:Label ID="lblStock" runat="server" Text='<%# Eval("Stock") %>' />
                                    <br />
                                    Descripción:
                                    <asp:Label ID="lblDescripcion" runat="server" Text='<%# Eval("Descripción") %>' />
                                    <br />
                                    </span>
                                    <asp:Button ID="btnComprar" runat="server" CommandName="eventoComprarProducto" Text="Comprar" />
                                </td>
                            </ItemTemplate>
                            <LayoutTemplate>
                                <table runat="server">
                                    <tr runat="server">
                                        <td runat="server">
                                            <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                <tr id="groupPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td runat="server" style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF">
                                            <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                                                <Fields>
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                    <asp:NumericPagerField />
                                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                                </Fields>
                                            </asp:DataPager>
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                            <SelectedItemTemplate>
                                <td runat="server" style="background-color: #E2DED6;font-weight: bold;color: #333333;">Legajo_Producto:
                                    <asp:Label ID="Legajo_ProductoLabel" runat="server" Text='<%# Eval("Legajo_Producto") %>' />
                                    <br />
                                    Nombre:
                                    <asp:Label ID="NombreLabel" runat="server" Text='<%# Eval("Nombre") %>' />
                                    <br />
                                    PU:
                                    <asp:Label ID="PULabel" runat="server" Text='<%# Eval("PU") %>' />
                                    <br />
                                    Marca:
                                    <asp:Label ID="MarcaLabel" runat="server" Text='<%# Eval("Marca") %>' />
                                    <br />
                                    Categoria:
                                    <asp:Label ID="CategoriaLabel" runat="server" Text='<%# Eval("Categoria") %>' />
                                    <br />
                                    Stock:
                                    <asp:Label ID="StockLabel" runat="server" Text='<%# Eval("Stock") %>' />
                                    <br />
                                    Descripción:
                                    <asp:Label ID="DescripciónLabel" runat="server" Text='<%# Eval("Descripción") %>' />
                                    <br />
                                    Imagen:
                                    <asp:Label ID="ImagenLabel" runat="server" Text='<%# Eval("Imagen") %>' />
                                    <br />
                                </td>
                            </SelectedItemTemplate>
                        </asp:ListView>
                    </td>
                    <td>
                        <asp:ListView ID="lvCarrito" runat="server" OnItemCommand="lvCarrito_ItemCommand" >
                            <LayoutTemplate>
                                <div>
                                    <h1>Carrito</h1>
                                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                </div>
                            </LayoutTemplate>
                             <ItemTemplate>
                                <div>
                                    <asp:Label ID="lblCarrito_nombre" runat="server" Text='<%#Eval("Nombre") %>'>Nombre</asp:Label>
                                    <asp:Label ID="lblCarrito_precio" runat="server" Text='<%# Eval("PU") %>'></asp:Label>
                                    <asp:Label ID="lblCarrito_descripcion" runat="server" Text='<%# Eval("Descripcion") %>'></asp:Label>
                                    <asp:Button ID="btn_mas" runat="server" Text="-" CommandArgument="<%# Container.DataItemIndex %>"  CommandName="eventoCarrito-restar" />
                                    <asp:Label ID="lblCarrito_cantidad" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                                    <asp:Button ID="btn_menos" runat="server" Text="+" CommandArgument="<%# Container.DataItemIndex %>" CommandName="eventoCarrito-sumar" />
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style14">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style12"></td>
                    <td class="auto-style2">
                        <asp:Label ID="lblMensaje0" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">&nbsp;</td>
                    <td colspan="2">
                        &nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hl_Indice" runat="server" NavigateUrl="~/Indice_Usuario.aspx">Ir al indice</asp:HyperLink>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
