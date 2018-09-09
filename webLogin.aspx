<%@ Page Language="C#" AutoEventWireup="true" CodeFile="webLogin.aspx.cs" Inherits="webLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%--<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>--%>

<script runat="server">


</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Branch Manager...User Login</title>
    <%--<script src="JS/Datepicker.js" type="text/javascript"></script>

    <link href="App_Themes/style.css" rel="stylesheet" type="text/css" />--%>
</head>
<body onload="document.form1.txtUser.focus()" >
    <form id="form1" runat="server">
    <div style="width:800px; height:400px; margin-left:auto; margin-right:auto;  padding-top:auto; padding-bottom:auto; "> 
        <div style="width:800px; text-align:center; font-family: 'Courier New', Courier, monospace; font-size: 25px; font-weight: bold; font-style: oblique; color: #000000;"> 
           Credit Approval Management System<hr />
        </div>
     
       <div style="width:800px"> 
                <div style="float:left; width:500px; padding-top:100px" >
                   &nbsp;
                </div>
                <div style="float:right; width:300px; padding-top:100px">
                <center>
                    <table style="width:300px; border: 2px solid #9900CC; ">
                        <tr>
                            <td style="text-align:center" colspan="2">
                                Log In
                           </td>
                        </tr>                      
                        <tr>
                            <td style="text-align:left; width:100px; text-align:left; vertical-align:top;">
                                User Id :
                            </td>
                             <td style="text-align:left; width:200px">
                                <asp:TextBox ID="txtUser" runat="server" style="width:150px"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserId" runat="server" 
                                     ErrorMessage="Enter User Id" ControlToValidate="txtUser" 
                                     ValidationGroup="LogIn">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left; width:100px">
                                Password :
                            </td>
                             <td style="text-align:left; width:200px">
                                <asp:TextBox ID="txtPass" runat="server" style="width:150px" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Pass" runat="server" 
                                     ErrorMessage="Enter Password" ControlToValidate="txtPass" 
                                     ValidationGroup="LogIn">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       <tr>
                            <td style="text-align:left; width:100px">
                                &nbsp;
                            </td>
                             <td style="text-align:left; width:200px">
                                 <asp:Label ID="lblInfo" runat="server" Font-Names="Times New Roman" 
                                     Font-Size="12px" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left; width:100px">
                                &nbsp;
                            </td>
                             <td style="text-align:left; width:200px">
                                 <asp:Button ID="Button1" runat="server" Text="Log In" style="width:100px" 
                                     onclick="Btn_LogIn_Click" ValidationGroup="LogIn" />
                            </td>
                        </tr>
                        
                         <tr>
                            <td style="text-align:left; width:100px">
                                &nbsp;
                            </td>
                             <td style="text-align:left; width:200px">
                                 <asp:ValidationSummary ID="ValidationSummary_LogIn" runat="server" 
                                     ValidationGroup="LogIn" Font-Names="Times New Roman" Font-Size="9px" />
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align:center" colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    </center>
                </div>
       </div>
    </div>
    
      <div style="width:800px; height:400px; text-align:center; margin-left:auto; margin-right:auto;  padding-top:100px; padding-bottom:auto; font-family: 'Times New Roman'; font-size: 10px;"> 
        <hr />
        National Bank Limited &nbsp; |&nbsp; Information Technology Division
        <hr />
      </div>
    </form>
</body>
</html>