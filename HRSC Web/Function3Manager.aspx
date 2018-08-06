<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function3Manager.aspx.cs" Inherits="Function3Manager" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Update Database.</h4>
    <div id="f1Button">

    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" DataKeyNames="User_No" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="Vertical" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowEditButton="True" />
                <asp:BoundField DataField="User_No" HeaderText="User_No" InsertVisible="False" ReadOnly="True" SortExpression="User_No" />
                <asp:BoundField DataField="User_Type" HeaderText="User_Type" SortExpression="User_Type" />
                <asp:BoundField DataField="User_Name" HeaderText="User_Name" SortExpression="User_Name" />
                <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [User] WHERE [User_No] = @User_No" InsertCommand="INSERT INTO [User] ([User_Type], [User_Name], [Password]) VALUES (@User_Type, @User_Name, @Password)" SelectCommand="SELECT * FROM [User]" UpdateCommand="UPDATE [User] SET [User_Type] = @User_Type, [User_Name] = @User_Name, [Password] = @Password WHERE [User_No] = @User_No">
            <DeleteParameters>
                <asp:Parameter Name="User_No" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="User_Type" Type="String" />
                <asp:Parameter Name="User_Name" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="User_Type" Type="String" />
                <asp:Parameter Name="User_Name" Type="String" />
                <asp:Parameter Name="Password" Type="String" />
                <asp:Parameter Name="User_No" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>