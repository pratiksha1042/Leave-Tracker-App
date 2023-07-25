<%@ Page Title="Contact" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="LeaveDetails.aspx.cs" Inherits="Leave_App.LeaveDetails" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <style>
        .card {
            /*width: 77rem !important;*/
            margin-top: 10px !important;
        }

        #example {
            margin-top: 10px !important;
        }

        .secondrow {
            margin-top: 10px !important;
        }
    </style>

    <div class="card">
        <div class="card-header" id="btnAdd">
            Leave Details
             <input type="button" id="btnAddbutton"  value="Add Leavee Details" class="btn btn-dark"  style="float:right"/>
        </div>
        <div class="card-body" id="MainDiv" style="display: none">

            <div class="row">
                <div class="col-sm" style="display:none">
                     <asp:TextBox ID="IDTextBox" runat="server"></asp:TextBox>
                 </div>
                <div class="col-sm">
                    <label class="fw-bold">Username</label>
                </div>
                <div class="col-sm" >
                    <asp:DropDownList ID="AssociateIDDropDownList" CssClass="btn btn-dark" runat="server" ></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="AssociateIDDropDownListRequiredFieldValidator" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="AssociateIDDropDownList" SetFocusOnError="True" Text="please enter User name" ForeColor="Red"></asp:RequiredFieldValidator>
                 </div>
               <%-- <div class="col-sm">
                    <label class="fw-bold">Project Name</label>
                </div>
                <div class="col-sm">
                     <asp:DropDownList ID="ProjectIDDropDownList" CssClass="btn btn-info" runat="server"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ProjectIDDropDownList" SetFocusOnError="True" Text="please enter project name" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>--%>
                <div class="col-sm">
                    <label class="fw-bold">Description</label>
                </div>
                <div class="col-sm">
                   <asp:TextBox ID="Descriptiontxt" runat="server" CssClass="form-control"> </asp:TextBox>
                    <asp:RequiredFieldValidator ForeColor="Red" ID="DescriptionRequired" runat="server" ErrorMessage="RequiredFieldValidator" Text="Please enter description" ControlToValidate="Descriptiontxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row secondrow">
                <div class="col-sm">
                    <label class="fw-bold">Start Date</label>
                </div>
                <div class="col-sm">
                   <asp:TextBox ID="StartDatetxt"
                                            runat="server"
                                            Width="155px"
                                            AutoPostBack="False"
                                            TabIndex="1"
                                            placeholder="dd/mm/yyyy"
                                            autocomplete="off"
                                            CssClass="form-control"
                                            MaxLength="10">
                     </asp:TextBox>
                  <asp:RequiredFieldValidator ForeColor="Red" ID="StartDateRequired" runat="server" ErrorMessage="RequiredFieldValidator" Text="Please enter start date" ControlToValidate="StartDatetxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                       
                </div>
                <div class="col-sm">
                    <label class="fw-bold">End Date</label>
                </div>
                <div class="col-sm">
                     <asp:TextBox ID="EndDatetxt"
                                            runat="server"
                                            Width="135px"
                                            AutoPostBack="False"
                                            TabIndex="1"
                                            placeholder="dd/mm/yyyy"
                                            autocomplete="off"
                                            CssClass="form-control"
                                            MaxLength="10">

                     </asp:TextBox>
                     <asp:RequiredFieldValidator ForeColor="Red" ID="EndDatetxtRequired" runat="server" ErrorMessage="RequiredFieldValidator" Text="Please enter end date" ControlToValidate="EndDatetxt" SetFocusOnError="True"></asp:RequiredFieldValidator>

                </div>
                
            </div>
            <div class="row secondrow">
                <div class="row justify-content-end" id="AddbtnDiv">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="AddButton" class="btn btn-dark" runat="server" Text="Submit" Style="margin: 2px" OnClick="AddButton_Click" />
                        <input type="button" id="btnCancel"  value="Cancel" style="margin: 2px" class="btn btn-dark" onclick="cancelClick()" />

                    </div>
                </div>
                <div class="row justify-content-end" id="UpdatebtnDiv" style="display: none;">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="UpdateButton" runat="server" class="btn btn-dark" Text="Update" Style="margin: 2px" OnClick="UpdateButton_Click" />
                        <asp:Button ID="Cancelbtn" runat="server" class="btn btn-dark" Text="Cancel" Style="margin: 2px" OnClick="Cancelbtn_Click" />
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
                        <th>User Name</th>
                        <%--<th>Project Name</th>--%>
                        <th>Description</th>
                        <th>Start Date</th>
                        <th>End Date</th>
                        
                        <th>Action</th>
                    </tr>
                </thead>
            </table>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            var dataString = '<%= LeaveListString %>';
            var jsonData = JSON.parse(dataString);
           

            $("#MainContent_StartDatetxt").datepicker({
                dateFormat: 'd/m/yy',
                changeMonth: true,
                changeYear: true,
                minDate: 0,
                yearRange: "2023:2100",
                onSelect: function (selected) {
                    $("#MainContent_EndDatetxt").datepicker("option", "minDate", selected)
                }
            }
            );
            $('#MainContent_EndDatetxt').datepicker({
                dateFormat: 'd/m/yy',
                changeMonth: true,
                changeYear: true,
                minDate: 0,
                yearRange: "2023:2100",
                onSelect: function (selected) {
                   // $("#MainContent_StartDatetxt").datepicker("option", "minDate", selected)
                }
            }
            );
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
                //order: [[9, 'desc']],
                columns: [
                    {
                        data: 'UserName', 
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    //{
                    //    data: 'ProjectName',
                    //    render: function (data, type, row) {
                    //        return data;
                    //    },
                    //},
                    {
                        data: 'Description',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'StartDate',
                        render: function (data, type, row) {
                            return data;
                        },
                    },
                    {
                        data: 'EndDate',
                        render: function (data, type, row) {
                            return data;
                        },
                    },

                    {
                        data: 'ID',
                        render: function (data, type, row) {
                            return '<input type="button" class="btn btn-secondary pencil-square btn-rounded btn-sm my-0"  onclick="ShowData(' + data + ')" value="Edit"></input> ' +
                                '<input type="button" class="btn btn-danger btn-rounded btn-sm my-0" id = "deleteButton" onclick = "DeleteRow(' + data + ')" value="Delete"> </input> ';
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
                    url: "LeaveDetails.aspx/ShowData",
                    data: JSON.stringify(obj),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        if (response.d.length > 0) {
                            var result = JSON.parse(response.d)
                            result = result[0];
                            $('#MainContent_IDTextBox').val(result.ID);
                            $('#MainContent_AssociateIDDropDownList').val(parseInt(result.UserName));
                            //$('#MainContent_ProjectIDDropDownList').val(result.projectID);
                            //$('#MainContent_StartDatetxt').val(result.StartDate);
                            //$('#MainContent_EndDatetxt').val(result.EndDate);
                            $('#MainContent_Descriptiontxt').val(result.Description);
                            $('#MainContent_StartDatetxt').datepicker("setDate", result.StartDate);
                            $('#MainContent_EndDatetxt').datepicker("setDate", result.EndDate);

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


        


        //delete Function
        function DeleteRow(data) {
            if (confirm("Are You sure to delete this record..?")) {
                var obj = {};
                obj.ID = data;


                $.ajax({
                    type: "POST",
                    url: "LeaveDetails.aspx/DeleteData",
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

        function cancelClick() {
            $('#MainContent_IDTextBox').val();
            $('#MainContent_AssociateIDDropDownList').val(0);
            $('#MainContent_ProjectIDDropDownList').val(0);
            $('#MainContent_Descriptiontxt').val('');
            $('#MainContent_StartDatetxt').val('');
            $('#MainContent_EndDatetxt').val('');

            $('#MainDiv').css('display', 'none');
            $('#btnAdd').css('display', 'flex');
        }

    </script>

</asp:Content>
