namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("set identity_insert MembershipTypes On");
            Sql("Insert into MembershipTypes(Id, SignupFee, DiscountInMonths, DiscountRate) values ( 1, 0, 0, 0)");
            Sql("Insert into MembershipTypes(Id, SignupFee, DiscountInMonths, DiscountRate) values ( 2, 30, 1, 10)");
            Sql("Insert into MembershipTypes(Id, SignupFee, DiscountInMonths, DiscountRate) values ( 3, 90, 3, 15)");
            Sql("Insert into MembershipTypes(Id, SignupFee, DiscountInMonths, DiscountRate) values ( 4, 300, 12, 20)");
            Sql("set identity_insert MembershipTypes Off");
        }
        
        public override void Down()
        {
        }
    }
}
