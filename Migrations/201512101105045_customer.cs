namespace Production.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.customer",
              c => new
              {
                  custID = c.Int(nullable: false, identity: true),
                  FirstName = c.String(),
                  LastName = c.String(),
                  Culture = c.String(),
                  TimeZone = c.String(),
                  Phone = c.String(),
                  email = c.String(),
                  Channel = c.Int(),
                  Gender = c.Int(),
                  Created = c.DateTime(),
                  CreatedBy = c.Guid(),
                  Changed = c.DateTime(),
                  ChangedBy = c.Guid(),

              })
              .PrimaryKey(t => t.custID);
                
        }
        
        public override void Down()
        {
            DropTable("dbo.customer");
        }
    }
}
