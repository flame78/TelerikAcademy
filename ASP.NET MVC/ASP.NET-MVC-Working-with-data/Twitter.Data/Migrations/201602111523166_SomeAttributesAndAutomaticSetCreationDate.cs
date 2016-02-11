namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeAttributesAndAutomaticSetCreationDate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tweets", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Tweets", new[] { "AuthorId" });
            AlterColumn("dbo.Tweets", "AuthorId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Tweets", "Content", c => c.String(nullable: false));
            CreateIndex("dbo.Tweets", "AuthorId");
            AddForeignKey("dbo.Tweets", "AuthorId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tweets", "AuthorId", "dbo.AspNetUsers");
            DropIndex("dbo.Tweets", new[] { "AuthorId" });
            AlterColumn("dbo.Tweets", "Content", c => c.String());
            AlterColumn("dbo.Tweets", "AuthorId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Tweets", "AuthorId");
            AddForeignKey("dbo.Tweets", "AuthorId", "dbo.AspNetUsers", "Id");
        }
    }
}
