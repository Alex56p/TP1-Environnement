<%@ Page Title="Chat Room..." Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1_ASP.NET.ChatRoom" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: auto; width: 65%; background-color: lightgray; padding-left: 10px; padding-top: 10px; border: 1px solid black;">
        <asp:Panel runat="server" DefaultButton="BTN_Envoyer">
                <table style="width: 849px">
                    <tr>
                        <td style="width: 176px">Liste des discussions</td>
                        <td style="width: 327px">
                            <asp:Label ID="Titre" runat="server">... </asp:Label>
                            <asp:Label runat="server">Créateur: </asp:Label>
                            <asp:Label ID="Createur" runat="server">*créateur</asp:Label>
                            <asp:Label ID="Date" runat="server">*date</asp:Label>
                        </td>
                        <td>Invités</td>
                    </tr>
                    <tr>
                        <td>
                            <div style="height:400px;margin: auto; background-color: white;width:200px">
                                <asp:Panel runat="server" ScrollBars="Auto">
                                        <asp:UpdatePanel ID="UPN_Threads" runat="server">
                                        <ContentTemplate>
                                            <asp:Panel ID="PN_Threads" runat="server" ScrollBars="Vertical"></asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                                
                            </div>
                        </td>
                        <td style="width: 325px">
                            <div style="height:400px;margin: auto; background-color: white;width:600px">
                                <asp:UpdatePanel ID="UPN_Chat" runat="server">
                                    <ContentTemplate>
                                        <asp:Timer ID="TimerPanel" runat="server" OnTick="TimerPanel_Tick" Interval="1000"></asp:Timer>
                                        <asp:Panel ID="Panel_Chat" runat="server" ScrollBars="Vertical">
                                            <asp:Table ID="Chat" runat="server"></asp:Table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </td>
                        <td>
                            <div style="height:400px;margin: auto; background-color: white;width:200px">
                                <asp:UpdatePanel ID="UPN_Users" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel_Users" runat="server" ScrollBars="Vertical">
                                            <asp:Table ID="TableUsers" runat="server"></asp:Table>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>

                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 327px">
                            <asp:UpdatePanel ID="Panel_TB" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:TextBox ID="TB_Text" TextMode="MultiLine" runat="server" AutoPostBack="true" Width="600px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Button ID="BTN_Envoyer" runat="server" Text="Envoyer..." OnClick="BTN_Envoyer_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:UpdatePanel ID="UP_LB" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="LB_Modifier" runat="server" Text="veuillez entrer le nouveau texte" Visible="false"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="BTN_Retour" CssClass="TD_BTN" runat="server" Text="Retour" Width="70px" OnClick="BTN_Retour_Click" />
                        </td>
                    </tr>
                </table>
        </asp:Panel>
    </div>


</asp:Content>
