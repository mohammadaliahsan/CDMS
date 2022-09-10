using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class TasksManager
    {
        TasksGateway aTasksGateway = new TasksGateway();
        string successMessage = string.Empty;

        public string Save(Tasks aTasks)
        {
            try
            {
                if (aTasksGateway.Save(aTasks) > 0)
                {
                    successMessage = "Tasks Save Successfully!!";
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

        public string Update(Tasks aTasks)
        {
            try
            {
                if (aTasksGateway.Update(aTasks) > 0)
                {
                    successMessage = "Tasks Save Successfully!!";
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

        public List<Tasks> GetAllTasks()
        {
            return aTasksGateway.GetAllTasks();
        }

        public Tasks GetTasksById(int TasksId)
        {
            var tasks = GetAllTasks();
            Tasks task = tasks.FirstOrDefault(t => t.Id == TasksId);
            return task;
        }
    }
}