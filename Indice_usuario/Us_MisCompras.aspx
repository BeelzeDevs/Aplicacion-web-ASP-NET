<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Us_MisCompras.aspx.cs" Inherits="TIF_Grupo_12.Indice_usuario.Us_MisCompras" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 357px;
        }
        .auto-style6 {
            width: 135px;
            height: 23px;
        }
        .auto-style8 {
            width: 357px;
            height: 23px;
        }
        .auto-style10 {
            width: 122px;
            height: 23px;
        }
        .auto-style11 {
            width: 61px;
        }
        .auto-style12 {
            width: 61px;
            height: 23px;
        }
        .auto-style13 {
            width: 61px;
            height: 56px;
        }
        .auto-style14 {
            width: 135px;
            height: 56px;
        }
        .auto-style15 {
            width: 122px;
            height: 56px;
        }
        .auto-style16 {
            width: 357px;
            height: 56px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td colspan="2">
                    <asp:Label ID="lbl_Titulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Mis compras"></asp:Label>
                </td>
                <td class="auto-style3">
                        <asp:HyperLink ID="hl_CerrarSesión" runat="server" NavigateUrl="~/Ingreso.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
            </tr>
            <tr>
                <td class="auto-style13"></td>
                <td class="auto-style14">Busqueda por fecha:</td>
                <td class="auto-style15">
                        <asp:TextBox ID="txt_BusquedaxFecha" runat="server" Width="136px"></asp:TextBox>
                    &nbsp;
                        <asp:Button ID="btn_Filtro" runat="server" Text="Buscar" Width="55px" />
                    </td>
                <td class="auto-style16"></td>
            </tr>
            <tr>
                <td class="auto-style11">&nbsp;</td>
                <td colspan="2">
                    <asp:GridView ID="gvMisCompras" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvMisCompras_RowCommand" PageSize="8" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="gvMisCompras_PageIndexChanging" OnSorting="gvMisCompras_Sorting">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nro. Compra" SortExpression="ordenarxLegajo_Compras">
                                <ItemTemplate>
                                    <asp:Label ID="lblLegajoCompra" runat="server" Text='<%# Eval("Legajo_Compra") %>' ></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Fecha" SortExpression="ordenarxFecha">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total" SortExpression="ordenarxTotal">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotal" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnVerDetalles" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="eventoVerDetalles" Text="Ver Detalles" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                    <br />
                </td>
                <td class="auto-style3">
                    <asp:GridView ID="gvDetalleCompra" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:TemplateField HeaderText="Nro Compra">
                                <ItemTemplate>
                                    <asp:Label ID="lblLegajoCompra" runat="server" Text='<%# Eval("Legajo_Compra") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Nombre">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Marca">
                                <ItemTemplate>
                                    <asp:Label ID="lblMarca" runat="server" Text='<%# Eval("Marca") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Categoria">
                                <ItemTemplate>
                                    <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Precio Unitario">
                                <ItemTemplate>
                                    <asp:Label ID="lblPU" runat="server" Text='<%# Eval("PU") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Subtotal">
                                <ItemTemplate>
                                    <asp:Label ID="lblSubtotal" runat="server" Text='<%# Eval("Subtotal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style6"></td>
                <td class="auto-style10"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style6">
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </td>
                <td class="auto-style10">
                    &nbsp;</td>
                <td class="auto-style8">
                        <asp:HyperLink ID="hl_Indice" runat="server" NavigateUrl="~/Indice_Usuario.aspx">Ir al indice</asp:HyperLink>
                    </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
