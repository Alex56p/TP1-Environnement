<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Index1.aspx.cs" Inherits="TP1_ASP.NET.Index1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: auto; width: 220px;background-color: lightgray; padding-left: 10px; padding-top: 10px; border: 1px solid black;">
        <table>
            <tr>
                <td>
                    <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." OnClick="BTN_Profil_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Online" runat="server" Text="Usagers en ligne..." OnClick="BTN_Online_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Journal" runat="server" Text="Journal des visites..." OnClick="BTN_Journal_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_ChatRoom" runat="server" Text="Salle de discussions..." OnClick="BTN_ChatRoom_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Gerer" runat="server" Text="Gérer mes discussions..." OnClick="BTN_Gerer_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Deconnexion" runat="server" Text="Déconnexion..." OnClick="BTN_Deconnexion_Click" Width="200px" CssClass="textcenter"/>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
