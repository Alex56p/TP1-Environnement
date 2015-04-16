﻿<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Room1.aspx.cs" Inherits="TP1_ASP.NET.Room1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:UpdatePanel ID="Panel_Chat" UpdateMode="Conditional" runat="server">     
            <ContentTemplate>
                <asp:Timer ID="Timer1" OnTick="Timer1_Tick" Interval="3000" runat="server"></asp:Timer>
                <asp:Panel ID="PN_ListUsers" runat="server"></asp:Panel>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>

        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" />
    </div>
</asp:Content>
