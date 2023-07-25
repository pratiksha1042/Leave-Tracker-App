<%@ Page Title="About" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="Leave_App.ProjectDetails" %>


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
            Project Details
             <input type="button" id="btnAddbutton"  value="Add Project Details" class="btn btn-dark"  style="float:right"/>
        </div>
        <div class="card-body" id="MainDiv" style="display: none">

            <div class="row">
                 <div class="col-sm" style="display:none">
                      
                     <asp:TextBox ID="IDtxt" runat="server" display="none"></asp:TextBox>
                     
                 </div>
                 <div class="col-sm">
                    <label class="fw-bold">Account</label>
                </div>
                <div class="col-sm">
                     <asp:TextBox ID="ClientNametxt" runat="server"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="clientNameRequired" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" Text="Please Enter Client Name" ControlToValidate="ClientNametxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                      <%-- <asp:CustomValidator ID="FirstNametxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="clientValidate"
                                        ControlToValidate="ProjectNametxt"
                                        Text="Can only contain letters"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                        </asp:CustomValidator>--%>
                </div>
               
              
          
                 <div class="col-sm">
                    <label class="fw-bold">Project Name</label>
                </div>
                <div class="col-sm">
                      
                    <asp:TextBox ID="ProjectNametxt" val="ProjectNametxt" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="ProjectNametxtRequiredFieldValidator" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ProjectNametxt" SetFocusOnError="True" Text="Please Enter Project Name"></asp:RequiredFieldValidator>
                  
                    <%-- <asp:CustomValidator ID="UserNametxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="clientValidate"
                                        ControlToValidate="ClientNametxt"
                                        Text="Please Enter FirstName_LastName"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True">

                       </asp:CustomValidator>--%>
                        
                </div>
               </div>
            <div class="row secondrow">
               
                 <div class="col-sm">
                    <label class="fw-bold">Project ID</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="ProjectIDtxt" val="ProjectIDtxt" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ProjectIDtxtRequiredFieldValidator" ForeColor="Red" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="ProjectIDtxt" SetFocusOnError="True" Text="Please Enter Project Code"></asp:RequiredFieldValidator>
                                   <%--<asp:CustomValidator ID="LastNametxtCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="clientValidate"
                                        ControlToValidate="ProjectIDtxt"
                                        Text="Can only contain letters"
                                        ForeColor="Red"
                                        SetFocusOnError="True" ValidateEmptyText="True"></asp:CustomValidator>--%>
                </div>
                <div class="col-sm">
                    <label class="fw-bold">Monthly Leaves</label>
                </div>
                <div class="col-sm">
                    <asp:TextBox ID="MontlyLeavestxt" val="MontlyLeavestxt" runat="server" ></asp:TextBox>
                  <asp:RequiredFieldValidator ID="MontlyLeavesRequired" runat="server" ForeColor="Red" ErrorMessage="RequiredFieldValidator" Text="Please enter Monthly Leaves" ControlToValidate="MontlyLeavestxt" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <%-- <asp:CustomValidator ID="MontlyLeavesCustomValidator"
                                        runat="server"
                                        ErrorMessage="CustomValidator"
                                        ClientValidationFunction="MontlyLeavestxtValidate"
                                        ControlToValidate="MontlyLeavestxt"
                                        ForeColor="Red"
                                        Text="Please Enter Organization Email ID"
                                        SetFocusOnError="True" ValidateEmptyText="True"></asp:CustomValidator>
                     </div>--%>
                </div>
              
            </div>
            <div class="row secondrow">
                <div class="row justify-content-end" id="AddbtnDiv">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="AddButton" class="btn btn-dark" runat="server" Text="Submit" Style="margin: 2px"  OnClick="AddButton_Click" />
                        <input type="button" id="btnCancel"  value="Cancel" style="margin: 2px" class="btn btn-dark" onclick="cancelClick()" />

                    </div>
                </div>
                <div class="row justify-content-end" id="UpdatebtnDiv" style="display: none;">
                    <div class="form-group col-sm-2">
                        <asp:Button ID="UpdateButton" runat="server" class="btn btn-dark" Text="Update" Style="margin: 2px" OnClick="UpdateButton_Click"  />
                        <asp:Button ID="Cancelbtn" runat="server" class="btn btn-dark" Text="Cancel" Style="margin: 2px" onclick="Cancelbtn_Click" />
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
                        <th>Account</th>
                        <th>Project Name</th>
                        <th>Project ID</th>
                        <th>Monthly Leaves</th>
                        <th>Action</th>
                    </tr>
                </thead>
            </table>
        </div>
      </div>

        <script type="text/javascript">
            $(function () {
                var dataString = '<%= ProjectListString %>';
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
                    // "dom": '<"pull-left"f><"pull-right"l>tip',
                    "dom": 'Bfrtip',
                    "data": data,
                    "columns": columns,
                    "bPaginate": true,
                    "searching": true,
                    "bSort": true,
                    'pageLength': 10,
                    'lengthMenu': [[10, 20, 25, 50, -1], [10, 20, 25, 50, 'All']],
                    /* order: [4, 'desc'],*/
                    columns: [
                        {
                            data: 'ClientName',
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
                            data: 'ProjectID',
                            render: function (data, type, row) {
                                return data;
                            },
                        },
                        
                        {
                            data: 'MonthlyLeaves',
                            render: function (data, type, row) {
                                return data;
                            },
                        },
                        {
                            data: 'ID',
                            render: function (data, type, row) {
                                return '<input type="button" class="btn btn-secondary pencil-square btn-rounded btn-sm my-0"  onclick="ShowData(' + data + ')" value="Edit"></input> ' +
                                    '<input type="button" class="btn btn-danger btn-rounded btn-sm my-0" id = "deleteButton" onclick = "DeleteRow(' + data + ')" value="Delete"> </input> ' ;
                            },

                        }

                    ],


                });


              //  $('#example_length')[0].childNodes[0].removeChild($('#example_length')[0].childNodes[0].childNodes[2]);
            }


            // Edit record 
            function ShowData(data) {
                if (confirm("Are You sure to Update this record?")) {
                    var obj = {};
                    obj.ID = data;


                    $.ajax({
                        type: "POST",
                        url: "ProjectDetails.aspx/ShowData",
                        data: JSON.stringify(obj),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {
                            if (response.d.length > 0) {
                                var result = JSON.parse(response.d)
                                result = result[0];
                                $('#MainContent_IDtxt').val(result.ID);
                                $('#MainContent_ProjectNametxt').val(result.ProjectName);
                                $('#MainContent_ProjectIDtxt').val(result.ProjectID);
                                $('#MainContent_ClientNametxt').val(result.ClientName);
                                $('#MainContent_MontlyLeavestxt').val(result.MonthlyLeaves);

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
                if (confirm("Are You sure to Delete this record?")) {
                    var obj = {};
                    obj.ID = data;


                    $.ajax({
                        type: "POST",
                        url: "ProjectDetails.aspx/DeleteData",
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
            //Changing the css of add Button
           

            //Changing the css if update Button
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

            // Cancel function is For Add button
            function cancelClick() {
                $('#MainContent_IDTextBox').val();
                $('#MainContent_ProjectNametxt').val('');
                $('#MainContent_ProjectIDtxt').val('');
                $('#MainContent_ClientNametxt').val('');
                $('#MainContent_MontlyLeavestxt').val('');


                $('#MainDiv').css('display', 'none');
                $('#btnAdd').css('display', 'flex');
            }

        </script>


</asp:Content>


