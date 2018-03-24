namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Genres(Id, GenreType) values(1, 'Comedy')");
            Sql("insert into Genres(Id, GenreType) values(2, 'Action')");
            Sql("insert into Genres(Id, GenreType) values(3, 'Horror')");
            Sql("insert into Genres(Id, GenreType) values(4, 'Romance')");
            Sql("insert into Genres(Id, GenreType) values(5, 'Family')");
        }
        
        public override void Down()
        {
        }
    }
}
