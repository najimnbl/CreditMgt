<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoanAplicationCommentsInformation.aspx.cs" Inherits="LoanAplicationCommentsInformation" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  


<center>
       
       
       <table>
       <tr >

     
            <th>
                Aplication No.
            </th>
            <th>
             <asp:TextBox ID="txtAccount" runat="server"  width="200px"  >--ALL--</asp:TextBox> 
          </th>
  

       <th>
            Status
            </th>
       <th>
            <asp:DropDownList ID ="Rstaus" runat="Server" AutoPostBack="true"
            width="205px" Height="22px" >
            <asp:ListItem Value="--ALL--">--ALL--</asp:ListItem>
           <%-- <asp:ListItem Value="Accept">Accept</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Disbursement">Disbursement</asp:ListItem>--%>
             <asp:ListItem Value="Approved">Approved</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Need Modification">Need Modification</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
            </asp:DropDownList>
              
            </th>
            <th>
             Branch
            </th>
             <th>
             <asp:DropDownList ID ="drpbranch" runat="Server" 
            width="205px" Height="22px"  >
           <%-- <asp:ListItem Value="Accept">Accept</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Disbursement">Disbursement</asp:ListItem>--%>
            </asp:DropDownList>
            </th>

            <th>
            <asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                onclick="btnSearch_Click"  > </asp:Button>

               

             </th>

            </tr>
            </table>
       
       
        <fieldset style="width: 880px" >
      
        
       <%-- <legend align="left">Loan Aplication Information </legend>--%>
        
        <asp:GridView ID="GridView1" runat="server" 

             PageSize="15" Width="809px" align="center">
          
        </asp:GridView>

         </fieldset>
    </center>

</asp:Content>
