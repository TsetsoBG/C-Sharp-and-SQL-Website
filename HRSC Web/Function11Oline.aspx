<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function11Oline.aspx.cs" Inherits="Function10Corder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Oline Table Management</h4>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f11corder">

    </div>
    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Corder_No,Product_No">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Corder_No" HeaderText="Corder_No" ReadOnly="True" SortExpression="Corder_No" />
                <asp:BoundField DataField="Product_No" HeaderText="Product_No" ReadOnly="True" SortExpression="Product_No" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Oline] WHERE [Corder_No] = @Corder_No AND [Product_No] = @Product_No" InsertCommand="INSERT INTO [Oline] ([Corder_No], [Product_No], [Quantity]) VALUES (@Corder_No, @Product_No, @Quantity)" SelectCommand="SELECT * FROM [Oline]" UpdateCommand="UPDATE [Oline] SET [Quantity] = @Quantity WHERE [Corder_No] = @Corder_No AND [Product_No] = @Product_No">
            <DeleteParameters>
                <asp:Parameter Name="Corder_No" Type="Int32" />
                <asp:Parameter Name="Product_No" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Corder_No" Type="Int32" />
                <asp:Parameter Name="Product_No" Type="Int32" />
                <asp:Parameter Name="Quantity" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Quantity" Type="Int32" />
                <asp:Parameter Name="Corder_No" Type="Int32" />
                <asp:Parameter Name="Product_No" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>