Imports System.Data.SqlClient
Public Class InternHome
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        If Session("UserType") = 0 And Session("HoursEntered") = 0 Then
            Response.Redirect("EnterHours.aspx")
        End If

        If Session("UserType") = 1 Then
            Response.Redirect("Default.aspx")
        End If


        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim row As System.Data.DataRow
        Dim rows() As System.Data.DataRow
        Dim SQL As String

        Dim UserID As String
        Dim Creds_Values As System.Data.DataTable

        UserID = Session("UserID")
        Page.MaintainScrollPositionOnPostBack = True


        If IsPostBack = False Then

            'Set User label
            lblUser.Text = "Welcome, " & Session("Email")


            'Populate Categories 
            con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
            con.Open()

            cmd.Connection = con
            da.SelectCommand = cmd

            cmd.CommandType = Data.CommandType.Text

            SQL = SQL & "Select CredID, CredValue, CredTypeDesc From "
            SQL = SQL & "SupervisorCreds_Values "
            SQL = SQL & "Order By CredID, CredValue"

            cmd.CommandText = SQL

            Creds_Values = New System.Data.DataTable
            da.Fill(Creds_Values)

            con.Close()


            'Fees
            rows = Creds_Values.Select("CredTypeDesc = 'Fees'")
            cmbFees.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbFees.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'TestPrep
            rows = Creds_Values.Select("CredTypeDesc = 'TestPrep'")
            cmbTestPrep.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbTestPrep.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'Availability
            rows = Creds_Values.Select("CredTypeDesc = 'Availability'")
            cmbAvail.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbAvail.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'Modalities
            rows = Creds_Values.Select("CredTypeDesc = 'Modalities'")
            cmbModalities.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbModalities.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'Populations
            rows = Creds_Values.Select("CredTypeDesc = 'Populations'")
            cmbPopulations.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbPopulations.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next


            'Certifications
            rows = Creds_Values.Select("CredTypeDesc = 'Certifications'")
            cmbCertifications.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbCertifications.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next


            'SupervisionStyles
            rows = Creds_Values.Select("CredTypeDesc = 'SupervisionStyles'")
            cmbSuperStyles.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbSuperStyles.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'LicensedStates
            rows = Creds_Values.Select("CredTypeDesc = 'LicensedStates'")
            cmbStates.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbStates.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

            'LicenseTypes
            rows = Creds_Values.Select("CredTypeDesc = 'LicenseTypes'")
            cmbLicenseTypes.Items.Add(New ListItem("", "0"))

            For Each row In rows
                cmbLicenseTypes.Items.Add(New ListItem(row("CredValue"), row("CredID")))
            Next

        End If

    End Sub

    Protected Sub cmbModalities_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModalities.SelectedIndexChanged

        If lstModalities.Items.Contains(cmbModalities.SelectedItem) = False Then
            If cmbModalities.SelectedItem.Value <> "0" Then
                lstModalities.Items.Add(cmbModalities.SelectedItem)
                lstModalities.Items(lstModalities.SelectedIndex).Selected = False
            End If
        End If

    End Sub

    Protected Sub cmbCertifications_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCertifications.SelectedIndexChanged

        If lstCertifications.Items.Contains(cmbCertifications.SelectedItem) = False Then
            If cmbCertifications.SelectedItem.Value <> "0" Then
                lstCertifications.Items.Add(cmbCertifications.SelectedItem)
                lstCertifications.Items(lstCertifications.SelectedIndex).Selected = False
            End If
        End If

    End Sub

    Protected Sub cmbSuperStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuperStyles.SelectedIndexChanged

        If lstSuperStyles.Items.Contains(cmbSuperStyles.SelectedItem) = False Then
            If cmbSuperStyles.SelectedItem.Value <> "0" Then
                lstSuperStyles.Items.Add(cmbSuperStyles.SelectedItem)
                lstSuperStyles.Items(lstSuperStyles.SelectedIndex).Selected = False
            End If
        End If

    End Sub

    Protected Sub cmbStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStates.SelectedIndexChanged

        If lstStates.Items.Contains(cmbStates.SelectedItem) = False Then
            If cmbStates.SelectedItem.Value <> "0" Then
                lstStates.Items.Add(cmbStates.SelectedItem)
                lstStates.Items(lstStates.SelectedIndex).Selected = False
            End If
        End If

    End Sub

    Protected Sub cmbLicenseTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLicenseTypes.SelectedIndexChanged

        If lstLicenseTypes.Items.Contains(cmbLicenseTypes.SelectedItem) = False Then
            If cmbLicenseTypes.SelectedItem.Value <> "0" Then
                lstLicenseTypes.Items.Add(cmbLicenseTypes.SelectedItem)
                lstLicenseTypes.Items(lstLicenseTypes.SelectedIndex).Selected = False
            End If
        End If

    End Sub


    Protected Sub cmdSearch_Click(sender As Object, e As ImageClickEventArgs) Handles cmdSearch.Click

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As New System.Data.DataTable

        Dim Fees As String
        Dim TestPrep As String
        Dim Availability As String
        Dim Modalities As String
        Dim Populations As String
        Dim Certifications As String
        Dim SupervisionStyles As String
        Dim States As String
        Dim Licenses As String
        Dim DocList As String
        Dim CurrItem As ListItem
        Dim Where As String
        Dim SQL As String

        'Page.MaintainScrollPositionOnPostBack = False



        Fees = cmbFees.SelectedItem.Value
        TestPrep = cmbTestPrep.SelectedItem.Value
        Availability = cmbAvail.SelectedItem.Value

        'Modalities
        For Each CurrItem In lstModalities.Items
            Modalities = Modalities & CurrItem.Value & ","
        Next

        If Modalities <> "" Then
            Modalities = Mid(Modalities, 1, Modalities.Length - 1)
        End If

        Populations = cmbPopulations.SelectedItem.Value

        'Certifications
        For Each CurrItem In lstCertifications.Items
            Certifications = Certifications & CurrItem.Value & ","
        Next

        If Certifications <> "" Then
            Certifications = Mid(Certifications, 1, Certifications.Length - 1)
        End If

        'Supervision styles
        For Each CurrItem In lstSuperStyles.Items
            SupervisionStyles = SupervisionStyles & CurrItem.Value & ","
        Next

        If SupervisionStyles <> "" Then
            SupervisionStyles = Mid(SupervisionStyles, 1, SupervisionStyles.Length - 1)
        End If

        'States
        For Each CurrItem In lstStates.Items
            States = States & CurrItem.Value & ","
        Next

        If States <> "" Then
            States = Mid(States, 1, States.Length - 1)
        End If

        'LicenseTypes
        For Each CurrItem In lstLicenseTypes.Items
            Licenses = Licenses & CurrItem.Value & ","
        Next

        If Licenses <> "" Then
            Licenses = Mid(Licenses, 1, Licenses.Length - 1)
        End If



        'Search Docs
        Where = "Where "


        If Fees <> "0" Then
            Where = Where & "(CredTypeDesc = 'Fees' AND "
            Where = Where & "CredValueID = " & Fees & ") OR "
        End If

        If TestPrep <> "0" Then
            Where = Where & "(CredTypeDesc = 'TestPrep' AND "
            Where = Where & "CredValueID = " & TestPrep & ") OR "
        End If

        If Availability <> "0" Then
            Where = Where & "(CredTypeDesc = 'Availability' AND "
            Where = Where & "CredValueID = " & Availability & ") OR "
        End If

        If Modalities <> "" Then
            Where = Where & "(CredTypeDesc = 'Modalities' AND "
            Where = Where & "CredValueID IN(" & Modalities & ")) OR "
        End If

        If Populations <> "0" Then
            Where = Where & "(CredTypeDesc = 'Populations' AND "
            Where = Where & "CredValueID = " & Populations & ") OR "
        End If

        If Certifications <> "" Then
            Where = Where & "(CredTypeDesc = 'Certifications' AND "
            Where = Where & "CredValueID IN(" & Certifications & ")) OR "
        End If

        If SupervisionStyles <> "" Then
            Where = Where & "(CredTypeDesc = 'SupervisionStyles' AND "
            Where = Where & "CredValueID IN(" & SupervisionStyles & ")) OR "
        End If

        If States <> "" Then
            Where = Where & "(CredTypeDesc = 'LicensedStates' AND "
            Where = Where & "CredValueID IN(" & States & ")) OR "
        End If

        If Licenses <> "" Then
            Where = Where & "(CredTypeDesc = 'LicenseTypes' AND "
            Where = Where & "CredValueID IN(" & Licenses & ")) OR "
        End If

        If Where = "Where " Then
            lblErrorSearch.Visible = True
            Exit Sub
        Else
            lblErrorSearch.Visible = False
        End If

        'Get Docs
        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd

        Where = Mid(Where, 1, Where.Length - 3) 'Remove last OR

        cmd.CommandType = Data.CommandType.Text

        SQL = SQL & "SELECT UserID "
        SQL = SQL & "FROM SupervisorCreds "
        SQL = SQL & Where
        SQL = SQL & "GROUP BY UserID"

        cmd.CommandText = SQL

        table = New System.Data.DataTable
        da.Fill(table)

        con.Close()

        'Pass DocList to next page
        For Each row In table.Rows
            DocList = DocList & row("UserID") & ","
        Next

        If table.Rows.Count > 0 Then
            DocList = Mid(DocList, 1, DocList.Length - 1)
        End If

        Response.Redirect("InternSearch.aspx?DocList=" & DocList)

    End Sub

    '<System.Web.Services.WebMethod()>
    'Public Shared Sub UploadImage()

    '    Label8.Text = "X"
    '    'Response.Redirect("SupervisorEdit.aspx")

    'End Sub

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

    Protected Sub cmdModalitiesClear_Click(sender As Object, e As EventArgs) Handles cmdModalitiesClear.Click
        If lstModalities.SelectedIndex <> -1 Then
            lstModalities.Items.RemoveAt(lstModalities.SelectedIndex)
        End If
    End Sub

    Protected Sub cmdModalitiesClearAll_Click(sender As Object, e As EventArgs) Handles cmdModalitiesClearAll.Click
        lstModalities.Items.Clear()
    End Sub

    Protected Sub cmdCertificationsCLear_Click(sender As Object, e As EventArgs) Handles cmdCertificationsCLear.Click
        If lstCertifications.SelectedIndex <> -1 Then
            lstCertifications.Items.RemoveAt(lstCertifications.SelectedIndex)
        End If
    End Sub

    Protected Sub cmdCertificationsCLearAll_Click(sender As Object, e As EventArgs) Handles cmdCertificationsCLearAll.Click
        lstCertifications.Items.Clear()
    End Sub

    Protected Sub cmdSuperStylesClear_Click(sender As Object, e As EventArgs) Handles cmdSuperStylesClear.Click
        If lstSuperStyles.SelectedIndex <> -1 Then
            lstSuperStyles.Items.RemoveAt(lstSuperStyles.SelectedIndex)
        End If
    End Sub

    Protected Sub cmdSuperStylesClearAll_Click(sender As Object, e As EventArgs) Handles cmdSuperStylesClearAll.Click
        lstSuperStyles.Items.Clear()
    End Sub

    Protected Sub cmdStatesClear_Click(sender As Object, e As EventArgs) Handles cmdStatesClear.Click
        If lstStates.SelectedIndex <> -1 Then
            lstStates.Items.RemoveAt(lstStates.SelectedIndex)
        End If
    End Sub

    Protected Sub cmdStatesClearAll_Click(sender As Object, e As EventArgs) Handles cmdStatesClearAll.Click
        lstStates.Items.Clear()
    End Sub

    Protected Sub cmdLicenseTypesClear_Click(sender As Object, e As EventArgs) Handles cmdLicenseTypesClear.Click
        If lstLicenseTypes.SelectedIndex <> -1 Then
            lstLicenseTypes.Items.RemoveAt(lstLicenseTypes.SelectedIndex)
        End If
    End Sub

    Protected Sub cmdLicenseTypesClearAll_Click(sender As Object, e As EventArgs) Handles cmdLicenseTypesClearAll.Click
        lstLicenseTypes.Items.Clear()
    End Sub
End Class