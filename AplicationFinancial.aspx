<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AplicationFinancial.aspx.cs" Inherits="AplicationFinancial" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<script type="text/javascript">
    function validatenumber(event, obj) {
        var code = (event.which) ? event.which : event.keyCode;
        var character = String.fromCharCode(code);

        if ((code >= 48 && code <= 57)) { // check digits

            // Disallow all numbers if the entry is 0
            if (obj.value == "0")
                return false;

            if (!isNaN(obj.value)) {
                if (obj.value == "0.0" && code == 48) {
                    alert("Value cannot be less than 0.01");
                    return false;
                }
            }

            return true;
        }
        else if (code == 46) { // Check dot
            if (obj.value.indexOf(".") < 0) {
                if (obj.value.length == 0)
                    obj.value = "0";

                return true;
            }
        }
        else if (code == 8 || code == 116) { // Allow backspace, F5
            return true;
        }
        else if (code >= 37 && code <= 40) { // Allow directional arrows
            return true;
        }

                return false;

    

    }
 

</script>


<center>
    
<fieldset  style="width: 700px" >
  <legend>Loan Aplication Financial Data </legend>
    
<table cellspacing=0>
<tr>
<asp:Label ID="Label4" runat="server" Text="All data must be figure in lac" 
        style="font-weight: 700; color: #006600"></asp:Label>

</tr>
<tr class="Asad">
    <th style="text-align: left" class="style4">Aplication No</th>
    <th style="text-align: left" class="style5">
    <asp:TextBox ID="txtAplication" runat="server" 
               width="150px" ontextchanged="txtAplication_TextChanged" 
            AutoPostBack="True"   ></asp:TextBox>
             
            
    </th>


    
    <th 
       
   style="text-align: left" class="style6">SL
     <asp:TextBox ID="txtPlSL" runat="server" 
               width="30px"  
            AutoPostBack="True" onkeypress="return validatenumber(event, this);" 
            onblur="myFunction()" ontextchanged="txtPlSL_TextChanged"></asp:TextBox>

          

                </th>
                <th style="text-align: left">
                <asp:Button ID="btnSearch" runat="server" Text="search" width="53px" 
                    onclick="btnSearch_Click" />
 
    
    </th>
</tr>

<tr>
 <th style="text-align: left" class="style1">

         
         
         Type</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="DrpType" runat="Server" 
                width="150px" Height="22px" >
                <asp:ListItem Value="Fresh">Fresh</asp:ListItem>
                <asp:ListItem Value="Renewal">Renewal</asp:ListItem>
                <asp:ListItem Value="Enhancement">Enhancement</asp:ListItem>
                <asp:ListItem Value="Reduction">Reduction</asp:ListItem>
                <asp:ListItem Value="Reschedule">Reschedule</asp:ListItem>
                </asp:DropDownList>
             </th>

         <th style="text-align: left" class="style3">

         
         
         Nature</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="DropNature" runat="Server" 
                width="150px" Height="22px" >
                <asp:ListItem Value="CC">CC</asp:ListItem>
                <asp:ListItem Value="SOD">SOD</asp:ListItem>
                <asp:ListItem Value="SOD(FO)">SOD(FO)</asp:ListItem>
                
                </asp:DropDownList>
             </th>

   </tr>

   <tr class="Asad">
<th>
</th>
<th  style="text-align: left">
<asp:CheckBox ID="YrChkBox" runat="server"  Text="Is Group"   AutoPostBack="true"
        oncheckedchanged="YrChkBox_CheckedChanged"/>

   
</th>
<th></th>
</th>
<th></th>
</tr>

  <tr id="Group" runat="server" visible="false">
     <th style="text-align: left">
         Group Name
      </th>
       <th style="text-align: left">
            <asp:DropDownList ID ="drpGroup" runat="Server" AutoPostBack="true"
            width="160px" Height="22px" 
                onselectedindexchanged="drpGroup_SelectedIndexChanged">
            </asp:DropDownList>
              
         </th>

         <th class="style3">
          <asp:TextBox ID="txtGroupName" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>
           <th style="text-align: left">
           <asp:Button ID="btnGroup" runat="server" Text="Add" width="40px" onclick="btnGroup_Click" 
           />
           </th>

    </tr>

  <tr   id="SubGroup" runat="server" visible="false">
     <th style="text-align: left">
        Sub Group Name
      </th>
       <th  style="text-align: left">
            <asp:DropDownList ID ="DropSubGroup" runat="Server" AutoPostBack="true"
            width="160" Height="22px" 
                onselectedindexchanged="DropSubGroup_SelectedIndexChanged"  >
            
      

            </asp:DropDownList>
              
         </th>

         <th class="style3" >
          <asp:TextBox ID="txtSubGroupName" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>

          <th style="text-align: left">
           <asp:Button ID="btnSubGroup" runat="server" Text="Add" width="40px" onclick="btnSubGroup_Click" 
           />
           </th>
            

    </tr>

    <tr class="Asad">
    <th style="text-align: left" class="style1">Existing Limit</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtExistingLimmit" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
     </th>
    
    <th style="text-align: left" class="style1">Proposed Limit</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtProposedLimit" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
     </th>
     </tr>
    <tr>
    
    <th style="text-align: left" class="style1">Revised Limit</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtRevisedLimit" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
     </th>
    
    
    
    </tr>


    
    

    <tr  class="Asad">
   
    <th style="text-align: left" class="style1" >OutStanding</th>
   
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtOutStanding" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
   
   
   <th style="text-align: left" class="style1" >Overdue</th>
   
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtOverDeu" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
    </tr>

    <tr>
     <th style="text-align: left" class="style1" >EOL</th>
   
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtEOL" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
    </tr>

    <tr class="Asad">

    <th style="text-align: left" class="style3">Existing Saction</th>
    <th style="text-align: left">
    <asp:TextBox ID="txtExistingSanction" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


     <th style="text-align: left" class="style3">Proposed Saction</th>
    <th style="text-align: left">
    <asp:TextBox ID="txtSanctionAmount" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    </th>
</tr>

<tr>
<th style="text-align: left" class="style3">Revised Saction</th>
    <th style="text-align: left">
    <asp:TextBox ID="txtRevisedSanction" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>

</tr>





<tr  class="Asad">

    <th style="text-align: left" class="style1">Existing Tenor</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtexixtingTenor" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>

     <th style="text-align: left" class="style3"> Existing Installment</th>
    <th style="text-align: left">
    <asp:TextBox ID="txtExixtingInstallmentAmount" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    </th>
</tr>


<tr >
    <th style="text-align: left" class="style1">Proposed Tenor</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtProposedTenor" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


     <th style="text-align: left" class="style3">Proposed Installment </th>
    <th style="text-align: left">
    <asp:TextBox ID="txtProposedInstallment" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    </th>

   
</tr>







<tr class="Asad">
    <th style="text-align: left" class="style1">Revised Tenor</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtTenorRevised" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


     <th style="text-align: left" class="style3">Revised Installment </th>
    <th style="text-align: left">
    <asp:TextBox ID="txtRevisedInstallment" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    </th>

   
</tr>


<tr class="Asad">
    <th style="text-align: left" class="style1">Existing LC Comission </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtExistingLCComission" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>

     <th style="text-align: left" class="style1">Proposed LC Comission </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtProposedLCComission" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


</tr>


<tr >
    <th style="text-align: left" class="style1">LC Comission Revised</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtRevisedLCComission" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
</tr>

<tr class ="Asad">
    <th style="text-align: left" class="style1">Existing Accepted Commision </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtExistingAcceptedComission" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    
    </th>

    <th style="text-align: left" class="style1">Accepted Commision proposed </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtAcceptedCommisionProposed" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
    

</tr>


<tr>
<th style="text-align: left" class="style1">Accepted Commision Revised </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtAcceptedComissionRevised" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


</tr>


<tr class="Asad">

<th style="text-align: left" class="style1">Proposed Date</th>
    <th style="text-align: left" class="style2">
   
                <asp:TextBox ID="txtProposedDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton2" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton2" runat="server" TargetControlID="txtProposedDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label2" runat="server" ForeColor="green" Text="dd/MM/yyyy"></asp:Label>
    
    </th>





    <th style="text-align: left" class="style1">Sanction Date</th>
    <th style="text-align: left" class="style2">
   
                <asp:TextBox ID="txtSanctionDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton1" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender1" PopupButtonID="ImageButton1" runat="server" TargetControlID="txtSanctionDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label1" runat="server" ForeColor="green" Text="dd/MM/yyyy"></asp:Label>
    
    </th>
</tr>

<tr class="Asad">
    <th style="text-align: left" class="style1">Existing Intt. Rate</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtExistingInterestRate" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>

    <th style="text-align: left" class="style1">Proposed Intt. Rate</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtProposedInttRate" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


</tr>

<tr>
    <th style="text-align: left" class="style1">Revised Intereste Rate</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtRevisedInttRate" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>
</tr>





<tr class="Asad">
    <th style="text-align: left" class="style1">Existing Grace Preiod</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtExistingGracePriod" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


    <th style="text-align: left" class="style1">Proposed Grace Preiod </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtProposedGracePreiod" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>


</tr>

<tr>
<th style="text-align: left" class="style1">Revised Grace Preiod </th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtRevisedGracePreiod" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox>
    
    </th>

    <th style="text-align: left" class="style1">validity/Expiry Date</th>
    <th style="text-align: left" class="style2">
   
                <asp:TextBox ID="txtvalidityDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton3" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:CalendarExtender ID="CalendarExtender3" PopupButtonID="ImageButton3" runat="server" TargetControlID="txtvalidityDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label3" runat="server" ForeColor="green" Text="dd/MM/yyyy"></asp:Label>
    
    </th>


</tr>
<tr>
<th style="text-align: left" class="style1">

         
         
         Status</th>


            <th  style="text-align: left">
                <asp:DropDownList ID ="DropStatus" runat="Server" 
                width="100px" Height="22px" >
                <asp:ListItem Value=""></asp:ListItem>
                <asp:ListItem Value="Aproved">Aproved</asp:ListItem>
                <asp:ListItem Value="Decline">Decline</asp:ListItem>
                
                </asp:DropDownList>
             </th>

 

</tr>




<tr>
    <th style="text-align: left" class="style1">Margin</th>
    <th style="text-align: left" class="style2">
    <asp:TextBox ID="txtMargin" runat="server" 
               width="160px"  TextMode ="MultiLine" ></asp:TextBox>
    
    </th>
</tr>
<%--<tr>
<th>
</th>
<th  style="text-align: left">
<asp:CheckBox ID="YrChkBox" runat="server"  Text="Is Group"   AutoPostBack="true"
        oncheckedchanged="YrChkBox_CheckedChanged"/>

   
</th>
</tr>

  <tr id="Group" runat="server" visible="false">
     <th style="text-align: left">
         Group Name
      </th>
       <th style="text-align: left">
            <asp:DropDownList ID ="drpGroup" runat="Server" AutoPostBack="true"
            width="160px" Height="22px" 
                onselectedindexchanged="drpGroup_SelectedIndexChanged">
            </asp:DropDownList>
              
         </th>

         <th class="style3">
          <asp:TextBox ID="txtGroupName" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>
           <th style="text-align: left">
           <asp:Button ID="btnGroup" runat="server" Text="Add" width="40px" onclick="btnGroup_Click" 
           />
           </th>

    </tr>

  <tr   id="SubGroup" runat="server" visible="false">
     <th style="text-align: left">
        Sub Group Name
      </th>
       <th  style="text-align: left">
            <asp:DropDownList ID ="DropSubGroup" runat="Server" AutoPostBack="true"
            width="160" Height="22px" 
                onselectedindexchanged="DropSubGroup_SelectedIndexChanged"  >
            
      

            </asp:DropDownList>
              
         </th>

         <th class="style3" >
          <asp:TextBox ID="txtSubGroupName" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>

          <th style="text-align: left">
           <asp:Button ID="btnSubGroup" runat="server" Text="Add" width="40px" onclick="btnSubGroup_Click" 
           />
           </th>
            

    </tr>--%>

    




</table>
 </fieldset>
 <table>
 <asp:Button ID="btnSave" runat="server" Text="Save" width="100px" 
         onclick="btnSave_Click"  />
 </table>
 </center>


<style>.Asad  {
  background-color:#F4F5F4;
}

    .style1
    {
        width: 307px;
    }
    .style2
    {
        width: 171px;
    }

    .style3
    {
        width: 229px;
    }

    .style4
    {
        width: 307px;
        height: 38px;
    }
    .style5
    {
        width: 171px;
        height: 38px;
    }
    .style6
    {
        width : 175px !important;
        height: 38px;
    }

</style>
</asp:Content>

