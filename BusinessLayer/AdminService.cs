using BusinessLayer.Infrastructure;
using SharedLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class AdminService: IAdmin
    {
        public string GetAllPendingUserClaims()
        { string dummy = "To Be Processed";
            string query = @"SELECT[dbo].[UserClaim].Id,
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
                        [dbo].[User].UserName
                        from [dbo].[UserClaim]
                        Inner Join [dbo].[User] ON [dbo].[UserClaim].UserId =[dbo].[User].Id
                        where [dbo].[UserClaim].ClaimPhase LIKE '" + dummy + @"'
                        order by [dbo].[UserClaim].Date Desc"; 

                return query;

        }


        public string GetDeclinedClaims()
        {
            
            string query = @"SELECT[dbo].[UserClaim].Id,
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
                        [dbo].[User].UserName
                        from [dbo].[UserClaim]
                        Inner Join [dbo].[User] ON [dbo].[UserClaim].UserId =[dbo].[User].Id
                        where [dbo].[UserClaim].ClaimPhase LIKE 'Processed' and [dbo].[UserClaim].isApproved LIKE '0'
                        order by [dbo].[UserClaim].Date Desc";

            return query;

        }

        public string GetApprovedClaims()
        {
            
            string query = @"SELECT[dbo].[UserClaim].Id,
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
                        [dbo].[User].UserName
                        from [dbo].[UserClaim]
                        Inner Join [dbo].[User] ON [dbo].[UserClaim].UserId =[dbo].[User].Id
                        where [dbo].[UserClaim].ClaimPhase LIKE 'Processed' and [dbo].[UserClaim].isApproved LIKE '1'
                        order by [dbo].[UserClaim].Date Desc";

            return query;

        }

        
    }
}
