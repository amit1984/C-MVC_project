namespace Production.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city : DbMigration
    {
        public override void Up()
        {
            CreateTable(
              "dbo.city",
              c => new
              {
                  cityID = c.Int(nullable: false, identity: true),
                  cityName = c.String(),
                  countryID = c.Int()
              })
              .PrimaryKey(t => t.cityID)
               .ForeignKey("dbo.countries", t => t.countryID, cascadeDelete: true);
               
        }
        
        public override void Down()
        {
            DropTable("dbo.city");
        }
    }
}
