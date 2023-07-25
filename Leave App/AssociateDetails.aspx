<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="AssociateDetails.aspx.cs" Inherits="Leave_App.AssociateDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card {
            /*width: 77rem !important;*/
            margin-top: 10px !important;
            
        }
        .card {
             margin-top: 10px !important;
        }
        #example {
            margin-top: 30px !important;
        }

        .secondrow {
            margin-top: 10px !important;
        }
    </style>

    <div class="card">
        <div class="card-header" id="btnAdd">
            Associate Details
             <input type="button" id="btnAddbutton" <%--id="btnAdd"--%> value="Add Associate Details" class="btn btn-dark"  style="float:right"/>
        </div>
        <div class="card-body" id="MainDiv" style="display: none">

            <div class="row">
                <div class="col-sm" style="display:none">
                     <asp:TextBox ID="IDtxt" runat="server" display="none"></asp:TextBox>
                 </div>
                
               
                <div class="col-sm">
                    <label class="fw-bold">First Name</label>
                    
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="FirstNametxt" val="FirstNametxt" runat="server"></asp:TextBox>
                    <asp:requiredfieldvalidator id="firstnametxtrequiredfieldvalidator" forecolor="red" runat="server" errormessage="requiredfieldvalidator" controltovalidate="firstnametxt" setfocusonerror="true" text="please enter first name"></asp:requiredfieldvalidator>
                   <%-- <asp:customvalidator id="firstnametxtcustomvalidator"
                                        runat="server"
                                        errormessage="customvalidator"
                                        clientvalidationfunction="clientvalidate"
                                        controltovalidate="firstnametxt"
                                        text="can only contain letters"
                                        forecolor="red"
                                        setfocusonerror="true" validateemptytext="true">

                    </asp:customvalidator>--%>
                </div>
                <div class="col-sm">
                    <label class="fw-bold">Last Name</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="LastNametxt" val="LastNametxt" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="LastNametxtRequiredFieldValidator" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="LastNametxt" SetFocusOnError="True" Text="Please enter Last name"></asp:RequiredFieldValidator>
                    <%-- <asp:CustomValidator ID="LastNametxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="clientValidate"
                                        ControlToValidate="LastNametxt"
                                        Text="Can only contain letters"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                     </asp:CustomValidator>--%>
                </div>
                <div class="col-sm">
                    <label class="fw-bold">User Name</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="UserNametxt" val="UserNametxt" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="clientNameRequired" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" Text="Please enter User name" ControlToValidate="UserNametxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     <%--<asp:CustomValidator ID="UserNametxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="UserNameValidate"
                                        ControlToValidate="UserNametxt"
                                        Text="Please Enter FirstName_LastName"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                     </asp:CustomValidator>--%>
                </div>
            </div>
            <div class="row secondrow">
                <div class="col-sm">
                    <label class="fw-bold">Project Name</label>
                </div>
                <div class="col-sm">
                     <asp:DropDownList ID="ProjectIDDropDownList" CssClass="btn btn-dark" runat="server"></asp:DropDownList>
                     <asp:requiredfieldvalidator id="requiredfieldvalidator3" runat="server" errormessage="requiredfieldvalidator" controltovalidate="projectiddropdownlist" setfocusonerror="true" text="Please enter project name" forecolor="red"></asp:requiredfieldvalidator>
            
                </div>
                <div class="col-sm">
                    <label class="fw-bold">Email ID</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="EmailIDtxt" val="EmailIDtxt" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ForeColor="Red" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="EmailIDtxt" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>
                     <asp:RequiredFieldValidator ID="EmailIDRequired" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" Text="Please enter Email ID" ControlToValidate="EmailIDtxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <%-- <asp:CustomValidator ID="EmailIDtxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="EmailIDValidate"
                                        ControlToValidate="EmailIDtxt"
                                        ForeColor="Red"
                                        Text="Please Enter Organization Email ID"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                     </asp:CustomValidator>--%>
                </div>
                <div class="col-sm">
                    <label class="fw-bold">Contact No.</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="Phonetxt" val="Phonetxt" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ControlToValidate="Phonetxt" ErrorMessage="Invalid Contact" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>  
                   <asp:RequiredFieldValidator ID="PhonetxtRequiredFieldValidator" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" Text="Please enter Contact number" ControlToValidate="Phonetxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <%--<asp:CustomValidator ID="PhonetxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="ContactValidate"
                                        ControlToValidate="Phonetxt"
                                        Text="Please Enter 10 digit contact number"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                      </asp:CustomValidator>
                  --%>
                </div>
               
            </div>
            <div class="row secondrow">
                <div class="row justify-content-end" id="AddbtnDiv">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="AddButton" class="btn btn-dark" runat="server" Text="Submit" Style="margin: 2px" OnClick="AddButton_Click"/>
                        <input type="button" id="btnCancel"  value="Cancel" style="margin: 2px" class="btn btn-dark" onclick="cancelClick()"/>

                    </div>
                </div>
                <div class="row justify-content-end" id="UpdatebtnDiv" style="display: none;">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="UpdateButton" runat="server" class="btn btn-dark" Text="Update" Style="margin: 2px" OnClick="UpdateButton_Click" />
                        <asp:Button ID="Cancelbtn" runat="server" class="btn btn-dark" Text="Cancel" Style="margin: 2px" OnClick="Cancelbtn_Click"  />
                    </div>
                </div>
            </div>
        </div>
     </div>
   

    <div class="card">
        
        <div class="card-body">

            <table id="example" class="table table-striped table-bordered" style="width: 100%">
                <thead>
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>User Name</th>
                        <th>Email ID</th>
                        <th>Phone</th>
                        <th>Project Name</th>
                        <th>Action</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var dataString = '<%= AssociateListString %>';
            var jsonData = JSON.parse(dataString);
            bindDataTable(jsonData);
        })

        function bindDataTable(data) {

            var columnNames = Object.keys(data[0]);
            var columns = [
            ];
            for (var i in columnNames) {
                columns.push({
                    data: columnNames[i],
                    title: columnNames[i]
                });
            }
            $('#example').DataTable({
                //"dom": '<"pull-left"f><"pull-right"l>tip',
                "dom": 'Bfrtip',
                "data": data,
                "columns": columns,
                "bPaginate": true,
                "searching": true,
                "bSort": true,
                'pageLength': 10,
                'lengthMenu': [[10, 20, 25, 50, -1], [10, 20, 25, 50, 'All']],
                order: [[5, 'desc']],
                columns: [

                    {
                        data: 'FirstName',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'LastName',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'UserName',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'EmailID',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                   
                    {
                        data: 'Phone',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'ProjectName',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'ID',
                        //className: "dt-center editor-edit",
                        //defaultContent: '<i class="fa fa-pencil"/>',
                        //orderable: false,

                        render: function (data, type, row) {
                            return '<input type="button" class="btn btn-secondary pencil-square btn-rounded btn-sm my-0"  onclick="ShowData(' + data + ')" value="Edit"></input> ' +
                                '<input type="button" class="btn btn-danger btn-rounded btn-trash btn-sm my-0" id = "deleteButton" onclick = "DeleteRow(' + data + ')" value="Delete"> </input> ';
                        },
                    }
                ],
            });
            // Edit record 
            $('#example_length')[0].childNodes[0].removeChild($('#example_length')[0].childNodes[0].childNodes[2]);
        }

        function ShowData(data) {
            if (confirm("Are You sure to Update this record?")) {
                var obj = {};
                obj.ID = data;


                $.ajax({
                    type: "POST",
                    url: "AssociateDetails.aspx/ShowData",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d.length > 0) {
                            var result = JSON.parse(response.d)
                            result = result[0];
                            $('#MainContent_IDtxt').val(result.ID);
                            $('#MainContent_FirstNametxt').val(result.FirstName);
                            $('#MainContent_LastNametxt').val(result.LastName);
                            $('#MainContent_UserNametxt').val(result.UserName);
                            $('#MainContent_EmailIDtxt').val(result.EmailID);
                            $('#MainContent_Phonetxt').val(result.Phone);
                            //$("input: text").val(result.projectID);
                            $('#MainContent_ProjectIDDropDownList').val(parseInt(result.ProjectID));

                            //$("#MainContent_ProjectNametxt").prop("readonly", true);
                            //$("#MainContent_ProjectIDtxt").prop("readonly", true);
                            //$("#MainContent_MontlyLeavestxt").prop("readonly", true);



                            showUpdate();
                            $('#btnAddbutton').click();
                        }
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }
        }
        function showUpdate() {
            $('#AddbtnDiv').css("display", "none");
            $('#UpdatebtnDiv').css("display", "flex");
            $([document.documentElement, document.body]).animate({
                scrollTop: $("#MainDiv").offset().top
            }, 20);
        }
        function showAdd() {
            $('#AddbtnDiv').css("display", "block");
            $('#UpdatebtnDiv').css("display", "none");
            $([document.documentElement, document.body]).animate({
                scrollTop: $("#MainDiv").offset().top
            }, 20);
        }


        $('#btnAddbutton').click(function () {
            $('#MainDiv').css('display', 'block');
            $('#btnAdd').css('display', 'none');
        })

        //delete Function
        function DeleteRow(data) {
            if (confirm("Are You sure to delete this record..?")) {
                var obj = {};
                obj.ID = data;


                $.ajax({
                    type: "POST",
                    url: "AssociateDetails.aspx/DeleteData",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        alert('Records deleted successfully')
                        location.reload();
                    },
                    error: function (response) {
                        alert(response.d);
                    }
                });
            }

           

        // Cancel function is For Add button
        function cancelClick() {
            $('#MainContent_IDtxt').val();
            $('#MainContent_FirstNametxt').val('');
            $('#MainContent_LastNametxt').val('');
            $('#MainContent_UserNametxt').val('');
            $('#MainContent_ProjectIDDropDownList').val(0);
            $('#MainContent_EmailIDtxt').val('');
            $('#MainContent_Phonetxt').val('');
            $('#MainContent_Addresstxt').val('');


            $('#MainDiv').css('display', 'none');
            $('#btnAdd').css('display', 'flex');
            }
            //Changing the css if update Button
            


        }
    </script>
</asp:Content>
