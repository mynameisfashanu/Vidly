namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd0b51296-cacf-4d71-b308-293feea75106', N'Guest@vidly.com', 0, N'AO59JXIV2ghfq/yY7o8rNepIjrNo59bwvKfL0TL92vjS1yivfJ39lL/5K/B1tkom8g==', N'8e497981-ded2-4952-9976-84e7fd465b44', NULL, 0, 0, NULL, 1, 0, N'Guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ffed9d50-2d54-43e9-bb02-3aadcf05c361', N'admin@vidly.com', 0, N'ACWu3xjgXdBKgOZC3S5B/sioTzTC/Xcm93YsuTcjwoNYIGOglgDDNNKwDG4sez5KqQ==', N'6ec5f5ae-3d7c-4475-92b6-d69055fa81df', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7e0366a7-7b8e-4994-898f-115a01fb9944', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ffed9d50-2d54-43e9-bb02-3aadcf05c361', N'7e0366a7-7b8e-4994-898f-115a01fb9944')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
