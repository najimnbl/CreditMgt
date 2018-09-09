
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Customer.aspx.cs" Inherits="Customer" %>--%>


<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master"  AutoEventWireup="true"
    CodeFile="EmployeeInfo.aspx.cs" Inherits="EmployeeInfo" %>

<script runat="server">

  
</script>
<%--<script src="../../Scripts/jquery-1.3.2.min.js" language="javascript" type="text/javascript"/>

<script src="../../Scripts/jquery-ui-1.7.1.custom.min.js" type="text/javascript"/>
--%>




 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
     <center>
     <table style="height: 75px">
 <tr>
 <th class="style1">
 <fieldset  style="width: 400px" >
  <legend>Employee Information</legend>

  <table  border="0" >

    <tr>
    <th class="style2">Employee ID</th>
    <th class="style1"> 
        <asp:TextBox ID="txtEmployeeID" runat="server"  
           width="200px" MaxLength="25" ></asp:TextBox> </th>
      <th class="style4">

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtEmployeeID"
                runat="server" />
    </th>

    </tr>

               
    <tr> 
    <th class="style2">Employee Name</th>
   <th class="style1"> 
       <asp:TextBox ID="txtEmployeeName" runat="server" 
           width="200px" MaxLength="75" ></asp:TextBox> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtEmployeeName"
                runat="server" />
    </th>
    </tr>



    <tr> 
    <th class="style2">Designation</th>
   <th class="style1"> 
       <asp:TextBox ID="txtDesignation" runat="server" 
           width="200px" MaxLength="50" ></asp:TextBox> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtDesignation"
                runat="server" />
    </th>
    </tr>
 

 <tr> 
    <th class="style2">Registration No</th>
   <th class="style1"> 
       <asp:TextBox ID="txtRegistrationNo" runat="server" 
           width="200px" MaxLength="75" ></asp:TextBox> </th>
    
    <th class="style4">

           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtRegistrationNo"
                runat="server" />--%>
    </th>
    </tr>
 
  <tr> 
    <th class="style2">Branch Code</th>
   <th class="style1"> 
     <%--  <asp:TextBox ID="txtBranchCode" runat="server" 
           width="200px" MaxLength="3" ></asp:TextBox>--%>
           <asp:DropDownList ID ="txtBranchCode" runat="Server" 
            width="200px" Height="22px"  >
           
            </asp:DropDownList>
           
            </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtBranchCode"
                runat="server" />
    </th>
    </tr>


     <tr> 
    <th class="style2">Mobile No.</th>
   <th class="style1"> 
       <asp:TextBox ID="txtMobileNo" runat="server" 
           width="200px" MaxLength="11" ></asp:TextBox> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="txtMobileNo"
                runat="server" />
    </th>
    </tr>

 <tr>
 
 <th>
 </th>


 <th>
 <asp:Button  ID ="btnBSave" Text="Save" ValidationGroup="v"  runat="Server" Width="100px" onclick="btnBSave_Click1" 
          > </asp:Button>
     
     <asp:Button  ID ="txtNew" Text="New" runat="Server" Width="106px" 
         onclick="txtNew_Click1" > </asp:Button>
   
 </th>
 
   
 
 </tr>



    </table> 
    <asp:ScriptManager ID="ScriptManager1" runat="server">
      </asp:ScriptManager>


  
 </fieldset>
</th>

</tr>
</table>

<table ><tr><td></td><td colspan="3">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="true" 
                    AutoGenerateColumns="false" DataKeyNames="ID"
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                    OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" 
                    OnRowUpdating="GridView1_RowUpdating" PageSize="5" 
                    onrowdatabound="GridView1_RowDataBound">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
     <%--<asp:ButtonField   Text="SingleClick" CommandName="SingleClick"  />--%>
                        <asp:TemplateField Visible="false" >
                            <EditItemTemplate>
                                <asp:TextBox ID="GrID" runat="server" Text='<%#Eval("ID") %>' 
                                     ></asp:TextBox>
                                

                            </EditItemTemplate>

                            <ItemTemplate>


                                <asp:Label ID="idLabel" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        
                        
                        <asp:TemplateField HeaderText="Type Code">
                            <EditItemTemplate>
                                <asp:TextBox ID="GrEmployeeID" runat="server" Text='<%#Eval("EmployeeID") %>' 
                                    ></asp:TextBox>
                            </EditItemTemplate>
                            
                            
                            <ItemTemplate>
                                <asp:Label ID="txtEmployeeID" runat="server" 
                                    Text='<%#Eval("EmployeeID") %>'></asp:Label>
                            </ItemTemplate>
                            
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Employee Name">
                            
                            <ItemTemplate>
                                <asp:Label ID="ChargeCategoryNameLabel" runat="server" 
                                    Text='<%#Eval("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                             <asp:TextBox ID="GrEmployeeName" runat="server" Text='<%#Eval("EmployeeName") %>' 
                                    ></asp:TextBox>
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Designation">
                            <EditItemTemplate>
                              
                                     <asp:TextBox ID="GrDesignation" runat="server" Text='<%#Eval("Designation") %>' 
                                    ></asp:TextBox>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="RRemarks" runat="server" Text='<%#Eval("Designation") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Registration No">
                            <EditItemTemplate>
                              
                                     <asp:TextBox ID="GrRegistrationNo" runat="server" Text='<%#Eval("RegistrationNo") %>' 
                                    ></asp:TextBox>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="RRemarks" runat="server" Text='<%#Eval("RegistrationNo") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                          <asp:TemplateField HeaderText="Branch Code">
                            <EditItemTemplate>
                              
                                     <asp:TextBox ID="GrBranchCode" runat="server" Text='<%#Eval("BranchCode") %>' 
                                    ></asp:TextBox>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="RRemarks" runat="server" Text='<%#Eval("BranchCode") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                          <asp:TemplateField HeaderText="Mobile No">
                            <EditItemTemplate>
                              
                                     <asp:TextBox ID="GrMobileNo" runat="server" Text='<%#Eval("MobileNo") %>' 
                                    ></asp:TextBox>

                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="RRemarks" runat="server" Text='<%#Eval("MobileNo") %>' 
                                    ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                       
                        <asp:CommandField ShowEditButton="true" />
                        <asp:CommandField ShowDeleteButton="true" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td><td>&nbsp;</td></tr></table>
</center>

</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 375px;

        }
        .style2
        {
            width: 594px;
            text-align: left;
            background-color: #0B5E0A;
            font-family: Tahoma;
            color: #FFFAF0;
            font-size: 10pt;
            font-weight: 500;
        }
        .style4
        {
            width: 46px;
        }
    </style>
</asp:Content>


