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
    public partial class jobEdit : System.Web.UI.Page
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
            var jobService = new JobServices();

            try
            {
                var idText = Request.QueryString["id"];

                var job = new Job();
                job.Id = int.Parse(idText);

                job.jobTitle = TextBoxjobTitle.Text;
                job.numberOfJobPosition = TextBoxnumberOfJobPosition.Text;
                job.locationAddress = TextBoxlocationAddress.Text;
                job.expectedSalaryRange = TextBoxexpectedSalaryRange.Text;
        
                jobService.Update(job);
                LabelStatus.ShowStatusMessage("job record successfully updated!");
            }
            catch (Exception exception)
            {
                Debug.Print(exception.StackTrace);
                LabelStatus.ShowStatusMessage("Failed to update job record!");
            }
        }

        private void ShowDataToUpdate()
        {
            var idText = Request.QueryString["id"];
            try
            {
                var id = int.Parse(idText);

                var jobService = new JobServices();

                var job = jobService.GetById(id);

                if (job == null)
                {
                    LabelStatus.ShowStatusMessage("Specified Id not found in database!");
                    return;
                }

                TextBoxjobTitle.Text = job.jobTitle;
                TextBoxnumberOfJobPosition.Text = job.numberOfJobPosition;
                TextBoxlocationAddress.Text = job.locationAddress;
                TextBoxexpectedSalaryRange.Text = job.expectedSalaryRange;
               
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                LabelStatus.ShowStatusMessage("Id parameter not found!: " + exception.Message);
            }
        }

    }
}