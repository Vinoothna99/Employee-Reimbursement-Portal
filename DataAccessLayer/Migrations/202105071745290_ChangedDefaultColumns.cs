namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDefaultColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "UserPAN", c => c.String());
            AddColumn("dbo.User", "UserBankAccNo", c => c.String());
            AddColumn("dbo.User", "UserBankName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "UserBankName");
            DropColumn("dbo.User", "UserBankAccNo");
            DropColumn("dbo.User", "UserPAN");
        }
    }
}
