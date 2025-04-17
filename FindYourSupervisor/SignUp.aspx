<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SignUp.aspx.vb" Inherits="FindYourSupervisor.SignUp" %>

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
                BackImageUrl="~/Images/BlueBar.JPG" TabIndex="12">
            
                    <asp:Label ID="lblUser" runat="server" Font-Bold="True" ForeColor="White" Height="19px"
                        Style="z-index: 2; left: 21px; position: absolute; top: 8px; text-align: left; font-family: Arial;"
                        Width="229px" Font-Size="10pt" TabIndex="13"></asp:Label>
                    <asp:Label ID="lblAmazon" runat="server" Font-Bold="True" Font-Size="10pt" 
                        ForeColor="White" Height="19px" 
                        Style="z-index: 2; left: 21px; position: absolute; top: 33px; text-align: left; font-family: Arial; right: 1285px;" 
                        Width="229px" TabIndex="14">Find Your Supervisor</asp:Label>
                                    
                    
                        
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

            <asp:Panel ID="Panel4" runat="server" BackColor="#5D7B9D" Height="29px" Style="left: 470px;
                position: absolute; top: 362px" Width="442px" TabIndex="10">
                <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="14pt" ForeColor="White"
                           Style="left: 194px; position: absolute; top: 0px; width: 74px;" Text="Register"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="Panel3" runat="server" BackColor="#A7A7A7" BorderColor="White"
                Style="left: 470px; position: absolute; top: 389px; height: 317px;" Width="442px" TabIndex="11">
                
                <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 100px; position: absolute; top: 37px; text-align: right" Text="Email:"
                    Width="89px"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" Style="left: 190px; position: absolute;
                    top: 34px" Width="139px" TabIndex="1"></asp:TextBox>
                
                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 100px; position: absolute; top: 125px; text-align: right"
                    Text="Password:" Width="89px"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" Style="left: 190px; position: absolute;
                    top: 122px" Width="138px" TextMode="Password" TabIndex="3"></asp:TextBox>

                <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 39px; position: absolute; top: 167px; text-align: right; width: 150px;"
                    Text="Password confirm:"></asp:Label>
                <asp:TextBox ID="txtPasswordConfirm" runat="server" Style="left: 190px; position: absolute;
                    top: 166px" TextMode="Password" Width="138px" TabIndex="4"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="White" Style="left: 86px; position: absolute; top: 81px; text-align: right; width: 103px;"
                    Text="Enter Code:"></asp:Label>

                <asp:TextBox ID="txtCode" runat="server" Style="left: 190px; position: absolute;
                    top: 78px" Width="138px" TabIndex="2">
                </asp:TextBox>

                <asp:Button ID="cmdGetCode" runat="server" Style="left: 351px; position: absolute;
                            top: 78px;" Text="Get Code" Width="79px" 
                            BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" TabIndex="8" />

                <asp:CheckBox ID="chkIntern" runat="server" Style="left: 136px; position: absolute;
                              top: 207px; width: 91px; right: 215px;" ForeColor="White" Text="Intern" Font-Names="Arial" Font-Bold="True" TabIndex="5"/>

                <asp:CheckBox ID="chkSupervisor" runat="server" ForeColor="White" Style="left: 237px; position: absolute;
                              top: 207px; width: 105px;" Text="Supervisor" Font-Names="Arial" Font-Bold="True" TabIndex="6"/>

                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="12pt"
                    ForeColor="Red" Style="left: 48px; position: absolute; top: 241px; text-align: center; width: 367px;" TabIndex="9"></asp:Label>
                <asp:ImageButton ID="cmdSignUp" runat="server" ImageUrl="~/Images/SignUp_Green.bmp"
                                 Style="left: 180px; position: absolute; top: 275px; height: 30px; width: 110px;" TabIndex="7"/>
                                
            </asp:Panel>
                                   

        </asp:Panel>
    </form>
</body>
</html>
