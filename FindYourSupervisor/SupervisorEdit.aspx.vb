Imports System.Data.SqlClient
Public Class SupervisorEdit
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        If Session("UserType") = 0 Then
            Response.Redirect("Default.aspx")
        End If


        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim rows() As System.Data.DataRow
        Dim SQL As String

        Dim UserID As String
        Dim Creds As System.Data.DataTable
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



            'Fill Supervisor Creds
            con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
            con.Open()

            cmd.Connection = con
            da.SelectCommand = cmd

            cmd.CommandType = Data.CommandType.Text

            SQL = ""
            SQL = SQL & "Select a.CredTypeID, a.CredTypeDesc, b.CredID, b.CredValue, a.[FreeText] "
            SQL = SQL & "From SupervisorCreds a "
            SQL = SQL & "Left Join SupervisorCreds_Values b "
            SQL = SQL & "ON a.CredTypeID = b.CredTypeID AND "
            SQL = SQL & "a.CredValueID = b.CredID "
            SQL = SQL & "Where UserID = " & UserID

            cmd.CommandText = SQL

            Creds = New System.Data.DataTable
            da.Fill(Creds)


            con.Close()

            If Creds.Rows.Count > 0 Then

                rows = Creds.Select("CredTypeDesc = 'Fees'")
                cmbFees.Items(cmbFees.Items.IndexOf(New ListItem(rows(0)("CredValue"), rows(0)("CredID")))).Selected = True

                rows = Creds.Select("CredTypeDesc = 'TestPrep'")
                cmbTestPrep.Items(cmbTestPrep.Items.IndexOf(New ListItem(rows(0)("CredValue"), rows(0)("CredID")))).Selected = True

                rows = Creds.Select("CredTypeDesc = 'Availability'")
                cmbAvail.Items(cmbAvail.Items.IndexOf(New ListItem(rows(0)("CredValue"), rows(0)("CredID")))).Selected = True

                rows = Creds.Select("CredTypeDesc = 'Experience'")
                txtExperience.Text = rows(0)("FreeText")


                rows = Creds.Select("CredTypeDesc = 'Modalities'")

                For Each row In rows
                    lstModalities.Items.Add(New ListItem(row("CredValue"), row("CredID")))
                Next

                rows = Creds.Select("CredTypeDesc = 'Populations'")
                cmbPopulations.Items(cmbPopulations.Items.IndexOf(New ListItem(rows(0)("CredValue"), rows(0)("CredID")))).Selected = True


                rows = Creds.Select("CredTypeDesc = 'Certifications'")

                For Each row In rows
                    lstCertifications.Items.Add(New ListItem(row("CredValue"), row("CredID")))
                Next


                rows = Creds.Select("CredTypeDesc = 'SupervisionStyles'")

                For Each row In rows
                    lstSuperStyles.Items.Add(New ListItem(row("CredValue"), row("CredID")))
                Next


                rows = Creds.Select("CredTypeDesc = 'LicensedStates'")

                For Each row In rows
                    lstStates.Items.Add(New ListItem(row("CredValue"), row("CredID")))
                Next

                rows = Creds.Select("CredTypeDesc = 'LicenseTypes'")

                For Each row In rows
                    lstLicenseTypes.Items.Add(New ListItem(row("CredValue"), row("CredID")))
                Next

            End If


            'Profile Pic
            con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
            con.Open()

            cmd.Connection = con
            da.SelectCommand = cmd

            cmd.CommandType = Data.CommandType.Text

            SQL = ""
            SQL = SQL & "Select AutoID From Images "
            SQL = SQL & "Where UserID = " & Session("UserID")

            cmd.CommandText = SQL

            table = New System.Data.DataTable
            da.Fill(table)

            con.Close()

            If table.Rows.Count > 0 Then
                cmdImg1.ImageUrl = "~/LoadImage.aspx?UserID=" & Session("UserID")
            End If

        Else

            'Upload profile pic
            If FileUpload1.PostedFile.ContentLength > 0 Then
                InsertImage()
            End If

        End If

    End Sub

    Sub InsertImage()


        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim SQL As String

        Dim intImageSize As Int64
        Dim strImageType As String
        Dim ImageStream As System.IO.Stream

        Dim bmp As System.Drawing.Bitmap

        Dim ImageContent(intImageSize) As Byte
        Dim intStatus As Integer


        ' Gets the Size of the Image
        intImageSize = FileUpload1.PostedFile.ContentLength

        ' Gets the Image Type
        strImageType = FileUpload1.PostedFile.ContentType

        ' Reads the Image
        ImageStream = FileUpload1.PostedFile.InputStream

        ReDim ImageContent(intImageSize)
        intStatus = ImageStream.Read(ImageContent, 0, intImageSize)

        'Get dimensions
        bmp = New System.Drawing.Bitmap(ImageStream)

        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd


        'Remove current image
        cmd.CommandType = Data.CommandType.Text

        SQL = SQL & "Delete From Images Where "
        SQL = SQL & "UserID = " & Session("UserID")

        cmd.CommandText = SQL

        cmd.ExecuteNonQuery()

        'Add Image
        cmd.CommandType = Data.CommandType.StoredProcedure
        cmd.CommandText = "InsertImage"


        Dim prmPersonImage As New SqlParameter("@Image", Data.SqlDbType.Image)
        prmPersonImage.Value = ImageContent
        cmd.Parameters.Add(prmPersonImage)

        Dim prmImageHeight As New SqlParameter("@Height", Data.SqlDbType.SmallInt)
        prmImageHeight.Value = bmp.Height
        cmd.Parameters.Add(prmImageHeight)

        Dim prmImageWidth As New SqlParameter("@Width", Data.SqlDbType.SmallInt)
        prmImageWidth.Value = bmp.Width
        cmd.Parameters.Add(prmImageWidth)

        Dim prmUserID As New SqlParameter("@UserID", Data.SqlDbType.BigInt)
        prmUserID.Value = Session("UserID")
        cmd.Parameters.Add(prmUserID)


        cmd.ExecuteNonQuery()
        con.Close()

        cmdImg1.ImageUrl = "~/LoadImage.aspx?UserID=" & Session("UserID")
        cmd.Parameters.Clear()


    End Sub

    Protected Sub cmbModalities_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbModalities.SelectedIndexChanged

        If lstModalities.Items.Contains(cmbModalities.SelectedItem) = False Then
            If cmbModalities.SelectedItem.Value <> "0" Then
                lstModalities.Items.Add(cmbModalities.SelectedItem)
                lstModalities.Items(lstModalities.SelectedIndex).Selected = False

                lblErrorModalities.Visible = False
            End If
        End If

    End Sub

    Protected Sub cmbCertifications_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCertifications.SelectedIndexChanged

        If lstCertifications.Items.Contains(cmbCertifications.SelectedItem) = False Then
            If cmbCertifications.SelectedItem.Value <> "0" Then
                lstCertifications.Items.Add(cmbCertifications.SelectedItem)
                lstCertifications.Items(lstCertifications.SelectedIndex).Selected = False

                lblErrorCertifications.Visible = False
            End If
        End If

    End Sub

    Protected Sub cmbSuperStyles_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSuperStyles.SelectedIndexChanged

        If lstSuperStyles.Items.Contains(cmbSuperStyles.SelectedItem) = False Then
            If cmbSuperStyles.SelectedItem.Value <> "0" Then
                lstSuperStyles.Items.Add(cmbSuperStyles.SelectedItem)
                lstSuperStyles.Items(lstSuperStyles.SelectedIndex).Selected = False

                lblErrorSuperStyles.Visible = False
            End If
        End If

    End Sub

    Protected Sub cmbStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStates.SelectedIndexChanged

        If lstStates.Items.Contains(cmbStates.SelectedItem) = False Then
            If cmbStates.SelectedItem.Value <> "0" Then
                lstStates.Items.Add(cmbStates.SelectedItem)
                lstStates.Items(lstStates.SelectedIndex).Selected = False

                lblErrorStates.Visible = False
            End If
        End If

    End Sub

    Protected Sub cmbLicenseTypes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLicenseTypes.SelectedIndexChanged

        If lstLicenseTypes.Items.Contains(cmbLicenseTypes.SelectedItem) = False Then
            If cmbLicenseTypes.SelectedItem.Value <> "0" Then
                lstLicenseTypes.Items.Add(cmbLicenseTypes.SelectedItem)
                lstLicenseTypes.Items(lstLicenseTypes.SelectedIndex).Selected = False

                lblErrorLicenseTypes.Visible = False
            End If
        End If

    End Sub


    Protected Sub cmdSave_Click(sender As Object, e As ImageClickEventArgs) Handles cmdSave.Click

        If Session("UserID") Is Nothing Then
            Response.Redirect("SignIn.aspx")
            Exit Sub
        End If

        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As New System.Data.DataTable
        Dim SQL As String

        Dim Experience As String
        Dim UserID As String
        Dim CurrItem As ListItem


        Experience = Trim(txtExperience.Text)


        UserID = Session("UserID")
        Page.MaintainScrollPositionOnPostBack = False

        'Creds validation
        If cmbFees.SelectedItem.Value = "0" Then
            lblErrorFees.Visible = True
            Exit Sub
        Else
            lblErrorFees.Visible = False
        End If

        If cmbTestPrep.SelectedItem.Value = "0" Then
            lblErrorTestPrep.Visible = True
            Exit Sub
        Else
            lblErrorTestPrep.Visible = False
        End If

        If cmbAvail.SelectedItem.Value = "0" Then
            lblErrorAvail.Visible = True
            Exit Sub
        Else
            lblErrorAvail.Visible = False
        End If

        If Experience = "" Then
            lblErrorExperience.Visible = True
            Exit Sub
        Else
            lblErrorExperience.Visible = False
        End If

        If lstModalities.Items.Count = 0 Then
            lblErrorModalities.Visible = True
            Exit Sub
        Else
            lblErrorModalities.Visible = False
        End If

        If cmbPopulations.SelectedItem.Value = "0" Then
            lblErrorPopulations.Visible = True
            Exit Sub
        Else
            lblErrorPopulations.Visible = False
        End If

        If lstCertifications.Items.Count = 0 Then
            lblErrorCertifications.Visible = True
            Exit Sub
        Else
            lblErrorCertifications.Visible = False
        End If

        If lstSuperStyles.Items.Count = 0 Then
            lblErrorSuperStyles.Visible = True
            Exit Sub
        Else
            lblErrorSuperStyles.Visible = False
        End If

        If lstStates.Items.Count = 0 Then
            lblErrorStates.Visible = True
            Exit Sub
        Else
            lblErrorStates.Visible = False
        End If

        If lstLicenseTypes.Items.Count = 0 Then
            lblErrorLicenseTypes.Visible = True
            Exit Sub
        Else
            lblErrorLicenseTypes.Visible = False
        End If

        'Profile Pic
        If FileUpload1.PostedFile.ContentLength = 0 And cmdImg1.ImageUrl = "~/Images/Home/White.jpg" Then
            lblErrorProfilePic.Visible = True
            Exit Sub
        Else
            lblErrorProfilePic.Visible = False
        End If

        'Update Creds
        con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
        con.Open()

        cmd.Connection = con
        da.SelectCommand = cmd


        cmd.CommandType = Data.CommandType.Text

        SQL = SQL & "Delete From SupervisorCreds "
        SQL = SQL & "Where UserID = " & UserID

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()


        'Fees
        SQL = ""
        SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
        SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
        SQL = SQL & UserID & ",1,'Fees'," & cmbFees.SelectedItem.Value & ",'')"

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()

        'TestPrep
        SQL = ""
        SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
        SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
        SQL = SQL & UserID & ",2,'TestPrep'," & cmbTestPrep.SelectedItem.Value & ",'')"

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()

        'Availability
        SQL = ""
        SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
        SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
        SQL = SQL & UserID & ",3,'Availability'," & cmbAvail.SelectedItem.Value & ",'')"

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()

        'Experience
        SQL = ""
        SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
        SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
        SQL = SQL & UserID & ",4,'Experience',0,'" & Experience & "')"

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()


        'Modalities
        For Each CurrItem In lstModalities.Items

            SQL = ""
            SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
            SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
            SQL = SQL & UserID & ",5,'Modalities'," & CurrItem.Value & ",'')"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Next

        'Populations
        SQL = ""
        SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
        SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
        SQL = SQL & UserID & ",6,'Populations'," & cmbPopulations.SelectedItem.Value & ",'')"

        cmd.CommandText = SQL
        cmd.ExecuteNonQuery()


        'Certifications
        For Each CurrItem In lstCertifications.Items

            SQL = ""
            SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
            SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
            SQL = SQL & UserID & ",7,'Certifications'," & CurrItem.Value & ",'')"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Next

        'SupervisionStyles
        For Each CurrItem In lstSuperStyles.Items

            SQL = ""
            SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
            SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
            SQL = SQL & UserID & ",8,'SupervisionStyles'," & CurrItem.Value & ",'')"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Next

        'LicensedStates
        For Each CurrItem In lstStates.Items

            SQL = ""
            SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
            SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
            SQL = SQL & UserID & ",9,'LicensedStates'," & CurrItem.Value & ",'')"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Next

        'LicenseTypes
        For Each CurrItem In lstLicenseTypes.Items

            SQL = ""
            SQL = SQL & "Insert Into SupervisorCreds (UserID, CredTypeID, "
            SQL = SQL & "CredTypeDesc, CredValueID, [FreeText]) VALUES ("
            SQL = SQL & UserID & ",10,'LicenseTypes'," & CurrItem.Value & ",'')"

            cmd.CommandText = SQL
            cmd.ExecuteNonQuery()
        Next

        con.Close()
        Response.Redirect("Default.aspx")

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