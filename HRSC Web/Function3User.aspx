<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Function3User.aspx.cs" Inherits="Function3User" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h4>Update Password
    </h4>
     <asp:Label ID="f3ULabel" runat="server" Text="Current Password: "></asp:Label>     <asp:Label ID="f3ULabel2" runat="server" Text=""></asp:Label>
    <div id="f1TextBox">

    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </div>
    <div id="f1Button">
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" Height="42px" Width="76px" />

    <div id="f3Grid">
        </br>
    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>