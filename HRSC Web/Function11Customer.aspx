<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function11Customer.aspx.cs" Inherits="Function10Corder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Customer Table Management</h4>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f1Button">

    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Custno">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Custno" HeaderText="Custno" ReadOnly="True" SortExpression="Custno" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Depot_No" HeaderText="Depot_No" SortExpression="Depot_No" />
                <asp:BoundField DataField="Credit_Limit" HeaderText="Credit_Limit" SortExpression="Credit_Limit" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Customer] WHERE [Custno] = @Custno" InsertCommand="INSERT INTO [Customer] ([Custno], [Name], [Address], [Depot_No], [Credit_Limit]) VALUES (@Custno, @Name, @Address, @Depot_No, @Credit_Limit)" SelectCommand="SELECT * FROM [Customer]" UpdateCommand="UPDATE [Customer] SET [Name] = @Name, [Address] = @Address, [Depot_No] = @Depot_No, [Credit_Limit] = @Credit_Limit WHERE [Custno] = @Custno">
            <DeleteParameters>
                <asp:Parameter Name="Custno" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Custno" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Depot_No" Type="Int32" />
                <asp:Parameter Name="Credit_Limit" Type="Decimal" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Depot_No" Type="Int32" />
                <asp:Parameter Name="Credit_Limit" Type="Decimal" />
                <asp:Parameter Name="Custno" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>