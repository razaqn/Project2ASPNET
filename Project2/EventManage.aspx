<%@ Page Title="Event Management" Language="C#" MasterPageFile="~/Back.Master" AutoEventWireup="true" CodeBehind="EventManage.aspx.cs" Inherits="Project2.EventManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header">
                        <h3 class="card-title">Event Management</h3>
                    </div>
                    <div class="card-body">
                        <asp:Panel ID="pnlGrid" runat="server">
                            <asp:Button ID="btnAdd" runat="server" Text="Add New Event" CssClass="btn btn-primary mb-3" OnClick="btnAdd_Click" />
                            <asp:GridView ID="gvEvents" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" DataKeyNames="EventID" OnRowCommand="gvEvents_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="EventID" HeaderText="ID" />
                                    <asp:BoundField DataField="EventName" HeaderText="Event Name" />
                                    <asp:BoundField DataField="EventDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Location" HeaderText="Location" />
                                    <asp:BoundField DataField="Capacity" HeaderText="Capacity" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                                    <asp:TemplateField HeaderText="Actions">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-warning btn-sm" CommandName="EditEvent" CommandArgument='<%# Eval("EventID") %>'>
                                                <i class="fas fa-edit"></i> Edit
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnDelete" runat="server" CssClass="btn btn-danger btn-sm" CommandName="DeleteEvent" CommandArgument='<%# Eval("EventID") %>' OnClientClick="return confirm('Are you sure you want to delete this event?');">
                                                <i class="fas fa-trash"></i> Delete
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>

                        <asp:Panel ID="pnlForm" runat="server" Visible="false">
                            <div class="form-group">
                                <label for="txtEventName">Event Name</label>
                                <asp:TextBox ID="txtEventName" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvEventName" runat="server" ControlToValidate="txtEventName" 
                                    ErrorMessage="Event Name is required" CssClass="text-danger" ValidationGroup="EventForm" />
                            </div>
                            <div class="form-group">
                                <label for="txtDescription">Description</label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                            </div>
                            <div class="form-group">
                                <label for="txtEventDate">Event Date</label>
                                <asp:TextBox ID="txtEventDate" runat="server" CssClass="form-control" TextMode="Date" />
                                <asp:RequiredFieldValidator ID="rfvEventDate" runat="server" ControlToValidate="txtEventDate" 
                                    ErrorMessage="Event Date is required" CssClass="text-danger" ValidationGroup="EventForm" />
                            </div>
                            <div class="form-group">
                                <label for="txtLocation">Location</label>
                                <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control" />
                                <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation" 
                                    ErrorMessage="Location is required" CssClass="text-danger" ValidationGroup="EventForm" />
                            </div>
                            <div class="form-group">
                                <label for="txtCapacity">Capacity</label>
                                <asp:TextBox ID="txtCapacity" runat="server" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator ID="rfvCapacity" runat="server" ControlToValidate="txtCapacity" 
                                    ErrorMessage="Capacity is required" CssClass="text-danger" ValidationGroup="EventForm" />
                                <asp:RangeValidator ID="rvCapacity" runat="server" ControlToValidate="txtCapacity" 
                                    MinimumValue="1" MaximumValue="99999" Type="Integer"
                                    ErrorMessage="Capacity must be between 1 and 99999" CssClass="text-danger" ValidationGroup="EventForm" />
                            </div>
                            <div class="form-group">
                                <label for="txtPrice">Price</label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" />
                                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" 
                                    ErrorMessage="Price is required" CssClass="text-danger" ValidationGroup="EventForm" />
                                <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" 
                                    MinimumValue="0" MaximumValue="999999999" Type="Double"
                                    ErrorMessage="Price must be between 0 and 999999999" CssClass="text-danger" ValidationGroup="EventForm" />
                            </div>
                            <div class="form-group mt-3">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ValidationGroup="EventForm" />
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
