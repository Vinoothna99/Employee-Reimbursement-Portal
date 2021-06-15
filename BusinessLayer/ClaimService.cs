using BusinessLayer.Infrastructure;
using DataAccessLayer;
using DataAccessLayer.DataEntityModels;
using SharedLayer;
using SharedLayer.HelperModels;
using SharedLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ClaimService:IClaim
    {
        
        public string Post(ClaimModel claimModel)
        {
            ClaimDataAccess claimDataAccess = new ClaimDataAccess();
            Automapper autoMapper = new Automapper();
            ApplicationUserClaim applicationUserClaim = autoMapper.Mapper.Map<ClaimModel, ApplicationUserClaim>(claimModel);

            //Calling DataAccessLayer
            string result = claimDataAccess.Post(applicationUserClaim);
            return result;
        }


        public string Put(AdminClaimModel claimModel)
        {
            ClaimDataAccess claimDataAccess = new ClaimDataAccess();
            Automapper autoMapper = new Automapper();
            ApplicationUserClaim applicationUserClaim = autoMapper.Mapper.Map<AdminClaimModel, ApplicationUserClaim>(claimModel);

            //Calling DataAccessLayer
            string result = claimDataAccess.Put(applicationUserClaim);
            return result;
        }

        public string Delete(int Id)
        {
            ClaimDataAccess claimDataAccess = new ClaimDataAccess();
            

            //Calling DataAccessLayer
            string result = claimDataAccess.Delete(Id);
            return result;
        }
    }
}
