namespace Shelterly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedAnimals : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                SET IDENTITY_INSERT [dbo].[Animals] ON
                INSERT INTO [dbo].[Animals] ([Id], [Name], [DateOfBirth], [RaceId], [ShelterId]) VALUES (3, N'Alex', NULL, 1, 1)
                INSERT INTO [dbo].[Animals] ([Id], [Name], [DateOfBirth], [RaceId], [ShelterId]) VALUES (4, N'Freddie', NULL, 1, 1)
                INSERT INTO [dbo].[Animals] ([Id], [Name], [DateOfBirth], [RaceId], [ShelterId]) VALUES (5, N'Garfield', NULL, 2, 1)
                INSERT INTO [dbo].[Animals] ([Id], [Name], [DateOfBirth], [RaceId], [ShelterId]) VALUES (6, N'Peanut', NULL, 3, 1)
                SET IDENTITY_INSERT [dbo].[Animals] OFF
                ");
        }
        
        public override void Down()
        {
        }
    }
}
