<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SearchContant.aspx.cs" Inherits="SearchContant" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<center>
       
       
       <table>
       <tr >

     
            <th>
                Search  Application Content.
            </th>
            <th>
             <asp:TextBox ID="txtAccount" runat="server"  width="200px"  ></asp:TextBox> 
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


