namespace MVC_Login_B.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClassLoginModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TB_M_Login",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TB_M_Login");
        }
    }
}
