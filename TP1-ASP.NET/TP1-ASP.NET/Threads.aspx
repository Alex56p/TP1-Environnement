<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Threads.aspx.cs" Inherits="TP1_ASP.NET.Threads" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UPN_Erreur" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="LB_Titre_Check" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LB_Empty_Check" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LB_Usagers_Check" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BTN_Nouveau" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BTN_Creer" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
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
                <asp:UpdatePanel ID="UPN_Threads" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PN_Threads" runat="server" ScrollBars="Vertical"></asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <asp:UpdatePanel ID="UPN_Titre" UpdateMode="Conditional" runat="server">
                <ContentTemplate>
                    <td>
                        <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
                    </td>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="BTN_Nouveau" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </tr>
        <tr>
            <td class="TD_BTN">
                <asp:Button ID="BTN_Nouveau" runat="server" Text="Nouveau" OnClick="BTN_Nouveau_Click" Width="70px" />
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Sélection des invités"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="TD_BTN">
                <asp:UpdatePanel ID="UPN_Bouton" runat="server">
                    <ContentTemplate>
                        <asp:Button ID="BTN_Creer" CssClass="TD_BTN" runat="server" Text="Créer" OnClick="BTN_Modifier_Click" Width="70px" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Button ID="BTN_Effacer" CssClass="TD_BTN" runat="server" Text="Effacer" Width="70px" OnClick="BTN_Effacer_Click" />
                <asp:Button ID="BTN_Retour" CssClass="TD_BTN" runat="server" Text="Retour" Width="70px" OnClick="BTN_Retour_Click" />
            </td>
            <td>
                <asp:UpdatePanel ID="UPN_CheckBox" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="CB_Tous" runat="server" OnCheckedChanged="CB_Tous_CheckedChanged" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Nouveau" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
                <asp:Label ID="Label4" runat="server" Text="Tous les usagers"></asp:Label>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:UpdatePanel ID="UPN_Usagers" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="Panel_Usagers" runat="server" ScrollBars="Auto" Height="200px">
                            <asp:Table ID="Table_Usagers" runat="server"></asp:Table>
                        </asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Nouveau" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="CB_Tous" EventName="CheckedChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Content>
