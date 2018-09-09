<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="LoanDocumentChecklist.aspx.cs" Inherits="LoanDocumentChecklist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">







<center>
 <fieldset  style="width: 500px" >
  <legend>Loan Document Checklist </legend>
  <table>
  <tr>
      <th>
        Aplication No.
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
     <th>
         Document Name
      </th>
       <th>
            <asp:DropDownList ID ="drpLoanDocument" runat="Server" AutoPostBack="true"
            width="205px" Height="22px" 
                onselectedindexchanged="drpLoanDocument_SelectedIndexChanged" >
            
      
             <asp:ListItem Value="--Select--">--Select--</asp:ListItem>
            <%--<asp:ListItem Value="DEED">DEED</asp:ListItem>
            <asp:ListItem Value="KATIAN">KATIAN</asp:ListItem>
            <asp:ListItem Value="NID">NID</asp:ListItem>
            <asp:ListItem Value="NAC">NAC</asp:ListItem>
             <asp:ListItem Value="TIN">TIN</asp:ListItem>
              <asp:ListItem Value="NIL">NIL</asp:ListItem>--%>
         

           <asp:ListItem Value="Trade License (Up to date)">Trade License (Up to date)</asp:ListItem>
            <asp:ListItem Value="TIN(Up to date)">TIN(Up to date)</asp:ListItem>
            <asp:ListItem Value="Income Tax clearance certificate">Income Tax clearance certificate</asp:ListItem>
            <asp:ListItem Value="VAT">VAT</asp:ListItem>
             <asp:ListItem Value="IRC / ERC(Up to date)">IRC / ERC(Up to date)</asp:ListItem>
              <asp:ListItem Value="Enlistment certificate (in case of work /supply order finance)">Enlistment certificate (in case of work /supply order finance)</asp:ListItem>
              <asp:ListItem Value="National ID / Passport">National ID / Passport</asp:ListItem>
            <asp:ListItem Value="Memorandum of Association">Memorandum of Association</asp:ListItem>
            <asp:ListItem Value="Articles of Association">Articles of Association</asp:ListItem>
            <asp:ListItem Value="KYC form">KYC form</asp:ListItem>
             <asp:ListItem Value="Transaction profile">Transaction profile</asp:ListItem>
              <asp:ListItem Value="Board resolution">Board resolution</asp:ListItem>
              <asp:ListItem Value="BLA opinion (If required)">BLA opinion (If required)</asp:ListItem>

                  <asp:ListItem Value="CIB report(Up to date)">CIB report(Up to date)</asp:ListItem>
            <asp:ListItem Value="CRG score sheet (Up to date)">CRG score sheet (Up to date)</asp:ListItem>
            <asp:ListItem Value="Cash flow statement">Cash flow statement</asp:ListItem>
            <asp:ListItem Value="Business Net Worth statement">Business Net Worth statement</asp:ListItem>
             <asp:ListItem Value="Personal Net Worth statement">Personal Net Worth statement</asp:ListItem>
              <asp:ListItem Value="Borrower’s request letter">Borrower’s request letter</asp:ListItem>
              <asp:ListItem Value="Valuation report of branch and Bank’s enlisted surveyor">Valuation report of branch and Bank’s enlisted surveyor</asp:ListItem>
            <asp:ListItem Value="Copy of Insurance policy (for existing borrower)">Copy of Insurance policy (for existing borrower)</asp:ListItem>
            <asp:ListItem Value="Copy of BLA satisfactory certificate regarding loan documentation(for existing borrower)">Copy of BLA satisfactory certificate regarding loan documentation(for existing borrower)</asp:ListItem>
            <asp:ListItem Value="Copy of security satisfaction certificate of CAD (for existing borrower)">Copy of security satisfaction certificate of CAD (for existing borrower) </asp:ListItem>
             <asp:ListItem Value="Copy of clearance from CAD for loan disbursement (for existing borrower)">Copy of clearance from CAD for loan disbursement (for existing borrower)</asp:ListItem>
              <asp:ListItem Value="Copy of charge created on borrowing companys fixed & floating assets with the RJSC & Firms (for existing borrower)">Copy of charge created on borrowing companys fixed & floating assets with the RJSC & Firms (for existing borrower)</asp:ListItem>


              <asp:ListItem Value="Photocopy of FDR / Term deposit / WEDB / other financial instruments under lien / pledged, duly attested by the Branch Manager">Photocopy of FDR / Term deposit / WEDB / other financial instruments under lien / pledged, duly attested by the Branch Manager</asp:ListItem>
            <asp:ListItem Value="Account statement of the borrower">Account statement of the borrower</asp:ListItem>
            <asp:ListItem Value="Pro forma Invoice (PI) / Quotation.">Pro forma Invoice (PI) / Quotation. </asp:ListItem>
            <asp:ListItem Value="Permission / Clearance / NOC issued by Government / regulatory authorities.">Permission / Clearance / NOC issued by Government / regulatory authorities.   </asp:ListItem>

            <asp:ListItem Value="Others">Others</asp:ListItem>
           
           
              


          
            </asp:DropDownList>
              
         </th>

         <th>
          <asp:TextBox ID="txtDocName" runat="server" 
           width="200px"  ></asp:TextBox> 
           </th>

    </tr>
   
   <tr>
  
   <th></th>

   <th>

               <asp:Button  ID ="btnDocSave"  Text="Save" runat="Server"  Width="100px" 
                      onclick="btnDocSavee_Click" > </asp:Button>
              </th>
            
   
   </tr>

          </table>   
          </fieldset>


<center>
<p>
        <asp:GridView ID="GridView1" runat="server" 
           
            onrowdeleting="GridView1_RowDeleting" 
            
            onrowediting="GridView1_RowEditing1"   PageSize="15" Width="399px" 
            >
            <Columns>
               <%-- <asp:CommandField ShowEditButton="True" CancelText="" DeleteText="" />--%>
             <%--  OnRowCancelingEdit="GridView1_RowCancelingEdit" --%>
                <%--<asp:CommandField ShowEditButton="True" />--%>
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
          
        </asp:GridView>

    </p>



    </center>



</center>




</asp:Content>

