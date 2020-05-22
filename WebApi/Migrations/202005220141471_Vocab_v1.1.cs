namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vocab_v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Words", "Audio", c => c.String());
            AddColumn("dbo.Words", "ExampleAudio", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Words", "ExampleAudio");
            DropColumn("dbo.Words", "Audio");
        }
    }
}
