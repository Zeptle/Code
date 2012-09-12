Imports Oracle.DataAccess.Client
Imports System.Data

Partial Class RACA_Dup_Address
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label4.Text = "<h1>RACA Store Duplicate</h1>"


        SqlDataSource1.SelectCommand = "SELECT DISTINCT(COUNTRY) FROM ZEUS.STORE " & _
                                       "WHERE (Store_Type like '%ACP%' OR Store_Type like '%ACC%' or Store_Type like '%LTD%') and  " & _
                                       "(COUNTRY IS NOT NULL) and ( BRAND NOT like '%TRS Leasing%') ORDER BY COUNTRY"
        SqlDataSource1.DataBind()


    End Sub

    Protected Sub COUNTRY_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles COUNTRY_DropDownList.SelectedIndexChanged

        DropDownList1.Items.Clear()
        DropDownList1.Items.Insert(0, "Select From List...")
        SqlDataSource2.SelectCommand = "SELECT DISTINCT(STATE) FROM ZEUS.STORE WHERE COUNTRY like '" & COUNTRY_DropDownList.SelectedValue & "' and (Store_Type like '%ACP%' OR Store_Type like '%ACC%' or Store_Type like '%LTD%') and BRAND NOT like '%TRS Leasing%' " & _
                                                                 "ORDER BY STATE"
        SqlDataSource2.DataBind()

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged
        DropDownList2.Items.Clear()
        DropDownList2.Items.Insert(0, "Select From List...")
        SqlDataSource3.SelectCommand = "SELECT DISTINCT(CITY) FROM ZEUS.STORE WHERE STATE like '" & DropDownList1.SelectedValue & "' and (Store_Type like '%ACP%' OR Store_Type like '%ACC%' or Store_Type like '%LTD%') and BRAND NOT like '%TRS Leasing%' " & _
                                       "ORDER BY City"
        SqlDataSource3.DataBind()




    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged
        'display address information here
        SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Close_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                       "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%ACP%' OR Store_Type like '%ACC%' or Store_Type like '%LTD%') and (BRAND NOT like '%TRS Leasing%') and CITY like '" & DropDownList2.SelectedValue & "' and State like '" & DropDownList1.SelectedValue & "' " & _
                                       "Order by Organization_Name"

        SqlDataSource4.DataBind()
        'Response.Write(SqlDataSource4.SelectCommand)

    End Sub
End Class
