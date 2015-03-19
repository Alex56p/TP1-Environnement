<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bloquer.aspx.cs" Inherits="TP1_ASP.NET.Bloquer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <div>    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="OnTick"></asp:Timer>
    <h1>
        Session expirée!
    </h1>
    </div>
    </form>
</body>
</html>
