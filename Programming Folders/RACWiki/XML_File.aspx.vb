Imports System.Xml
Imports System.IO
Imports System.Data
Imports Oracle.DataAccess.Client
Imports System.Net.Mail

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '********************************
        'Declared Variables
        '********************************


        Dim File As String = "DWBOE" 'Request.QueryString("ID")

        Dim DEPT_ID As String
        Dim Path As String
        If File = "ZEUS" Then
            DEPT_ID = "DWZEU"
            Path = "S:\Data Warehouse Group\Erwin Metadata\xml_min\High Touch To Be.xml"
        Else
            DEPT_ID = "DWBOE"
            Path = "S:\Data Warehouse Group\Erwin Metadata\xml_min\Data Marts.xml"
        End If


        Dim reader As StreamReader
        Dim streamRead As New System.IO.FileStream(Path, System.IO.FileMode.Open)
        Dim XML As String
        Dim number As Integer
        Dim count As Integer
        Dim DW_Name As String
        Dim attribute As String
        Dim Table_Name As String
        Dim Table_Definition As String
        Dim History_Date As String
        Dim Verdict As String
        Dim Test As String
        Dim Good_Standing As String
        Dim Bad_Standing As String
        Dim Last_Count As Integer
        Dim a() As String
        Dim a2() As String
        Dim a3() As String
        Dim a4() As String
        Dim a5() As String
        Dim a6() As String
        Dim a7() As String

        '***********************************************************
        ' DB Connection
        '***********************************************************

        Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"
        Dim conn As New OracleConnection(oradb)
        conn.Open()

        '***********************************************************
        ' Open the stream using a StreamReader for easy access.
        '***********************************************************

        reader = New StreamReader(streamRead)

        '***********************************************************
        ' Read the content.
        '***********************************************************

        XML = reader.ReadToEnd
       
        'XML = reader.ReadContentAsString



        '***********************************************************
        ' Get rid of junk not needed and separate XML.  
        ' Loaded into arrays
        '*********************************************
        If InStr(XML, "</ModelProps><Entity_Groups>") Then
            a = Split(XML, "</ModelProps><Entity_Groups>")
            a2 = Split(a(1), "</Entity_Groups><Domain_Groups>")
        End If

        streamRead.Close()
        reader.Close()
        DW_Name = a2(0)

        '***************************************************************
        ' Separate the tables individually based on </Entity> Element.  
        ' Loaded into arrays.  Reuse Array variables (a and a2)
        '***************************************************************

        If DW_Name <> "" Then
            a = Split(DW_Name, "</Entity>")
        End If

Begin_Process:
        For i = 0 To UBound(a) - 1
            a2 = Split(a(i), "<Physical_Columns_Order_Ref_Array>")

            DW_Name = a2(0) & "</EntityProps></Entity>"

            Dim xmlDS2 = XElement.Parse(DW_Name)

            Dim query2 = From c In xmlDS2.Descendants("EntityProps") _
                    Select Physical_NAME = c.Element("Physical_Name"), Definition = c.Element("Definition")

            For Each c In query2
                Table_Name = c.Physical_NAME
                Table_Definition = c.Definition
            Next


            'Finds the last date the table had an update
            a5 = Split(a2(1), "</Key_Group_Groups>")
            a6 = Split(a5(1), "</Creation_Time>")
            number = UBound(a6) - 1
            a7 = Split(a6(number), "<Creation_Time>")
            History_Date = a7(1)

            '***************************************************
            ' Counter that counts column in Erwin.
            ' Use to compare what we have in current DB.
            ' If <> same then flagged and email sent.
            '****************************************************
            '  Try
            If a2.Length = 2 Then
                Test = a2(1)
            Else
                Test = a2(0)
            End If

            attribute = "<Wrapper><EntityProps><Physical_Columns_Order_Ref_Array>" & Test & "</Wrapper>"

            Using reader2 As XmlReader = XmlReader.Create(New StringReader(attribute))

                reader2.MoveToContent()
                If reader2.ReadToFollowing("Attribute") Then
                    count = 1
                    While reader2.ReadToNextSibling("Attribute")
                        count += 1
                    End While
                End If

                Verdict = Table_Count(count, Table_Name)

                If UCase(Verdict) = "TRUE" Then
                    Good_Standing = Good_Standing & "<br />" & Table_Name
                Else
                    Bad_Standing = Bad_Standing & "<br />" & Table_Name
                End If

                If InStr(Table_Name, "'") > 0 Then
                    Table_Name = Table_Name.Replace("'", "`")
                End If


                If InStr(Table_Definition, "'") > 0 Then
                    Table_Definition = Table_Definition.Replace("'", "`")
                End If

                Response.Write(Verdict & "<br />" & Table_Name & "<br />" & i & "Count: " & count & "<br /><br />")
                Label1.Text = Good_Standing


                Dim sql_Count As String = "SELECT NVL(MAX(ID),0) FROM ERWIN_TABLE_NAME"
                Dim cmd_Count As New OracleCommand(sql_Count, conn)
                cmd_Count.CommandType = CommandType.Text
                Dim dr_COUNT As OracleDataReader = cmd_Count.ExecuteReader
                dr_COUNT.Read()

                Last_Count = dr_COUNT(0) + 1




                'Insert Table Name into DB from ERwin
                Dim sql_insert = "INSERT INTO ERWIN_TABLE_NAME (ID, NAME, ATTRIBUTE_COUNT, Verdict, DESCRIPTION, History_Date, DEPT_ID) " & _
                                    "VALUES (" & Last_Count & ",'" & Table_Name & "'," & count & ",'" & Verdict & "','" & Table_Definition & "', TO_DATE('" & History_Date & "', 'MM/DD/YYYY:hh:mi:ssam'), '" & DEPT_ID & "')"

                Dim cmd As New OracleCommand(sql_insert, conn)
                cmd.ExecuteNonQuery()

            End Using
            ' Catch ex As Exception
            '  Error_Log(attribute)
            '    Response.Write("<br />")
            ' End Try


            '***************************************************
            ' Information about specific columns
            ' Populate the specific columns
            '****************************************************

            'DW_NAMe is XML file, should be able to get information from that file that will populate into
            'table with specific instructions and brieft description. a2(0) - variable

            If a2(1) <> "" Then
                a3 = Split(a2(1), "</EntityProps>")
                a4 = Split(a3(1), "<Key_Group_Groups>")
            End If

            Dim xmlDS = XElement.Parse(a4(0))

            Dim query = From b In xmlDS.Descendants("AttributeProps") _
                    Select Physical_Name = b.Element("Physical_Name"), Physical_Data_Type = b.Element("Physical_Data_Type"), Definition = b.Element("Definition"), PK = b.Element("Type")

            For Each b In query
                Dim Physical_Name As String = b.Physical_Name
                Dim Physical_Data_Type As String = b.Physical_Data_Type
                Dim Definition As String = b.Definition
                Dim PK As String = b.PK

                If InStr(Definition, "'") > 0 Then
                    Definition = Definition.Replace("'", "`")
                End If

                Dim sql_insert2 = "INSERT INTO ERWIN_ATTRIBUTES (ERID, NAME, TYPE, DEFINITION, PK) " & _
                                    "VALUES (" & Last_Count & ",'" & Physical_Name & "','" & Physical_Data_Type & "','" & Definition & "'," & PK & ")"
                Dim cmd2 As New OracleCommand(sql_insert2, conn)
                cmd2.ExecuteNonQuery()
            Next

        Next

        '****************************************************************
        ' Sends an email of the tables not included on ERwin but         *
        ' are in the database.  -- These tables need to be added         *
        '****************************************************************
        'Bad_Standing = "The following need to be added to ERwin:<br />" & Bad_Standing
        'SENDEMAIL(Bad_Standing)

        conn.Close()
        conn.Dispose()

    End Sub

    Public Function Table_Count(ByVal Count As Integer, ByVal Name As String) As String
        Try
            '*****************************************************************
            ' Hits DB and finds out if columsn have accurate count
            '*****************************************************************
            Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"
            Dim conn As New OracleConnection(oradb)
            conn.Open()

            Dim sql As String = "SELECT COUNT(COLUMN_NAME), table_Name " & _
                                "from All_tab_columns@prod_biprod where table_name like " & _
                                "'" & Name & "' Group By table_name"

            Dim cmd As New OracleCommand(sql, conn)
            cmd.CommandType = CommandType.Text
            Dim dr As OracleDataReader = cmd.ExecuteReader

            dr.Read()

            If dr(0) <> Count Then
                Return False
            Else
                Return True
            End If

            conn.Close()
            conn.Dispose()

        Catch ex As Exception
            '******************************************************
            'Change the publish type to 0 since these are no 
            'longer found in the database
            '******************************************************
            Dim oradb As String = "Data Source=oraedw;User Id=metadata;Password=meta_dw;"
            Dim conn As New OracleConnection(oradb)
            conn.Open()

            Dim sql2 As String = "SELECT NVL(COUNT(*), 0) FROM MD_MAIN WHERE ENTITY_NAME like '" & Name & "'"

            Dim cmd As New OracleCommand(sql2, conn)
            cmd.CommandType = CommandType.Text
            Dim dr As OracleDataReader = cmd.ExecuteReader

            dr.Read()

            If dr(0) <> 0 Then
                Dim Update_Query = "Update MD_Main SET PUBLISH = 0 WHERE ENTITY_NAME like '" & Name & "'"
                Dim cmd2 As New OracleCommand(Update_Query, conn)
                cmd2.ExecuteNonQuery()
            End If

            conn.Close()
            conn.Dispose()

            Response.Write("Not found in the database: " & Name & "<br />")

        End Try

        Return Nothing
    End Function

    Public Function Error_Log(ByVal Error_Sub As String) As String

        'Send error information here.
        Dim er() As String
        Dim er2() As String
        Dim Err_Log As String

        If InStr(Error_Sub, "><Name>") Then
            er = Split(Error_Sub, "<Name>")
            er2 = Split(er(1), "</Name>")
        End If

        Err_Log = Err_Log & "<br />" & er2(0)
        Err_Log = "Error on the following tables: <br />" & Err_Log
        SENDEMAIL(Err_Log)
        Return Nothing

    End Function

    Public Function SENDEMAIL(ByVal Message As String) As String

        Dim myMessage As MailMessage = New MailMessage
        myMessage.Subject = "ERwin/RacWiki Table Organization"
        myMessage.Body = Message
        myMessage.IsBodyHtml = True
        myMessage.From = New MailAddress("Laurence.Brown@rentacenter.com", "Laurence Brown")
        myMessage.To.Add(New MailAddress("Laurence.Brown@rentacenter.com", "Laurence Brown"))
        'myMessage.To.Add(New MailAddress("Ian.Nyer@rentacenter.com", "Ian Nyer"))
        'myMessage.To.Add(New MailAddress("Daniel.Nilsson@Rentacenter.com", "Daniel Nilsson"))

        Dim mySmtpClient As SmtpClient = New SmtpClient()
        mySmtpClient.Send(myMessage)

        Return Nothing
    End Function

End Class
