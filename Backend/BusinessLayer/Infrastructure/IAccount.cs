using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SharedLayer.Models;

namespace BusinessLayer.Infrastructure
{
    public interface IAccount
    {
        IdentityResult Register(AccountModel model);
        
    }
}
