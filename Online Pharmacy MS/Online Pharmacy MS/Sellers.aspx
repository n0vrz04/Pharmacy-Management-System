<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sellers.aspx.cs" Inherits="Online_Pharmacy_MS.Sellers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
            <h3>Sellers</h3>
        </div>
        <div id="I">
        </div>
        <br><br>
        <div id="Bloc1">
            <input type="text" name="" id="SName" placeholder="Seller Name" runat="server">
            <asp:DropDownList ID="SGen" runat="server">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:DropDownList>
            <input type="date" name="" id="SDOB" runat="server">
            <input type="text" name="" id="SPhone" placeholder="Phone Number" runat="server">
            <input type="text" name="" id="SAdd" placeholder="Seller Address" runat="server">
            <input type="password" name="" id="SPass" placeholder="Seller Password" runat="server">
            

        </div>
        <br><br>
        <div id="BtDiv">
            <asp:Button ID="AddBtn" runat="server" Text="Add"  CssClass="button-common" OnClick="AddBtn_Click"/>
            <asp:Button ID="EditBtn" runat="server" Text="Edit"  CssClass="button-common" OnClick="EditBtn_Click"/>
            <asp:Button ID="DeleteBtn" runat="server" Text="Delete"  CssClass="button-common" OnClick="DeleteBtn_Click"/>
            
            
        </div>

        <br /><br />
        
        <div id="GVDiv">

            <asp:GridView ID="SellerGV" runat="server" Width="80%" Height="80px" CssClass="table table-condensed table-hover" AutoGenerateSelectButton="True" OnSelectedIndexChanged="SellerGV_SelectedIndexChanged"></asp:GridView>

         </div>
       
    </div>
</body>
</html>
</asp:Content>
