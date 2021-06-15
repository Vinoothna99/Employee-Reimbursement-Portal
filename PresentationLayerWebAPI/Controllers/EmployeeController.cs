using BusinessLayer;
using BusinessLayer.Infrastructure;
using SharedLayer.HelperModels;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PresentationLayerWebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpPost]
        [Route("api/Employee/GetUserId")]
        public HttpResponseMessage GetUserId(string userName)
        {
            string query = @"SELECT [dbo].[User].Id from [dbo].[User]
                            
                            where [dbo].[User].UserName LIKE '" + userName + @"'
                            ";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(ClaimModel model)
        {
            //Calling Business 
            IClaim claimService = new BusinessFacade().GetClaimService();
            

            
            string result = claimService.Post(model);
            return result;
        }


        public string Put(AdminClaimModel model)
        {
            //Calling Business 
            IClaim claimService = new BusinessFacade().GetClaimService();

            string result = claimService.Put(model);
            return result;
        }

        public string Delete(AdminClaimModel model)
        {
            //Calling Business 
            IClaim claimService = new BusinessFacade().GetClaimService();
            int Id = model.Id;
            string result = claimService.Delete(Id);
            return result;
        }

        [HttpPost]
        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos"+filename);
                postedFile.SaveAs(physicalPath);
                return filename;

            }catch(Exception)
            {
                return "anonymous.png";
            }
        }
    }
}
