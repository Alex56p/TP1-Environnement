<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="Threads.aspx.cs" Inherits="TP1_ASP.NET.Threads" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UPN_Threads" runat="server">
        <ContentTemplate>        
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
                        <asp:Panel ID="PN_Threads" runat="server" ScrollBars="Vertical"></asp:Panel>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td  class="TD_BTN">
                        <asp:Button ID="BTN_Nouveau" runat="server" Text="Nouveau" OnClick="BTN_Nouveau_Click" Width="70px"/>

                    </td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Sélection des invités"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="TD_BTN">
                        <asp:Button ID="BTN_Modifier" CssClass="TD_BTN" runat="server" Text="Modifier" OnClick="BTN_Modifier_Click" Width="70px"/>
                        <asp:Button ID="BTN_Effacer" CssClass="TD_BTN" runat="server" Text="Effacer" Width="70px" OnClick="BTN_Effacer_Click" />
                        <asp:Button ID="BTN_Retour" CssClass="TD_BTN" runat="server" Text="Retour" Width="70px" OnClick="BTN_Retour_Click"/>
                    </td>
                    <td>
                        <asp:CheckBox id="CB_Tous" runat="server" />
                         <asp:Label ID="Label4" runat="server" Text="Tous les usagers"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td> </td>
                    <td>
                        <asp:Panel ID="Panel_Usagers" runat="server" ScrollBars="Auto" Height="200px">
                            <asp:Table ID="Table_Usagers" runat="server"></asp:Table>
                        </asp:Panel>
                    </td>
                </tr>
              </table>
            </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
