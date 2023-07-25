<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/NewMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Leave_App.Dashboard" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.13.4/js/dataTables.bootstrap4.min.js"></script>

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
  



       <%-- <h2 id="title"><%: Title %></h2>--%>

        <asp:Table ID="Table1" runat="server"></asp:Table>

         <asp:DropDownList CssClass="btn btn-dark" runat="server" ID="ClientNameDropDownList">

            <%--<asp:ListItem    Text="Account 1" Value="Account 1"></asp:ListItem>
            <asp:ListItem    Text="Account 2" Value="Account 2"></asp:ListItem>
            <asp:ListItem   Text="Account 3" Value="Account 3"></asp:ListItem>--%>

        </asp:DropDownList>

        <asp:DropDownList CssClass="btn btn-dark" runat="server" ID="YearDropdown">

            <asp:ListItem    Text="2022" Value="2022"></asp:ListItem>
            <asp:ListItem    Text="2023" Value="2023"></asp:ListItem>
            <asp:ListItem    Text="2024" Value="2024"></asp:ListItem>
            <asp:ListItem    Text="2025" Value="2025"></asp:ListItem>

        </asp:DropDownList>

        <asp:DropDownList CssClass="btn btn-dark" runat="server" ID="Quarter_Dropdown">

            <asp:ListItem Text="Quarter 1" Value="Q1"></asp:ListItem>
            <asp:ListItem Text="Quarter 2" Value="Q2"></asp:ListItem>
            <asp:ListItem Text="Quarter 3" Value="Q3"></asp:ListItem>
            <asp:ListItem Text="Quarter 4" Value="Q4"></asp:ListItem>

        </asp:DropDownList>




        <br />
        <br />

        <div id="tblDashboard">
        </div>

     <div class="card">
        <div class="card-body">
            <table id="example" class="table table-striped table-bordered" style="width: 100%">
                <thead>
                    <tr>
                        <th>Client Name</th>
                        <th>UserName</th>
                        <th>Project Name</th>
                        <th>Jan</th>
                        <th>Feb</th>
                        <th>Mar</th>
                        <th>Apr</th>
                        <th>May</th>
                        <th>Jun</th>
                        <th>Jul</th>
                        <th>Aug</th>
                        <th>Sep</th>
                        <th>Oct</th>
                        <th>Nov</th>
                        <th>Dec</th>
                        <th>Allowed Leaves</th>
                        <th>Total Leaves Taken</th>
                        <th>Total Leaves Taken</th>
                        <th>Total Leaves Taken</th>
                        <th>Total Leaves Taken</th>
                        <th>Adjustment Leaves</th>
                        <th>Adjustment Leaves</th>
                        <th>Adjustment Leaves</th>
                        <th>Adjustment Leaves</th>
                    </tr>
                </thead>

            </table>
        </div>
         </div>
   
    <script type="text/javascript">
        $(function () {
            //var dataString = "<%= dashboardModelList %>";
            var dataString = '<%= dashboardModelList %>';
            var jsonData = JSON.parse(dataString);
            bindDataTable(jsonData);
            onLoadFirstQuarter();
        })
        var columns = [];


        $(document).on('change', '#MainContent_YearDropdown', function () {
            var YearInputhropdown = $('#MainContent_YearDropdown').val();
            var clientDropdown = $('#MainContent_ClientNameDropDownList').val();

            var returnData = JQueryCall(clientDropdown,parseInt(YearInputhropdown));  
        });
        $(document).on('change', '#MainContent_ClientNameDropDownList', function () {
            var YearInputhropdown = $('#MainContent_YearDropdown').val();
            var clientDropdown = $('#MainContent_ClientNameDropDownList').val();

            var returnData = JQueryCall(clientDropdown, parseInt(YearInputhropdown));
        });


        $(document).on('change', '#MainContent_Quarter_Dropdown', function () {  
            var Quarter_Dropdown = $('#MainContent_Quarter_Dropdown').val(); 
            QuarterDropdownChange(Quarter_Dropdown); 
        });




        function QuarterDropdownChange(Quarter_Dropdown) {
            var table = $('#example').DataTable();
            var columnCount = table.columns().nodes().length;
            //Visible all columns
            for (var i = 0; i < columnCount; i++) {
                table.column(i).visible(true);
            }
            // visible onyl respective Quarter
            if (Quarter_Dropdown == 'Q1') {

                for (var i = 0; i < columnCount; i++) {
                    if (i > 6) {
                        if (i != 16 && i != 20) {
                            table.column(i).visible(false);
                        }
                    }
                }
            }
            if (Quarter_Dropdown == 'Q2') {
                var columnCount = table.columns().nodes().length;
                for (var i = 0; i < columnCount; i++) {
                    if (i> 3 && i < 7) {
                        table.column(i).visible(false);
                    }
                    if (i > 9) {
                        if (i != 17 && i != 21) {
                            table.column(i).visible(false);
                        }
                    }
                }
            }
            if (Quarter_Dropdown == 'Q3') {
                var columnCount = table.columns().nodes().length;
                for (var i = 0; i < columnCount; i++) {
                    if (i > 3 && i < 10) {
                        table.column(i).visible(false);
                    }
                    if (i > 12) {
                        if (i != 18 && i != 22 ) {
                            table.column(i).visible(false);
                        }
                    }
                }
            }
            if (Quarter_Dropdown == 'Q4') {
                var columnCount = table.columns().nodes().length;
                for (var i = 0; i < columnCount; i++) {
                    if (i > 3 && i < 13) {
                        table.column(i).visible(false);
                    }
                    if (i > 15) {
                        if (i != 19 && i != 23) {
                            table.column(i).visible(false);
                        }
                    }
                }
            }
        }



        function JQueryCall(projectID, data) {
            //var ID = parseInt(projectID);
            var obj = {};
            obj.projectID = parseInt(projectID);
            obj.years = data;



            $.ajax({
                type: "POST",
                url: "Dashboard.aspx/GetAllData",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response.d.length > 0) {
                        var result = JSON.parse(response.d);
                        $('#example').DataTable().destroy();

                        $('#MainContent_Quarter_Dropdown').val("Q1");
                        bindDataTable(result);
                        onLoadFirstQuarter(); 
                    }
                },
                error: function (response) {
                    alert(response.d);
                }
            });
        }

        function bindDataTable(data) {
            CreateColumns(data);
            $('#example').DataTable({

                //"columns": columns,
                "dom": '<"pull-left"f><"pull-right"l>tip',

                "data": data,
                "columns": columns,
                "bPaginate": true,
                "searching": true,
                "bSort": true,
                'pageLength': 10,
                'lengthMenu': [[10, 20, 25, 50, -1], [10, 20, 25, 50, 'All']],
                "language": {
                    "emptyTable": "No data available in table"
                }
            });
            $('#example_length')[0].childNodes[0].removeChild($('#example_length')[0].childNodes[0].childNodes[2]);
        }


        function onLoadFirstQuarter() {
            var Quarter_Dropdown = $('#MainContent_Quarter_Dropdown').val();
            var table = $('#example').DataTable();
            if (Quarter_Dropdown == 'Q1') {
                var columnCount = table.columns().nodes().length;
                for (var i = 0; i < columnCount; i++) {
                    if (i > 6) {
                        if (i != 16 && i != 20 ) {
                            table.column(i).visible(false);
                        }
                    }
                }
            }
        }



        function CreateColumns(data) {
            if (data.length > 0) {
                var columnNames = Object.keys(data[0]);
                if (columns.length == 0) {
                    for (var i in columnNames) {
                        columns.push({
                            data: columnNames[i],
                            title: columnNames[i]
                        });
                    }
                }
            }
        }



    </script>

</asp:Content>
