<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditJob.aspx.cs" Inherits="BootstapADOAssigmentDay57.EditJob" %>

<%@ Import Namespace="Web.Services" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>view All jobs</title>
    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
    <link href="css/style.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container-fluid">
                <div class="row ">
                    <!-- navbar content start -->
                    <div class="col-md-12 p-0">
                        <nav class="navbar navbar-expand-lg navbar-light " style="background-color: #25ccb6;">
                            <div class="container-fluid">
                                <img src="https://www.waiin.com/wp-content/uploads/2021/07/WAi-symbol-placeholder.png" class="logo-img" style="height: 60px; width: 120px;">
                                <span>Technologies</span>
                                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                                    <span class="navbar-toggler-icon"></span>
                                </button>
                                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                                        <!--<li class="nav-item active">
                                    <a class="nav-link text-white font-weight-light">Home</a>
                                </li>-->
                                    </ul>
                                    <div class=" justify-content-end">

                                        <i class="pt-3 social-icon pb-3  text-dark   fab fa-facebook"></i>
                                        <i class="pt-3 social-icon pb-3  text-dark   fab fa-twitter"></i>
                                        <i class="pt-3 social-icon pb-3  text-dark  fab fa-instagram"></i>
                                        <i class="pt-3 social-icon pb-3  text-dark   fab fa-linkedin"></i>

                                    </div>
                                </div>
                            </div>
                        </nav>
                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <!--slide nav-->

                            <div class="col-md-2 bg-dark" style="height: 550px;">
                                <p class="dashboard">
                                    Dashboard
                                </p>
                                <ul>

                                    <a href="AddEmp.aspx">
                                        <li>Add Employee</li>
                                    </a>
                                    <a href="EditEmp.aspx">
                                        <li>Edit Employee</li>
                                    </a>
                                    <a href="DeleteEmp.aspx">
                                        <li>Delete Employee</li>
                                    </a>
                                    <a href="ViewAllEmp.aspx">
                                        <li>View All Employees</li>
                                    </a>
                                    <a href="AddJob.aspx">
                                        <li>Add JOb</li>
                                    </a>
                                    <a href="EditJob.aspx">
                                        <li>Edit JOb</li>
                                    </a>
                                    <a href="DeleteJob.aspx">
                                        <li>Delete JOb</li>
                                    </a>
                                    <a href="ViewAllJob.aspx">
                                        <li>view All JOb</li>
                                    </a>
                                </ul>
                                <p class="dashboard">
                                    LogOut
                                </p>
                            </div>
                            <!--slide nav-->
                            <!--main section-->
                            <div class="col-md-10">
                                <h4 class="p-3 text-info  bg-dark mt-4">Edit Job Record</h4>
                                <table class="table table-bordered table-striped scroll mt-3">
                                    <thead class="alert alert-warning text-center">
                                        <tr>
                                            <th>Id</th>
                                            <th>Job Title</th>
                                            <th>Number of Job Position</th>
                                            <th>Location Address</th>
                                            <th>Expected Salary Range</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <%
                                            var jobService = new JobServices();
                                            var jobs = jobService.GetAll();

                                            foreach (var job in jobs)
                                            {
                                        %>
                                        <tr>
                                            <td><%= job.Id %></td>
                                            <td><%= job.jobTitle %></td>
                                            <td><%= job.numberOfJobPosition %></td>
                                            <td><%= job.locationAddress %></td>
                                            <td><%= job.expectedSalaryRange %></td>
                                                <td><a href="jobEdit.aspx?id=<%= job.Id %>">Edit</a></td>
                                            <%-- <td><a href="empDelete.aspx?id=<%= emp.Id %>">Delete</a></td>--%>

                                        </tr>
                                        <%
                                            }
                                        %>
                                    </tbody>
                                </table>
                            </div>
                            <!--main section-->

                            <div class="col-md-12  bg-dark">
                                <p class="text-center text-white mt-3">© 2022 WAi Technologies. All rights Reserved</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

