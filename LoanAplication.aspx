<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="LoanAplication.aspx.cs" Inherits="LoanAplication" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<%@ Register Assembly = "AjaxControlToolkit" Namespace = "AjaxControlToolkit" TagPrefix = "ajax" %>

 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

   <script type="text/javascript">
       function myFunction() {
           var x = 0;
           var y = 0;
           x = document.getElementById('<%= txtAdvanchTarget.ClientID %>')
            var y = document.getElementById('<%= txtDepositTarget.ClientID %>')
//            var y = document.getElementById('<%= txtAdvanchTarget.ClientID %>')     
//             }

             var a = parseInt(x.value); 
             var b = parseInt(y.value);
//             document.getElementById('<%= txtADRTarget.ClientID %>').value = a + b;

             if (a > b) {
//                
                 document.getElementById('<%= txtADRTarget.ClientID %>').value = ((a / b).toFixed(2)).toString()+':1.00';
             }
             else {

//                 var p = (a / b).toString + ':1';
                 document.getElementById('<%= txtADRTarget.ClientID %>').value = '1.00:'+ ((b / a).toFixed(2)).toString();

   
             }


         }




         function Second() {
             var p = 0;
             var q = 0;
             p = document.getElementById('<%= txtAdvanchAchievemen.ClientID %>')
             q = document.getElementById('<%= txtDepositAchievemen.ClientID %>')
             //             }

             var m = parseInt(p.value);
             var n = parseInt(q.value);
             //             document.getElementById('<%= txtADRTarget.ClientID %>').value = a + b;

             if (m > n) {
                 //                
                 document.getElementById('<%= txtADRAchievemen.ClientID %>').value = ((m / n).toFixed(2)).toString() + ':1.00';
             }
             else {

                 //                 var p = (a / b).toString + ':1';
                 document.getElementById('<%= txtADRAchievemen.ClientID %>').value = '1.00:' + ((n / m).toFixed(2)).toString();


             }


         }

         function ModalValue() {
        
    var textBoxValue = <%= txtSubject.ClientID %>.value ;
    var sReturn = window.showModalDialog('webform2.aspx?val='+textBoxValue+'&scr=webform2.aspx');
//    var sReturn = window.showModalDialog('iframe.asp?val='+textBoxValue+'&scr=popup1.aspx&title=" & Server.UrlEncode("Enter") & "&',null, 'dialogHeight:150px;dialogWidth:450px;status:no;help:no;scroll:yes;resizable:yes;');
// 
       


         }

   function validatenumber(event, obj)
  {
    var code = (event.which) ? event.which : event.keyCode;
    var character = String.fromCharCode(code);
 
    if ((code >= 48 && code <= 57))
    { // check digits
 
      // Disallow all numbers if the entry is 0
      if (obj.value =="0")
        return false;
 
      if (!isNaN(obj.value))
      {
        if (obj.value =="0.0" && code == 48)
        {
          alert("Value cannot be less than 0.01");
          return false;
        }
      }
 
      return true;
    }
    else if (code == 46)
    { // Check dot
      if (obj.value.indexOf(".") < 0)
      {
        if (obj.value.length == 0)
         obj.value ="0";
 
        return true;
      }
    }
    else if (code == 8 || code == 116)
    { // Allow backspace, F5
      return true;
    }
    else if (code >=37 && code <= 40)
    { // Allow directional arrows
      return true;
    }
 
    return false;
  }
 
             


</script>  
       
       
        <!-- TinyMCE -->
 <center>
      
      <table style =" border:1px solid #dddddd;"  >
      <%--<table border-right:3px solid #bbb  >--%>

      
        <tr>
          <th>Branch position as on |</th>
          <th>Target(Taka in lac)|</th>
          <th class="style3"> Achievemen(Taka in lac)</th>
         </tr>
         <tr>
          <th style="text-align: left">Deposit  </th>
          <th><asp:TextBox ID="txtDepositTarget" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()"  ></asp:TextBox> </th>


              <%-- <asp:RegularExpressionValidator ID="NumericOnlyValidator" runat="server" ControlToValidate="txtDepositTarget" ErrorMessage="Enter a valid number" ValidationExpression="^\d$">
               </asp:RegularExpressionValidator>--%>

          <th class="style3"> <asp:TextBox ID="txtDepositAchievemen" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="Second()" ></asp:TextBox></th>
         </tr>


         <tr>
          <th style="text-align: left">Advance   </th>
          <th><asp:TextBox ID="txtAdvanchTarget" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()" ></asp:TextBox> </th>
          <th class="style3"> <asp:TextBox ID="txtAdvanchAchievemen" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="Second()"  ></asp:TextBox></th>
         </tr>

         <tr>
          <th style="text-align: left">ADR  
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
             </th>
          <th><asp:TextBox ID="txtADRTarget" runat="server" 
               width="100px"    ></asp:TextBox> </th>
          <th class="style3"> 
              <asp:TextBox ID="txtADRAchievemen" runat="server" 
               width="100px"   ></asp:TextBox></th>
         </tr>

         
         
         <tr>
         <th style="text-align: left">
         Clasification
         </th>
         <th>
         <asp:TextBox ID="txtClasification" runat="server" 
               width="70px" onkeypress="return validatenumber(event, this);" onblur="Second()"  ></asp:TextBox>
             (%)</th>
         
         </tr>
        
<tr>
          
         <th  style="text-align: left">
             AS On Date
          </th>
           <th>


         
      <asp:TextBox ID="AsOnDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton2" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server"  />
   
        </th>

        <th class="style3">
        
         <cc1:CalendarExtender ID="CalendarExtender2" PopupButtonID="ImageButton2" runat="server" TargetControlID="AsOnDate"
        Format="dd/MM/yyyy">
    </cc1:CalendarExtender>
        <asp:Label ID="Label2" runat="server" ForeColor="Red" Text="dd/MM/yyyy"></asp:Label>
   
        
        </th>

    </tr>




      </table>

       <table>

       <tr>
            <th style="text-align: left" class="style2">
            Name Of Customer
            </th>
            <th style="text-align: left">
             <asp:TextBox ID="txtCustomerName" runat="server"  type="text" validation="required" 
                      name="txtComments" Width="420px" 
                      Height="22px" ></asp:TextBox>
            
            </th>
         </tr>

      <tr>
            <th style="text-align: left" class="style2">
               Subject
            </th>
            <th class="style1" style="text-align: left">
             <%-- <asp:TextBox ID="txtSubject" runat="server" 
               width="347px" textmode="MultiLine" CssClass="NoEditor" ></asp:TextBox> --%>
                <asp:TextBox ID="txtSubject" runat="server"  type="text" validation="required" 
                      name="txtComments" Width="420px" textmode="MultiLine" CssClass="NoEditor" 
                      Height="42px" ></asp:TextBox>
          </th>

          <th>

          <asp:Button  ID ="txtZoom"  Text="Zoom" runat="Server"  Width="50px" 
                  onclick="txtZoom_Click" OnClientClick="ModalValue();"> </asp:Button>

          </th>

          </tr>
     

        <tr    runat="server" visible="false">
         <th class="style2">
           Classified Status 

          </th>
           <th style="text-align: left">
                <asp:DropDownList ID ="DropClissifiedStatus" runat="Server" 
                width="205px" Height="22px" >

                 <asp:ListItem Value="TR">STD</asp:ListItem>
                <asp:ListItem Value="AC">BL</asp:ListItem>
                <asp:ListItem Value="LD">DF</asp:ListItem>
                <asp:ListItem Value="TR">SMA</asp:ListItem>
                <asp:ListItem Value="TR">SS</asp:ListItem>


                </asp:DropDownList>
              
             </th>
    </tr >

        <tr runat="server" visible="false">
         <th style="text-align: left" class="style2">
         Loan Nature

          </th>
           <th style="text-align: left">
                <asp:DropDownList ID ="DropLoanNature" runat="Server" 
                width="205px" Height="22px" >

               

                <asp:ListItem Value="Fresh">Fresh</asp:ListItem>
                <asp:ListItem Value="Renewal">Renewal</asp:ListItem>
                <asp:ListItem Value="Enhancement">Enhancement</asp:ListItem>
                <asp:ListItem Value="Reduction">Reduction</asp:ListItem>
                <asp:ListItem Value="Loan Pricing">Loan Pricing</asp:ListItem>
                <asp:ListItem Value="Conditional">Conditional</asp:ListItem>
                <asp:ListItem Value="Reschedule">Reschedule</asp:ListItem>



                </asp:DropDownList>
              
             </th>
    </tr>

         <tr>
         <th style="text-align: left" class="style2">
             Loan Type
          </th>
           <th style="text-align: left">
                <asp:DropDownList ID ="drpLoanType" runat="Server" 
                width="205px" Height="22px" >
            
      
                 <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
                <asp:ListItem Value="AC">AC</asp:ListItem>
                <asp:ListItem Value="LD">LD</asp:ListItem>
                <asp:ListItem Value="TR">TR</asp:ListItem>
           
                <%--<asp:ListItem Value="NAC">NAC</asp:ListItem>
                 <asp:ListItem Value="TIN">TIN</asp:ListItem>
                  <asp:ListItem Value="NIL">NIL</asp:ListItem>--%>
              <%--   onselectedindexchanged="Rstaus_SelectedIndexChanged"--%>
          
                </asp:DropDownList>
              
             </th>
    </tr>




    <%--<tr>
         <th style="text-align: left">
             Proposed Amount
          </th>
           <th>
               <asp:TextBox ID="txtProposedAmount" runat="server" 
              width="205px" Height="20px" onkeypress="return validatenumber(event, this);"  ></asp:TextBox>
             </th>
    </tr>--%>


     




   
   <tr>
  
   <th class="style2" style="text-align: left"></th>

   <th style="text-align: left">

               <asp:Button  ID ="btnNewLoan"  Text="New Loan" runat="Server"  Width="100px" onclick="btnNewLoan_Click" 
                      > </asp:Button>
              </th>
            
   
   </tr>


            <tr>
            <th style="text-align: left" class="style2">
                Aplication No.
            </th>
            <th style="text-align: left">
              <asp:TextBox ID="txtAccount" runat="server" 
               width="200px"  ></asp:TextBox> 

               <asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                    onclick="btnSearch_Click"  > </asp:Button>

          </th>
          <th>
                <%--<asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                    onclick="btnSearch_Click"  > </asp:Button>--%>
            </th>
            </tr>
      </table>

     



  </center>
  <%--<cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" TargetControlID="txtZoom"
     BackgroundCssClass="Background" CancelControlID="btnCancel" OkControlID="btnOkay" 
            Drag="true" PopupDragHandleControlID="PopupHeader">
</cc1:ModalPopupExtender>--%>
<%--<asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" style = "display:none">
    <iframe style=" width: 350px; height: 300px;" id="irm1" src="webform2.aspx" runat="server"></iframe>
   <br/>
    <asp:Button ID="Button2" runat="server" Text="Close" />
</asp:Panel>

--%> 

        <script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options
            mode: "textareas",
            theme: "advanced",
            editor_deselector: "NoEditor",
//            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",

            plugins: "style,layer,table,preview,searchreplace,print,paste,directionality,fullscreen,noneditable",

            setup: function (ed) {
                ed.onKeyPress.add(
                    function (ed, evt) {

                    }
                );
            },
            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
//            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,undo,redo,|,insertdate,inserttime,preview,|,forecolor,backcolor",

//            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons3: "tablecontrols,|,print,|,fullscreen",

//            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
            content_css: "css/content.css",

            // Drop lists for link/image/media/template dialogs
            template_external_list_url: "lists/template_list.js",
            external_link_list_url: "lists/link_list.js",
            external_image_list_url: "lists/image_list.js",
            media_external_list_url: "lists/media_list.js",

            // Style formats
            style_formats: [
			{ title: 'Bold text', inline: 'b' },
			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
			{ title: 'Example 1', inline: 'span', classes: 'example1' },
			{ title: 'Example 2', inline: 'span', classes: 'example2' },
			{ title: 'Table styles' },
			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
		],

            // Replace values for the template plugin
            template_replace_values: {
                username: "Some User",
                staffid: "991234"
            }
        });
    </script>

    <!-- /TinyMCE -->

<body>
    <%--<form id="form1" runat="server">--%>
    <div align="center">
    <textarea id="elm1" name="elm1" 
            style="width: 94%; height: 518px; margin-right: 0px;" 
        AutoPostBack="True" runat="server" EnableViewState="False"></textarea>
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />

   </div>
    <%--</form>--%>
</body>


 </asp:Content>
 <asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 363px;
        }
        .NoEditor
        {}
        .style2
        {
            width: 145px;
        }
        .style3
        {
            width: 188px;
        }
        
         <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size:16px;
            font-style:italic;
            font-weight:bold;
        }
    </style>
    </style>
</asp:Content>


