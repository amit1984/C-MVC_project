namespace Production.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Budget : DbMigration
    {
        public override void Up()
        {
            CreateTable(
             "dbo.Budget",
             c => new
             {
                 budgetID = c.Int(nullable: false, identity: true),
                 custID = c.Int(),
                 premium = c.String(),
                 cheap = c.String(),
                 luxury = c.String()
             })
             .PrimaryKey(t => t.budgetID)
              .ForeignKey("dbo.customers", t => t.custID, cascadeDelete: true);
               
        }
        
        public override void Down()
        {
            DropTable("dbo.Budget");
        }
    }
}
