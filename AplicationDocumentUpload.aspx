<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AplicationDocumentUpload.aspx.cs" Inherits="AplicationDocumentUpload" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <center>
<fieldset  style="clear: both; width: 50%">
<%--<div style="width: 420px">--%>
  
  <input id="filMyFile" runat="server" type="file"/>

    <asp:Button ID="btnUpload" Text="Upload File" runat="server" 
        onclick="btnUpload_Click" style="height: 26px"   />

          <asp:GridView ID="gvFiles" CssClass="GridViewStyle"
            AutoGenerateColumns="true" runat="server">
            <FooterStyle CssClass="GridViewFooterStyle" />
            <RowStyle CssClass="GridViewRowStyle" />    
            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
            <PagerStyle CssClass="GridViewPagerStyle" />
            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
            <HeaderStyle CssClass="GridViewHeaderStyle" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server"
                            NavigateUrl='<%# Eval("ID", "GetFile.aspx?ID={0}") %>'
                            Text="Download"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

</fieldset>

</center>

</asp:Content>

