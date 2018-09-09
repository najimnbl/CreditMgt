<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="rptGroupwiseLoanStatus.aspx.cs" Inherits="rptGroupwiseLoanStatus" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<center>
<fieldset style="width: 300px"><legend style="width: 250px">Group Wise Aproved Loan Status</legend> 
<table>
<tr>

<th></th>

<th  style="text-align: left">
    &nbsp;</th>
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

         
         
         Group Name</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="drpGroup" runat="Server" AutoPostBack="true"
                 width="160px" Height="22px" 
                onselectedindexchanged="drpGroup_SelectedIndexChanged">
                </asp:DropDownList>
             </th>

   </tr>

   <tr>
   
    <th style="text-align: left" class="style1">

         
         
         Sub Group</th>


          <th  style="text-align: left">
            <asp:DropDownList ID ="DropSubGroup" runat="Server" AutoPostBack="true"
            width="160" Height="22px" 
                onselectedindexchanged="DropSubGroup_SelectedIndexChanged"  >
                <asp:ListItem Value="--ALL--">--ALL--</asp:ListItem>
                
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

