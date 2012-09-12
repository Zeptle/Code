Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports Subgurim.Controles
Partial Class Service_Center_Locate
    Inherits System.Web.UI.Page

    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim Service_Center(22) As String
        Dim request As WebRequest
        Dim response As HttpWebResponse
        Dim dataStream As Stream
        Dim reader As StreamReader
        Dim responseFromServer As String
        Dim miles As Double
        Dim Zip As String
        Dim Address As String

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

        If Zip_TextBox.Text >= 96700 And Zip_TextBox.Text <= 96899 Then
            Zip = 96720
            GoTo Foreign
        End If

        If Zip_TextBox.Text >= 600 And Zip_TextBox.Text <= 999 Then
            Zip = 725
            GoTo Foreign
        End If

        For i = 0 To Service_Center.GetUpperBound(0)

            ' Create a request for the URL. 		
            request = WebRequest.Create("http://maps.googleapis.com/maps/api/distancematrix/xml?origins=" & Zip_TextBox.Text & "&units=imperial&destinations=" & Service_Center(i) & "&sensor=false")

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
            Label1.Text = responseFromServer & "<br />"

            Dim a() As String
            Dim a2() As String
            Dim a3() As String

            If InStr(responseFromServer, "<distance>") Then
                a = Split(responseFromServer, "<distance>")
                a2 = Split(a(1), "<text>")

                If InStr(a2(1), "mi") Then
                    a3 = Split(a2(1), "mi</text>")
                Else
                    a3 = Split(a2(1), "ft</text>")
                End If

            End If

            'Me.Response.Write("miles: " & Service_Center(i) & "-" & a3(0) & "<br />")

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


        Label1.Text = miles & " miles - <b>" & Address & "</b>"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sStreetAddress(24) As String
        Dim sComment(24) As String
        Dim Marker(1) As Int16
        Dim sMapKey As String = ConfigurationManager.AppSettings("googlemaps.subgurim.net")
        Dim GeoCode As Subgurim.Controles.GeoCode

        GMap1.addControl(New GControl(GControl.preBuilt.GOverviewMapControl))
        GMap1.addControl(New GControl(GControl.preBuilt.LargeMapControl))

        sStreetAddress(0) = "ANGORA INDUSTRIAL PARK, CAGUAS, PR 00725"
        sStreetAddress(1) = "5207 LINBAR DR, STE 704,NASHVILLE,TN 37211"
        sStreetAddress(2) = "250 EXECUTIVE DRIVE, STE 6,NEWARK, DE 19702"
        sStreetAddress(3) = "12795 Premier Center Court, Plymouth, MI 48170"
        sStreetAddress(4) = "4015 SHOPTON RD, STE 600, CHARLOTTE, NC 28217"
        sStreetAddress(5) = "1438 Trae Lane, Lithia Springs, GA 30122"
        sStreetAddress(6) = "144 Commerce Drive, Freedom, PA 15042"
        sStreetAddress(7) = "165 Grove Street, Franklin, MA 02038"
        sStreetAddress(8) = "2663 TRADEPORT DRIVE, STE 800,ORLANDO,FL 32834"
        sStreetAddress(9) = "1019 SEABROOK WAY, CINCINNATI, OH 45245"
        sStreetAddress(10) = "4131 North Kentucky Avenue, Kansas City, MO 64161"
        sStreetAddress(11) = "8536 CONCORD CENTER DRIVE,ENGLEWOOD,CO 80112"
        sStreetAddress(12) = "3738 WEST 2340 SOUTH, STE C,WEST VALLEY CITY,UT 84120"
        sStreetAddress(13) = "4425 S 100TH ST SW, STE E, LAKEWOOD,WA 98498"
        sStreetAddress(14) = "98-1277 Kaahumanu St, Aiea, HI 96701"
        sStreetAddress(15) = "4536 Morgan Place, Liverpool, NY"
        sStreetAddress(16) = "9750 Alburtis Avenue, Santa Fe Springs, CA 90670"
        sStreetAddress(17) = "594 TERRITORIAL DR, STE A	BOLINGBROOK,IL 60440"
        sStreetAddress(18) = "9035 South Kyrene Road, Tempe, AZ 85284"
        sStreetAddress(19) = "600 Industrial Drive, Galt, CA 95632"
        sStreetAddress(20) = "16580 Air Center Boulevard, Houston, TX 77032"
        sStreetAddress(21) = "11 Industrial Drive, Cahokia, IL 62206"
        sStreetAddress(22) = "200 Kanoelehua Avenue, Hilo, HI 96720"
        sStreetAddress(23) = "1200 Lakeside Parkway, Flower Mound, TX"

        sComment(0) = "<center><b>Service Center # 00146</b><br />ANGORA INDUSTRIAL PARK, EDIFICIO B CARR #1 KM 33.3<br /> CAGUAS, PR 00725</center>"
        sComment(1) = "<center><b>Service Center # 00182</b><br />5207 LINBAR DR, STE 704<br />NASHVILLE, TN 37211</center>"
        sComment(2) = "<center><b>Service Center # 00183</b><br />250 EXECUTIVE DRIVE, STE 6<br />NEWARK,DE	19702</center>"
        sComment(3) = "<center><b>Service Center # 00184</b><br />12795 PREMIER CENTER CT, BG 300<br />PLYMOUTH, MI	48170</center>"
        sComment(4) = "<center><b>Service Center # 00185</b><br />4015 SHOPTON RD, STE 600<br />CHARLOTTE, NC 28217</center>"
        sComment(5) = "<center><b>Service Center # 00186</b><br />1438 TRAE LANE<br />LITHIA SPRINGS, GA 30122</center>"
        sComment(6) = "<center><b>Service Center # 00187</b><br />144 COMMERCE DRIVE<br />FREEDOM, PA 15042</center>"
        sComment(7) = "<center><b>Service Center # 00188</b><br />165 GROVE STREET, STE 130<br />FRANKLIN, MA 02038</center>"
        sComment(8) = "<center><b>Service Center # 00189</b><br />2663 TRADEPORT DRIVE, STE 800<br />ORLANDO, FL 32834</center>"
        sComment(9) = "<center><b>Service Center # 00190</b><br />1019 SEABROOK WAY<br />CINCINNATI, OH	45245</center>"
        sComment(10) = "<center><b>Service Center # 00191</b><br />4131 N KENTUCKY AVE<br />KANSAS CITY, MO 64161</center>"
        sComment(11) = "<center><b>Service Center # 00192</b><br />8536 CONCORD CENTER DRIVE, UNIT B<br />ENGLEWOOD, CO 80112</center>"
        sComment(12) = "<center><b>Service Center # 00193</b><br />3738 WEST 2340 SOUTH, STE C<br />WEST VALLEY CITY, UT 84120</center>"
        sComment(13) = "<center><b>Service Center # 00194</b><br />4425 S 100TH ST SW, STE E<br />LAKEWOOD, WA 98498</center>"
        sComment(14) = "<center><b>Service Center # 00195</b><br />PO BOX 98-1277 KAAHUMANU ST #410<br />AIEA, HI 96701</center>"
        sComment(15) = "<center><b>Service Center # 00286</b><br />4536 MORGAN PLACE<br />LIVERPOOL, NY 13090</center>"
        sComment(16) = "<center><b>Service Center # 00199</b><br />9750 ALBURTIS AVE<br />SANTA FE SPRINGS, CA 90670</center>"
        sComment(17) = "<center><b>Service Center # 00200</b><br />594 TERRITORIAL DR, STE A<br />BOLINGBROOK, IL 60440</center>"
        sComment(18) = "<center><b>Service Center # 00201</b><br />9035 SOUTH KYRENE, STE 101<br />TEMPE, AZ 85284</center>"
        sComment(19) = "<center><b>Service Center # 00202</b><br />600 INDUSTRIAL DRIVE<br />GALT, CA 95632</center>"
        sComment(20) = "<center><b>Service Center # 00203</b><br />16580 AIR CENTER BLVD<br />HOUSTON, TX	77032</center>"
        sComment(21) = "<center><b>Service Center # 00204</b><br />#11 INDUSTRIAL DRIVE<br />CAHOKIA, IL	62206</center>"
        sComment(22) = "<center><b>Service Center # 00205</b><br />200 KANOELEHUA AVE<br />HILO, HI	96720</center>"
        sComment(23) = "<center><b>Service Center # 00198</b><br />1200 LAKESIDE PKWY, BLDG 4, STE. 475<br />FLOWER MOUND, TX 75028</center>"

        For I As Integer = 0 To 23

            GeoCode = Subgurim.Controles.GMap.geoCodeRequest(sStreetAddress(I), sMapKey)
            Dim gLatLng As New Subgurim.Controles.GLatLng(GeoCode.Placemark.coordinates.lat, GeoCode.Placemark.coordinates.lng)

            GMap1.setCenter(gLatLng, 16, Subgurim.Controles.GMapType.GTypes.Normal)

            Dim oMarker As New Subgurim.Controles.GMarker(gLatLng)
            GMap1.addGMarker(oMarker)

            Dim window As New Subgurim.Controles.GInfoWindow(oMarker, sComment(I), False)
            GMap1.addInfoWindow(window)

        Next

        GMap1.GZoom = 3

    End Sub

End Class
