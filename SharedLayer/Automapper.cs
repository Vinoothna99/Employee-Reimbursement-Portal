using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedLayer.Models;
using DataAccessLayer.DataEntityModels;
using SharedLayer.HelperModels;

namespace SharedLayer
{
    public class Automapper
    {
        public static MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<AccountModel, ApplicationUser>();
            cfg.CreateMap<ApplicationUser, AccountModel>();
            cfg.CreateMap<ClaimModel, ApplicationUserClaim>();
            cfg.CreateMap<ApplicationUserClaim, ClaimModel>();
            cfg.CreateMap<AdminClaimModel, ApplicationUserClaim>();
            cfg.CreateMap<ApplicationUserClaim, AdminClaimModel>();
            cfg.CreateMap<AdminClaimModel, ClaimModel>();
            cfg.CreateMap<ClaimModel, AdminClaimModel>();


        });

        public IMapper Mapper = config.CreateMapper();
    }
}
