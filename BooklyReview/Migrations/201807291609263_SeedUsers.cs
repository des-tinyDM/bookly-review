namespace BooklyReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ad55a523-f930-465b-be83-0e14c9181386', N'admin@bookly.com', 0, N'AKuz8Jtn61qN9YJ2kJIL1ax3ZWAiG9bfiCZhvgrIQ5mN5YkbmWOmSo8I8yp/RphZrg==', N'e1ec52b0-3965-4143-b360-0e7c3111db4e', NULL, 0, 0, NULL, 1, 0, N'admin@bookly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'bfd80c9b-a0f4-42ad-862c-a2415cc4cd74', N'guest@bookly.com', 0, N'AN80rfmSCuLPRgWCgqWiM6ZarUDd/YRJH78+yMIU8Wmw7E0FzsmIaIz24CDfMR5IDA==', N'dc418625-7a93-4720-a7d1-ee95009ba195', NULL, 0, 0, NULL, 1, 0, N'guest@bookly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1de63057-b8d2-4251-bc2f-3111e96d0c73', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ad55a523-f930-465b-be83-0e14c9181386', N'1de63057-b8d2-4251-bc2f-3111e96d0c73')

");
        }
        
        public override void Down()
        {
        }
    }
}
