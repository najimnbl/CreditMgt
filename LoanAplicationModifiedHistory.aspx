<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoanAplicationModifiedHistory.aspx.cs" Inherits="LoanAplicationModifiedHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<center>
       
       
       <table>
       <tr >
            <th>
             Aplication NO.
            </th>
             <th>
              <asp:TextBox ID="txtAplication" runat="server"  width="200px"  ></asp:TextBox> 
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
                <asp:CommandField ShowDeleteButton="True" DeleteText="Details" />
            </Columns>
          
        </asp:GridView>

         </fieldset>
    </center>
</asp:Content>

