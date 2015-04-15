<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Room1.aspx.cs" Inherits="TP1_ASP.NET.Room1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:UpdatePanel ID="Panel_Chat" UpdateMode="Conditional" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:Timer ID="SessionTimeOut" runat="server" Interval="1000" OnTick="SessionTimeOut_Tick"></asp:Timer>
                <asp:Panel ID="PN_ListUsers" runat="server"></asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
    </div>
</asp:Content>
