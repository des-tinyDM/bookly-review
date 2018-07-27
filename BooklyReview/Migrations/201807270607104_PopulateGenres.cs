namespace BooklyReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Classical Literature')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Science Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Autobiographical')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Non-Fiction')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Young Adult')");
        }
        
        public override void Down()
        {
        }
    }
}
