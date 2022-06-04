using System;
using System.Data.SqlClient;
using Web.Services;
using Web.Services.Utilities;

namespace BootstapADOAssigmentDay57
{
    public partial class DeleteEmp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        protected void ButtonDelete_OnClick(object sender, EventArgs e)
        {
            DeleteData();
        }


        private void DeleteData()
        {
            var idText = Request.QueryString["id"];
            var id = int.Parse(idText);

            var empService = new EmployeeServices();

            try
            {
                empService.Delete(id);

                LabelStatus.ShowStatusMessage("Employee record successfully deleted!");
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                LabelStatus.ShowStatusMessage("Failed to delete Employee record! Maybe a foreign key was found! Please contact database admin!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Failed to delete Employee record!");
            }
        }
    }
}