<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MakePayment.aspx.vb" Inherits="FindYourSupervisor.MakePayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <style>
        body {
        background-image: url("/Images/Nature/ocean_reef.jpg");
        background-repeat: no-repeat;
        background-position: top;
        background-size: 100%
        }
    </style>

    <link href="/app.css" rel="stylesheet" />
    
        <script type="text/javascript"
            src="https://web.squarecdn.com/v1/square.js">
    </script>


    <script>
        const appId = 'YourID';
        const locationId = 'YourID';

        async function initializeCard(payments) {
            const card = await payments.card();
            await card.attach('#card-container');

            return card;
        }

        async function createPayment(token) {
            const body = JSON.stringify({
                locationId,
                sourceId: token,
            });

            const paymentResponse = await fetch('/payment', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body,
            });

            if (paymentResponse.ok) {
                return paymentResponse.json();
            }

            const errorBody = await paymentResponse.text();
            throw new Error(errorBody);
        }

        async function tokenize(paymentMethod) {
            const tokenResult = await paymentMethod.tokenize();
            if (tokenResult.status === 'OK') {
                return tokenResult.token;
            } else {
                let errorMessage = `Tokenization failed with status: ${tokenResult.status}`;
                if (tokenResult.errors) {
                    errorMessage += ` and errors: ${JSON.stringify(
                        tokenResult.errors
                    )}`;
                }

                throw new Error(errorMessage);
            }
        }

        // status is either SUCCESS or FAILURE;
        function displayPaymentResults(status) {
            const statusContainer = document.getElementById(
                'payment-status-container'
            );
            if (status === 'SUCCESS') {
                statusContainer.classList.remove('is-failure');
                statusContainer.classList.add('is-success');
            } else {
                statusContainer.classList.remove('is-success');
                statusContainer.classList.add('is-failure');
            }

            statusContainer.style.visibility = 'visible';
        }

        document.addEventListener('DOMContentLoaded', async function () {
            if (!window.Square) {
                throw new Error('Square.js failed to load properly');
            }

            let payments;
            try {
                payments = window.Square.payments(appId, locationId);
            } catch {
                const statusContainer = document.getElementById(
                    'payment-status-container'
                );
                statusContainer.className = 'missing-credentials';
                statusContainer.style.visibility = 'visible';
                return;
            }

            let card;
            try {
                card = await initializeCard(payments);
            } catch (e) {
                console.error('Initializing Card failed', e);
                return;
            }

            // Checkpoint 2.
            async function handlePaymentMethodSubmission(event, paymentMethod) {
                event.preventDefault();

                //try {
                    // disable the submit button as we await tokenization and make a payment request.
                cardButton.disabled = true;
                const token = await tokenize(paymentMethod);

                var rb = document.getElementById("rbOneMonth");
                var rb1 = document.getElementById("rbSixMonth");

                PageMethods.ProcessPayment(token, rb.checked, rb1.checked, onFormsSuccessMethod, onFailMethod);
            }

            function onFormsSuccessMethod()
            {
                displayPaymentResults('SUCCESS');
            }

            function onFailMethod() {
                cardButton.disabled = false;
                displayPaymentResults('FAILURE');
                onsole.error(e.message);
            }

            const cardButton = document.getElementById('card-button');
            cardButton.addEventListener('click', async function (event) {
                await handlePaymentMethodSubmission(event, card);
            });
        });
    </script>
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

        <%--<asp:RadioButton ID="rbOneMonth" runat="server" Text="$20 One Month Subscription" 
            Style="position: absolute; left: 20px; top: 20px; width: 200px; height: 20px; text-align: left; font-family: Arial;"/>
        <asp:RadioButton ID="rbSixMonth" runat="server" Text="$100 Six month subscription" 
            Style="position: absolute; left: 20px; top: 40px; width: 200px; height: 20px; text-align: left; font-family: Arial;"/>--%>

        <%--<input type="radio" id="rbOneMonth" name="subscription" value="$20 One Month Subscription" /><label for="rbOneMonth">$20 One Month Subscription</label><br/>
        
        <input type="radio" id="rbSixMonth" name="subscription" value="$100 Six Month Subscription" />
        <label for="rbSixMonth">$100 Six Month Subscription</label><br/>--%>

        <%--<asp:RadioButtonList ID="rblSubscription" runat="server" Width="241px">
            <asp:ListItem Text="$20 One Month Subscription" Value="20" Style="text-align: left; font-family: Arial;"/>
            <asp:ListItem Text="$100 Six Month Subscription" Value="100" Style="text-align: left; font-family: Arial;"/>
        </asp:RadioButtonList>--%>

        <asp:Panel ID="Panel3" runat="server" Style="position: relative; margin: 0 auto; top: 0px; left: 0px; height: 2072px; width: 500px;">
        

        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        <br/>
        
        <asp:RadioButton ID="rbOneMonth" runat="server" GroupName="subscription" Height="40px" Checked="True" />
            <label style="font-size: 20px; font-weight: bold; font-family: Arial; color:yellow;">$20 One month subscription</label><br/>
        <asp:RadioButton ID="rbSixMonth" runat="server" GroupName="subscription" Height="40px" />
            <label style="font-size: 20px; font-weight: bold; font-family: Arial; color:yellow;">$100 Six month subscription</label><br/>

        <div id="card-container">
        </div>

        <button id="card-button" type="button">
            Make Payment
        </button>

        <div id="payment-status-container">
        </div>


        <%--<div id="card-container"
            Style="position: absolute; left: 20px; top: 100px;">
        </div>

        <button id="card-button" type="button"
            Style="position: absolute; left: 20px; top: 200px;">
            Make Payment
        </button>

        <div id="payment-status-container"
            Style="position: absolute; left: 20px; top: 300px;">
        </div>--%>
        
         <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>

        
            

        
        </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>


<%--<form runat="server">
      <asp:ImageButton ID="cmdPay" runat="server" ImageUrl="~/Images/Search_Transparent.png"
                         Style="height: 72px; width: 212px;"/> 
    </form>--%>