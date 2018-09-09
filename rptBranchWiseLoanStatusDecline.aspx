<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rptBranchWiseLoanStatusDecline.aspx.cs" Inherits="rptBranchWiseLoanStatusDecline" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<center>
<fieldset style="width: 300px"><legend style="width: 250px">Branch Wise Decline Loan Status</legend> 
<table>
<tr>

<th></th>

<th  style="text-align: left">
<asp:CheckBox ID="YrChkBox" runat="server"  Text="As On Date"   AutoPostBack="true"
        oncheckedchanged="YrChkBox_CheckedChanged"/> 
</th>
</tr>
<tr>
<th style="text-align: left" class="style1">From Date</th>
    <th style="text-align: left" class="style2">
   
                <asp:TextBox ID="txtFromDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton2" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton2" runat="server" TargetControlID="txtFromDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label2" runat="server" ForeColor="green" Text="dd/MM/yyyy"></asp:Label>
    
    </th>


    </tr>
    <tr>

    <th style="text-align: left" class="style1">To Date</th>
    <th style="text-align: left" class="style2">
   
                <asp:TextBox ID="txtToDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton1" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtToDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label1" runat="server" ForeColor="green" Text="dd/MM/yyyy"></asp:Label>
    
    </th>
</tr>

 <tr >
            <th style="text-align: left" class="style2">
             Branch
            </th>
             <th style="text-align: left" class="style2">
             <asp:DropDownList ID ="drpBranch" runat="Server" 
            width="150px" Height="22px"  >
           <%-- <asp:ListItem Value="Accept">Accept</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Disbursement">Disbursement</asp:ListItem>--%>
            </asp:DropDownList>
            </th>

            </tr>

            <tr>
             <th style="text-align: left" class="style3">

         
         
         Nature</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="DropNature" runat="Server" 
                width="150px" Height="22px" >
                <asp:ListItem Value="--ALL--">--ALL--</asp:ListItem>
                <asp:ListItem Value="CC">CC</asp:ListItem>
                <asp:ListItem Value="SOD">SOD</asp:ListItem>
                <asp:ListItem Value="SOD(FO)">SOD(FO)</asp:ListItem>
                
                </asp:DropDownList>
             </th>

   </tr>

   <tr>
   
    <th style="text-align: left" class="style1">

         
         
         Type</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="DrpType" runat="Server" 
                width="150px" Height="22px" >
                <asp:ListItem Value="--ALL--">--ALL--</asp:ListItem>
                <asp:ListItem Value="Fresh">Fresh</asp:ListItem>
                <asp:ListItem Value="Renewal">Renewal</asp:ListItem>
                <asp:ListItem Value="Enhancement">Enhancement</asp:ListItem>
                <asp:ListItem Value="Reduction">Reduction</asp:ListItem>
                <asp:ListItem Value="Reschedule">Reschedule</asp:ListItem>
                </asp:DropDownList>
             </th>
   </tr>


   <tr>
   <th></th>
   <th style="text-align: left">
    <asp:Button  ID ="ShowReport"  Text="Report Show" runat="Server"  Width="100px" onclick="ShowReport_Click" 
                  > </asp:Button>
       <asp:ScriptManager ID="ScriptManager1" runat="server">
       </asp:ScriptManager>
  </th>
   </tr>

</table>
</fieldset>
</center>
</asp:Content>