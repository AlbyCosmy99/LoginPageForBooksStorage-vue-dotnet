namespace loginPage_v1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pageloginmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        UserName = c.String(),
                        NumberPrefix = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Author = c.String(),
                        BookLanguage = c.String(),
                        publicationyear = c.Int(),
                        pages = c.Int(),
                        Genre = c.String(),
                        finishingDate = c.DateTime(),
                        price = c.String(),
                        personalRating = c.String(),
                        Notes = c.String(),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "UserId", "dbo.Users");
            DropIndex("dbo.Books", new[] { "UserId" });
            DropTable("dbo.Books");
            DropTable("dbo.Users");
        }
    }
}
