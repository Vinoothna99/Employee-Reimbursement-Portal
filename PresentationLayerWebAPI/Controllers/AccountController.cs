using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharedLayer.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using BusinessLayer.Infrastructure;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Claims;
using SharedLayer.HelperModels;

namespace PresentationLayerWebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public IdentityResult Register(AccountModel model)
        {   
            //Calling Business 
            IAccount accountService = new BusinessFacade().GetAccountService();

            IdentityResult result = accountService.Register(model);
            return result;
        }


        [HttpGet]
        [Route("api/GetUserClaims")]
        public HttpResponseMessage GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;

            AccountModel model = new AccountModel()
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,                
                UserPAN = identityClaims.FindFirst("UserPAN").Value,
                UserBankName = identityClaims.FindFirst("UserBankName").Value,
                UserBankAccNo = identityClaims.FindFirst("UserBankAccNo").Value
            };

            if (model.UserName == "admin@gmail.com")
            {
                IAdmin adminService = new BusinessFacade().GetAdminService();

                string query = adminService.GetAllPendingUserClaims();
                
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
            else
            {
                IEmployee employeeService = new BusinessFacade().GetEmployeeService();

                string query = employeeService.GetAllUserClaims(model.UserName);
                
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



        




        [Route("api/User/GetUsers")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var query =
                @"SELECT UserName, Email  FROM [dbo].[User];";
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
