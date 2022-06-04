using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Services;
using Web.Services.Utilities;

namespace BootstapADOAssigmentDay57
{
    public partial class DeleteJob : System.Web.UI.Page
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

            var empService = new JobServices();

            try
            {
                empService.Delete(id);

                LabelStatus.ShowStatusMessage("job record successfully deleted!");
            }
            catch (SqlException sqlException)
            {
                Console.WriteLine(sqlException);
                LabelStatus.ShowStatusMessage("Failed to delete job record! Maybe a foreign key was found! Please contact database admin!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Failed to delete job record!");
            }
        }
    }
}