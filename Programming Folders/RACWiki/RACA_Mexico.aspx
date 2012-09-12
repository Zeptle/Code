<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="RACA_Mexico.aspx.vb" Inherits="RACA_Mexico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div class="Glossary">
     <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        
             
        
        &nbsp&nbsp Select Country:
        <asp:DropDownList ID="COUNTRY_DropDownList" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="COUNTRY" DataValueField="COUNTRY" AppendDataBoundItems="true"
            CssClass="dropdown_Marts">
            <asp:ListItem>--Select Country--</asp:ListItem>
            <asp:ListItem Value="ALL">   List All   </asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ProviderName="System.Data.OracleClient"
            ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
        &nbsp&nbsp Select State:
        <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="STATE" DataValueField="STATE"
            AutoPostBack="True" DataSourceID="SqlDataSource2" AppendDataBoundItems="true"
            CssClass="dropdown_Marts">
            <asp:ListItem Value="NONE">Select From List...</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ProviderName="System.Data.OracleClient"
            ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
        &nbsp&nbsp Select City:
        <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource3"
            AutoPostBack="True" DataTextField="CITY" DataValueField="CITY" AppendDataBoundItems="True"
            CssClass="dropdown_Marts">
            <asp:ListItem Value="NONE">Select From List...</asp:ListItem>
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ProviderName="System.Data.OracleClient"
            ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
       <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataSourceID="SqlDataSource4"
            ForeColor="Black" GridLines="Vertical" CssClass="DM_gridvew">
            <Columns>
                <asp:BoundField DataField="ORGANIZATION_NAME" HeaderText="Store #" SortExpression="ORGANIZATION_NAME" />
                <asp:BoundField DataField="Store_type" HeaderText="Type" SortExpression="Store_type" />
                <asp:BoundField DataField="ADDRESS_LINE_1" HeaderText="ADDRESS_01" SortExpression="ADDRESS_LINE_1" />
                <asp:BoundField DataField="ADDRESS_LINE_2" HeaderText="ADDRESS_02" SortExpression="ADDRESS_LINE_2" />
                <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                <asp:BoundField DataField="STATE" HeaderText="STATE" SortExpression="STATE" />
                <asp:BoundField DataField="ZIP" HeaderText="ZIP" SortExpression="ZIP" />
                <asp:BoundField DataField="COUNTRY" HeaderText="COUNTRY" SortExpression="COUNTRY" />
                <asp:BoundField DataField="Ownership_Date" HeaderText="OPEN DATE" DataFormatString="{0:M-dd-yyyy}"
                    SortExpression="Ownership_Date" />
                
                <asp:BoundField DataField="Close_Type" HeaderText="Close Type" SortExpression="Close_Type" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#CCCCCC" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ProviderName="System.Data.OracleClient"
            ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"></asp:SqlDataSource>
    </div>
    <br />
</asp:Content>

