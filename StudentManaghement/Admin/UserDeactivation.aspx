<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin_mst.Master" AutoEventWireup="true" CodeBehind="UserDeactivation.aspx.cs" Inherits="StudentManaghement.Admin.UserDeactivation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://cdn.tailwindcss.com"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:Label ID="lblMessage" runat="server"
        CssClass="block mb-4 px-4 py-2 rounded text-sm font-medium hidden"></asp:Label>


    <div class="overflow-x-auto shadow rounded-lg">

        <div class="mb-4 grid grid-cols-3 gap-4 text-center">


            <asp:Label ID="lblActive" runat="server"
                CssClass="block bg-green-100 text-green-700 py-2 rounded font-semibold">Active</asp:Label>

            <asp:Label ID="lblInactive" runat="server"
                CssClass="block bg-gray-200 text-gray-700 py-2 rounded font-semibold">InActive</asp:Label>

        </div>

        <asp:GridView
            ID="gvUsers"
            runat="server"
            AutoGenerateColumns="false"
            DataKeyNames="UserId"
            OnRowDeleting="gvUsers_RowDeleting"
            CssClass="min-w-full divide-y divide-gray-200 text-sm text-left"
            OnRowDataBound="gvUsers_RowDataBound"
            OnRowEditing="gvUsers_RowEditing"
            OnRowUpdating="gvUsers_RowUpdating"
            OnRowCancelingEdit="gvUsers_RowCancelingEdit"
            >


            <HeaderStyle CssClass="bg-gray-800 text-white text-xs uppercase tracking-wider" />
            <RowStyle CssClass="bg-white hover:bg-gray-50 transition" />
            <AlternatingRowStyle CssClass="bg-gray-50" />

            <Columns>


                <asp:BoundField DataField="UserId" HeaderText="ID"
                    ItemStyle-CssClass="px-4 py-2 font-medium text-gray-700" />

                <asp:TemplateField HeaderText="UserId">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server">
        <%# Eval("UserId") %>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lblId" runat="server"></asp:Label>
                        <%# Eval("UserId") %>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="FullName">
                    <ItemTemplate>
                        <asp:Label ID="lblFullName" runat="server">
        <%# Eval("FullName") %>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtfullname" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>



                <asp:TemplateField HeaderText="Email">

                    <ItemTemplate>
                        <asp:Label ID="lblEmail" runat="server">
                        <%# Eval("EmailId") %>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Eval("EmailId") %>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Phone">
                    <ItemTemplate>
                        <asp:Label ID="lblPhoneNo" runat="server">
                        <%# Eval("PhoneNo") %>
                        </asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemStyle CssClass="px-4 py-2" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <span class='<%# Eval("Status").ToString() == "active" 
    ? "px-2 py-1 rounded bg-green-100 text-green-700 text-xs font-semibold"
    : Eval("Status").ToString() == "inactive"
    ? "px-2 py-1 rounded bg-gray-200 text-gray-700 text-xs font-semibold"
    : "px-2 py-1 rounded bg-yellow-100 text-yellow-700 text-xs font-semibold" %>'>

                            <%# Eval("Status") %>
                        </span>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server"
                            CssClass="border rounded px-2 py-1 text-sm focus:outline-none focus:ring-2 focus:ring-blue-400">
                            <asp:ListItem Text="Active" Value="active"></asp:ListItem>
                            <asp:ListItem Text="Inactive" Value="inactive"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>

                    <ItemStyle CssClass="px-4 py-2" />
                </asp:TemplateField>


                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server"
                            CommandName="Edit"
                            CssClass="bg-blue-500 text-white px-3 py-1 rounded text-xs mr-2 hover:bg-blue-600">
                            Edit
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnDelete" runat="server"
                            CommandName="Delete"
                            CssClass="bg-red-500 text-white px-3 py-1 rounded text-xs hover:bg-red-600"
                            OnClientClick="return confirm('Are you sure you want to delete this user?');">
                            Delete
                        </asp:LinkButton>
                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:LinkButton ID="btnUpdate" runat="server"
                            CommandName="Update"
                            CssClass="bg-green-500 text-white px-3 py-1 rounded text-xs mr-2 hover:bg-green-600">
                            Update
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnCancel" runat="server"
                            CommandName="Cancel"
                            CssClass="bg-gray-500 text-white px-3 py-1 rounded text-xs hover:bg-gray-600">
                            Cancel
                        </asp:LinkButton>
                    </EditItemTemplate>

                    <ItemStyle CssClass="px-4 py-2" />
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
