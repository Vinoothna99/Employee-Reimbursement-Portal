using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataEntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public string UserPAN { get; set; }
        public string UserBankAccNo { get; set; }
        public string UserBankName { get; set; }
        
    }

    public class ApplicationUserClaim : IdentityUserClaim
    {
        public string Date { get; set; }
        public string Currency { get; set; }
        public string ReceiptPhotoFileName { get; set; }
        public string ClaimPhase { get; set; } = "To Be Processed";
        public string isApproved { get; set; }
        public string ApprovedBy { get; set; }
        public string ApprovedValue { get; set; }
        public string InternalNotes { get; set; }
        

    }



    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>()
                .ToTable("User");

            //IdentityRole -> Role
            modelBuilder.Entity<IdentityRole>()
                .ToTable("Role");

            //IdentityUserRole -> UserRole
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UserRole");

            //IdentityUserClaim -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("UserClaim");

            //IdentityUserLogin -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("UserLogin");




        }
    }
}
