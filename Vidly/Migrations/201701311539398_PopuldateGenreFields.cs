namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopuldateGenreFields : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VAlUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Horror')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Action')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Fantasy')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Thriller')");
            Sql("INSERT INTO Genres (Name) VAlUES ('Sci-Fi')");
        }

        public override void Down()
        {
        }
    }
}
