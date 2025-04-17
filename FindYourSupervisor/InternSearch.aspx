<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="InternSearch.aspx.vb" Inherits="FindYourSupervisor.InternSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select Adds to Edit</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
          
    <asp:Panel ID="Panel1" runat="server" 
        Style="position: relative; margin: 0 auto; top: 0px; left: 0px; height: 1015px; width: 1382px;">
    
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
    
    <asp:Label ID="lblTitle" runat="server" Font-Size="XX-Large" 
        Style="position: absolute; left: 534px; top: 114px; height: 38px; width: 314px; font-family: Arial; text-align:center" 
        Text="Search Results"></asp:Label>

    <asp:Label ID="ColHeaderFees" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 79px; height: 18px;"
        Text="Fees" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderTestPrep" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 79px; height: 18px;"
        Text="TestPrep" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderAvail" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 79px; height: 18px;"
        Text="Availability" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderPop" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 79px; height: 18px;"
        Text="Populations" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderSuper" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 150px; height: 18px;"
        Text="SupervisionStyles" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderStates" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 100px; height: 18px;"
        Text="LicensedStates" Visible="True"></asp:Label>
    <asp:Label ID="ColHeaderLicenses" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 230px; text-align: left; width: 91px; height: 18px;"
        Text="LicenseTypes" Visible="True"></asp:Label>


    <asp:ImageButton ID="cmdImg1" runat="server" Style="left: 218.5px; position: absolute;
        top: 248px" Visible="False" Height="102px" Width="102px" />
    <asp:Label ID="lblFees1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 79px; height: 18px;"
        Text="lblFees1" Visible="False"></asp:Label>
    <asp:Label ID="lblTestPrep1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 79px; height: 18px;"
        Text="lblTestPrep1" Visible="False"></asp:Label>
    <asp:Label ID="lblAvail1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 75px; height: 18px;"
        Text="lblAvail1" Visible="False"></asp:Label>
    <asp:Label ID="lblPop1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 77px; height: 18px;"
        Text="lblPop1" Visible="False"></asp:Label>
    <asp:Label ID="lblSuper1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 150px; height: 38px;
        white-space:normal; overflow:auto;" 
        Text="lblSuper1" Visible="False"></asp:Label>
    <asp:Label ID="lblStates1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 100px; height: 18px;" 
        Text="lblSattes1" Visible="False"></asp:Label>
    <asp:Label ID="lblLicenses1" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 332px; text-align: left; width: 150px; height: 18px;" 
        Text="lblLicenses1" Visible="False"></asp:Label>
            



    <asp:ImageButton ID="cmdImg2" runat="server" Style="left: 218.5px; position: absolute;
        top: 372px" Visible="False" Height="102px" Width="102px" />
    <asp:Label ID="lblFees2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 79px; height: 18px;"
        Text="lblFees2" Visible="False"></asp:Label>
    <asp:Label ID="lblTestPrep2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 79px; height: 18px;"
        Text="lblTestPrep2" Visible="False"></asp:Label>
    <asp:Label ID="lblAvail2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 75px; height: 18px;"
        Text="lblAvail2" Visible="False"></asp:Label>
    <asp:Label ID="lblPop2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 77px; height: 18px;"
        Text="lblPop2" Visible="False"></asp:Label>
    <asp:Label ID="lblSuper2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 150px; height: 38px;
        white-space:normal; overflow:auto;"
        Text="lblSuper2" Visible="False"></asp:Label>
    <asp:Label ID="lblStates2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 100px; height: 18px;" 
        Text="lblStates2" Visible="False"></asp:Label>
    <asp:Label ID="lblLicenses2" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 456px; text-align: left; width: 150px; height: 18px;" 
        Text="lblLicenses2" Visible="False"></asp:Label>



    <asp:ImageButton ID="cmdImg3" runat="server" Style="left: 218.5px; position: absolute;
        top: 496px" Visible="False" Height="102px" Width="102px" />
    <asp:Label ID="lblFees3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 79px; height: 18px;"
        Text="lblFees3" Visible="False"></asp:Label>
    <asp:Label ID="lblTestPrep3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 79px; height: 18px;"
        Text="lblTestPrep3" Visible="False"></asp:Label>
    <asp:Label ID="lblAvail3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 75px; height: 18px;"
        Text="lblAvail3" Visible="False"></asp:Label>
    <asp:Label ID="lblPop3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 77px; height: 18px;"
        Text="lblPop3" Visible="False"></asp:Label>
    <asp:Label ID="lblSuper3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 150px; height: 38px;
        white-space:normal; overflow:auto;"
        Text="lblSuper3" Visible="False"></asp:Label>
    <asp:Label ID="lblStates3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 100px; height: 18px;" 
        Text="lblStates3" Visible="False"></asp:Label>
    <asp:Label ID="lblLicenses3" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 580px; text-align: left; width: 150px; height: 18px;" 
        Text="lblLicenses3" Visible="False"></asp:Label>


    <asp:ImageButton ID="cmdImg4" runat="server" Style="left: 218.5px; position: absolute;
        top: 620px" Visible="False" Height="102px" Width="102px" />
    <asp:Label ID="lblFees4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 79px; height: 18px;"
        Text="lblFees4" Visible="False"></asp:Label>
    <asp:Label ID="lblTestPrep4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 79px; height: 18px;"
        Text="lblTestPerp4" Visible="False"></asp:Label>
    <asp:Label ID="lblAvail4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 75px; height: 18px;"
        Text="lblAvail4" Visible="False"></asp:Label>
    <asp:Label ID="lblPop4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 77px; height: 18px;"
        Text="lblPop4" Visible="False"></asp:Label>
    <asp:Label ID="lblSuper4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 150px; height: 38px;
        white-space:normal; overflow:auto;"
        Text="lblSuper4" Visible="False"></asp:Label>
    <asp:Label ID="lblStates4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 100px; height: 18px;" 
        Text="lblStates4" Visible="False"></asp:Label>
    <asp:Label ID="lblLicenses4" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 704px; text-align: left; width: 150px; height: 18px;" 
        Text="lblLicenses4" Visible="False"></asp:Label>


    <asp:ImageButton ID="cmdImg5" runat="server" Style="left: 218.5px; position: absolute;
        top: 744px" Visible="False" Height="102px" Width="102px" />
    <asp:Label ID="lblFees5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 344px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 79px; height: 18px;"
        Text="lblFees5" Visible="False"></asp:Label>
    <asp:Label ID="lblTestPrep5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 447px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 79px; height: 18px;"
        Text="lblTestPrep5" Visible="False"></asp:Label>
    <asp:Label ID="lblAvail5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 553px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 75px; height: 18px;"
        Text="lblAvail5" Visible="False"></asp:Label>
    <asp:Label ID="lblPop5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 651px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 77px; height: 18px;"
        Text="lblPop5" Visible="False"></asp:Label>
    <asp:Label ID="lblSuper5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 752px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 150px; height: 38px;
        white-space:normal; overflow:auto;"
        Text="lblSuper5" Visible="False"></asp:Label>
    <asp:Label ID="lblStates5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 915px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 100px; height: 18px;"
        Text="lblStates5" Visible="False" ></asp:Label>
    <asp:Label ID="lblLicenses5" runat="server" Style="font-weight: bold; font-size: 10pt;
        left: 1041px; font-family: Arial; position: absolute; top: 828px; text-align: left; width: 150px; height: 18px;" 
        Text="lblLicenses5" Visible="False"></asp:Label>


    <asp:ImageButton ID="cmdImgNext" runat="server" 
        style="left: 1179px; position: absolute; top: 973px" Height="19px" 
        ImageUrl="~/Images/Paging/Next_Shrunk_2_70_Transparent.png" Width="24px" 
        OnClientClick="Post();"/>
    <asp:ImageButton ID="cmdImgLast" runat="server" 
        style="left: 1212px; position: absolute; top: 973px" Height="19px" 
        ImageUrl="~/Images/Paging/Last_Shurnk_1_50_70_Transparent.png" Width="29px" 
        OnClientClick="Post();" />
    <asp:ImageButton ID="cmdImgFirst" runat="server" 
            style="left: 945px; position: absolute; top: 973px" Height="19px" 
            ImageUrl="~/Images/Paging/First_Shrunk_1_50_70_Transparent.png" Width="29px" 
            OnClientClick="Post();" />
    <asp:ImageButton ID="cmdImgPrevious" runat="server" 
            style="left: 983px; position: absolute; top: 973px" Height="19px" 
            ImageUrl="~/Images/Paging/Previous_Shrunk_1_50_70_Transparent.png" Width="23px" 
            OnClientClick="Post();" />
    <asp:TextBox ID="txtPage" runat="server" Style="font-weight: bold; font-size: 11pt;
        left: 1026px; font-family: Arial; position: absolute; top: 972px; text-align: center"
        Width="45px"></asp:TextBox>
        
    <asp:Label ID="Label1" runat="server" Style="font-weight: normal; font-size: 10pt;
        left: 1086px; font-family: Arial; position: absolute; top: 976px; text-align: center"
        Text="of" Width="18px"></asp:Label>
    <asp:Label ID="lblTotalPages" runat="server" Height="18px" Style="font-weight: bold; font-size: 11pt;
        left: 1111px; font-family: Arial; position: absolute; top: 976px; text-align: center;" Width="56px">0</asp:Label>
        
        <script type="text/javascript">
            function Post() {
                __doPostBack ('idValue','5');
            }
        </script>
    
    
    
    </asp:Panel>
    
    
   
   
    </div>
    </form>
</body>
</html>
