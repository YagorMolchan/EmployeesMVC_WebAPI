namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Salery");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Salery", c => c.Int(nullable: false));
            DropColumn("dbo.Employees", "Salary");
        }
    }
}
