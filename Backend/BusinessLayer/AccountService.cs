using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Infrastructure;
using SharedLayer.Models;
using DataAccessLayer.DataEntityModels;
using Microsoft.AspNet.Identity;
using DataAccessLayer;
using SharedLayer;
using System.Security.Claims;

namespace BusinessLayer
{
    public class AccountService : IAccount
    {
        public IdentityResult Register(AccountModel model)
        {
            AccountDataAccess accountDataAccess = new AccountDataAccess();
            

            //Mapping AccountModel object to ApplicationUser object
            Automapper autoMapper = new Automapper();
            ApplicationUser applicationUser = autoMapper.Mapper.Map<AccountModel, ApplicationUser>(model);

            //Calling DataAccessLayer
            IdentityResult result = accountDataAccess.Register(applicationUser, model.Password);
            return result;
        }


        
    }
}
