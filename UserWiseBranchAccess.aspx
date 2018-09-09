<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserWiseBranchAccess.aspx.cs" Inherits="UserWiseBranchAccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">


<div style="width:500px; margin-left:auto; margin-right:auto;  padding-top:auto; padding-bottom:auto; "> 
        <div style="width:500px; text-align:center; font-family: 'Courier New', Courier, monospace; font-size: 14px; font-weight: bold; font-style: oblique; color: #000000;"> 
          User Wise Branch Authentication <hr />
        </div>


<table align="center">
  <tr> 
    <th >User ID </th>
   <th > 
        <asp:DropDownList ID="userDropDownList" runat="server" Height="25px" 
       
        Width="174px" onselectedindexchanged="userDropDownList_SelectedIndexChanged" ontextchanged="userDropDownList_TextChanged" AutoPostBack="true"
        >
    </asp:DropDownList>
     </th>
    
    <th >

           <asp:Button ID="BtnLoad" runat="server" Text="Load" onclick="BtnLoad_Click" 
               Visible="False" />
    </th>
    </tr>

</table>

<hr />

<table border="0" cellpadding="0" cellspacing="0" align="center">

<tr>
<th>Not Authorization Branches</th>
<th></th>
<th> Authorization Branches</th>

</tr>

    <tr>
        <td>
            <asp:ListBox ID="lstLeft" runat="server" SelectionMode="Multiple" Width="185" Height="400">
                <%--<asp:ListItem Text="January" Value="1" />
                <asp:ListItem Text="Februray" Value="2" />
                <asp:ListItem Text="March" Value="3" />
                <asp:ListItem Text="April" Value="4" />
                <asp:ListItem Text="May" Value="5" />
                <asp:ListItem Text="June" Value="6" />
                <asp:ListItem Text="July" Value="7" />
                <asp:ListItem Text="August" Value="8" />
                <asp:ListItem Text="September" Value="9" />
                <asp:ListItem Text="October" Value="10" />
                <asp:ListItem Text="November" Value="11" />
                <asp:ListItem Text="December" Value="12" />--%>
            </asp:ListBox>
        </td>
        <td>
        <asp:Button ID="BtnRight" runat="server" Text=">" onclick="BtnRight_Click" /><br /><br />
        <asp:Button ID="BtnLeft" runat="server" Text="<" onclick="BtnLeft_Click"  /><br /><br />
        <asp:Button ID="BtnRightAll" runat="server" Text=">>" 
                onclick="BtnRightAll_Click"  /><br /><br />
        <asp:Button ID="BtnLeftAll" runat="server" Text="<<" onclick="BtnLeftAll_Click" />        
        </td>
        <td>
            <asp:ListBox ID="lstRight" runat="server" SelectionMode="Multiple" Width="185" Height="400"></asp:ListBox>
        </td>
    </tr>


 </table>



<hr />


<table  align ="center">
<tr>
<th> </th>
<th>
 <asp:Button ID="btnSubmit" Text="Authentication" runat="server"  onclick="btnSubmit_Click"/>
 </th>
</tr>

<th> </th>

  </table>






<table>
        <%--<td  valign="top"><asp:Label ID="Label1" runat="server" Text="Left ListBox Items:<br/>"></asp:Label></td>
        <td valign="top"><asp:Label ID="Label2" runat="server" Text="Right ListBox Items:<br/>"></asp:Label></td>--%>
    </tr>
</table>
</asp:Content>


