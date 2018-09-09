<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserInfo.aspx.cs" Inherits="UserInfo" %>

 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  
     <center>
     <table style="height: 75px">
 <tr>
 <th class="style1">
 <fieldset  style="width: 400px" >
  <legend>Create User</legend>
  <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
  <table  border="0" >

    <tr>
    <th class="style2">User ID</th>
    <th class="style1"> 
        <asp:TextBox ID="userIdTextBox" runat="server"  
           width="200px" MaxLength="25" ></asp:TextBox> </th>
      <th class="style4">

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="userIdTextBox"
                runat="server" />
    </th>

    </tr>

               
    <tr> 
    <th class="style2">User Name</th>
   <th class="style1"> 
       <asp:DropDownList ID="userNameDropDownList" runat="server" Height="24px" 
           Width="200px">
       </asp:DropDownList> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="userNameDropDownList"
                runat="server" />
    </th>
    </tr>



    <tr> 
    <th class="style2">Password</th>
   <th class="style1"> 
       <asp:TextBox ID="passwordTextBox" runat="server" 
           width="200px"  TextMode="Password" ></asp:TextBox> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="passwordTextBox"
                runat="server" />
    </th>
    </tr>
 

 <tr> 
    <th class="style2">Confirm Password</th>
   <th class="style1"> 
       <asp:TextBox ID="confirmPasswordTextBox" runat="server" 
           width="200px" MaxLength="75" TextMode="Password" ></asp:TextBox> </th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="confirmPasswordTextBox"
                runat="server" />
    </th>
    </tr>
 <tr> 
    <th class="style2">User Type</th>
   <th class="style1"> 
       <asp:DropDownList ID="userTypeDropDownList" runat="server" Height="24px" 
           Width="200px" 
           onselectedindexchanged="userTypeDropDownList_SelectedIndexChanged">
           <asp:ListItem>Admin</asp:ListItem>
           <asp:ListItem>Branch</asp:ListItem>
           <asp:ListItem>Branch CC</asp:ListItem>
           <asp:ListItem>Regional Office</asp:ListItem>
           <asp:ListItem>Regional  CC</asp:ListItem>
           <asp:ListItem>Head Office-CRM</asp:ListItem>
           <asp:ListItem>Head Offic -CC</asp:ListItem>
          
           <asp:ListItem>DMD/MD</asp:ListItem>
           <asp:ListItem>Executive Commite</asp:ListItem>
           <asp:ListItem>Head Offic -CAD</asp:ListItem>
           <asp:ListItem>Law & Recovery</asp:ListItem>


       </asp:DropDownList></th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="userTypeDropDownList"
                runat="server" />
    </th>
    </tr>

 <tr> 
    <th class="style2">Active</th>
   <th align="left" class="style1"> 
     <asp:CheckBox ID="activeCheckBox" Checked="true" runat="server" /></th>
    
    <th class="style4">

            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="Required" ValidationGroup="v"  ForeColor="Red" ControlToValidate="userTypeDropDownList"
                runat="server" />
    </th>
    </tr>
 <tr>
 
 <th class="style5">
 </th>


 <th>
 <asp:Button  ID ="saveButton" Text="Save" ValidationGroup="v"  runat="Server" 
         Width="100px" onclick="saveButton_Click" 
          > </asp:Button>
     
     <asp:Button  ID ="newButton" Text="New" runat="Server" Width="106px" 
         onclick="newButton_Click" > </asp:Button>
   
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
       
             <asp:GridView ID="GridView1" runat="server" AllowPaging="true" 
                    AutoGenerateColumns="false" DataKeyNames="ID"
                    OnPageIndexChanging="GridView1_PageIndexChanging" 
                  
                    OnRowDeleting="GridView1_RowDeleting" 
                 
                    PageSize="5"  >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
   
                        <asp:TemplateField Visible="false">
                            <EditItemTemplate>
                                <asp:TextBox ID="idTextBox" runat="server" Text='<%#Eval("ID") %>' 
                                    Visible="false"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="idLabel" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserID">
                           
                            <ItemTemplate>
                                <asp:Label ID="UserIDLabel" runat="server" Text='<%#Eval("UserID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User Name">
                         
                            <ItemTemplate>
                                <asp:Label ID="EmployeeNameLabel" runat="server" 
                                    Text='<%#Eval("EmployeeName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserType">
                         
                            <ItemTemplate>
                                <asp:Label ID="UserTypeLabel" runat="server" 
                                    Text='<%#Eval("UserType") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Active">
                         
                            <ItemTemplate>
                                <asp:Label ID="ActiveLabel" runat="server" 
                                    Text='<%#Eval("Active") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <%-- <asp:TemplateField HeaderText="Right">
                            
                            <ItemTemplate>
                                <asp:Label ID="CustomerSexLabel" runat="server" 
                                    Text='<%#Eval("NomineeRightPercentage") %>'></asp:Label>
                            </ItemTemplate>
                      
                        </asp:TemplateField>--%>
                     
                          
                  <asp:TemplateField>
        <ItemTemplate>
                <asp:LinkButton ID="btnEdit" ForeColor="Black" runat="server" Text="Edit" OnClick="btnEdit_Click"/>
        </ItemTemplate>
    </asp:TemplateField>
                                               
                   
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
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
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
            width: 622px;
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
        .style5
        {
            width: 622px;
        }
    </style>
</asp:Content>


