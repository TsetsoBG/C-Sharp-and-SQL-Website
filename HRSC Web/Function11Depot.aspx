﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function11Depot.aspx.cs" Inherits="Function10Corder" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Depot Table Management</h4>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f11corder">

    </div>
    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Depot_No">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Depot_No" HeaderText="Depot_No" ReadOnly="True" SortExpression="Depot_No" />
                <asp:BoundField DataField="Location" HeaderText="Location" SortExpression="Location" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="Rep_No" HeaderText="Rep_No" SortExpression="Rep_No" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Depot] WHERE [Depot_No] = @Depot_No" InsertCommand="INSERT INTO [Depot] ([Depot_No], [Location], [Address], [Rep_No]) VALUES (@Depot_No, @Location, @Address, @Rep_No)" SelectCommand="SELECT * FROM [Depot]" UpdateCommand="UPDATE [Depot] SET [Location] = @Location, [Address] = @Address, [Rep_No] = @Rep_No WHERE [Depot_No] = @Depot_No">
            <DeleteParameters>
                <asp:Parameter Name="Depot_No" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Depot_No" Type="Int32" />
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Rep_No" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="Location" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="Rep_No" Type="Int32" />
                <asp:Parameter Name="Depot_No" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        </div>
    </div>
</asp:Content>