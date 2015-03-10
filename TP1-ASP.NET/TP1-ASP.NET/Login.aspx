<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1_ASP.NET.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.2/themes/smoothness/jquery-ui.css" />
    <script src="ClientFormUtilities.js"></script>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script type="text/javascript">

        function BuildForm(targetFormID) {
            // création du div qui englobe le formulaire
            divObject = document.createElement("div");
            divObject.setAttribute("class", "main");
            divObject.appendChild(BuildTable(9, 2));
            document.getElementById(targetFormID).appendChild(divObject);
            // création des controles
            AddInputText(0, "Nom d'usager:", "USERNAME");
            AddInputText(1, "Mot de passe:", "PASSWORD");

            // la rangée 2 est volontairement sautée
            AddSubmitButton(3, "Connexion...");
            AddSubmitButton(4, "Inscription...");
            AddSubmitButton(5, "Mot de passe oublié...");
            // installation des "delegates" pour les inputs de classe "ident"
            var inputObjects = document.getElementsByClassName("ident");
            for (i = 0; i < inputObjects.length; i++) {
                inputObjects[i].onkeyup = function () { ConstrainToAlpha(event); };
                inputObjects[i].onblur = function () { HighLiteEmptyInput(event); };
            }
        }
    </script>

    <style> 
        #form1{
            position: absolute;
            left:50%;
            right:50%;
            width: 300px;
            height: 150px;
            margin-left:-200px;
            margin-right:-100px;
            background-color: lightgray;
            border:solid;
            border-width: 1px;
            padding-left:10px;
            padding-top:10px;
        }

        .submitBTN{
            display:block;
            width:150px;
            text-align:center;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script type="text/javascript">
            BuildForm("form1");
        </script>
    </div>
    </form>
</body>
</html>
