Public Class SupervisorHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        If Session("UserType") = 0 Then
            Response.Redirect("Default.aspx")
        End If

        lblUser.Text = "Welcome, " & Session("Email")

        Dim UserID As String
        UserID = Request.QueryString("UserID")

        'Redirect to Edit Creds if no creds exist
        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim Creds As System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim rows() As System.Data.DataRow
        Dim SQL As String


        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        'Profile Pic
        Image1.ImageUrl = "~/LoadImage.aspx?UserID=" & UserID

        'Get Creds
        SQL = SQL & "Select a.CredTypeID, a.CredTypeDesc, b.CredValue, a.[FreeText] "
        SQL = SQL & "From SupervisorCreds a "
        SQL = SQL & "Left Join SupervisorCreds_Values b "
        SQL = SQL & "ON a.CredTypeID = b.CredTypeID AND "
        SQL = SQL & "a.CredValueID = b.CredID "
        SQL = SQL & "Where UserID = " & UserID

        cmd.CommandText = SQL
        Creds = New System.Data.DataTable

        da.Fill(Creds)
        con.Close()

        If Creds.Rows.Count = 0 Then
            Response.Redirect("SupervisorEdit.aspx")
            Exit Sub
        End If


        'Show Creds

        'Fees
        rows = Creds.Select("CredTypeDesc = 'Fees'")
        lblFees.Text = rows(0)("CredValue")

        'TestPrep
        rows = Creds.Select("CredTypeDesc = 'TestPrep'")
        lblTestPrep.Text = rows(0)("CredValue")

        'Availability
        rows = Creds.Select("CredTypeDesc = 'Availability'")
        lblAvail.Text = rows(0)("CredValue")

        'Experience
        rows = Creds.Select("CredTypeDesc = 'Experience'")
        txtExperience.Text = rows(0)("FreeText")

        'Modalities
        rows = Creds.Select("CredTypeDesc = 'Modalities'")

        For Each row In rows
            lstModalities.Items.Add(row("CredValue"))
        Next

        'Populations
        rows = Creds.Select("CredTypeDesc = 'Populations'")
        lblPopulations.Text = rows(0)("CredValue")

        'Certifications
        rows = Creds.Select("CredTypeDesc = 'Certifications'")

        For Each row In rows
            lstCertifications.Items.Add(row("CredValue"))
        Next

        'SupervisionStyles
        rows = Creds.Select("CredTypeDesc = 'SupervisionStyles'")


        For Each row In rows
            lstSuperStyles.Items.Add(row("CredValue"))
        Next

        'LicensedStates
        rows = Creds.Select("CredTypeDesc = 'LicensedStates'")

        For Each row In rows
            lblStates.Text = lblStates.Text & row("CredValue") & ","
        Next

        If rows.Length > 0 Then
            lblStates.Text = Mid(lblStates.Text, 1, lblStates.Text.Length - 1)
        End If

        'LicenseTypes
        rows = Creds.Select("CredTypeDesc = 'LicenseTypes'")

        For Each row In rows
            lblLicenseTypes.Text = lblLicenseTypes.Text & row("CredValue") & ","
        Next

        If rows.Length > 0 Then
            lblLicenseTypes.Text = Mid(lblLicenseTypes.Text, 1, lblLicenseTypes.Text.Length - 1)
        End If


    End Sub


    Protected Sub lbHome_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbHome.Click
        Response.Redirect("Default.aspx")
    End Sub

    Protected Sub lbSignIn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSignIn.Click
        Response.Redirect("SignIn.aspx")
    End Sub

    Protected Sub lbSignUp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSignUp.Click
        Response.Redirect("SignUp.aspx")
    End Sub

    Protected Sub lbEdit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbEdit.Click

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        Response.Redirect("SupervisorEdit.aspx")
    End Sub

    Protected Sub lbLougout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbLougout.Click
        Session.Remove("UserID")
        Session.Remove("UserType")
        Session.Remove("Email")
        Response.Redirect("Default.aspx")
    End Sub


End Class