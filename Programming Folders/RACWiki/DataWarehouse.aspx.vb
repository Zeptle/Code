
Partial Class DataWarehouse
    Inherits System.Web.UI.Page

    Protected Sub Table_DropdownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Table_DropdownList.SelectedIndexChanged
        Response.Redirect("Data_Mart_Details.aspx?&id=" & Table_DropdownList.SelectedValue)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sql As String = "Select Type, Column_ID, Type_ID From Category_Dropdowns where Dept_ID = 0 and Type_ID = 0 or Type_ID = 9999 Order by Type "
        SqlDataSource1.SelectCommand = sql
        SqlDataSource1.DataBind()

        Dim sql2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Type_ID = 9998 Order by Type"
        SqlDataSource2.SelectCommand = sql2
        SqlDataSource2.DataBind()

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        Dim sql2 As String = "SELECT Type, Type_ID From CATEGORY_DROPDOWNS WHERE Dept_ID =" & DropDownList1.SelectedValue & " or Type_ID = 9998 Order by Type"
        SqlDataSource2.SelectCommand = sql2
        SqlDataSource2.DataBind()
    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged

        Dim sql3 As String = "SELECT TO_CHAR(Type_ID) as ENTITY_ID, TO_CHAR(Type) as ENTITY_NAME FROM Category_Dropdowns Where Type_ID = 9997 " & _
                             "Union SELECT TO_CHAR(ENTITY_ID), TO_CHAR(UPPER(ENTITY_NAME)) as ENTITY_NAME FROM Datawarehouse_01 WHERE (Type =" & DropDownList2.SelectedValue & " and Publish = 1 ) Order by Entity_NAME, ENTITY_ID"


        SqlDataSource3.SelectCommand = sql3
        SqlDataSource3.DataBind()

    End Sub
End Class
