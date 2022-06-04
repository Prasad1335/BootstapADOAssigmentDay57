using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Services;
using Web.Services.Models;
using Web.Services.Utilities;

namespace BootstapADOAssigmentDay57
{
    public partial class AddJob : System.Web.UI.Page
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
            var jobService = new JobServices();

            try
            {
                var jobs = new Job()
                {
                    jobTitle = TextBoxjobTitle.Text,
                    numberOfJobPosition = TextBoxnumberOfJobPosition.Text,
                    locationAddress = TextBoxlocationAddress.Text,
                    expectedSalaryRange = TextBoxexpectedSalaryRange.Text,
                   
                };
                jobService.Add(jobs);

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