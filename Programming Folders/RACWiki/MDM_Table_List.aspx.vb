Imports System.Data
Imports Oracle.DataAccess.Client

Partial Class MDM_Table_List
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'SQL Statement
        Dim sql As String = "SELECT Entity_Name, URL, Entity_ID FROM MD_MAIN WHere DEPT_ID = 'MDM' and Type = 300"
        Dim sql2 As String = "SELECT Entity_Name, URL, Entity_ID FROM MD_MAIN WHere DEPT_ID = 'MDM' and Type = 301"
        Dim sql3 As String = "SELECT Entity_Name, URL, Entity_ID FROM MD_MAIN WHere DEPT_ID = 'MDM' and Type = 302"
        Dim sql4 As String = "SELECT Entity_Name, URL, Entity_ID FROM MD_MAIN WHere DEPT_ID = 'MDM' and Type = 303"

        Dim cmd As New OracleCommand(sql, conn)
        Dim cmd2 As New OracleCommand(sql2, conn)
        Dim cmd3 As New OracleCommand(sql3, conn)
        Dim cmd4 As New OracleCommand(sql4, conn)

        cmd.CommandType = CommandType.Text
        cmd2.CommandType = CommandType.Text
        cmd3.CommandType = CommandType.Text
        cmd4.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader
        Dim dr2 As OracleDataReader = cmd2.ExecuteReader
        Dim dr3 As OracleDataReader = cmd3.ExecuteReader
        Dim dr4 As OracleDataReader = cmd4.ExecuteReader

        Customer_Label.Text = "<ul>"
        Location_Label.Text = "<ul>"
        Product_Label.Text = "<ul>"
        View_Label.Text = "<ul>"

        For Each r In dr
            Customer_Label.Text = Customer_Label.Text & "<li><a href=http://racwiki/" & dr(1) & "id=" & dr(2) & ">" & dr(0) & "</li>"
        Next
        Customer_Label.Text = Customer_Label.Text & "</ul>"

        For Each a In dr2
            Location_Label.Text = Location_Label.Text & "<li><a href=http://racwiki/" & dr2(1) & "id=" & dr2(2) & ">" & dr2(0) & "</li>"
        Next
        Location_Label.Text = Location_Label.Text & "</ul>"

        For Each a In dr3
            Product_Label.Text = Product_Label.Text & "<li><a href=http://racwiki/" & dr3(1) & "id=" & dr3(2) & ">" & dr3(0) & "</li>"
        Next
        Product_Label.Text = Product_Label.Text & "</ul>"

        For Each a In dr4
            View_Label.Text = View_Label.Text & "<li><a href=http://racwiki/" & dr4(1) & "id=" & dr4(2) & ">" & dr4(0) & "</li>"
        Next
        View_Label.Text = View_Label.Text & "</ul>"


        Dim Dept_sql As String = "Select Type, Column_ID, Type_ID From Category_Dropdowns where Dept_ID = 0 and Type_ID = 0 or Type_ID = 9999 Order by Type "
        Dept_SqlDataSource.SelectCommand = Dept_sql
        Dept_SqlDataSource.DataBind()

        Dim Type_sql As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Type_ID = 9998 Order by Type"
        Type_SqlDataSource.SelectCommand = Type_sql
        Type_SqlDataSource.DataBind()

        conn.Close()
        conn.Dispose()

    End Sub

    Protected Sub Type_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Type_DropDownList.SelectedIndexChanged

        Dim Type_SQL As String = "SELECT TO_CHAR(Type_ID) as ENTITY_ID, TO_CHAR(Type) as ENTITY_NAME FROM Category_Dropdowns Where Type_ID = 9997 " & _
                             "Union SELECT TO_CHAR(ENTITY_ID), TO_CHAR(UPPER(ENTITY_NAME)) as ENTITY_NAME FROM MD_MAIN WHERE (Type =" & Type_DropDownList.SelectedValue & " and Publish = 1 ) Order by Entity_NAME, ENTITY_ID"


        Table_SqlDataSource.SelectCommand = Type_SQL
        Table_SqlDataSource.DataBind()
    End Sub

    Protected Sub Table_DropdownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Table_DropdownList.SelectedIndexChanged
        Response.Redirect("Data_Mart_Details.aspx?&id=" & Table_DropdownList.SelectedValue)
    End Sub

    Protected Sub Dept_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dept_DropDownList.SelectedIndexChanged
        Dim Dept_sql As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Dept_ID =" & Dept_DropDownList.SelectedValue & " or Type_ID = 9998 Order by Type"
        Type_SqlDataSource.SelectCommand = Dept_sql
        Type_SqlDataSource.DataBind()
    End Sub
End Class
