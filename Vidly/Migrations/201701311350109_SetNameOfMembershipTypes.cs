namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameOfMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Pay as You go' where Id = 1");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' where Id = 2");
            Sql("UPDATE MembershipTypes SET Name = 'Quarterly' where Id = 3");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' where Id = 4");
            Sql("UPDATE MembershipTypes SET Name = 'Annual' where Id = 5");

        }

        public override void Down()
        {
        }
    }
}
