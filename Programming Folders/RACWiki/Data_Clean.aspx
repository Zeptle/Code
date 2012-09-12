<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage2.master" AutoEventWireup="false" CodeFile="Data_Clean.aspx.vb" Inherits="Data_Clean" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<p>
                                        <asp:Label ID="OPEN_TEXT" runat="server" CssClass="text_search"></asp:Label></p>
                                        <asp:Label ID="Update_Rules" runat="server" CssClass="text_search"></asp:Label>
                                                                              

                                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="ContentPanel"
                                            ExpandControlID="TitlePanel" CollapseControlID="TitlePanel" Collapsed="True"
                                            TextLabelID="Label1" CollapsedText="(Show Details...)" ExpandedText="(Hide Details...)"
                                            ImageControlID="Image1" CollapsedImage="images/expand_blue.jpg" ExpandedImage="images/collapse_blue.jpg"
                                            SuppressPostBack="true">
                                        </asp:CollapsiblePanelExtender>
                                        <asp:Panel ID="TitlePanel" CssClass="collapsePanelHeader" runat="server">
                                            <asp:Image ID="Image1" runat="server" ImageUrl="images/expand_blue.jpg" />
                                            &nbsp;&nbsp; Customer Cleansing Rules 0 - 36&nbsp;&nbsp;
                                            <asp:Label ID="Label2" runat="server" Text="Label">(Show Details...)</asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="ContentPanel" CssClass="collapsePanel" runat="server" Width="550px">
                                            <asp:GridView ID="GridView1" Width="550px" CssClass="DM_gridvew" runat="server" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" EnableViewState="False">
                                                <RowStyle BackColor="#EFF3FB" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
                                                <HeaderStyle BackColor="#0F8491" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                            </asp:GridView>
                                        </asp:Panel>
                                        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="ContentPanel2"
                                            ExpandControlID="TitlePanel2" CollapseControlID="TitlePanel2" Collapsed="True"
                                            TextLabelID="Label4" CollapsedText="(Show Details...)" ExpandedText="(Hide Details...)"
                                            ImageControlID="Image2" CollapsedImage="images/expand_blue.jpg" ExpandedImage="images/collapse_blue.jpg"
                                            SuppressPostBack="true">
                                        </asp:CollapsiblePanelExtender>
                                        <asp:Panel ID="TitlePanel2" CssClass="collapsePanelHeader2" runat="server">
                                            <asp:Image ID="Image2" runat="server" ImageUrl="images/expand_blue.jpg" />
                                            &nbsp;&nbsp; Customer Cleansing Rules 37 - 59&nbsp;&nbsp;
                                            <asp:Label ID="Label4" runat="server" Text="Label">(Show Details...)</asp:Label>
                                        </asp:Panel>
                                        <asp:Panel ID="ContentPanel2" CssClass="collapsePanel" runat="server" Width="550px">
                                            <asp:GridView ID="GridView2" Width="550px" CssClass="DM_gridvew" runat="server" CellPadding="4"
                                                ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" EnableViewState="False">
                                                <RowStyle BackColor="#EFF3FB" />
                                                <FooterStyle BackColor="#CCCCCC" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#000099" ForeColor="White" Font-Bold="True" />
                                                <HeaderStyle BackColor="#0F8491" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="#CCCCCC" />
                                            </asp:GridView>
                                        </asp:Panel>
</asp:Content>

