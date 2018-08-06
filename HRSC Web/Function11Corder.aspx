<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function11Corder.aspx.cs" Inherits="Function10Corder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Corder Table Management</h4>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f11corder">

    </div>
    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Corder] WHERE [Corder_No] = @Corder_No" InsertCommand="INSERT INTO [Corder] ([Corder_No], [Customer_No], [Date_Placed], [Date_Delivered]) VALUES (@Corder_No, @Customer_No, @Date_Placed, @Date_Delivered)" SelectCommand="SELECT * FROM [Corder]" UpdateCommand="UPDATE [Corder] SET [Customer_No] = @Customer_No, [Date_Placed] = @Date_Placed, [Date_Delivered] = @Date_Delivered WHERE [Corder_No] = @Corder_No">
            <DeleteParameters>
                <asp:Parameter Name="Corder_No" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Corder_No" Type="Int32" />
                <asp:Parameter Name="Customer_No" Type="Int32" />
                <asp:Parameter DbType="DateTime2" Name="Date_Placed" />
                <asp:Parameter DbType="DateTime2" Name="Date_Delivered" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Customer_No" Type="Int32" />
                <asp:Parameter DbType="DateTime2" Name="Date_Placed" />
                <asp:Parameter DbType="DateTime2" Name="Date_Delivered" />
                <asp:Parameter Name="Corder_No" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>