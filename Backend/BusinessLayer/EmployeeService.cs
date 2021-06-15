using BusinessLayer.Infrastructure;
using DataAccessLayer;
using DataAccessLayer.DataEntityModels;
using SharedLayer;
using SharedLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeService: IEmployee
    {
        public string GetAllUserClaims(string userName)
        {
            string query = @"SELECT [dbo].[UserClaim].Id,
                            [dbo].[UserClaim].ClaimValue,
                            [dbo].[UserClaim].ClaimPhase,
                            [dbo].[UserClaim].ClaimType,
                            [dbo].[UserClaim].Date,
                            [dbo].[UserClaim].Currency,
                            [dbo].[UserClaim].ReceiptPhotoFileName,
                            [dbo].[UserClaim].isApproved,
                            [dbo].[UserClaim].ApprovedBy,
                            [dbo].[UserClaim].ApprovedValue,
                            [dbo].[UserClaim].InternalNotes,
                            [dbo].[UserClaim].UserId,
                            [dbo].[User].Email
                            from [dbo].[UserClaim]
                            Inner Join [dbo].[User] ON [dbo].[UserClaim].UserId=[dbo].[User].Id
                            where [dbo].[User].UserName LIKE '" + userName + @"'
                            order by [dbo].[UserClaim].ClaimPhase Desc , [dbo].[UserClaim].Date Desc ;";
            return query;

            
        }

    }



}
