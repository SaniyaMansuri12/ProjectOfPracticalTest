<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CrudOperationWithStoredProcedureGrid.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .Heading{
            text-align : left;
        }
        .auto-style1 {
            margin-left: 69px;
        }
        .auto-style2 {
            margin-left: 129px;
        }
        .auto-style3 {
            margin-left: 32px;
        }
        .auto-style4 {
            width: 29%;
            height: 21px;
        }
        .auto-style5 {
            width: 463px;
            height: 22px;
        }
        .auto-style6 {
            width: 566px;
            height: 22px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="Heading">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Product Details </h1>
            <table class="auto-style4">
                <tr>
                    <td class="auto-style5">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Select Product&nbsp;</td>
                    <td class="auto-style6">
                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style3" Height="34px" Width="150px">
                </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <p class="Heading">
                <asp:Button ID="btnSearch" runat="server" CssClass="auto-style2" Height="34px" OnClick="btnSearch_Click" Text="Search" Width="99px" />
            </p>
            <p class="Heading" style="font-weight: bold; color: #FF0000">
                &nbsp;&nbsp;&nbsp; NOTE - User Can Only Edit Product Details</p>
        </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" CssClass="auto-style1" GridLines="None" Height="228px" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" Width="762px">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                <asp:BoundField DataField="ProductDescription" HeaderText="ProductDescription" />
                <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" />
                <asp:BoundField DataField="Username" HeaderText="Username" />
            </Columns>
            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#594B9C" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#33276A" />
        </asp:GridView>
    </form>
</body>
</html>
