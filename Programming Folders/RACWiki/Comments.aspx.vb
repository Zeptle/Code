Imports System.Net.Mail

Partial Class Comments
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myMessage As MailMessage = New MailMessage
        myMessage.Subject = "RacWiki Suggestion Box: " & TextBox3.Text
        myMessage.Body = Editor1.Content
        myMessage.IsBodyHtml = True
        myMessage.From = New MailAddress(TextBox1.Text)
        myMessage.To.Add(New MailAddress("Laurence.Brown@rentacenter.com", "Laurence Brown"))
        myMessage.To.Add(New MailAddress("John.Gideon@rentacenter.com", "John Gideon"))

        Dim mySmtpClient As SmtpClient = New SmtpClient()
        mySmtpClient.Send(myMessage)

        Panel1.Visible = False
        Label4.Text = "Thank you for your submission.  It will be reviewed by someone shortly."
        Panel2.Visible = True
    End Sub
End Class
