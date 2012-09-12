<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="diagrams.aspx.vb" Inherits="diagrams" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
    <b><a name="DW_BO_devtest.JPG" class="DW_Links">Dev Warehouse</a></b><br />
    <br />
    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="http://racwiki/documents/DW_BO_devtest.JPG" />
    <br />
    <br />
    <br />
    <b><a name="DW_BO_prod.JPG" class="DW_Links">Production Warehouse</a></b><br />
    <br />
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="http://racwiki/documents/DW_BO_prod.JPG" />
</asp:Content>

