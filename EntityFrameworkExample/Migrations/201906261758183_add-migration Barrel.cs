namespace EntityFrameworkExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmigrationBarrel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Barrels", "hidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Barrels", "hidden");
        }
    }
}
