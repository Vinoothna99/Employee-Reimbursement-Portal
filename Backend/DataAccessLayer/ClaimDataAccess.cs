using DataAccessLayer.DataEntityModels;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Http;
using System.Text;
using System.Threading.Tasks;


namespace DataAccessLayer
{
    public class ClaimDataAccess
    {
        

        public string Post(ApplicationUserClaim claim)
        {
            string claimData = claim.UserId;
            try
            {
               
                string query = @"insert into [dbo].[UserClaim] values
                    ((SELECT [dbo].[User].Id from [dbo].[User]
                            
                            where [dbo].[User].UserName LIKE '" + claim.UserId + @"'), 
                    '" + claim.ClaimType + @"',
                    '" + claim.ClaimValue + @"',
                    '" + claim.Date + @"',
                    '" + claim.Currency + @"',
                    '" + claim.ReceiptPhotoFileName + @"',
                    '" + claim.ClaimPhase + @"',
                    '" + claim.isApproved + @"',
                    '" + claim.ApprovedBy + @"',
                    '" + claim.ApprovedValue + @"',
                    '" + claim.InternalNotes + @"',
                    ''
                    )";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";

            }
            catch (Exception ex)
            {
                var errorMessages = claimData+  "   Failed to add!!!   " + ex;
                return errorMessages;
            }
        }



        public string Put(ApplicationUserClaim claim)
        {
            try
            {
                string query = @"update [dbo].[UserClaim] set 
                ClaimPhase= '" + claim.ClaimPhase + @"',
                ClaimType='" + claim.ClaimType + @"',
                Currency='" + claim.Currency + @"',
                Date='" + claim.Date + @"',
                ReceiptPhotoFileName='" + claim.ReceiptPhotoFileName + @"',
                ClaimValue='" + claim.ClaimValue + @"',
                ApprovedValue='" + claim.ApprovedValue + @"',
                ApprovedBy='" + claim.ApprovedBy + @"',
                isApproved='" + claim.isApproved + @"',
                InternalNotes='" + claim.InternalNotes + @"'
                
                where Id="+ claim.Id +@"
                
                
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Update!!!";
            }
        }



        public string Delete(int Id)
        {
            try
            {
                string query = @"delete from [dbo].[UserClaim]  
                                
                where Id=" + Id + @"
                
                
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefautConnection"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";

            }
            catch (Exception)
            {
                return "Failed to Delete!!!";
            }
        }


        
    }
}
