<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manufacturer.aspx.cs" Inherits="Online_Pharmacy_MS.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <html lang="en">
<head>
    <title>Medicines</title>
    <link rel="stylesheet" href="Medicines.css">
    <style>
        .table-condensed{
            border-collapse:collapse;
        }
       .table-condensed tr th{
           color:#148b0b;
           background-color:#fff;
       }
       .table-condensed , table-condensed tr td{
           border:1px solid #000;
       }
       tr:nth-child(even){
           background:#f8f7ff;
       }
       tr:nth-child(odd){
           background:#fff;
       }
    </style>
</head>
<body>
    <div id="BigCont">
        <div id="Ti">
            <h3>Manufacturer</h3>
        </div>
        <div id="I">
        </div>
        <br><br>
        <div id="Bloc1">
            <input type="text" name="" id="MName" placeholder="Manufacturer Name" runat="server">
            <input type="text" name="" id="MAdd" placeholder="Address" runat="server">
            <input type="text" name="" id="MPhone" placeholder="Phone" runat="server">
            <input type="date" name="" id="MDate" runat="server">

        </div>
        <br><br>
        <div id="BtDiv">
            <asp:Button ID="AddBtn" runat="server" Text="Add"  CssClass="button-common" OnClick="AddBtn_Click"/>
            <asp:Button ID="EditBtn" runat="server" Text="Edit"  CssClass="button-common" OnClick="EditBtn_Click"/>
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete"  CssClass="button-common" OnClick="DeleteBtn_Click"/>
            
            
        </div>

        <br /><br />
        
        <div id="GVDiv">

            <asp:GridView ID="ManGV" runat="server" Width="80%" Height="80px" CssClass="table table-condensed table-hover" AutoGenerateSelectButton="True" OnSelectedIndexChanged="ManGV_SelectedIndexChanged"></asp:GridView>

         </div>
       
    </div>
</body>
</html>
</asp:Content>
