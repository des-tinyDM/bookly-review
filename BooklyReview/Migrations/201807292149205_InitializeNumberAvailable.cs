namespace BooklyReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeNumberAvailable : DbMigration
    {
        public override void Up()
        {

            Sql("UPDATE Books SET NumberAvailable = NumberInStock");
        }

        public override void Down()
        {
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
