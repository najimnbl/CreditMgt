<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MenuAndSubMenu.aspx.cs" Inherits="MenuAndSubMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <center>
<fieldset style="width: 600px"><legend style="width: 150px">Menu & Sub Menu<asp:ScriptManager 
        ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </legend>
<table>
<tr><td><label>Menu Item:</label></td><td>
    <asp:DropDownList ID="menuItemDropDownList" runat="server" Height="25px" 
        onselectedindexchanged="menuItemDropDownList_SelectedIndexChanged" AutoPostBack="true" 
        Width="174px">
    </asp:DropDownList>
</td></tr>
</table>
<table  ><tr><td></td><td>
       
        </td><td> <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" 
                    AutoGenerateColumns="false"         
                    
                   >
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
     <%--<asp:ButtonField   Text="SingleClick" CommandName="SingleClick"  />--%>
                        <asp:TemplateField Visible="false">
                            <EditItemTemplate>
                                <asp:TextBox ID="idTextBox" runat="server" Text='<%#Eval("ID") %>' 
                                    Visible="false"></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="idLabel" runat="server" Text='<%#Eval("ID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubMenuNo" Visible="false">
                          
                            <ItemTemplate>
                                <asp:Label ID="SubMenuNoLabel" runat="server" 
                                    Text='<%#Eval("SubMenuNo") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SubMenuName">
                           
                            <ItemTemplate>
                                <asp:Label ID="SubMenuNameLabel" runat="server" 
                                    Text='<%#Eval("SubMenuName") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                       <asp:TemplateField HeaderText="MenuNo" Visible="false" >
                           
                            <ItemTemplate>
                                <asp:Label ID="MenuNoLabel" runat="server" 
                                    Text='<%#Eval("MenuNo") %>' ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                       
                    </Columns>
                   
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel></td></tr>
        <tr><td></td><td></td><td align="center"><asp:Button ID="addButton" runat="server" Text="Add" 
                    onclick="addButton_Click" /></td></tr></table>

</fieldset>
</center>
</asp:Content>

