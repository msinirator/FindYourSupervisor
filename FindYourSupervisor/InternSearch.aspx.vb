
Partial Class InternSearch
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


        Dim x As Integer
        Dim y As Integer

        Dim cmdImg As ImageButton
        Dim lblFees As Label
        Dim lblTestPrep As Label
        Dim lblAvail As Label
        Dim lblPop As Label
        Dim lblSuper As Label
        Dim lblStates As Label
        Dim lblLicenses As Label


        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim rows() As System.Data.DataRow
        Dim SQL As String
        Dim Creds As System.Data.DataTable


        Dim CurrPage As Integer
        Dim TotalPages As Integer
        Dim LoopMax As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String


        If IsPostBack = False Then

            DocList = Request.QueryString("DocList")

            If DocList = "" Then
                lblTitle.Text = "No Supervisors found"
                Exit Sub
            End If


            'Set User label
            lblUser.Text = "Welcome, " & Session("UserName")

            'Load Grid
            con.ConnectionString = ConfigurationManager.ConnectionStrings("LiveConnection").ConnectionString
            con.Open()

            cmd.Connection = con
            da.SelectCommand = cmd

            SQL = SQL & "Select a.UserID, a.CredTypeID, a.CredTypeDesc, b.CredValue "
            SQL = SQL & "From SupervisorCreds a "
            SQL = SQL & "Left Join SupervisorCreds_Values b "
            SQL = SQL & "ON a.CredTypeID = b.CredTypeID AND "
            SQL = SQL & "a.CredValueID = b.CredID "
            SQL = SQL & "Where a.UserID In(" & DocList & ")"

            cmd.CommandText = SQL

            Creds = New System.Data.DataTable
            da.Fill(Creds)
            con.Close()

            DocArr = Split(DocList, ",")

            If DocArr.Length <= 5 Then
                LoopMax = DocArr.Length
            Else
                LoopMax = 5
            End If


            For x = 1 To LoopMax


                'Find controls
                cmdImg = Page.FindControl("cmdImg" & CStr(x))
                lblFees = Page.FindControl("lblFees" & CStr(x))
                lblTestPrep = Page.FindControl("lblTestPrep" & CStr(x))
                lblAvail = Page.FindControl("lblAvail" & CStr(x))
                lblPop = Page.FindControl("lblPop" & CStr(x))
                lblSuper = Page.FindControl("lblSuper" & CStr(x))
                lblStates = Page.FindControl("lblStates" & CStr(x))
                lblLicenses = Page.FindControl("lblLicenses" & CStr(x))



                'row = Creds.Rows(x - 1)
                UserID = DocArr(x - 1)

                'Set Data
                rows = Creds.Select("CredTypeDesc = 'Fees' AND UserID = " & UserID)
                lblFees.Text = rows(0)("CredValue")

                rows = Creds.Select("CredTypeDesc = 'TestPrep' AND UserID = " & UserID)
                lblTestPrep.Text = rows(0)("CredValue")

                rows = Creds.Select("CredTypeDesc = 'Availability' AND UserID = " & UserID)
                lblAvail.Text = rows(0)("CredValue")

                rows = Creds.Select("CredTypeDesc = 'Populations' AND UserID = " & UserID)
                lblPop.Text = rows(0)("CredValue")



                rows = Creds.Select("CredTypeDesc = 'SupervisionStyles' AND UserID = " & UserID)
                lblSuper.Text = ""

                For Each row In rows
                    lblSuper.Text = lblSuper.Text & row("CredValue") & ","
                Next

                If lblSuper.Text <> "" Then
                    lblSuper.Text = Mid(lblSuper.Text, 1, lblSuper.Text.Length - 1)
                End If


                rows = Creds.Select("CredTypeDesc = 'LicensedStates' AND UserID = " & UserID)
                lblStates.Text = ""

                For Each row In rows
                    lblStates.Text = lblStates.Text & row("CredValue") & ","
                Next

                If lblStates.Text <> "" Then
                    lblStates.Text = Mid(lblStates.Text, 1, lblStates.Text.Length - 1)
                End If


                rows = Creds.Select("CredTypeDesc = 'LicenseTypes' AND UserID = " & UserID)
                lblLicenses.Text = ""

                For Each row In rows
                    lblLicenses.Text = lblLicenses.Text & row("CredValue") & ","
                Next

                If lblLicenses.Text <> "" Then
                    lblLicenses.Text = Mid(lblLicenses.Text, 1, lblLicenses.Text.Length - 1)
                End If


                cmdImg.ImageUrl = "~/LoadImage.aspx?UserID=" & UserID



                'Set Visible
                cmdImg.Visible = True
                lblFees.Visible = True
                lblTestPrep.Visible = True
                lblAvail.Visible = True
                lblPop.Visible = True
                lblSuper.Visible = True
                lblStates.Visible = True
                lblLicenses.Visible = True


            Next

            CurrPage = 1
            txtPage.Text = CurrPage

            TotalPages = 1

            'Get total pages
            For x = 1 To DocArr.Length

                If y = 5 Then
                    TotalPages = TotalPages + 1
                    y = 0
                End If

                y = y + 1

            Next

            lblTotalPages.Text = TotalPages

            Session("Items_Edit") = Creds
            Session("DocList_Edit") = DocList
            Session("CurrPage_Edit") = CurrPage
            Session("TotalPages_Edit") = TotalPages

        Else

            Dim EvnTarget As String
            Dim EvnArg As String
            Dim UserPage As Integer

            EvnTarget = Request("__EVENTTARGET")
            EvnArg = Request("__EVENTARGUMENT")

            If EvnTarget = "" And EvnArg = "" Then

                If Trim(txtPage.Text) = "" Then
                    Exit Sub
                End If

                TotalPages = Session("TotalPages_Edit")
                UserPage = Trim(txtPage.Text)

                If UserPage <= 0 Then
                    Exit Sub
                End If

                If UserPage > TotalPages Then
                    Exit Sub
                End If

                FlipPage(UserPage)
                Session("CurrPage_Edit") = UserPage

            End If

        End If

    End Sub

    Protected Sub cmdImgNext_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImgNext.Click

        Dim CurrPage As Integer
        Dim TotalPages As Integer

        CurrPage = Session("CurrPage_Edit")
        TotalPages = Session("TotalPages_Edit")

        If CurrPage >= TotalPages Then
            Exit Sub
        End If

        CurrPage = CurrPage + 1

        FlipPage(CurrPage)

        Session("CurrPage_Edit") = CurrPage
        txtPage.Text = CurrPage

    End Sub

    Protected Sub cmdImgPrevious_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImgPrevious.Click

        Dim CurrPage As Integer
        Dim TotalPages As Integer

        CurrPage = Session("CurrPage_Edit")
        TotalPages = Session("TotalPages_Edit")

        If CurrPage <= 1 Then
            Exit Sub
        End If

        CurrPage = CurrPage - 1

        FlipPage(CurrPage)

        Session("CurrPage_Edit") = CurrPage
        txtPage.Text = CurrPage

    End Sub

    Protected Sub cmdImgLast_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImgLast.Click

        Dim CurrPage As Integer
        Dim TotalPages As Integer

        CurrPage = Session("CurrPage_Edit")
        TotalPages = Session("TotalPages_Edit")

        CurrPage = TotalPages

        FlipPage(CurrPage)

        Session("CurrPage_Edit") = CurrPage
        txtPage.Text = CurrPage

    End Sub

    Protected Sub cmdImgFirst_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImgFirst.Click

        Dim CurrPage As Integer
        Dim TotalPages As Integer

        CurrPage = Session("CurrPage_Edit")
        TotalPages = Session("TotalPages_Edit")

        CurrPage = 1

        FlipPage(CurrPage)

        Session("CurrPage_Edit") = CurrPage
        txtPage.Text = CurrPage

    End Sub

    Sub FlipPage(ByVal CurrPage As Integer)

        Dim cmdImg As ImageButton
        Dim lblFees As Label
        Dim lblTestPrep As Label
        Dim lblAvail As Label
        Dim lblPop As Label
        Dim lblSuper As Label
        Dim lblStates As Label
        Dim lblLicenses As Label


        Dim con As New System.Data.SqlClient.SqlConnection
        Dim cmd As New System.Data.SqlClient.SqlCommand
        Dim da As New System.Data.SqlClient.SqlDataAdapter
        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim rows() As System.Data.DataRow
        Dim Creds As System.Data.DataTable


        Dim StartPos As Integer
        Dim x As Integer
        Dim y As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        'Get StartPos
        Creds = Session("Items_Edit")
        DocList = Session("DocList_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next


        'Hide Elements
        For x = 1 To 5

            cmdImg = Page.FindControl("cmdImg" & CStr(x))
            lblFees = Page.FindControl("lblFees" & CStr(x))
            lblTestPrep = Page.FindControl("lblTestPrep" & CStr(x))
            lblAvail = Page.FindControl("lblAvail" & CStr(x))
            lblPop = Page.FindControl("lblPop" & CStr(x))
            lblSuper = Page.FindControl("lblSuper" & CStr(x))
            lblStates = Page.FindControl("lblStates" & CStr(x))
            lblLicenses = Page.FindControl("lblLicenses" & CStr(x))


            cmdImg.Visible = False
            lblFees.Visible = False
            lblTestPrep.Visible = False
            lblAvail.Visible = False
            lblPop.Visible = False
            lblSuper.Visible = False
            lblStates.Visible = False
            lblLicenses.Visible = False
        Next

        y = 1
        DocArr = Split(DocList, ",")


        'Load Grid
        For x = StartPos To DocArr.Length - 1 'table.Rows.Count - 1

            'Find controls
            cmdImg = Page.FindControl("cmdImg" & CStr(y))
            lblFees = Page.FindControl("lblFees" & CStr(y))
            lblTestPrep = Page.FindControl("lblTestPrep" & CStr(y))
            lblAvail = Page.FindControl("lblAvail" & CStr(y))
            lblPop = Page.FindControl("lblPop" & CStr(y))
            lblSuper = Page.FindControl("lblSuper" & CStr(y))
            lblStates = Page.FindControl("lblStates" & CStr(y))
            lblLicenses = Page.FindControl("lblLicenses" & CStr(y))

            'row = table.Rows(x)
            UserID = DocArr(x)

            'Set Data
            rows = Creds.Select("CredTypeDesc = 'Fees' AND UserID = " & UserID)
            lblFees.Text = rows(0)("CredValue")

            rows = Creds.Select("CredTypeDesc = 'TestPrep' AND UserID = " & UserID)
            lblTestPrep.Text = rows(0)("CredValue")

            rows = Creds.Select("CredTypeDesc = 'Availability' AND UserID = " & UserID)
            lblAvail.Text = rows(0)("CredValue")

            rows = Creds.Select("CredTypeDesc = 'Populations' AND UserID = " & UserID)
            lblPop.Text = rows(0)("CredValue")



            rows = Creds.Select("CredTypeDesc = 'SupervisionStyles' AND UserID = " & UserID)
            lblSuper.Text = ""

            For Each row In rows
                lblSuper.Text = lblSuper.Text & row("CredValue") & ","
            Next

            If lblSuper.Text <> "" Then
                lblSuper.Text = Mid(lblSuper.Text, 1, lblSuper.Text.Length - 1)
            End If


            rows = Creds.Select("CredTypeDesc = 'LicensedStates' AND UserID = " & UserID)
            lblStates.Text = ""

            For Each row In rows
                lblStates.Text = lblStates.Text & row("CredValue") & ","
            Next

            If lblStates.Text <> "" Then
                lblStates.Text = Mid(lblStates.Text, 1, lblStates.Text.Length - 1)
            End If


            rows = Creds.Select("CredTypeDesc = 'LicenseTypes' AND UserID = " & UserID)
            lblLicenses.Text = ""

            For Each row In rows
                lblLicenses.Text = lblLicenses.Text & row("CredValue") & ","
            Next

            If lblLicenses.Text <> "" Then
                lblLicenses.Text = Mid(lblLicenses.Text, 1, lblLicenses.Text.Length - 1)
            End If


            cmdImg.ImageUrl = "~/LoadImage.aspx?UserID=" & UserID



            'Set Visible
            cmdImg.Visible = True
            lblFees.Visible = True
            lblTestPrep.Visible = True
            lblAvail.Visible = True
            lblPop.Visible = True
            lblSuper.Visible = True
            lblStates.Visible = True
            lblLicenses.Visible = True

            y = y + 1

            If y = 6 Then
                Exit For
            End If

        Next


    End Sub


    Protected Sub cmdImg1_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImg1.Click

        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim CurrPage As Integer
        Dim StartPos As Integer
        Dim x As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        DocList = Session("DocList_Edit")
        CurrPage = Session("CurrPage_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next

        DocArr = Split(DocList, ",")

        UserID = DocArr(StartPos)
        Response.Redirect("SupervisorHome.aspx?UserID=" & UserID)

    End Sub

    Protected Sub cmdImg2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImg2.Click

        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim CurrPage As Integer
        Dim StartPos As Integer
        Dim x As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        DocList = Session("DocList_Edit")
        CurrPage = Session("CurrPage_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next

        DocArr = Split(DocList, ",")

        StartPos = StartPos + 1
        UserID = DocArr(StartPos)
        Response.Redirect("SupervisorHome.aspx?UserID=" & UserID)

    End Sub

    Protected Sub cmdImg3_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImg3.Click

        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim CurrPage As Integer
        Dim StartPos As Integer
        Dim x As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        DocList = Session("DocList_Edit")
        CurrPage = Session("CurrPage_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next

        DocArr = Split(DocList, ",")

        StartPos = StartPos + 2
        UserID = DocArr(StartPos)
        Response.Redirect("SupervisorHome.aspx?UserID=" & UserID)

    End Sub

    Protected Sub cmdImg4_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImg4.Click

        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim CurrPage As Integer
        Dim StartPos As Integer
        Dim x As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        DocList = Session("DocList_Edit")
        CurrPage = Session("CurrPage_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next

        DocArr = Split(DocList, ",")

        StartPos = StartPos + 3
        UserID = DocArr(StartPos)
        Response.Redirect("SupervisorHome.aspx?UserID=" & UserID)

    End Sub

    Protected Sub cmdImg5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles cmdImg5.Click

        Dim table As New System.Data.DataTable
        Dim row As System.Data.DataRow
        Dim CurrPage As Integer
        Dim StartPos As Integer
        Dim x As Integer

        Dim DocList As String
        Dim DocArr() As String
        Dim UserID As String

        DocList = Session("DocList_Edit")
        CurrPage = Session("CurrPage_Edit")

        For x = 1 To CurrPage - 1
            StartPos = StartPos + 5
        Next

        DocArr = Split(DocList, ",")

        StartPos = StartPos + 4
        'row = table.Rows(StartPos)
        UserID = DocArr(StartPos)
        Response.Redirect("SupervisorHome.aspx?UserID=" & UserID)

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
