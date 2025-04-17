﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SupervisorEdit.aspx.vb" Inherits="FindYourSupervisor.SupervisorEdit" MaintainScrollPositionOnPostBack="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Style="position: relative; margin: 0 auto; top: 0px; left: 0px; height: 3072px; width: 1382px;">

            <asp:Panel ID="Panel2" runat="server" 
            
                Style="left: 0px; position: absolute; top: -7px; z-index: 1; height: 63px; width: 1382px; bottom: 1048px;" 
                BackImageUrl="~/Images/BlueBar.JPG">
            
                    <asp:Label ID="lblUser" runat="server" Font-Bold="True" ForeColor="White" Height="19px"
                        Style="z-index: 2; left: 21px; position: absolute; top: 8px; text-align: left; font-family: Arial;"
                        Width="229px" Font-Size="10pt"></asp:Label>
                    <asp:Label ID="lblAmazon" runat="server" Font-Bold="True" Font-Size="10pt" 
                        ForeColor="White" Height="19px" 
                        Style="z-index: 2; left: 21px; position: absolute; top: 33px; text-align: left; font-family: Arial; right: 1285px;" 
                        Width="229px">Find Your Supervisor</asp:Label>
                                    
                    
                        
                    <asp:LinkButton ID="lbHome" runat="server" Font-Bold="True" 
                        Font-Underline="False" ForeColor="White" Style="left: 1060px;
                        top: 19px; position: absolute; z-index: 2; font-family: Arial;" Font-Size="10pt">Home</asp:LinkButton>
                        
                    <asp:LinkButton ID="lbSignIn" runat="server" Font-Bold="True" 
                        Font-Underline="False" ForeColor="White" Style="top: 19px; 
                        position: absolute; z-index: 2; left: 1121px; font-family: Arial; height: 16px;" Font-Size="10pt">Sign In</asp:LinkButton>
                        
                    <asp:LinkButton ID="lbSignUp" runat="server" Font-Underline="False" Style="position: absolute;
                        top: 19px; z-index: 2; left: 1188px; font-family: Arial;" ForeColor="White" Font-Bold="True" Font-Size="10pt">Sign Up</asp:LinkButton> 
                        
                    <asp:LinkButton ID="lbEdit" runat="server" Font-Underline="False" Style="left: 1263px;
                        top: 19px; position: absolute; z-index: 2; font-family: Arial;" ForeColor="White" 
                        Font-Bold="True" Font-Size="10pt">Edit</asp:LinkButton>
                         
                    <asp:LinkButton  ID="lbLougout" runat="server" Font-Underline="False" Style="position: absolute;
                        top: 19px; z-index: 2; left: 1316px; font-family: Arial;" ForeColor="White" Font-Bold="True" Font-Size="10pt">Logout</asp:LinkButton>
                    
                    <asp:Label ID="lblBar1" runat="server" ForeColor="White" Height="15px" Style="left: 1110px;
                        position: absolute; top: 17px; z-index: 2; width: 6px;" Text="|"></asp:Label>
                    <asp:Label ID="lblBar2" runat="server" ForeColor="White" Height="15px" Style="left: 1177px;
                        position: absolute; top: 17px; z-index: 2; width: 6px;" Text="|"></asp:Label>
                    <asp:Label ID="lblBar3" runat="server" ForeColor="White" Height="15px" Style="left: 1303px;
                        position: absolute; top: 17px; z-index: 2; width: 6px;" Text="|"></asp:Label>
                    <asp:Label ID="lblBar4" runat="server" ForeColor="White" Height="15px" Style="left: 1246px;
                        position: absolute; top: 17px; z-index: 2; width: 6px;" Text="|"></asp:Label>
                    
                        
            </asp:Panel>

        <asp:Label ID="Label8" runat="server" Text="Fees" Style="left: 655px; position: absolute;
             top: 104px; height: 38px; width: 72px; right: 683px; font-family: Arial;" 
             Font-Size="XX-Large"></asp:Label>
        
        <asp:DropDownList ID="cmbFees" runat="server" Style="left: 373px; position: absolute;
             top: 146px; width: 636px; text-align: center" Font-Size="Medium" 
             TabIndex="1">
        </asp:DropDownList>

        <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Style="left: 622px; position: absolute;
            top: 218px; height: 38px; width: 138px; right: 596px; font-family: Arial;" 
                    Text="Test Prep"></asp:Label>
        
        <asp:DropDownList ID="cmbTestPrep" runat="server" 
             Style="position: absolute; top: 260px; left: 373px; width: 636px; text-align: center" 
             Font-Size="Medium" TabIndex="2">
         </asp:DropDownList>

        <asp:Label ID="Label9" runat="server" Font-Size="XX-Large" Style="left: 618px; position: absolute;
            top: 333px; height: 38px; width: 146px; font-family: Arial;" Text="Availability"></asp:Label>
        
        <asp:DropDownList ID="cmbAvail" runat="server" 
             Style="position: absolute; left: 373px; width: 636px; top: 376px; text-align: center" 
             Font-Size="Medium" TabIndex="3">
         </asp:DropDownList>

        <asp:Label ID="Label10" runat="server" Font-Size="XX-Large" Style="left: 611px; position: absolute;
             top: 452px; height: 38px; width: 160px; font-family: Arial; text-align:center" Text="Experience"></asp:Label>
        
        <asp:TextBox ID="txtExperience" runat="server" 
            Style="position: absolute; left: 373px; top: 496px; width: 636px; height: 300px; 
            font-family: Arial; text-align: center" TextMode="MultiLine" 
            Font-Size="Large" TabIndex="4">
        </asp:TextBox>

        <asp:Label ID="Label11" runat="server" Font-Size="XX-Large" Style="left: 541px; position: absolute;
            top: 844px; height: 38px; width: 300px; font-family: Arial;" Text="Treatment Modalities"></asp:Label>

        <asp:DropDownList ID="cmbModalities" runat="server" 
             Style="position: absolute; left: 373px; width: 308px; top: 883px; text-align: center; right: 419px;" 
             Font-Size="Medium" TabIndex="5" AutoPostBack="True">
         </asp:DropDownList>

        <asp:ListBox ID="lstModalities" runat="server" 
            Style="position: absolute; left: 701px; top: 883px; width: 308px; height: 300px; 
            font-family: Arial" 
            Font-Size="Medium" TabIndex="6" SelectionMode="Multiple">
        </asp:ListBox>

        <asp:Button ID="cmdModalitiesClear" runat="server"
            Style="position: absolute; left: 1020px; top: 883px;
            font-family:Arial; width: 78px;" Text="Remove">
        </asp:Button>

        <asp:Button ID="cmdModalitiesClearAll" runat="server"
            Style="position: absolute; left: 1020px; top: 932px;
            font-family:Arial; width: 78px;" Text="Remove All">
        </asp:Button>

        <asp:Label ID="Label12" runat="server" Font-Size="XX-Large" Style="left: 552px; position: absolute;
            top: 1236px; height: 38px; width: 278px; font-family: Arial;" Text="Populations Served"></asp:Label>

        <asp:DropDownList ID="cmbPopulations" runat="server" 
             Style="position: absolute; left: 373px; top: 1280px; width: 636px; text-align: center; 
             font-family: Arial;" Font-Size="Medium" 
             TabIndex="7">
        </asp:DropDownList>

        <asp:Label ID="Label13" runat="server" Font-Size="XX-Large" Style="left: 599px; position: absolute;
                top: 1355px; height: 38px; width: 184px; font-family: Arial;" Text="Certifications"></asp:Label>

        <asp:DropDownList ID="cmbCertifications" runat="server" 
             Style="position: absolute; left: 373px; width: 308px; top: 1394px; text-align: center; right: 473px;" 
             Font-Size="Medium" TabIndex="8" AutoPostBack="True">
         </asp:DropDownList>

        <asp:ListBox ID="lstCertifications" runat="server" 
            Style="position: absolute; left: 701px; top: 1394px; width: 308px; height: 300px; 
            font-family: Arial" 
            Font-Size="Medium" TabIndex="9" SelectionMode="Multiple">
        </asp:ListBox>

        <asp:Button ID="cmdCertificationsCLear" runat="server"
            Style="position: absolute; left: 1020px; top: 1394px;
            font-family:Arial; width: 78px;" Text="Remove">
        </asp:Button>

        <asp:Button ID="cmdCertificationsCLearAll" runat="server"
            Style="position: absolute; left: 1020px; top: 1443px;
            font-family:Arial; width: 78px;" Text="Remove All">
        </asp:Button>

         <asp:Label ID="Label14" runat="server" Font-Size="XX-Large" Style="left: 556px; position: absolute;
             top: 1747px; height: 38px; width: 270px; font-family: Arial; text-align:center" Text="Supervision Styles"></asp:Label>
        
        <asp:DropDownList ID="cmbSuperStyles" runat="server" 
             Style="position: absolute; left: 373px; width: 308px; top: 1786px; text-align: center; right: 701px;" 
             Font-Size="Medium" TabIndex="10" AutoPostBack="True">
         </asp:DropDownList>

        <asp:ListBox ID="lstSuperStyles" runat="server" 
            Style="position: absolute; left: 701px; top: 1786px; width: 308px; height: 300px; 
            font-family: Arial" 
            Font-Size="Medium" TabIndex="11" SelectionMode="Multiple"></asp:ListBox>

        <asp:Button ID="cmdSuperStylesClear" runat="server"
            Style="position: absolute; left: 1020px; top: 1786px;
            font-family:Arial; width: 78px;" Text="Remove">
        </asp:Button>

        <asp:Button ID="cmdSuperStylesClearAll" runat="server"
            Style="position: absolute; left: 1020px; top: 1835px;
            font-family:Arial; width: 78px;" Text="Remove All">
        </asp:Button>
        
        <asp:Label ID="Label15" runat="server" Font-Size="XX-Large" Style="left: 577px; position: absolute;
                top: 2139px; height: 38px; width: 228px; font-family: Arial;" Text="Licensed States"></asp:Label>

        <asp:DropDownList ID="cmbStates" runat="server" 
             Style="position: absolute; left: 373px; width: 308px; top: 2178px; text-align: center; right: 473px;" 
             Font-Size="Medium" TabIndex="12" AutoPostBack="True">
         </asp:DropDownList>

        <asp:ListBox ID="lstStates" runat="server"
             Style="position: absolute; left: 701px; top: 2178px; width: 303px; height:200px; 
             font-family: Arial;" Font-Size="Medium" 
             TabIndex="13" SelectionMode="Multiple">
        </asp:ListBox>

        <asp:Button ID="cmdStatesClear" runat="server"
            Style="position: absolute; left: 1020px; top: 2178px;
            font-family:Arial; width: 78px;" Text="Remove">
        </asp:Button>

        <asp:Button ID="cmdStatesClearAll" runat="server"
            Style="position: absolute; left: 1020px; top: 2227px;
            font-family:Arial; width: 78px;" Text="Remove All">
        </asp:Button>

        <asp:Label ID="Label17" runat="server" Font-Size="XX-Large" Style="left: 586px; position: absolute;
                top: 2440px; height: 38px; width: 210px; font-family: Arial;" Text="License Types"></asp:Label>

         <asp:DropDownList ID="cmbLicenseTypes" runat="server" 
             Style="position: absolute; left: 373px; width: 308px; top: 2479px; text-align: center" 
             Font-Size="Medium" TabIndex="14" AutoPostBack="True">
         </asp:DropDownList>

        <asp:ListBox ID="lstLicenseTypes" runat="server"
             Style="position: absolute; left: 701px; top: 2479px; width: 303px; height:200px;
             font-family: Arial;" Font-Size="Medium" 
             TabIndex="15" SelectionMode="Multiple">
        </asp:ListBox>

        <asp:Button ID="cmdLicenseTypesClear" runat="server"
            Style="position: absolute; left: 1020px; top: 2479px;
            font-family:Arial; width: 78px;" Text="Remove">
        </asp:Button>

            <asp:Button ID="cmdLicenseTypesClearAll" runat="server"
            Style="position: absolute; left: 1020px; top: 2528px;
            font-family:Arial; width: 78px;" Text="Remove All">
        </asp:Button>


        <asp:Label ID="Label18" runat="server" Font-Size="XX-Large" Style="left: 617px; position: absolute;
            top: 2715px; height: 38px; width: 148px; font-family: Arial;" Text="Profile Pic">
        </asp:Label>

        <asp:ImageButton ID="cmdImg1" runat="server" Height="102px" Style="left: 640px; position: absolute;
                top: 2757px" Visible="True" Width="102px" BorderColor="Black" 
                BorderStyle="Solid" BorderWidth="1px" 
                ImageUrl="~/Images/White.jpg" />

         <asp:ScriptManager ID="ScriptMgr" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        
         <asp:FileUpload ID="FileUpload1" runat="server" Style="left: 756px; position: absolute;
                top: 2841px; width: 218px; " BorderStyle="Solid" BorderWidth="1px" onchange="submitform()"/>


         <script type="text/javascript"> 
             function submitform()
             {
                 document.form1.submit();                 
             }

         </script>
    
        
        <asp:ImageButton ID="cmdSave" runat="server" ImageUrl="~/Images/Save_Transparent.png"
                         Style="left: 585px; position: absolute; top: 2953px; height: 63px; width: 212px;"/>



        <!--Errors-->
        <asp:Label ID="lblErrorFees" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 608px; position: absolute;
             top: 174px; height: 19px; width: 166px;" 
             Text="Enter Fees in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorTestPrep" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 592px; position: absolute;
             top: 288px; height: 19px; width: 191px;" 
             Text="Select test prep in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorAvail" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 586px; position: absolute;
             top: 402px; height: 19px; width: 206px;" 
             Text="Select avaliablity in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorExperience" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 589px; position: absolute;
             top: 806px; height: 19px; width: 199px;" 
             Text="Enter experience in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorModalities" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 373px; position: absolute;
             top: 914px; height: 19px; width: 199px;" 
             Text="Select modalities in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorPopulations" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 588px; position: absolute;
             top: 1307px; height: 19px; width: 212px;" 
             Text="Enter populations in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorCertifications" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 373px; position: absolute;
             top: 1424px; height: 19px; width: 218px;" 
             Text="Select certifications in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorSuperStyles" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 373px; position: absolute;
             top: 1816px; height: 19px; width: 244px;" 
             Text="Select supervision styles in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorStates" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 373px; position: absolute;
             top: 2207px; height: 19px; width: 177px;" 
             Text="Select states in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorLicenseTypes" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 373px; position: absolute;
             top: 2509px; height: 19px; width: 190px;" 
             Text="Select licenses in order to continue" Visible="False">
        </asp:Label>

        <asp:Label ID="lblErrorProfilePic" runat="server" Font-Size="Small" ForeColor="Red" Style="left: 587px; position: absolute;
             top: 2867px; height: 19px; width: 208px;" 
             Text="Upload Profile Pic in order to continue" Visible="False">
        </asp:Label>

        </asp:Panel>

    </form>
</body>
</html>
