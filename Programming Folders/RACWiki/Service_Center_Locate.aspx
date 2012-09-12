<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage3.master" AutoEventWireup="false" CodeFile="Service_Center_Locate.aspx.vb" Inherits="Service_Center_Locate" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2>Locate Service Center</h2>
<p>This is to search through all service centers in the Rent-A-Center company and find the closest one to the zip code.  Make sure enter the zip with 5 digits.  <b>Please note, this may take a little longer than a normal web page for results due to calculating the distances.</b></p>
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
        ErrorMessage="Invalid ZIP code, format should be either 12345." ControlToValidate="Zip_TextBox" 
        ValidationExpression="\d{5}(-\d{4})?" /><br />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
         ErrorMessage="Invalid ZIP code, format should be either 12345." 
        ControlToValidate="Zip_TextBox"></asp:RequiredFieldValidator>
 <br />
       Enter Zip Code: <asp:TextBox ID="Zip_TextBox" runat="server" MaxLength="5"></asp:TextBox>


        <asp:Button ID="Button3" runat="server" Text="Locate Service Center" />
    
   <br />   <br /> <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />   <br /> 
       <cc1:GMap ID="GMap1" runat="server" Width="800px" Height="500px" 
        enableGoogleBar="True" enableHookMouseWheelToZoom="True" Version="3.x" />
    
</asp:Content>

