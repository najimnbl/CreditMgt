<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="LoanComments.aspx.cs" Inherits="LoanComments" %>

<%--ValidateRequest="false" AutoEventWireup="true"--%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

 <asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

 

       
        <!-- TinyMCE -->
        <table align =center>
         <tr>
         <th style="text-align: left">
         Account No
         </th>
        <th>
          <asp:TextBox ID="txtAccount" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>
           <th>
            <asp:Button  ID ="btnSearch"  Text="Search" runat="Server"  Width="100px" 
                onclick="btnSearch_Click"  > </asp:Button>

               

             </th>
             </tr>
            
            <tr>
            <th style="text-align: left">
            Recommended Status
            </th>
            <th>
            <asp:DropDownList ID ="Rstaus" runat="Server" AutoPostBack="true"
            width="205px" Height="22px" onselectedindexchanged="Rstaus_SelectedIndexChanged">
            <asp:ListItem Value="Select">Select</asp:ListItem>
            <asp:ListItem Value="Approved">Approved</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Need Modification">Need Modification</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
           <%-- <asp:ListItem Value="Disbursement">Disbursement</asp:ListItem>--%>
            </asp:DropDownList>
              
            </th>
            </tr>
            <tr id="bankBranchRow" runat="server" visible="false">
            <th style="text-align: left">
            Disbursement Branch
            </th>
            <th>
             <asp:DropDownList ID ="drpbranch" runat="Server" 
            width="205px" Height="22px"  >
           <%-- <asp:ListItem Value="Accept">Accept</asp:ListItem>
            <asp:ListItem Value="Reject">Reject</asp:ListItem>
            <asp:ListItem Value="Forward">Forward</asp:ListItem>
            <asp:ListItem Value="Disbursement">Disbursement</asp:ListItem>--%>
            </asp:DropDownList>
            </th>
            </tr>
           <%-- <tr id="SnactionAmount" runat="server" visible="false">
            <th style="text-align: left">Sanction Amount </th>
            <th style="text-align: left">
             <asp:TextBox ID="txtSanctionAmount" runat="server" 
               width="100px" onkeypress="return validatenumber(event, this);" onblur="myFunction()" ></asp:TextBox>
               </th>
            </tr>--%>
           <tr  id="Mdate" runat="server" visible="false">
           <th style="text-align: left">Metting Date<asp:ScriptManager ID="ScriptManager1" runat="server">
               </asp:ScriptManager>
                </th>
              
          
          <th style="text-align: left">

      <asp:TextBox ID="MettingDate" runat="server" Height="20px" 
            Width="74px" />
       
               <asp:ImageButton ID="ImageButton1" ImageUrl="image/calendar.png" ImageAlign="Bottom"
        runat="server" />
    <cc1:calendarextender ID="CalendarExtender1" PopupButtonID="ImageButton1" runat="server" TargetControlID="MettingDate" Format="dd/MM/yyyy">
    </cc1:calendarextender>
        <asp:Label ID="Label1" runat="server" ForeColor="Green" Text="dd/MM/yyyy"></asp:Label>
   

        </th>
            </tr >
            <tr id="MNo" runat="server" visible="false">
            <th style="text-align: left">Metting No</th>
             
             <th style="text-align: left">
             
             <asp:TextBox ID="txtMettingNo" runat="server" 
               width="100px"  ></asp:TextBox>
     <%--         onkeypress="return validatenumber(event, this);" onblur="myFunction()"--%>
              
               </th>


            </tr>




            
            </table>
             
             

  
  <script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
    <script type="text/javascript">
        tinyMCE.init({
            // General options
            //            mode: "textareas", none
            ////
//            mode: "textareas",
//            theme: "none",
            mode: "textareas",
            theme: "advanced",
            editor_deselector: "NoEditor",
            
////            plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave",
//Customarize by FRD
// plugins: "preview",
// theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
        //End

////            setup: function (ed) {
////                ed.onKeyPress.add(
////                    function (ed, evt) {

////                    }
////                );
////            },

            // Theme options
////            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
////            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",



////            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
////            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft",
//            
////            theme_advanced_toolbar_location: "top",
////            theme_advanced_toolbar_align: "left",
////            theme_advanced_statusbar_location: "bottom",
////            theme_advanced_resizing: true,

            // Example content CSS (should be your site CSS)
////            content_css: "css/content.css",

            // Drop lists for link/image/media/template dialogs
////            template_external_list_url: "lists/template_list.js",
////            external_link_list_url: "lists/link_list.js",
////            external_image_list_url: "lists/image_list.js",
////            media_external_list_url: "lists/media_list.js",

            // Style formats
////            style_formats: [
////			{ title: 'Bold text', inline: 'b' },
////			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
////			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
////			{ title: 'Example 1', inline: 'span', classes: 'example1' },
////			{ title: 'Example 2', inline: 'span', classes: 'example2' },
////			{ title: 'Table styles' },
////			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
////		],

            // Replace values for the template plugin
////            template_replace_values: {
////                username: "Some User",
////                staffid: "991234"
////            }
        });
    </script>

    <!-- /TinyMCE -->


<body>
    <%--<form id="form1" runat="server">--%>
    <div align="center">
    <textarea id="elm1" name="elm1"  
            style="width: 89%; height: 439px; margin-right: 0px;" runat="server"  
            EnableViewState="False"    ></textarea>&nbsp;

           
           <asp:Label ID="lblDisplay" runat="server" Text="" Visible = "false" ></asp:Label>

     <table align ="center">
              
              <tr valign="top">
              <th>
              Comments
              </th>
              <th class="style1">

               <asp:TextBox ID="txtComments" runat="server"  type="text" validation="required" 
                      name="txtComments" Width="551px" textmode="MultiLine" CssClass="NoEditor" 
                      Height="62px" ></asp:TextBox>
          

              </th>
              </tr>
              <tr>
              <th></th>
              <th align "center" class="style1">
               <asp:Button  ID ="btnCommentSave"  Text="Save" runat="Server"  Width="100px" 
                      onclick="btnCommentSave_Click" > </asp:Button>
              </th>
              </tr>
             
              </table>


            <%--<asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click"  readonly="readonly" />--%>

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
    </style>
</asp:Content>

