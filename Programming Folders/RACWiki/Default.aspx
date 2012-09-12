<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage3.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="Whatever" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="SearchCloud" Namespace="IntrepidStudios.SearchCloud" TagPrefix="IS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <br />
    <asp:Panel ID="Panel2" runat="server" DefaultButton="Button1">
        
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="Advanced_Search.aspx" ForeColor="White">Advanced Search</asp:LinkButton>
        
        <asp:TextBox ID="Search_textBox" class="text_search" runat="server" Width="300px"></asp:TextBox>
        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="Search_textBox"
            ServiceMethod="GetCompletionList" UseContextKey="True" MinimumPrefixLength="1"
            CompletionSetCount="15" CompletionInterval="0" EnableViewState="True">
        </asp:AutoCompleteExtender>
        <asp:Button ID="Button1" runat="server" Text="Search" />
        &nbsp&nbsp&nbsp&nbsp</asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Welcome_MSG">
        <asp:Label ID="Intro_Label" runat="server">Welcome to RACiPedia, RAC’s collaborative online information source created by coworkers, 
        for coworkers. Your input is needed to keep the site up to date. So how can you contribute? When you see RACiPedia entries that can 
        be improved, or when you’d like to add new information, click the <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="http://racwiki/images/Big_Question.png"  OnClientClick="window.open('http://racwiki/Comments.aspx', 'child', 'height=500,width=700,scrollbars=no'); return false" ImageAlign="Middle" Width="17" Height="17" />  
        to submit your ideas for page updates.
        <h3>RACiPedia Includes</h3>
        <p><b>Glossary for all Coworkers</b><br />
        Explains terms used in our daily business operations. Just click the glossary tab at top or enter your term into the Search Box at upper right.</p>
        <p><b>Documentation for Technical Teams</b><br />
        Provides in-depth data warehouse and MDM process information for Field Support Center coworkers who support these processes. Just click the Technical Docs tab at upper right.</p>
        <i>Most recently updated terms, and most commonly searched terms are below.</i>
        
        </asp:Label>
    </div>
    <br />
    
    
    <asp:Panel ID="IMPT_MSG_PANEL" runat="server" >
    <table border="0" cellpadding="0" cellspacing="0" width="800px">
        <tr>
            <td colspan="3"><img src="images/Attention_01.gif" width="800" alt=""></td>
        </tr>
        <tr>
            <td  background="images/Attention_02.gif" width="40" style="height: 65%; text-align:left;"></td>
            <td width="730" class="IMPT_MSG" style="height: 65%">
                Effective upon SIMS release, The terms BOR and APU will be change to the following
                names:
                <br />
                <ul>
                    <li>Balance on Rent (BOR) -> Accounts on Rent (AOR) 
                        <a href="http://racwiki/Glossary.aspx?id=13#13" >Definition</a></li>
                    <li>Average Per Unit (APU) -> Average Per Account (APA) <a href="http://racwiki/Glossary.aspx?id=8#8" >Definition</a></li>
                </ul>
            </td>
            <td background="images/Attention_04.gif" width="32" style="height: 100%"></td>
        </tr>
        <tr>
            <td colspan="3">
                <img src="images/Attention_05.gif" width="800" alt="">
            </td>
        </tr>
    </table>
    </asp:Panel>
    
    <asp:Panel ID="MAIN_Panel" runat="server">
    
<table border="0" width="800px">
<tr>
    <td valign="top">
    <asp:ListView ID="ListView2" runat="server" DataSourceID="SqlDataSource2">
        <LayoutTemplate>
        <div class="Update_MSG_Align">
            <table border="0" width="400px" cellpadding="0" cellspacing="0" class="column2_Update">
            <tr id="Tr2" runat="server">
                <td colspan="2" valign="top" align="center" class="Cloud_Header"><b>Recently Updated Terms</b></td>
            </tr>
            <tr runat="server" id="itemPlaceholder"></tr>
            </table></div>
        <br />
        </LayoutTemplate>
        <ItemTemplate>
            <tr>
                <td colspan="2"><hr /></td>
            </tr>
            <tr id="Tr1" runat="server">
                <td>
                    
                    <asp:HyperLink ID="HyperLink1" class="Search_display" Text='<%#Eval("Entity_Name") %>'
                    NavigateUrl='<%#Eval("URL") + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID"))%> '
                    runat="server"></asp:HyperLink>&nbsp<asp:Label ID="Label2" CssClass="column1_Update" runat="server" Text='<%#Eval("Update_Date") %>'></asp:Label>&nbsp     
                    
                    <br />
                       <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUMMARY") %>' />
                    
                    <br />
                    
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Sourace=oraedw;User Id=metadata;Password=meta_dw;"
    ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
    </td>
    <td align="justify" valign="top">
        <table border="0" cellpadding="0"  cellspacing="0"   class="Cloud_align">
        <tr>
            <td align="center" class="Cloud_Header"><b>Popular Term Searches</b><hr /></td>
        </tr>
        <tr>
            <td><IS:Cloud ID="cloud1" MaxColor="#339966" MinColor="#999999" MaxFontSize="150" MinFontSize="80"
        FontUnit="%" CssClass="cloud" runat="server" Visible="False" Height="100%" 
                    Width="100%"  /></td>
        </tr>
        </table>
    
    
        
       
    </td>
</tr>
</table>
</asp:Panel>




    <asp:ListView runat="server" ID="ListView1" DataSourceID="SqlDataSource1" DataKeyNames="Entity_ID">
        <LayoutTemplate>
            <table id="Table1" border="0" width="500px" cellpadding="0" cellspacing="0" align="center"
                runat="server">
                <tr id="Tr2" runat="server">
                    <td colspan="3" valign="bottom" class="Results_01" align="center">
                        <asp:Label ID="Label4" runat="server" Text="Glossary Results" CssClass="header"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="itemPlaceholder">
                </tr>
                <tr id="Tr5" runat="server">
                    <td colspan="3" align="left">
                        <asp:Image ID="Image2" runat="server" Width="500px" ImageUrl="http://racwiki/images/Results/Results_Frame_05.gif" />
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink ID="HyperLink1" Width="400px" class="Search_display" Text='<%#Eval("Entity_Name") %>'
                        NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID")) %>'
                        runat="server"></asp:HyperLink>
                    <br />
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" width="500px" runat="server" class="Summary_display">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUMMARY") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server" class="Search_display2">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink Width="400px" ID="HyperLink1" Text='<%#Eval("Entity_Name") %>' NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID"))%>'
                        runat="server"></asp:HyperLink>
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" runat="server" class="Summary_display2">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUMMARY") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) + "#" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
        
        
    <!-- test -->
    <asp:ListView runat="server" ID="ListView3" DataSourceID="SqlDataSource3" DataKeyNames="Entity_ID">
        <LayoutTemplate>
            <table id="Table1" border="0" width="500px" cellpadding="0" cellspacing="0" align="center"
                runat="server">
                <tr id="Tr2" runat="server">
                    <td colspan="3" valign="bottom" class="Results_01" align="center">
                        <asp:Label ID="Label4" runat="server" Text="Data Warehouse Search Results" CssClass="header"></asp:Label>
                    </td>
                </tr>
                <tr runat="server" id="itemPlaceholder">
                </tr>
                <tr id="Tr5" runat="server">
                    <td colspan="3" align="left">
                        <asp:Image ID="Image2" runat="server" Width="500px" ImageUrl="http://racwiki/images/Results/Results_Frame_05.gif" />
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink ID="HyperLink1" Width="400px" class="Search_display" Text='<%#Eval("Entity_Name") %>'
                        NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) %>'
                        runat="server"></asp:HyperLink>
                    <br />
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" width="500px" runat="server" class="Summary_display">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUMMARY") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr id="Tr1" runat="server">
                <td id="Td1" runat="server" class="Results_02">
                </td>
                <td id="Td2" runat="server" class="Search_display2">
                    <%-- Data-bound content. --%>
                    <asp:HyperLink Width="400px" ID="HyperLink1" Text='<%#Eval("Entity_Name") %>' NavigateUrl='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID"))%>'
                        runat="server"></asp:HyperLink>
                </td>
                <td id="Td3" runat="server" class="Results_03">
                </td>
            </tr>
            <tr id="Tr2" runat="server">
                <td id="Td4" runat="server" class="Results_02">
                </td>
                <td id="Td5" runat="server" class="Summary_display2">
                    <%-- Data-bound content. --%>
                    <table border="0" width="400px" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("SUMMARY") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" CssClass="Summary_URL" Text='<%#cstr(Eval("URL")) + "id=" + cstr(Eval("Entity_ID")) %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                </td>
                <td id="Td6" runat="server" class="Results_03">
                </td>
            </tr>
        </AlternatingItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        ProviderName="System.Data.OracleClient"></asp:SqlDataSource>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Footer_ContentPlaceHolder" Runat="Server">
    <div align="right"></div><asp:Label ID="Counter_Label" runat="server" Text="" CssClass="Web_Counter"></asp:Label></div>
    </asp:Content>

