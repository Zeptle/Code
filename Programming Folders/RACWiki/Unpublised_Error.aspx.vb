Imports System.Net.Mail

Partial Class Unpublised_Error
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load




        Dim myMessage As MailMessage = New MailMessage

        Dim Message As String = "ERROR has occured by the site: " & Request.ServerVariables("HTTP_REFER")


        myMessage.Subject = "Page Error: RACWiki"
        myMessage.Body = Message
        myMessage.IsBodyHtml = True
        myMessage.From = New MailAddress("Laurence.Brown@rentacenter.com", "Laurence Brown")
        myMessage.To.Add(New MailAddress("Laurence.Brown@rentacenter.com", "Laurence Brown"))
        'myMessage.To.Add(New MailAddress("Ian.Nyer@rentacenter.com", "Ian Nyer"))
        'myMessage.To.Add(New MailAddress("Daniel.Nilsson@Rentacenter.com", "Daniel Nilsson"))

        Dim mySmtpClient As SmtpClient = New SmtpClient()
        mySmtpClient.Send(myMessage)
    End Sub
End Class
