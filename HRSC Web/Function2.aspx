<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function2.aspx.cs" Inherits="Function2" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Find Order Details by Customer using Customer Name or Customer Number.</h4>
    <div id="f1DropDown">
    <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="cName">Customer Name</asp:ListItem>
                <asp:ListItem Value="cNumber">Customer Number</asp:ListItem>
    </asp:DropDownList>
    </div>
    <div id="f1TextBox">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div id="f1error">
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    <div id="f1Button">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Find" Height="34px" Width="47px" />

    <div id="f1Grid">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
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
        </div>
    </div>
</asp:Content>