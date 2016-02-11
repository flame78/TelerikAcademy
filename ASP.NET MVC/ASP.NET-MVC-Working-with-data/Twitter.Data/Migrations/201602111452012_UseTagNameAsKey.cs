namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UseTagNameAsKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TweetTags", "Tag_Id", "dbo.Tags");
            DropIndex("dbo.TweetTags", new[] { "Tag_Id" });
            RenameColumn(table: "dbo.TweetTags", name: "Tag_Id", newName: "Tag_Name");
            DropPrimaryKey("dbo.Tags");
            DropPrimaryKey("dbo.TweetTags");
            AlterColumn("dbo.Tags", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.TweetTags", "Tag_Name", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Tags", "Name");
            AddPrimaryKey("dbo.TweetTags", new[] { "Tweet_Id", "Tag_Name" });
            CreateIndex("dbo.TweetTags", "Tag_Name");
            AddForeignKey("dbo.TweetTags", "Tag_Name", "dbo.Tags", "Name", cascadeDelete: true);
            DropColumn("dbo.Tags", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tags", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.TweetTags", "Tag_Name", "dbo.Tags");
            DropIndex("dbo.TweetTags", new[] { "Tag_Name" });
            DropPrimaryKey("dbo.TweetTags");
            DropPrimaryKey("dbo.Tags");
            AlterColumn("dbo.TweetTags", "Tag_Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Tags", "Name", c => c.String());
            AddPrimaryKey("dbo.TweetTags", new[] { "Tweet_Id", "Tag_Id" });
            AddPrimaryKey("dbo.Tags", "Id");
            RenameColumn(table: "dbo.TweetTags", name: "Tag_Name", newName: "Tag_Id");
            CreateIndex("dbo.TweetTags", "Tag_Id");
            AddForeignKey("dbo.TweetTags", "Tag_Id", "dbo.Tags", "Id", cascadeDelete: true);
        }
    }
}
