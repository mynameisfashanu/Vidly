namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET name = 'Pay as You go' where Id = 1");
            Sql("UPDATE MembershipTypes SET name = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes SET name = 'Quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes SET name = 'Annual' where Id = 4");
            Sql("UPDATE MembershipTypes SET name = 'Annual' where Id = 5");

        }

        public override void Down()
        {
        }
    }
}
