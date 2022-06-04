using System;
using Web.Services;
using Web.Services.Models;
using Web.Services.Utilities;

namespace BootstapADOAssigmentDay57
{
    public partial class AddEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCreate_OnClick(object sender, EventArgs e)
        {
            CreateData();
        }

        private void CreateData()
        {
            var employeeService = new EmployeeServices();

            try
            {

                

                var emp = new Employee()
                {
                    empNumber = int.Parse(TextBoxEmployeeNumber.Text),
                    empName = TextBoxEmployeeName.Text,
                    //empGender = TextBoxGender.Text,
                    empGender = RadioButtonGender.SelectedValue,
                //empGender = MaleRadioButton.Checked ? MaleRadioButton.Text : MaleRadioButton.Checked ? OtherRadioButton.Text : OtherRadioButton.Text,
                empAddress = TextBoxAddress.Text,
                    empDepartment = TextBoxDepartment.Text,
                    empPosition = TextBoxPosition.Text,
                    empDOJ = DateTime.Parse(TextBoxDoj.Text),
                    empEmail = TextBoxEmail.Text,
                };
                employeeService.Add(emp);

                LabelStatus.ShowStatusMessage("Users record successfully added!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Failed to add Users record! > " + exception.Message);
            }
        }
    }
}