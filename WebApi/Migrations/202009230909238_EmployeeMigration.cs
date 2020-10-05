namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salery", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Salery");
        }
    }
}
