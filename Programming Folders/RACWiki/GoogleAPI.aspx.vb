Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Oracle.DataAccess.Client
Imports System.Data

Partial Class GoogleAPI
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim oradb As String = "Data Source=oraedw;User Id=BROLAU;password=We!comeBack2011"

        Dim conn As New OracleConnection(oradb)
        conn.Open()

        Dim SQL1 As String = "SELECT A.Store_NUmber_Code, A.ZIP, B.Organization_Name, A.City, A.State From ZEUS.STORE A " & _
                                "Inner JOIN ( select A.RAC_ORGANIZATION_NUMBER, B.ORGANIZATION_NAME, C.Close_type, C.Store_type  " & _
                                "from ZEUS.RAC_Alignment A, Zeus.RAC_Organization B, Zeus.Store C WHERE  " & _
                                "(A.RAC_ORGANIZATION_NUMBER = B.RAC_ORGANIZATION_NUMBER) and (C.Store_Number_Code = B.RAC_ORGANIZATION_NUMBER)   " & _
                                "and (ALIGNMENT_CODE = 4) and (END_DATE IS NULL)  and (C.Close_type is NULL and C.Close_Date is NULL) " & _
                                "MINUS select A.RAC_ORGANIZATION_NUMBER, B.ORGANIZATION_NAME, C.Close_type, C.Store_type  " & _
                                "from ZEUS.RAC_Alignment A, Zeus.RAC_Organization B, Zeus.Store C WHERE (A.RAC_ORGANIZATION_NUMBER = B.RAC_ORGANIZATION_NUMBER) and  " & _
                                "(C.Store_Number_Code = B.RAC_ORGANIZATION_NUMBER)  and (ALIGNMENT_CODE = 3) and (END_DATE IS NULL) " & _
                                ") B ON B.RAC_ORGANIZATION_NUMBER = A.Store_Number_Code "



        Dim cmd As New OracleCommand(SQL1, conn)

        cmd.CommandType = CommandType.Text

        Dim dr1 As OracleDataReader = cmd.ExecuteReader


        Dim Service_Center(22) As String
        Dim request As WebRequest
        Dim response As HttpWebResponse
        Dim dataStream As Stream
        Dim reader As StreamReader
        Dim responseFromServer As String
        Dim miles As Double
        Dim Zip As String
        Dim Address As String

        Dim a() As String
        Dim a2() As String
        Dim a3() As String

        Service_Center(0) = 37211
        Service_Center(1) = 19702
        Service_Center(2) = 48170
        Service_Center(3) = 28217
        Service_Center(4) = 30122
        Service_Center(5) = 15042
        Service_Center(6) = "02038"
        Service_Center(7) = 32834
        Service_Center(8) = 45245
        Service_Center(9) = 64161
        Service_Center(10) = 80112
        Service_Center(11) = 84120
        Service_Center(12) = 98498
        Service_Center(13) = 96701
        Service_Center(14) = 75028
        Service_Center(15) = 90670
        Service_Center(16) = 60440
        Service_Center(17) = 85284
        Service_Center(18) = 95632
        Service_Center(19) = 77032
        Service_Center(20) = 62206
        Service_Center(21) = 96720
        Service_Center(22) = 13090

        For Each index In dr1

            If dr1(1) >= 96700 And dr1(1) <= 96899 Then
                Zip = 96720
                GoTo Foreign
            End If

            If dr1(1) >= 600 And dr1(1) <= 999 Then
                Zip = 725
                GoTo Foreign
            End If

            For i = 0 To Service_Center.GetUpperBound(0)
                ' Create a request for the URL. 		
                request = WebRequest.Create("http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & dr1(1) & "&units=imperial&destinations=" & Service_Center(i) & "&sensor=false")

                ' If required by the server, set the credentials.
                request.Credentials = CredentialCache.DefaultCredentials

                ' Get the response.
                response = CType(request.GetResponse(), HttpWebResponse)

                ' Display the status.
                Console.WriteLine(response.StatusDescription)

                ' Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream()

                ' Open the stream using a StreamReader for easy access.
                reader = New StreamReader(dataStream)

                ' Read the content.
                responseFromServer = reader.ReadToEnd()

                ' Display the content.
                'Label1.Text = responseFromServer & "<br />"



                If InStr(responseFromServer, "<distance>") Then
                    a = Split(responseFromServer, "<distance>")
                    a2 = Split(a(1), "<text>")

                    If InStr(a2(1), "mi") Then
                        a3 = Split(a2(1), "mi</text>")
                    Else
                        a3 = Split(a2(1), "ft</text>")
                    End If
                End If

                If miles >= a3(0) Then
                    miles = a3(0)
                    Zip = Service_Center(i)
                ElseIf miles = 0 Then
                    miles = a3(0)
                    Zip = Service_Center(i)
                End If

            Next

            ' Cleanup the streams and the response.
            reader.Close()
            dataStream.Close()
            response.Close()




Foreign:
            Select Case (Zip)
                Case 37211
                    Address = "SVC: 00182"
                Case 19702
                    Address = "SVC: 00183"
                Case 48170
                    Address = "SVC: 00184"
                Case 28217
                    Address = "SVC: 00185"
                Case 30122
                    Address = "SVC: 00186"
                Case 15042
                    Address = "SVC: 00187"
                Case "02038"
                    Address = "SVC: 00188"
                Case 32834
                    Address = "SVC: 00189"
                Case 45245
                    Address = "SVC: 00190"
                Case 64161
                    Address = "SVC: 00191"
                Case 80112
                    Address = "SVC: 00192"
                Case 84120
                    Address = "SVC: 00193"
                Case 98498
                    Address = "SVC: 00194"
                Case 96701
                    Address = "SVC: 00195"
                Case 75028
                    Address = "SVC: 00198"
                Case 90670
                    Address = "SVC: 00199"
                Case 60440
                    Address = "SVC: 00200"
                Case 85284
                    Address = "SVC: 00201"
                Case 95632
                    Address = "SVC: 00202"
                Case 77032
                    Address = "SVC: 00203"
                Case 62206
                    Address = "SVC: 00204"
                Case 96720
                    Address = "SVC: 00205"
                Case 13090
                    Address = "SVC: 00286"
                Case 725
                    Address = "SVC: 00146"
                Case Else
                    Address = "SVC: NOT FOUND"
            End Select



            Me.Response.Write(Address & "- Store: " & dr1(2) & "<br />")

        Next

    End Sub
End Class
