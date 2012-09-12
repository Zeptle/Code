Imports Oracle.DataAccess.Client
Imports System.Data

Partial Class RACA_Mexico
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label4.Text = "<h1>RAC México List</h1>"


        SqlDataSource1.SelectCommand = "SELECT DISTINCT(COUNTRY) FROM ZEUS.STORE " & _
                                       "WHERE (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and  " & _
                                       "(COUNTRY IS NOT NULL) and ( BRAND NOT like '%TRS Leasing%') ORDER BY COUNTRY"
        SqlDataSource1.DataBind()

    End Sub

    Protected Sub COUNTRY_DropDownList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles COUNTRY_DropDownList.SelectedIndexChanged
        If COUNTRY_DropDownList.SelectedValue = "ALL" Then
            'display address information here
            SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Ownership_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                           "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and (BRAND NOT like '%TRS Leasing%') " & _
                                           "Order by Organization_Name"
            SqlDataSource4.DataBind()

            DropDownList1.Items.Clear()
            DropDownList1.Items.Insert(0, "Select From List...")
            DropDownList2.Items.Clear()
            DropDownList2.Items.Insert(0, "Select From List...")
        Else

            'GridView1.Visible = False


            DropDownList1.Items.Clear()
            DropDownList1.Items.Insert(0, "Select From List...")
            SqlDataSource2.SelectCommand = "SELECT DISTINCT(STATE) FROM ZEUS.STORE WHERE COUNTRY like '" & COUNTRY_DropDownList.SelectedValue & "' and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and BRAND NOT like '%TRS Leasing%' " & _
                                                                     "ORDER BY STATE"

            SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Ownership_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                          "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and (BRAND NOT like '%TRS Leasing%')  and COUNTRY like '" & COUNTRY_DropDownList.SelectedValue & "'" & _
                                          "Order by Organization_Name"
            SqlDataSource4.DataBind()

        End If
        SqlDataSource2.DataBind()
        GridView1.Visible = True

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.SelectedIndexChanged

        If DropDownList1.SelectedValue = "NONE" Then
            GridView1.Visible = False



        Else

            DropDownList2.Items.Clear()
            DropDownList2.Items.Insert(0, "Select From List...")
            SqlDataSource3.SelectCommand = "SELECT DISTINCT(CITY) FROM ZEUS.STORE WHERE STATE like '" & DropDownList1.SelectedValue & "' and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and BRAND NOT like '%TRS Leasing%' " & _
                                           "ORDER BY City"
            SqlDataSource3.DataBind()

            SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Ownership_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                           "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and (BRAND NOT like '%TRS Leasing%') and  State like '" & DropDownList1.SelectedValue & "' " & _
                                           "Order by Organization_Name"
            SqlDataSource4.DataBind()
            GridView1.Visible = True
        End If


    End Sub

    Protected Sub DropDownList2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.SelectedIndexChanged

        If DropDownList2.SelectedValue = "NONE" Then

            SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Ownership_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                           "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and (BRAND NOT like '%TRS Leasing%') and  State like '" & DropDownList1.SelectedValue & "' " & _
                                           "Order by Organization_Name"
        Else

            'display address information here
            SqlDataSource4.SelectCommand = "SELECT B.ORGANIZATION_NAME,  A.Store_TYPE, A.ADDRESS_LINE_1, A.ADDRESS_LINE_2, A.CITY, A.STATE, A.ZIP,  A.COUNTRY, A.Ownership_Date, B.Inactive_Date, A.Close_Type FROM ZEUS.STORE A , ZEUS.RAC_ORGANIZATION B " & _
                                           "WHERE (A.STORE_NUMBER_CODE = B.RAC_ORGANIZATION_NUMBER) and (Store_Type like '%RMX%' OR Store_Type like '%RMW%') and (BRAND NOT like '%TRS Leasing%') and CITY like '" & DropDownList2.SelectedValue & "' and State like '" & DropDownList1.SelectedValue & "' " & _
                                           "Order by Organization_Name"
        End If

        SqlDataSource4.DataBind()
        GridView1.Visible = True

    End Sub
End Class
