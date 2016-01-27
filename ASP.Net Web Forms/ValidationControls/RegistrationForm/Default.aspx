<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RegistrationForm.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="RegisterForm" runat="server" class="simple_form new_user_basic">
        <div>
            <div class="panel panel-primary">
                <div class="panel-heading">Register Form</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-4">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Logon Info</div>
                                <div class="panel-body">
                                    <div>
                                        <label class="control-label" for="TextBoxUserName">User name</label>
                                        <asp:TextBox runat="server" ID="TextBoxUserName" CssClass="string form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorUserName" ControlToValidate="TextBoxUserName" ErrorMessage="User name required!" ForeColor="Red" ValidationGroup="VGLogOn" Display="Dynamic" />
                                    </div>
                                    <div>
                                        <label class="control-label" for="TextBoxPassword">Password</label>
                                        <asp:TextBox runat="server" ID="TextBoxPassword" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorPasswod" ControlToValidate="TextBoxPassword" ErrorMessage="Password required!" ForeColor="Red" ValidationGroup="VGLogOn" Display="Dynamic"/>
                                    </div>
                                    <div>
                                        <label class="control-label" for="TextBoxRepeatPassword">Repeat password</label>
                                        <asp:TextBox runat="server" ID="TextBoxRepeatPassword" CssClass="form-control" TextMode="Password" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorRepeatPassword" ControlToValidate="TextBoxRepeatPassword" ErrorMessage="Repeat password required!" ForeColor="Red" ValidationGroup="VGLogOn" Display="Dynamic"/>
                                        <asp:CompareValidator runat="server" ID="CompareValidatorPassword" ControlToValidate="TextBoxPassword" ControlToCompare="TextBoxRepeatPassword" ValueToCompare="Text" ForeColor="Red" ErrorMessage="Password doesn't match!" ValidationGroup="VGLogOn" Display="Dynamic"/>
                                    </div>
                                    <br />
                                    <asp:ValidationSummary runat="server" ID="VSLI" ValidationGroup="VGLogOn"  ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                        <div class="col-sm-4">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Personal Info</div>
                                <div class="panel-body">
                                    <div>
                                        <label class="control-label" for="TextBoxFirstName">First name</label>
                                        <asp:TextBox runat="server" ID="TextBoxFirstName" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorFirstName" ControlToValidate="TextBoxFirstName" ErrorMessage="First name required!" ForeColor="Red" ValidationGroup="VGPersonal" Display="Dynamic"/>
                                    </div>

                                    <div>
                                        <label class="control-label" for="TextBoxLastName">Last name</label>
                                        <asp:TextBox runat="server" ID="TextBoxLastName" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorLastName" ControlToValidate="TextBoxLastName" ErrorMessage="Last name required!" ForeColor="Red" ValidationGroup="VGPersonal" Display="Dynamic"/>
                                    </div>
                                    <div>
                                        <label class="control-label" for="TextBoxAge">Age</label>
                                        <asp:TextBox runat="server" ID="TextBoxAge" CssClass="form-control" TextMode="Number" />
                                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidatorAge" ControlToValidate="TextBoxAge" ErrorMessage="Age is required!" ForeColor="Red" ValidationGroup="VGPersonal" Display="Dynamic" />
                                        <asp:RangeValidator runat="server" ID="RangeValidatorAge" ControlToValidate="TextBoxAge" MinimumValue="18" MaximumValue="81" Type="Integer" ErrorMessage="Valid age is between 18 and 81!" ForeColor="Red" ValidationGroup="VGPersonal" Display="Dynamic"/>
                                    </div>
                                    <br />
                                    <asp:ValidationSummary runat="server" ID="VSPresonal" ValidationGroup="VGPersonal"  ForeColor="Red"/>
                                </div>
                            </div>
                        </div>

                        <div class="col-sm-4">
                            <div class="panel panel-primary">
                                <div class="panel-heading">Address Info</div>
                                <div class="panel-body">
                                    <div>
                                        <label class="control-label" for="TextBoxEmail">Email</label>
                                        <asp:TextBox runat="server" ID="TextBoxEmail" CssClass="form-control" TextMode="Email" />
                                        <asp:RequiredFieldValidator runat="server" ID="RFVEmail" ControlToValidate="TextBoxEmail" ErrorMessage="Email required!" ForeColor="Red" ValidationGroup="VGAddress" Display="None" />
                                        <asp:RegularExpressionValidator runat="server" ID="REVEmail" ControlToValidate="TextBoxEmail" ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$" ErrorMessage="Invalid Email!" ForeColor="Red" ValidationGroup="VGAddress" Display="Dynamic"/>
                                    </div>
                                    <div>
                                        <label class="control-label" for="TextBoxLocalAddress">Local address</label>
                                        <asp:TextBox runat="server" ID="TextBoxLocalAddress" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="RFVLocalAddresss" ControlToValidate="TextBoxLocalAddress" ErrorMessage="Address requred!" ForeColor="Red" ValidationGroup="VGAddress" Display="Dynamic" />
                                    </div>
                                    <div>
                                        <label class="control-label" for="TextBoxPhone">Phone number</label>
                                        <asp:TextBox runat="server" ID="TextBoxPhone" CssClass="form-control" />
                                        <asp:RequiredFieldValidator runat="server" ID="RFVPhone" ControlToValidate="TextBoxPhone" ErrorMessage="Phone required!" ForeColor="Red" ValidationGroup="VGAddress" Display="Dynamic"/>
                                        <asp:RegularExpressionValidator runat="server" ID="REVPhone" ControlToValidate="TextBoxPhone" ValidationExpression="^[0-9\-\+]{3,15}$" ErrorMessage="Invalid phone number" ForeColor="Red" ValidationGroup="VGAddress" Display="Dynamic" />
                                    </div>
                                    <br />
                                    <asp:ValidationSummary runat="server" ID="VSAddress" ValidationGroup="VGAddress" ForeColor="Red" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-6">
                            <label class="control-label" for="RadioButtonListGender">Gender</label>
                            <asp:RadioButtonList runat="server" ID="RadioButtonListGender" OnSelectedIndexChanged="RadioButtonListGender_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="Other" Value="0" />
                                <asp:ListItem Text="Male" Value="1" />
                                <asp:ListItem Text="Female" Value="2" />
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-sm-6">
                            <asp:ScriptManager runat="server" />
                            <asp:UpdatePanel runat="server" ID="UpdatePanelGender">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="RadioButtonListGender" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <div runat="server" id="divMale" visible="false">
                                        Choose favorite cars
                                <asp:CheckBoxList runat="server" ID="CheckBoxListFavCars">
                                    <asp:ListItem Text="BMW" />
                                    <asp:ListItem Text="Toyota" />
                                    <asp:ListItem Text="Mercedes" />
                                </asp:CheckBoxList>
                                    </div>
                                    <div runat="server" id="divFemale" visible="false">
                                        Choose favorite coffee
                                <asp:DropDownList runat="server" ID="DropDowmListFavCoffee">
                                    <asp:ListItem Text="Lavazza" />
                                    <asp:ListItem Text="New Brazil" />
                                    <asp:ListItem Text="Spetema" />
                                </asp:DropDownList>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div>
                        <asp:CheckBox runat="server" ID="CheckBoxAccept" Text=" I accept " />
                        <asp:CustomValidator runat="server" ID="CVCBAccept" OnServerValidate="CVCBAccept_ServerValidate" ErrorMessage="Please accept the terms..." ForeColor="Red" />
                    </div>
                    <asp:Button  runat="server" ID="BtnCreate" OnClick="BtnCreate_Click" CssClass="btn btn-default center-block" Text="Create User" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
