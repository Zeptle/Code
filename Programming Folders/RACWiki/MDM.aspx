<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="MDM.aspx.vb" Inherits="MDM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<br />
                                        <asp:Label ID="Intro_Label" runat="server" CssClass="text_search"></asp:Label>
                                        <asp:HyperLink ID="HyperLink1" NavigateUrl="MDM_Table_List.aspx"  runat="server">MDM Table List</asp:HyperLink>                                  
                                        <p><asp:Image ID="Image1" runat="server" ImageUrl="images/MDM Arch.jpg" 
                                            Height="422px" Width="554px" /></p>
                                            
    
</asp:Content>

