<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SupervisorHome.aspx.vb" Inherits="FindYourSupervisor.SupervisorHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
body {
  background-image: url("/Images/Nature/kamnitz_gorge.jpg");
  background-repeat: no-repeat;
  background-position: center;
  background-size: 100% 100%;
}
</style>
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
                        position: absolute; z-index: 2; left: 1121px; font-family: Arial;" Font-Size="10pt">Sign In</asp:LinkButton>
                        
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


        <asp:Image ID="Image1" runat="server" 
            Style="position: absolute; left: 100px; top: 104px; width:200px; height:200px" />

        <asp:Label ID="Label8" runat="server" Text="Fees" Style="left: 164px; position: absolute;
             top: 368px; height: 38px; width: 72px; right: 1146px; font-family: Arial;" 
             Font-Size="XX-Large" ForeColor="Yellow" Font-Bold="False"></asp:Label>
        
        <asp:Label ID="lblFees" runat="server" Style="left: 100px; position: absolute;
             top: 410px; width: 200px; text-align: center; font-family: Arial;" Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF"></asp:Label>

        <asp:Label ID="Label7" runat="server" Font-Size="XX-Large" Style="left: 131px; position: absolute;
            top: 482px; height: 38px; width: 138px; right: 1113px; font-family: Arial;" 
                    Text="Test Prep" ForeColor="Yellow" Font-Bold="False"></asp:Label>
        
        <asp:Label ID="lblTestPrep" runat="server" 
             Style="position: absolute; top: 524px; left: 100px; width: 200px; text-align: center; height: 19px;" 
             Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF"></asp:Label>

        <asp:Label ID="Label9" runat="server" Font-Size="XX-Large" Style="left: 127px; position: absolute;
            top: 596px; height: 38px; width: 146px; font-family: Arial;" Text="Availability" ForeColor="Yellow"></asp:Label>
        
        <asp:Label ID="lblAvail" runat="server" 
             Style="position: absolute; left: 100px; width: 200px; top: 638px; text-align: center" 
            Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF"></asp:Label>

        

        <asp:Label ID="Label12" runat="server" Font-Size="XX-Large" Style="left: 100px; position: absolute;
            top: 710px; height: 38px; width: 278px; font-family: Arial;" Text="Populations Served" ForeColor="Yellow"></asp:Label>

        <asp:Label ID="lblPopulations" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#84D7FF" Style="position: absolute; left: 121px; top: 752px; width: 370px; text-align: left; 
            font-family: Arial;"></asp:Label>

        <asp:Label ID="Label13" runat="server" Font-Size="XX-Large" ForeColor="Yellow" Style="left: 100px; position: absolute;
            top: 834px; height: 38px; width: 184px; font-family: Arial;" Text="Certifications"></asp:Label>

        <asp:BulletedList ID="lstCertifications" runat="server" 
            Style="position: absolute; left: 98px; top: 876px; width: 370px; height: 90px; 
            font-family: Arial" Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF">
        </asp:BulletedList>

         <asp:Label ID="Label14" runat="server" Font-Size="XX-Large" Style="left: 100px; position: absolute;
             top: 1018px; height: 38px; width: 270px; font-family: Arial; text-align:center" Text="Supervision Styles" ForeColor="Yellow"></asp:Label>
        
        <asp:BulletedList ID="lstSuperStyles" runat="server" 
            Style="position: absolute; left: 98px; top: 1062px; width: 313px; height: 66px; 
            font-family: Arial" Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF">
        </asp:BulletedList>

        
        <asp:Label ID="Label15" runat="server" Font-Size="XX-Large" Style="left: 100px; position: absolute;
                top: 1152px; height: 38px; width: 228px; font-family: Arial;" Text="Licensed States" ForeColor="Yellow"></asp:Label>

        <asp:Label ID="lblStates" runat="server" 
             Style="position: absolute; left: 121px; top: 1194px; width: 308px; text-align: left; 
             font-family: Arial;" Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF"></asp:Label>

        <asp:Label ID="Label16" runat="server" Font-Size="XX-Large" ForeColor="Yellow" Style="left: 100px; position: absolute;
             top: 1266px; height: 38px; width: 210px; font-family: Arial;" Text="License Types"></asp:Label>
            
        <asp:Label ID="lblLicenseTypes" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="#84D7FF" Style="position: absolute; left: 121px; 
             top: 1308px; width: 308px; text-align: left; 
             font-family: Arial;"></asp:Label>
            
            



            <%--right side--%>
            <asp:Label ID="Label10" runat="server" Font-Size="XX-Large" Style="left: 937px; position: absolute;
             top: 482px; height: 38px; width: 160px; font-family: Arial; text-align:center" Text="Experience" ForeColor="Yellow"></asp:Label>
        
        <asp:TextBox ID="txtExperience" runat="server" 
            Style="border-style: none; border-color: inherit; border-width: medium; position: absolute; left: 974px; top: 529px; width: 400px; height: 285px; 
            font-family: Arial; text-align: left; resize: none; background-color: transparent; " 
            TextMode="MultiLine" Font-Size="Large" ReadOnly="true" Font-Bold="True" ForeColor="#84D7FF"></asp:TextBox>

        <asp:Label ID="Label11" runat="server" Font-Size="XX-Large" Style="left: 937px; position: absolute;
            top: 834px; height: 38px; width: 300px; font-family: Arial;" Text="Treatment Modalities" ForeColor="Yellow"></asp:Label>

        <asp:BulletedList ID="lstModalities" runat="server" 
            Style="position: absolute; left: 935px; top: 885px; width: 395px; height: 417px; 
            font-family: Arial; " Font-Size="Medium" Font-Bold="True" ForeColor="#84D7FF">
        </asp:BulletedList>


        </asp:Panel>
    </form>
</body>
</html>
