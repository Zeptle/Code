
Partial Class MDM
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Intro_Label.Text = "<h2>MDM</h2>MDM is a component of the MAPS project, and it will impact MAPS, because it will be the " & _
                      "source of master data for the applications being implemented as part of MAPS:  SIMS and CRM.  One of the " & _
                      "objectives of the MAPS project is to replace the Legacy POS applications HIGHTOUCH and RSSS with SIMS. " & _
                      "Because these systems are being replaced, there is no plan to return cleansed and normalized Master  " & _
                      "Data to these systems."
    End Sub
End Class
