using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class ProjectManager
    {
        ProjectGateway aProjectGateway = new ProjectGateway();
        string successMessage = string.Empty;

        public string Save(Project aProject)
        {
            try
            {
                if (aProjectGateway.Save(aProject) > 0)
                {
                    successMessage = "Project Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message;
            }
            return successMessage;
        }

        public string Update(Project aProject)
        {
            try
            {
                if (aProjectGateway.Update(aProject) > 0)
                {
                    successMessage = "Project Save Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message;
            }
            return successMessage;
        }

        public List<Project> GetAllProject()
        {
            return aProjectGateway.GetAllProject();
        }

        public Project GetProjectById(int ProjectId)
        {
            var branches = GetAllProject();
            Project branch = branches.FirstOrDefault(t => t.Id == ProjectId);
            return branch;
        }
    }
}