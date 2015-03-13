<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1_ASP.NET.LoginsJournal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        div{
            display:block;
        }

        tbody {
          display: table-row-group;
          vertical-align: middle;
          border-color: inherit;
        }

        .header{
            width:99%;
        }
        .mainHeader{
                  width: 100%;
                  padding: 0px;
                }
        .thumbnail{
            width:64px;
            height:64px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainHeader">
        <table>
            <tbody>
                 <tr>
                    <td class="header">
                        <h2>Journal de connexion...</h2>
                    </td>
                    <td >
                        <asp:Label ID="LB_HdrUserName" runat="server" Text="Anonymous"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="Img_Username" CssClass="thumbnail"  runat="server" />
                    </td>
                </tr>
            </tbody>
            
        </table>
    </div>
    <div>
    
    </div>
    </form>
</body>
</html>
