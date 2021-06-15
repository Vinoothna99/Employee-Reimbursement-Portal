namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUserClaimColumns1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserClaim", "Date", c => c.String());
            AddColumn("dbo.UserClaim", "Currency", c => c.String());
            AddColumn("dbo.UserClaim", "ReceiptPhotoFileName", c => c.String());
            AddColumn("dbo.UserClaim", "ClaimPhase", c => c.String());
            AddColumn("dbo.UserClaim", "isApproved", c => c.String());
            AddColumn("dbo.UserClaim", "ApprovedBy", c => c.String());
            AddColumn("dbo.UserClaim", "ApprovedValue", c => c.String());
            AddColumn("dbo.UserClaim", "InternalNotes", c => c.String());
            AddColumn("dbo.UserClaim", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserClaim", "Discriminator");
            DropColumn("dbo.UserClaim", "InternalNotes");
            DropColumn("dbo.UserClaim", "ApprovedValue");
            DropColumn("dbo.UserClaim", "ApprovedBy");
            DropColumn("dbo.UserClaim", "isApproved");
            DropColumn("dbo.UserClaim", "ClaimPhase");
            DropColumn("dbo.UserClaim", "ReceiptPhotoFileName");
            DropColumn("dbo.UserClaim", "Currency");
            DropColumn("dbo.UserClaim", "Date");
        }
    }
}
