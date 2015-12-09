namespace Production.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Account : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Account",
               c => new
               {
                   userID = c.Int(nullable: false, identity: true),
                   FirstName = c.String(),
                   LastName = c.String(),
                   Culture = c.String(),
                   TimeZone = c.String(),
                   Phone = c.String(),
                   email = c.String(),
                   Created = c.DateTime(),
                   CreatedBy = c.Guid(),
                   Changed = c.DateTime(),
                   ChangedBy = c.Guid(),
                   
               })
               .PrimaryKey(t => t.userID);
                
        }
        
        public override void Down()
        {
            DropTable("dbo.Account");
        }
    }
}
