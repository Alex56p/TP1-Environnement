<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Threads.aspx.cs" Inherits="TP1_ASP.NET.Threads" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Liste de mes discussions"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Titre de la discussion"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ListBox ID="LB_Threads" runat="server" Height="190px" Width="150px"></asp:ListBox>
            </td>
            <td>
                <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td  class="TD_BTN">
                <asp:Button ID="BTN_Nouveau" runat="server" Text="Nouveau" OnClick="BTN_Nouveau_Click"/>

            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Sélection des invités"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TD_BTN">
                <asp:Button ID="BTN_Modifier" runat="server" Text="Modifier" OnClick="BTN_Modifier_Click" Width="70px"/>
            </td>
            <td>
                <asp:Panel ID="Panel_Usagers" runat="server"></asp:Panel>
            </td>
        </tr>
        <tr>
            <td  class="TD_BTN">
                <asp:Button ID="BTN_Effacer" runat="server" Text="Effacer" Width="73px" OnClick="BTN_Effacer_Click" />
            </td>
        </tr>
        <tr>
            <td  class="TD_BTN">
                <asp:Button ID="BTN_Retour" runat="server" Text="Retour" Width="72px" OnClick="BTN_Retour_Click"/>
            </td>
        </tr>
    </table>

</asp:Content>
