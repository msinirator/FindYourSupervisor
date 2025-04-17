<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignIn.aspx.vb" Inherits="FindYourSupervisor.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="Panel1" runat="server" Style="position: relative; margin: 0 auto; top: 0px; left: 0px; height: 2072px; width: 1382px;">

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

            <asp:Label ID="Label7" runat="server" Text="Welcome to FindYourSupervisor.net!" 
                Style="left: 379px; position: absolute; top: 68px; height: 21px; width: 634px; text-align:center; font-family: Arial;" Font-Bold="True" Font-Size="10pt"></asp:Label>

            <asp:Label ID="Label8" runat="server"  Text="This is a searchable portal to assist you in finding YOUR best supervisor!"
                Style="left: 379px; position: absolute; top: 93px; height: 21px; width: 634px; text-align:center; font-family: Arial;" Font-Bold="True" Font-Size="10pt">
            </asp:Label>

            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="10pt" Text="Joining as an Intern:" 
                Style="left: 493px; position: absolute; top: 139px; height: 21px; width: 144px; font-family: Arial;">
            </asp:Label>

            <asp:BulletedList ID="BulletedList1" runat="server"
                Style="left: 493px; position: absolute; top: 152px; height: 50px; width: 485px; font-family: Arial; font-size:10pt; bottom: 1851px; margin-bottom: 19px;">
                <asp:ListItem Style="padding-bottom:10px">A FREE searchable tool to locate a qualified supervisor that meets your needs as a
                    registered mental health/social work/marriage & family intern
                </asp:ListItem>
                <asp:ListItem Style="padding-bottom:10px">A FREE portal to log and save intern hours</asp:ListItem>
            </asp:BulletedList>

            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="10pt" Text="Joining as a Qualified Supervisor:"
                Style="left: 493px; position: absolute; top: 263px; height: 21px; width: 225px; font-family: Arial;" > 
            </asp:Label>

            <asp:BulletedList ID="BulletedList2" runat="server"
                Style="left: 493px; position: absolute; top: 275px; height: 50px; width: 485px; font-family: Arial; font-size:10pt; bottom: 1728px; margin-bottom: 19px;">
                <asp:ListItem Style="padding-bottom:10px">Providing interns that can gel within your practice and provide additional revenue</asp:ListItem>
                <asp:ListItem>$20/monthly to keep your profile up to date and searchable for potential interns</asp:ListItem>
            </asp:BulletedList>

            <asp:Panel ID="Panel4" runat="server" BackColor="#5D7B9D" Height="29px" Style="left: 470px;
                position: absolute; top: 406px" Width="442px">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="14pt" ForeColor="White"
                           Style="left: 206px; position: absolute; top: 0px; width: 48px;" Text="Login">
                </asp:Label>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" BackColor="#A7A7A7" BorderColor="White" Height="278px"
                Style="left: 470px; position: absolute; top: 434px" Width="442px">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 100px; position: absolute; top: 81px; text-align: right" Text="Email:"
                    Width="89px"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Style="left: 190px; position: absolute;
                    top: 78px" Width="139px"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 100px; position: absolute; top: 128px; text-align: right"
                    Text="Password:" Width="89px"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" Style="left: 190px; position: absolute;
                    top: 125px" Width="138px" TextMode="Password"></asp:TextBox>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="Red" Style="left: 93px; position: absolute; top: 184px; text-align: center"
                    Text="Login incorrect. Please try again." Visible="False" Width="267px">
                </asp:Label>
                <asp:ImageButton ID="cmdSignIn" runat="server" ImageUrl="~/Images/Login_Transparent.png"
                                 Style="left: 111px; position: absolute; top: 231px; height: 31px; width: 104px;"/>
                <asp:ImageButton ID="cmdSignUp" runat="server" ImageUrl="~/Images/SignUp_Green.bmp"
                                 Style="left: 265px; position: absolute; top: 231px; height: 30px; width: 110px;" TabIndex="7"/>

            </asp:Panel>
            
            
            
        </asp:Panel>
    </form>
</body>
</html>
