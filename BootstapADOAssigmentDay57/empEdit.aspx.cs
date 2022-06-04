using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Services;
using Web.Services.Models;
using Web.Services.Utilities;

namespace BootstapADOAssigmentDay57
{
    public partial class empEdit : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            ShowDataToUpdate();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var empService = new EmployeeServices();

            try
            {
                var idText = Request.QueryString["id"];

                var emp = new Employee();
                emp.Id = int.Parse(idText);
                emp.empNumber = int.Parse(TextBoxEmployeeNumber.Text);
                emp.empName = TextBoxEmployeeName.Text;
                emp.empGender = RadioButtonGender.SelectedValue;
                emp.empAddress = TextBoxAddress.Text;
                emp.empDepartment = TextBoxDepartment.Text;
                emp.empPosition = TextBoxPosition.Text;
                emp.empDOJ = (DateTime)(string.IsNullOrEmpty(TextBoxDoj.Text) ? (DateTime?)null : DateTime.Parse(TextBoxDoj.Text));
                emp.empEmail = TextBoxEmail.Text;

               

                empService.Update(emp);

                LabelStatus.ShowStatusMessage("User record successfully updated!");
            }
            catch (Exception exception)
            {
                Debug.Print(exception.StackTrace);
                LabelStatus.ShowStatusMessage("Failed to update User record!");
            }
        }

        private void ShowDataToUpdate()
        {
            var idText = Request.QueryString["id"];
            try
            {
                var id = int.Parse(idText);

                var empService = new EmployeeServices();

                var emp = empService.GetById(id);

                if (emp == null)
                {
                    LabelStatus.ShowStatusMessage("Specified Id not found in database!");
                    return;
                }

                TextBoxEmployeeNumber.Text = emp.empNumber.ToString();
                TextBoxEmployeeName.Text = emp.empName;
                RadioButtonGender.SelectedValue = emp.empGender;
                TextBoxAddress.Text = emp.empAddress;
                TextBoxDepartment.Text = emp.empDepartment;
                TextBoxPosition.Text = emp.empPosition;
                TextBoxDoj.Text = emp.empDOJ.ToString();
                TextBoxEmail.Text = emp.empEmail;
               


            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Id parameter not found!: " + exception.Message);
            }
        }

    }
}