using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLayer.HelperModels
{
    public class UserAndClaimsModel
    {
        public AccountModel accountModel { get; set; }

        //Student Exam Result List Model   
        public List<ClaimModel> ListOfClaims { get; set; }
    }
}
