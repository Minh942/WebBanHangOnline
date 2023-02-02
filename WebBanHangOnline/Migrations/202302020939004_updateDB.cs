namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "Alias", c => c.String());
            AddColumn("dbo.tb_News", "Alias", c => c.String());
            AddColumn("dbo.tb_Posts", "Alias", c => c.String());
            AddColumn("dbo.tb_Product", "Alias", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoKeywords", c => c.String(maxLength: 150));
            AlterColumn("dbo.tb_Category", "SeoDesception", c => c.String(maxLength: 250));
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tb_Category", "SeoTitle", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoDesception", c => c.String());
            AlterColumn("dbo.tb_Category", "SeoKeywords", c => c.String());
            DropColumn("dbo.tb_Product", "Alias");
            DropColumn("dbo.tb_Posts", "Alias");
            DropColumn("dbo.tb_News", "Alias");
            DropColumn("dbo.tb_Category", "Alias");
        }
    }
}
