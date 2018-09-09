<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AplicationFinancialInformation.aspx.cs" Inherits="AplicationFinancialInformation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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

             <th>  SL
       
  
     <asp:TextBox ID="txtPlSL" runat="server" 
               width="30px"  
            AutoPostBack="True" onkeypress="return validatenumber(event, this);" 
            onblur="myFunction()" ></asp:TextBox>

          

                </th>

            <th>
            <asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                onclick="btnSearch_Click"  > </asp:Button>

               

             </th>


             <th>
            <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="History" oncheckedchanged="CheckBox1_CheckedChanged" />--%>

            <asp:CheckBox ID="CheckBox1" runat="server" Text="History"  />

               

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

