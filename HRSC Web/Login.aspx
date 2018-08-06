<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="loginBody">
        <div id="Member">
        <asp:Label ID="Label3" runat="server" Text="Login"></asp:Label>
        </div>

        <div id="Username">
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
        </div>

        <div id="textbox1">
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Height="21px" Width="158px"></asp:TextBox>
        </div>
        
        <div id="error">
          <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
        </div>
        <div id="Password">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>

        </div>

        <div id="textbox2">
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" Height="21px" Width="158px" TextMode="Password"></asp:TextBox>

        </div>
        
        <div id="LoginButton">
            <asp:Button ID="Button1" runat="server" Text="LOGIN" Height="37px" Width="95px" Font-Size="15px" Font-Bold="true" OnClick="Button1_Click" />
        </div>
    </div>

</asp:Content>
