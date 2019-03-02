namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'299f4628-108d-4039-9c64-8130a3f1b38d', N'Admin@vidly.com', 0, N'ADgHgHRcPL0U7Z/VL/sv7DdzNkUmGlV+4N9JlP1k873twU4gJAyjwKSbBQbrqsvadQ==', N'6bf4b554-c933-4837-8491-772e0a408ad4', NULL, 0, 0, NULL, 1, 0, N'Admin@vidly.com')
            INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ef7d3764-f9d0-46c1-8e4a-061e0698ba13', N'guest@vidly.com', 0, N'ADJH3B2s92IiGmnAgZ37YFHoGfnk/sdkbGz8JVTAftYYCq34No3Z6OL/HOAfmNigmg==', N'5ee4a051-1cb6-45a9-bd4f-949c6cd57f36', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1c05a711-cf8e-4b7d-9c52-9d8615e54835', N'CanManageMovies')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'299f4628-108d-4039-9c64-8130a3f1b38d', N'1c05a711-cf8e-4b7d-9c52-9d8615e54835')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
