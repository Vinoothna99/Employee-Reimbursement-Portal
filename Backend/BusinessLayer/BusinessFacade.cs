using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Infrastructure;

namespace BusinessLayer
{
    public class BusinessFacade
    {
        public IAccount GetAccountService()
        {
            return new AccountService();
        }

        public IClaim GetClaimService()
        {
            return new ClaimService();
        }

        public IEmployee GetEmployeeService()
        {
            return new EmployeeService();
        }

        public IAdmin GetAdminService()
        {
            return new AdminService();
        }


    }
}

