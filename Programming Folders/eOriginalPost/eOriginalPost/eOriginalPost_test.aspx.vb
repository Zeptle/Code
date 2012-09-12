Imports System.Net
Imports System.IO
Imports System.Text

Partial Public Class eOriginalPost_test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim App_ID As Integer = 152026
        Dim TheCookie As String = eoLogin()
        'Response.Write("Cookie=" & TheCookie & "<br><br>")

        Dim CreateTransaction As String = eoCreateTransaction(App_ID, "Everly", "TX", 2, TheCookie)
        'Response.Write(CreateTransaction & vbCrLf & vbCrLf & vbCrLf)



        '*********************************************************
        'THIS DOES NOT WORK.  IT SOMEHOW CHANGES THE FILE CONTENTS:
        '*********************************************************
        'read file:
        Dim myFile As String = "C:\Users\joseph\Desktop\security_agreement_15e6d5d2-d625-45ee-81b4-1bdc428856d5.pdf"
        Dim FS As New FileStream(myFile, FileMode.Open)
        Dim BR As New BinaryReader(FS)
        Dim bytes() As Byte = New Byte((FS.Length) - 1) {}
        Dim numBytesToRead As Integer = CType(FS.Length, Integer)
        Dim numBytesRead As Integer = 0

        While (numBytesToRead > 0)
            ' Read may return anything from 0 to numBytesToRead.
            Dim n As Integer = FS.Read(bytes, numBytesRead, numBytesToRead)
            ' Break when the end of the file is reached.
            If (n = 0) Then
                Exit While
            End If
            numBytesRead = (numBytesRead + n)
            numBytesToRead = (numBytesToRead - n)

        End While
        numBytesToRead = bytes.Length

        BR.Close()
        FS.Close()

        'Response.OutputStream.Write(bytes, 0, bytes.Length)
        'Response.End()


        'Dim objStreamReader As New StreamReader(myFile)
        'Dim FileContents As String = objStreamReader.ReadToEnd()

        'write file:
        'Dim ObjReader As StreamWriter = New StreamWriter("C:\Users\joseph\Desktop\output.pdf")
        'ObjReader.Write(Encoding.UTF8.GetString(bytes))
        'ObjReader.Close()
        'Response.End()

        'Dim SW As New StreamWriter("C:\Users\joseph\Desktop\output3.pdf")
        'Dim Writer As New BinaryWriter(SW.BaseStream)
        'Writer.Write(bytes)
        'Writer.Close()



        '*********************************************************
        'BUT THIS WORKS JUST FINE:
        '*********************************************************
        'ReadWritePDF()


        'Dim bytes As Byte() = Encoding.UTF8.GetBytes(FileContents)
        'Dim myEncodedFile As String = Convert.ToBase64String(bytes)

        'Response.Write("myEncodedFile=" & myEncodedFile.ToString())
        'Response.End()

        Dim FileContents As String = ""
        Dim CreateDocument As String = ExecutePostCommand(myFile, bytes, FileContents, CreateTransaction, "ABECU Membership Form", TheCookie, "Security_Agreement.pdf")
        Response.Write(CreateDocument)

        'eoConfigureSortOrder:


        'eoConfigureRoles:


        'eoLogout:


    End Sub


    Function ParseCookie(ByVal Header As String)
        Dim myCookie As String = ""
        Dim A As Array = Split(Header, "Set-Cookie: ")
        Dim B As Array = Split(A(1), ";")
        myCookie = B(0)

        Return myCookie
    End Function


    Function ParseSID(ByVal XML As String)
        Dim myOutput As String = ""
        Dim A As Array = Split(XML, "<sid>")
        Dim B As Array = Split(A(1), "</sid>")
        myOutput = B(0)

        Return myOutput
    End Function

    Function eoLogin()
        Dim Ping_URL As String = "https://previewondemand.eoriginal.com/ecore/?"
        Dim xmlDoc As String = "action=eoLogin&loginUsername=EOD-944&loginPassword=refinance&loginOrganization=ORL"
        Dim Receive_Time As Integer = 15

        '********************************************
        'POST DATA TO SERVER:
        '********************************************
        Dim BuyerResponse As String = ""
        Dim BuyerHeaders As String = ""
        Dim RedirectURL As String = ""
        Dim myException As String = ""
        Dim Bytes As Byte()
        Bytes = Encoding.UTF8.GetBytes(xmlDoc)
        Dim httpRequest As HttpWebRequest
        httpRequest = HttpWebRequest.Create(Ping_URL)
        httpRequest.Timeout = Receive_Time * 1000 'in milliseconds
        httpRequest.Method = "POST"
        httpRequest.ContentLength = Len(xmlDoc)
        httpRequest.ContentType = "application/x-www-form-urlencoded"

        Dim myWriter As StreamWriter = New StreamWriter(httpRequest.GetRequestStream())
        Try
            myWriter.Write(xmlDoc)
        Catch ex As Exception
            myException = "ERROR: " & ex.Message & " " & ex.StackTrace
        Finally
            myWriter.Close()
        End Try

        Dim myResponse As HttpWebResponse = CType(httpRequest.GetResponse, HttpWebResponse)
        Dim ReceiveStream As Stream = myResponse.GetResponseStream

        If myResponse.StatusCode = HttpStatusCode.OK Then
            Dim Encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim readStream As New StreamReader(ReceiveStream, Encode)
            Response.ContentType = "application/x-www-form-urlencoded" 'no need to change this from lender to lender
            BuyerResponse = readStream.ReadToEnd
            BuyerHeaders = myResponse.Headers.ToString()
            readStream.Close()
        End If
        myResponse.Close()

        'Response.Write("eoLogin=" & BuyerResponse & vbCrLf & vbCrLf & vbCrLf)

        Dim TheCookie As String = ParseCookie(BuyerHeaders)

        Return TheCookie
    End Function



    Function eoCreateTransaction(ByVal App_ID As Integer, ByVal Last_Name As String, ByVal State As String, ByVal Loan_Type_ID As Integer, ByVal Cookie As String)
        Dim Ping_URL As String = "https://previewondemand.eoriginal.com/ecore/?"
        Dim xmlDoc As String = "action=eoCreateTransaction&transactionName=" & App_ID.ToString() & "&transactionXRef1=" & Last_Name & "&transactionXRef2=" & Loan_Type_ID & "&transactionXRef3=" & State
        Dim Receive_Time As Integer = 15

        '********************************************
        'POST DATA TO SERVER:
        '********************************************
        Dim BuyerResponse As String = ""
        Dim BuyerHeaders As String = ""
        Dim RedirectURL As String = ""
        Dim myException As String = ""
        Dim Bytes As Byte()
        Bytes = Encoding.UTF8.GetBytes(xmlDoc)
        Dim httpRequest As HttpWebRequest
        httpRequest = HttpWebRequest.Create(Ping_URL)
        httpRequest.Timeout = Receive_Time * 1000 'in milliseconds
        httpRequest.Method = "POST"
        httpRequest.ContentLength = Len(xmlDoc)
        httpRequest.ContentType = "application/x-www-form-urlencoded"
        httpRequest.Headers("Cookie") = Cookie

        Dim myWriter As StreamWriter = New StreamWriter(httpRequest.GetRequestStream())
        Try
            myWriter.Write(xmlDoc)
        Catch ex As Exception
            myException = "ERROR: " & ex.Message & " " & ex.StackTrace
        Finally
            myWriter.Close()
        End Try

        Dim myResponse As HttpWebResponse = CType(httpRequest.GetResponse, HttpWebResponse)
        Dim ReceiveStream As Stream = myResponse.GetResponseStream

        If myResponse.StatusCode = HttpStatusCode.OK Then
            Dim Encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")
            Dim readStream As New StreamReader(ReceiveStream, Encode)
            Response.ContentType = "application/x-www-form-urlencoded" 'no need to change this from lender to lender
            BuyerResponse = readStream.ReadToEnd
            BuyerHeaders = myResponse.Headers.ToString()
            readStream.Close()
        End If
        myResponse.Close()

        'Response.Write("eoCreateTransaction=" & BuyerResponse & vbCrLf & vbCrLf & vbCrLf)

        Dim SID As Integer = ParseSID(BuyerResponse)

        Return SID
    End Function




    Public Function ExecutePostCommand(ByVal filename As String, ByVal file As Byte(), ByVal FileContents As String, ByVal App_ID As Integer, ByVal Document_Type As String, ByVal TheCookie As String, ByVal Document_File_Name As String) As String
        ' Build Contents for Post 
        Dim boundary As String = System.Guid.NewGuid().ToString()
        Dim header As String = String.Format("--{0}", boundary)
        Dim footer As String = header & "--"

        Dim contents_Part1 As New StringBuilder()
        Dim contents_Part2 As New StringBuilder()

        ' file 
        contents_Part1.AppendLine(header)
        contents_Part1.AppendLine(String.Format("Content-Disposition: form-data; name=""srcFile""; filename=""" & Document_File_Name))
        contents_Part1.AppendLine("Content-Type: application/pdf")
        'contents.AppendLine("Content-Transfer-Encoding: base64")
        contents_Part1.AppendLine()
        'contents.AppendLine(Encoding.UTF8.GetString(file))
        'contents.AppendLine(FileContents)
        ' action 
        contents_Part2.AppendLine(header)
        contents_Part2.AppendLine("Content-Disposition: form-data; name=""action""")
        contents_Part2.AppendLine()
        contents_Part2.AppendLine("eoCreateDocumentProfileUploadDocument")

        contents_Part2.AppendLine(header)
        contents_Part2.AppendLine("Content-Disposition: form-data; name=""transactionSid""")
        contents_Part2.AppendLine()
        contents_Part2.AppendLine(App_ID.ToString())

        contents_Part2.AppendLine(header)
        contents_Part2.AppendLine("Content-Disposition: form-data; name=""dptName""")
        contents_Part2.AppendLine()
        contents_Part2.AppendLine(Document_Type)

        contents_Part2.AppendLine(header)
        contents_Part2.AppendLine("Content-Disposition: form-data; name=""mimeType""")
        contents_Part2.AppendLine()
        contents_Part2.AppendLine("application/pdf")

        contents_Part2.AppendLine(header)
        contents_Part2.AppendLine("Content-Disposition: form-data; name=""documentFileName""")
        contents_Part2.AppendLine()
        contents_Part2.AppendLine(Document_File_Name)

        ' Footer 
        contents_Part2.AppendLine(footer)


        ' This is sent to the Post 
        Dim bytes_Part1 As Byte() = Encoding.UTF8.GetBytes(contents_Part1.ToString())
        Dim bytes_Part2 As Byte() = Encoding.UTF8.GetBytes(contents_Part2.ToString())


        Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://previewondemand.eoriginal.com/ecore/?"), HttpWebRequest)
        request.PreAuthenticate = True
        request.AllowWriteStreamBuffering = True
        'request.Proxy = New WebProxy("127.0.0.1", 8888) 'route through fiddler
        request.ContentType = String.Format("multipart/form-data; boundary={0}", boundary)
        request.Method = "POST"
        request.Headers("Cookie") = TheCookie
        request.ContentLength = bytes_Part1.Length + file.Length + bytes_Part2.Length


        Using requestStream As Stream = request.GetRequestStream()
            requestStream.Write(bytes_Part1, 0, bytes_Part1.Length)
            requestStream.Write(file, 0, file.Length)
            requestStream.Write(bytes_Part2, 0, bytes_Part2.Length)
            requestStream.Flush()
            requestStream.Close()

            Using response As WebResponse = request.GetResponse()
                Using reader As New StreamReader(response.GetResponseStream())
                    Return reader.ReadToEnd()
                End Using
            End Using
        End Using
        Return Nothing
    End Function




    Public Shared Sub ReadWritePDF()
        ' Specify a file to read from and to create.
        Dim pathSource As String = "C:\Users\joseph\Desktop\security_agreement_15e6d5d2-d625-45ee-81b4-1bdc428856d5.pdf"
        Dim pathNew As String = "C:\Users\joseph\Desktop\Output2.pdf"
        Try
            Using fsSource As FileStream = New FileStream(pathSource, _
                FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
                numBytesToRead = bytes.Length

                ' Write the byte array to the other FileStream.
                Using fsNew As FileStream = New FileStream(pathNew, _
                    FileMode.Create, FileAccess.Write)
                    fsNew.Write(bytes, 0, numBytesToRead)
                End Using
            End Using
        Catch ioEx As FileNotFoundException
            Console.WriteLine(ioEx.Message)
        End Try
    End Sub

    Public Shared Function ReadPDF()
        ' Specify a file to read from and to create.
        Dim pathSource As String = "C:\Users\joseph\Desktop\security_agreement_15e6d5d2-d625-45ee-81b4-1bdc428856d5.pdf"
        Dim pathNew As String = "C:\Users\joseph\Desktop\Output2.pdf"
        Dim Output As String = ""
        Try
            Using fsSource As FileStream = New FileStream(pathSource, _
                FileMode.Open, FileAccess.Read)
                ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead, _
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
                numBytesToRead = bytes.Length

                Dim enc As New System.Text.UTF8Encoding()
                Output = enc.GetString(bytes)

                ' Write the byte array to the other FileStream.
                Using fsNew As FileStream = New FileStream(pathNew, _
                    FileMode.Create, FileAccess.Write)
                    fsNew.Write(bytes, 0, numBytesToRead)
                End Using
            End Using
        Catch ioEx As FileNotFoundException
            Console.WriteLine(ioEx.Message)
        End Try
        Return Output
    End Function


End Class