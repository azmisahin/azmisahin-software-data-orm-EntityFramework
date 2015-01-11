namespace @as.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Add-Migration Log
    /// </summary>
    public partial class Log : DbMigration
    {
        /// <summary>
        /// Up
        /// </summary>
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateTime = c.DateTime(nullable: false),
                        info = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        /// <summary>
        /// Down
        /// </summary>
        public override void Down()
        {
            DropTable("dbo.Logs");
        }
    }
}
