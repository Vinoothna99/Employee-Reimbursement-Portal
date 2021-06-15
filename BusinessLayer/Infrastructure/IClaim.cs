using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLayer.HelperModels;
using SharedLayer.Models;

namespace BusinessLayer.Infrastructure
{
    public interface IClaim
    {
        string Post(ClaimModel claimModel);
        string Put(AdminClaimModel claimModel);
       
        string Delete(int Id);
    }
}
