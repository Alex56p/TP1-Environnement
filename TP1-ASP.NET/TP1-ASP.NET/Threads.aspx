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
                <asp:UpdatePanel ID="UPN_Threads" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PN_Threads" runat="server" ScrollBars="Vertical"></asp:Panel>
                    </ContentTemplate>
                    <Triggers>
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UPN_Titre" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BTN_Nouveau" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
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
                <asp:CheckBox ID="CB_Tous" runat="server" />
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
                    </Triggers>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>

</asp:Content>
