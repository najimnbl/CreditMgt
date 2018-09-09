<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoanAplicationINformation.aspx.cs" Inherits="LoanAplicationINformation" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  


<center>
       
       
       <table>
       <tr >
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

            <th style="text-align: left" id="trrHideMe1" runat="Server">
         Loan Nature

          </th>
           <th id="trrHideMe" runat="Server">
                <asp:DropDownList ID ="DropLoanNature" runat="Server" 
                width="205px" Height="22px" >

               
               

                <asp:ListItem Value="--ALL--">--ALL--</asp:ListItem>
                <asp:ListItem Value="Fresh">Fresh</asp:ListItem>
                <asp:ListItem Value="Renewal">Renewal</asp:ListItem>
                <asp:ListItem Value="Enhancement">Enhancement</asp:ListItem>
                <asp:ListItem Value="Reduction">Reduction</asp:ListItem>
                <asp:ListItem Value="Loan Pricing">Loan Pricing</asp:ListItem>
                <asp:ListItem Value="Conditional">Conditional</asp:ListItem>
                <asp:ListItem Value="Reschedule">Reschedule</asp:ListItem>



                </asp:DropDownList>
              
             </th>

            <th>
            <asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                onclick="btnSearch_Click"  > </asp:Button>

               

             </th>

           
         
    </tr>


            </table>
       
       
        <fieldset style="width: 662px" >
      
        
       <%-- <legend align="left">Loan Aplication Information </legend>--%>
        
        <asp:GridView ID="GridView1" runat="server" 

             
              onrowdeleting="GridView1_RowDeleting" 
            
            onrowediting="GridView1_RowEditing1"  PageSize="15" Width="607px">
            
            <Columns>
               <%-- <asp:CommandField ShowEditButton="True" CancelText="" DeleteText="" />--%>
             <%--  OnRowCancelingEdit="GridView1_RowCancelingEdit" --%>
                <%--<asp:CommandField ShowEditButton="True" />--%>
                <asp:CommandField ShowDeleteButton="True" DeleteText="Comment" />
            </Columns>
          
        </asp:GridView>

         </fieldset>
    </center>

</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
</asp:Content>

--%>