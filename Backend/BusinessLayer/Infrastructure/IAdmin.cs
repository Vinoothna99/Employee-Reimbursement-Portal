using SharedLayer.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Infrastructure
{
    public interface IAdmin
    {
        string GetAllPendingUserClaims();
        string GetApprovedClaims();
        string GetDeclinedClaims();
    }
}
