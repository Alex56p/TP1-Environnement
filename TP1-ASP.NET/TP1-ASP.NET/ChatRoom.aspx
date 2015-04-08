<%@ Page Title="Chat Room..." Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_ASP.NET.ChatRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
    <link rel="stylesheet" href="/MasterPageCSS.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <asp:Panel ID="Panel_Chat" runat="server"></asp:Panel>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TB_Text" runat="server"></asp:TextBox>
                    <asp:Button ID="BTN_Envoyer" runat="server" Text="Envoyer..." OnClick="BTN_Envoyer_Click" />
                </td>
            </tr>
        </table>
    </div>
    
                
</asp:Content>
