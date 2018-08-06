<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function11Product.aspx.cs" Inherits="Function10Corder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Product Table Management</h4>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f11corder">

    </div>
    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Product_No">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Product_No" HeaderText="Product_No" ReadOnly="True" SortExpression="Product_No" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Supplier_No" HeaderText="Supplier_No" SortExpression="Supplier_No" />
                <asp:BoundField DataField="Marketing_Rep_No" HeaderText="Marketing_Rep_No" SortExpression="Marketing_Rep_No" />
                <asp:BoundField DataField="Supply_Depot_No" HeaderText="Supply_Depot_No" SortExpression="Supply_Depot_No" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Product] WHERE [Product_No] = @Product_No" InsertCommand="INSERT INTO [Product] ([Product_No], [Description], [Price], [Supplier_No], [Marketing_Rep_No], [Supply_Depot_No]) VALUES (@Product_No, @Description, @Price, @Supplier_No, @Marketing_Rep_No, @Supply_Depot_No)" SelectCommand="SELECT * FROM [Product]" UpdateCommand="UPDATE [Product] SET [Description] = @Description, [Price] = @Price, [Supplier_No] = @Supplier_No, [Marketing_Rep_No] = @Marketing_Rep_No, [Supply_Depot_No] = @Supply_Depot_No WHERE [Product_No] = @Product_No">
            <DeleteParameters>
                <asp:Parameter Name="Product_No" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Product_No" Type="Int32" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Supplier_No" Type="Int32" />
                <asp:Parameter Name="Marketing_Rep_No" Type="Int32" />
                <asp:Parameter Name="Supply_Depot_No" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Supplier_No" Type="Int32" />
                <asp:Parameter Name="Marketing_Rep_No" Type="Int32" />
                <asp:Parameter Name="Supply_Depot_No" Type="Int32" />
                <asp:Parameter Name="Product_No" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>