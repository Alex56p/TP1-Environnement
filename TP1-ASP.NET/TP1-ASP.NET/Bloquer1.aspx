<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Bloquer1.aspx.cs" Inherits="TP1_ASP.NET.Bloquer1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="OnTick"></asp:Timer>
        <h1>Session expirée!</h1>
    </div>
</asp:Content>
