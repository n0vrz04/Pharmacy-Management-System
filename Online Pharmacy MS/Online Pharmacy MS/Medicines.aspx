<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicines.aspx.cs" Inherits="Online_Pharmacy_MS.About" %>

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
            <h3>Medicines</h3>
        </div>
        <div id="I">
            <img src="img/Caduceus.svg" alt="caduceus">
        </div>
        <br><br>
        <div id="Bloc1">
            <input type="text" name="" id="MName" placeholder="Medicine Name" runat="server">
            <asp:DropDownList ID="MType" runat="server">
                <asp:ListItem Text="Sirop" Value="Sirop"></asp:ListItem>
                <asp:ListItem Text="Tablets" Value="Tablets"></asp:ListItem>
                <asp:ListItem Text="Injections" Value="Injections"></asp:ListItem>
                <asp:ListItem Text="Perfusion" Value="Perfusion"></asp:ListItem>
            </asp:DropDownList>
            <input type="number" name="" id="MQty" placeholder="Quantity" runat="server">
            <input type="number" name="" id="MPrice" placeholder="Price" runat="server">
            <asp:DropDownList ID="MMan" runat="server">
                <asp:ListItem Text="Alfamed" Value="Alfamed"></asp:ListItem>
                <asp:ListItem Text="Avita" Value="Avita"></asp:ListItem>
                <asp:ListItem Text="Avromed" Value="Avromed"></asp:ListItem>
                <asp:ListItem Text="Biomed" Value="Biomed"></asp:ListItem>
                <asp:ListItem Text="MedHouse" Value="MedHouse"></asp:ListItem>
            </asp:DropDownList>

        </div>
        <br><br>
        <div id="BtDiv">
            <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click" CssClass="button-common"/>
            <asp:Button ID="EditBtn" runat="server" Text="Edit" OnClick="EditBtn_Click" CssClass="button-common"/>
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete" OnClick="DeleteBtn_Click" CssClass="button-common"/>
            
            
        </div>

        <br /><br />
        
        <div id="GVDiv">

            <asp:GridView ID="MedGV" runat="server" Width="80%" Height="80px" OnSelectedIndexChanged="MedGV_SelectedIndexChanged" CssClass="table table-condensed table-hover" AutoGenerateSelectButton="True"></asp:GridView>

         </div>
       
    </div>
</body>
</html>
</asp:Content>
