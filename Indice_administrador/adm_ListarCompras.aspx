<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adm_ListarCompras.aspx.cs" Inherits="TIF_Grupo_12.Indice_administrador.adm_Listarcompras" %>

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
            width: 500px;
        }
        .auto-style3 {
            width: 153px;
        }
        .auto-style5 {
            width: 153px;
            height: 27px;
        }
        .auto-style6 {
            height: 27px;
        }
        .auto-style7 {
            width: 141px;
        }
        .auto-style8 {
            width: 153px;
            height: 328px;
        }
        .auto-style9 {
            height: 328px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">
                        <asp:Label ID="lbl_nombreusuario" runat="server" Font-Names="Arial" Font-Size="Large" ForeColor="Maroon"></asp:Label>
                    </td>
                    <td class="auto-style6" colspan="2">
                        <asp:Label ID="lbl_Titulo" runat="server" Font-Bold="True" Font-Size="Large" Text="Listar compras"></asp:Label>
                    </td>
                    <td class="auto-style6">
                        <asp:HyperLink ID="hl_CerrarSesión" runat="server" NavigateUrl="~/Ingreso.aspx">Cerrar Sesión</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">Busqueda por fecha:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="txt_BusquedaxFecha" runat="server"></asp:TextBox>
&nbsp;
                        <asp:Button ID="btn_Filtro" runat="server" Text="Buscar" Width="55px" OnClick="btn_Filtro_Click" />
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style8"></td>
                    <td colspan="2" class="auto-style9">
                        <asp:GridView ID="gv_ListarCompras" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" DataKeyNames="Legajo_Compra" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" OnPageIndexChanging="gv_ListarCompras_PageIndexChanging" OnSelectedIndexChanged="gv_ListarCompras_SelectedIndexChanged" OnSelectedIndexChanging="gv_ListarCompras_SelectedIndexChanging" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID Compra">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_LegajoCompra" runat="server" Text='<%# Eval("Legajo_Compra") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Fecha" runat="server" Text='<%# Eval("Fecha") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_Total" runat="server" Text='<%# Eval("Total") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Legajo_Cliente" Visible="False">
                                    <ItemTemplate>
                                        <asp:Label ID="lbl_LegajoCliente" runat="server" Text='<%# Eval("Legajo_Cliente") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                       
                    </td>
                    <td class="auto-style9">
                        <asp:GridView ID="gv_DetalleCliente" runat="server" CellPadding="3" GridLines="Vertical" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" style="margin-left: 0px">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:TemplateField HeaderText="Legajo Cliente">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegajoCliente" runat="server" Text='<%# Eval("Legajo Cliente") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Dirección">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDireccion" runat="server" Text='<%# Eval("Dirección") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Teléfono">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTelefono" runat="server" Text='<%# Eval("Teléfono") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Correo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCorreo" runat="server" Text='<%# Eval("Correo") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fecha Nac">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFecha" runat="server" Text='<%# Eval("Fecha Nac") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                        <asp:GridView ID="gv_DetalleProducto" runat="server" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID Producto">
                                    <ItemTemplate>
                                        <asp:Label ID="lblLegajoProducto" runat="server" Text='<%# Eval("Legajo_Producto") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nombre">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNombre" runat="server" Text='<%# Eval("Nombre") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCategoria" runat="server" Text='<%# Eval("Categoria") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Precio Unitario">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PU") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cantidad">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Subtotal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSubtotal" runat="server" Text='<%# Eval("Subtotal") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:HyperLink ID="hl_Indice" runat="server" NavigateUrl="~/Indice_Administrador.aspx">Ir al indice</asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
