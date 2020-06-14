namespace Online_Education.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sig7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Image", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "Image");
        }
    }
}
