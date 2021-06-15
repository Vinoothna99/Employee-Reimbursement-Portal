using BusinessLayer;
using BusinessLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PresentationLayerWebAPI.Controllers
{
    public class AdminController : ApiController
    {
        [HttpGet]
        [Route("api/GetDeclinedClaims")]
        public HttpResponseMessage GetDeclinedClaims()
        {
            IAdmin adminService = new BusinessFacade().GetAdminService();

            string query = adminService.GetDeclinedClaims();

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

        [HttpGet]
        [Route("api/GetApprovedClaims")]
        public HttpResponseMessage GetApprovedClaims()
        {
            IAdmin adminService = new BusinessFacade().GetAdminService();

            string query = adminService.GetApprovedClaims();

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
    }
    }
