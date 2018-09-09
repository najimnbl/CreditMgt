<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Default.aspx.cs"
    Inherits="ASPNetFileUpDownLoad.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("Home.aspx");
    }


    //protected void btnUpload_Click(object sender, EventArgs e)
    //{

    //}



    protected void gvFiles_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Loan File Up & Download Files</title>

   <%-- <link href="Styles/Site.css" rel="stylesheet" type="text/css" />--%>
</head>
<body>
<form id="frmDefault" enctype="multipart/form-data" runat="server">
<center>
<fieldset  style="clear: both; width: 50%">
<div style="width: 420px">
  
    <div style="clear: both; width: 102%">
        <input type="file" name="fileInput" />
        <asp:Button ID="btnUpload" Text="Upload File" runat="server" 
            onclick="btnUpload_Click" />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Go Home" />
    </div>
    <div style="margin-top: 5px; clear: both">
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
    </div>
  
</div>
</fieldset>
</center>
</form>
</body>
</html>
