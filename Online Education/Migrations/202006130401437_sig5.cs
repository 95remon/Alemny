namespace Online_Education.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sig5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Image", c => c.String(nullable: false));
        }
    }
}
