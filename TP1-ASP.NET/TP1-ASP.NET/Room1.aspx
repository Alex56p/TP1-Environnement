<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Room1.aspx.cs" Inherits="TP1_ASP.NET.Room1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Panel ID="PN_ListUsers" runat="server"></asp:Panel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
    </div>
</asp:Content>
