namespace Production.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class bb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusLists",
                c => new
                {
                    busID = c.Int(nullable: false, identity: true),
                    BusName = c.String(),
                    BusNo = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.busID);

            CreateTable(
             "dbo.country",
             c => new
             {
                 countryID = c.Int(nullable: false, identity: true),
                 countryName = c.String()

             })
             .PrimaryKey(t => t.countryID);

            CreateTable(
                "dbo.city",
                c => new
                {
                    cityID = c.Int(nullable: false, identity: true),
                    cityName = c.String(),
                    countryID = c.Int()
                })
                .PrimaryKey(t => t.cityID)
                 .ForeignKey("dbo.country", t => t.countryID, cascadeDelete: true);
               



        }

        public override void Down()
        {
            DropTable("dbo.BusLists");
            DropTable("dbo.country");
            DropTable("dbo.city");

        }
    }
}
