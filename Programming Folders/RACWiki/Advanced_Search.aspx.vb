Imports System.Data
Imports Oracle.DataAccess.Client

Partial Class Advanced_Search
    Inherits System.Web.UI.Page

    <System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()> _
    Public Shared Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer, ByVal contextKey As String) As String()


        '******************************* Note *******************************
        ' if the auto complete list is not working properly, double check
        ' & make sure that there are no keywords left blank
        '********************************************************************

        'Oracle DB connection
        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        'SQL Statement
        Dim sql As String = "SELECT COLUMN_NAME FROM DATAWAREHOUSE_ATTRIBUTES_01"

        '"SELECT KEYWORDS, Entity_Name FROM MD_MAIN Where Publish = 1"

        Dim cmd As New OracleCommand(sql, conn)
        cmd.CommandType = CommandType.Text

        'Data reader
        Dim dr As OracleDataReader = cmd.ExecuteReader

        Dim items As New ArrayList()
        Dim strArray As String()

        For Each a In dr
            Dim Str As String = dr("COLUMN_NAME")
            strArray = Str.Split(",")

            For count = 0 To strArray.Length - 1
                items.Add(Trim(strArray(count)))
            Next
            
        Next

        items.Sort()
        Dim ArrCount As Integer = items.Count
        For i = ArrCount - 1 To 1 Step -1
            If (LCase(items(i)).ToString() = LCase(items(i - 1)).ToString()) Then
                items.RemoveAt(i)
            End If
        Next i

        Dim string_array() As String
        string_array = DirectCast(items.ToArray(GetType(String)), String())

        ' Return matching myArray
        Return (From m In string_array Where m.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) Select m).Take(15).ToArray()

        'Close Connection
        conn.Close()
        conn.Dispose()

    End Function

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        '***********************
        ' Declare Variables Here
        '***********************
        Dim Search_Term As String = Search_TextBox.Text.ToString()
        Dim row_count As Integer = DropDownList1.SelectedValue.ToString()
        Dim DEPT_ID As Integer = 0
        Dim SQL_DEPT As String
        Dim SQL_FIND As String
        Dim SQL As String

        Error_Label.Visible = False
        Label2.Visible = False

        If Search_Term = "" Then
            Error_Label.Text = "Oops, you forgot to enter text into the search box."
            Error_Label.Visible = True
            GoTo End_ERROR
        End If

        '**************************************
        ' Create extension for SQL statement
        '**************************************
        For Each item As ListItem In CheckBoxList1.Items
            If item.Selected Then
                DEPT_ID = DEPT_ID + item.Value
            End If
        Next

        Select Case DEPT_ID
            Case 1
                SQL_DEPT = "DWBOE"
            Case 3
                SQL_DEPT = "MDM"
            Case 5
                SQL_DEPT = "DWZEU"
            Case 4
                SQL_DEPT = "DWBOE' or DEPT_ID like 'MDM"
            Case 6
                SQL_DEPT = "DWBOE' OR DEPT_ID = 'DWZEU"
            Case 7
                SQL_DEPT = "DICT"
            Case 8
                SQL_DEPT = "DWZEU' OR DEPT_ID = 'MDM"
            Case 9
                SQL_DEPT = "DWBOE' OR DEPT_ID = 'DWZEU' OR DEPT_ID = 'MDM"
            Case Else
                Error_Label.Text = "Error, please select a data source."
                Error_Label.Visible = True

                GoTo END_ERROR
        End Select

        Select Case RadioButtonList1.SelectedValue
            Case 0
                SQL_FIND = "%" & UCase(Search_Term) & "%"
            Case 1
                SQL_FIND = UCase(Search_Term)
            Case 2
                SQL_FIND = Replace(UCase(Search_Term), " OR ", "' OR ENTITY_NAME like '%")
        End Select


        '*****************************************
        ' Return results from Warehouse
        '*****************************************
        If SQL_DEPT <> "DICT" Then

            SQL = "SELECT A.COLUMN_NAME,B.ENTITY_NAME, B.URL, A.Entity_ID FROM DATAWAREHOUSE_ATTRIBUTES_01 A " & _
                  "INNER JOIN DATAWAREHOUSE_01 B ON " & _
                  "B.ENTITY_ID = a.ENTITY_ID " & _
                  "WHERE (B.DEPT_ID = '" & SQL_DEPT & "' ) and (A.COLUMN_NAME like '" & SQL_FIND & "') and ROWNUM < " & row_count & " and PUBLISH =1 ORDER BY A.COLUMN_NAME"
        Else
            SQL = "SELECT Concat(Substr(SUMMARY,0,50),'...') as COLUMN_NAME,ENTITY_NAME, URL,Entity_ID " & _
                  "FROM GLOSSARY WHERE Rownum < " & row_count & " and UPPER(Summary) like '" & SQL_FIND & "' and PUBLISH =1" & _
                  "ORDER BY ENTITY_NAME"
        End If
        SqlDataSource3.SelectCommand = SQL
        ListView3.DataBind()

        If ListView3.Items.Count = 0 Then
            Label2.Text = "<p>Sorry, no results were found.<br />  Please search again or submit a request for the topic by clicking on the Questions or Comments <img src='images/Big_Question.png'  height=17px width=17px /> icon at the top.</p>"
            Label2.Visible = True

        End If

End_ERROR:
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        If RadioButtonList1.SelectedValue = 2 Then
            Error_Label.Text = "Type OR between all the words you want: miniature OR standard"
            Error_Label.Visible = True
        End If

    End Sub
End Class
