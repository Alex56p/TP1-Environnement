﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Index1.aspx.cs" Inherits="TP1_ASP.NET.Index1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Stylesheets" runat="server">
        <link rel="stylesheet" href="/MasterPageCSS.css" type="text/css" />
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." OnClick="BTN_Profil_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Online" runat="server" Text="Usagers en ligne..." OnClick="BTN_Online_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Journal" runat="server" Text="Journal des visites..." OnClick="BTN_Journal_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Deconnexion" runat="server" Text="Déconnexion..." OnClick="BTN_Deconnexion_Click" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
