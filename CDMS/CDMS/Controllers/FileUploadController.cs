using System;
using System.IO;
using System.Web;
using System.Data;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Collections.Generic;
using CDMS.BLL;
using CDMS.Models;
using MySql.Data.MySqlClient;
using System.Web.Configuration;

namespace CDMS.Controllers
{
    public class FileUploadController : Controller
    {
        //string conString = "Data Source=.;Initial Catalog = SMS; integrated security=true;";
        public string connectionString = WebConfigurationManager.ConnectionStrings["U_DB"].ConnectionString;
        public MySqlCommand Command { get; set; }
        string Query = string.Empty;
        public MySql.Data.MySqlClient.MySqlConnection Connection;
        int Id = 0;
        string Name = string.Empty;

        // GET: Files  
        public ActionResult Index(FileUpload model, int id, string name)
        {

            Session["RecordId"] = id;
            Session["ControllerName"] = name;

            List<FileUpload> list = new List<FileUpload>();
            DataTable dtFiles = GetFileDetails(id, name);
            foreach (DataRow dr in dtFiles.Rows)
            {
                list.Add(new FileUpload
                {
                    FileId = @dr["FILEID"].ToString(),
                    FileName = @dr["FILENAME"].ToString(),
                    FileUrl = @dr["FILEURL"].ToString()
                });
            }
            model.FileList = list;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            FileUpload model = new FileUpload();
            List<FileUpload> list = new List<FileUpload>();
            Id = Convert.ToInt32(Session["RecordId"]);
            Name = Convert.ToString(Session["ControllerName"]);

            DataTable dtFiles = GetFileDetails(Id, Name);
            foreach (DataRow dr in dtFiles.Rows)
            {
                list.Add(new FileUpload
                {
                    FileId = @dr["FILEID"].ToString(),
                    FileName = @dr["FILENAME"].ToString(),
                    FileUrl = @dr["FILEURL"].ToString()
                });
            }
            model.FileList = list;

            if (files != null)
            {
                var Extension = Path.GetExtension(files.FileName);
                //var fileName = "my-file-" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Extension;

              

                var fileName = Name + "-" + Id + "-" + DateTime.Now.ToString("yyMMdd") + Extension;
                string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                model.FileUrl = Url.Content(Path.Combine("~/UploadedFiles/", fileName));
                model.FileName = fileName;

                model.ControllerName = Name;
                model.ControllerId = Id;
                model.CreatedBy = Convert.ToInt16(Session["Id"]);
                model.CreatedDate = DateTime.Now;
                model.CompanyId = Convert.ToInt16(Session["CompanyId"]);
                model.BranchId = Convert.ToInt16(Session["BranchId"]);

                if (SaveFile(model))
                {
                    files.SaveAs(path);
                    TempData["AlertMessage"] = "Uploaded Successfully !!";
                    return RedirectToAction("Index", "Files");
                }
                else
                {
                    ModelState.AddModelError("", "Error In Add File. Please Try Again !!!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Please Choose Correct File Type !!");
                return View(model);
            }
            return RedirectToAction("Index", "FileUpload");
        }

        private DataTable GetFileDetails(int id, string name)
        {
            Query = string.Format("Select * From FileUpload WHERE ControllerName = '{0}' AND  ControllerId = {1} ", name, id);
            Connection = new MySqlConnection(connectionString);

            DataTable dtData = new DataTable();
            Command = new MySqlCommand(Query, Connection);
            Connection.Open();
            //SqlCommand command = new SqlCommand(Query, connectionString);
            MySqlDataAdapter da = new MySqlDataAdapter(Command);
            da.Fill(dtData);
            Connection.Close();
            return dtData;
        }

        private bool SaveFile(FileUpload model)
        {
            Query = string.Format("INSERT INTO FileUpload (FileName, FileUrl, ControllerName, ControllerId) VALUES('{0}','{1}', '{2}', {3} )",
                                model.FileName, model.FileUrl, model.ControllerName, model.ControllerId);
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
            MySqlCommand command = new MySqlCommand(Query, Connection);
            int numResult = command.ExecuteNonQuery();
            Connection.Close();
            if (numResult > 0)
                return true;
            else
                return false;
        }

        public ActionResult DownloadFile(string filePath)
        {
            string fullName = Server.MapPath("~" + filePath);

            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filePath);
        }

        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
    }
}