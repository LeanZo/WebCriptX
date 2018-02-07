<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCriptX._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
            <table style="width: 100%;">
                <tr align="center">
                    <td><asp:Label ID="Label1" runat="server" Text="Insira o Texto:"></asp:Label></td>
                    <td>Palavra Chave:</td>
                    <td></td>
                </tr>
                <tr align="center">
                    <td><asp:TextBox ID="TextBoxText" runat="server" Height="161px" Width="480px" Wrap="false" TextMode="MultiLine" ></asp:TextBox></td>
                    <td><asp:TextBox ID="TextBoxPassword" runat="server" Width="236px"></asp:TextBox></td>
                    <td></td>
                </tr>
                <tr align="center">
                    <td>&nbsp;</td>
                    <td><asp:Button ID="Btn_Encriptar" runat="server" Text="Encriptar" />&nbsp;<asp:Button ID="Btn_Decriptar" runat="server" Text="Decriptar" /></td>
                    <td></td>
                </tr>
            </table>
    </div>

</asp:Content>