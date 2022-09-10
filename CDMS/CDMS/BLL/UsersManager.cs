using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CDMS.Gateway;
using CDMS.Models;

namespace CDMS.BLL
{
    public class UsersManager
    {
        UsersGateway usersGateway = new UsersGateway();
        string successMessage = string.Empty;

        public string Save(Users users)
        {
            try
            {
                if (usersGateway.Save(users) > 0)
                {
                    successMessage = "User Registration Successfully Done";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }
        public string SaveChangePassword(UsersChangePassowrd users)
        {
            try
            {
                if (usersGateway.SaveChangePassword(users) > 0)
                {
                    successMessage = "Password Change Successfully!!";
                }
                else
                {
                    successMessage = "Failed";
                }
            }
            catch (Exception ex)
            {
                successMessage = "Failed " + ex.Message + " " + ex.InnerException;
            }
            return successMessage;
        }

        public List<Users> GetUsers()
        {
            return usersGateway.GetUser();
        }
    }
}