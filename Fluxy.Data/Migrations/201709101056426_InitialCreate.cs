namespace Fluxy.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        PrivateMessagesExtend_Id = c.String(maxLength: 128),
                        PrivateVideoExtend_Id = c.String(maxLength: 128),
                        UserProfileExtend_Id = c.String(maxLength: 128),
                        VideoAttributesExtend_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PrivateMessages", t => t.PrivateMessagesExtend_Id)
                .ForeignKey("dbo.PrivateVideoExtends", t => t.PrivateVideoExtend_Id)
                .ForeignKey("dbo.UserProfile", t => t.UserProfileExtend_Id)
                .ForeignKey("dbo.VideoAttributes", t => t.VideoAttributesExtend_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.PrivateMessagesExtend_Id)
                .Index(t => t.PrivateVideoExtend_Id)
                .Index(t => t.UserProfileExtend_Id)
                .Index(t => t.VideoAttributesExtend_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PrivateMessages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FromUserId = c.String(maxLength: 128),
                        ToUserId = c.String(maxLength: 128),
                        Subject = c.String(nullable: false, maxLength: 200),
                        Text = c.String(nullable: false, maxLength: 500),
                        IsRead = c.Boolean(nullable: false),
                        IsDeletedByAuthor = c.Boolean(nullable: false),
                        IsDeletedByRecipient = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
            CreateTable(
                "dbo.PrivateVideoExtends",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FromUserId = c.String(maxLength: 128),
                        ToUserId = c.String(maxLength: 128),
                        Message = c.String(),
                        VideoAttributeId = c.String(maxLength: 128),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FromUserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ToUserId)
                .ForeignKey("dbo.VideoAttributes", t => t.VideoAttributeId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId)
                .Index(t => t.VideoAttributeId);
            
            CreateTable(
                "dbo.VideoAttributes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 200),
                        ShortName = c.String(maxLength: 100),
                        Url = c.String(),
                        Length = c.String(),
                        Tags = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                        Thumbunail = c.Binary(),
                        IsPublicVideo = c.Boolean(nullable: false),
                        IsAdultContent = c.Boolean(nullable: false),
                        IsAllowFullScreen = c.Boolean(nullable: false),
                        ViewCount = c.Long(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        CategoryId = c.String(maxLength: 128),
                        LanguageId = c.String(maxLength: 128),
                        VideoSettingsId = c.String(maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.VideoSettings", t => t.VideoSettingsId)
                .Index(t => t.CategoryId)
                .Index(t => t.LanguageId)
                .Index(t => t.VideoSettingsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 200),
                        LanguageCulture = c.String(maxLength: 100),
                        Rtl = c.Boolean(nullable: false),
                        DefaultCurrency = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        FrameWidth = c.Int(nullable: false),
                        FrameHeight = c.Int(nullable: false),
                        FrameFilters = c.String(maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        VideoAttributes_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VideoAttributes", t => t.VideoAttributes_Id)
                .Index(t => t.VideoAttributes_Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        DisplayPicture = c.Binary(),
                        Firstname = c.String(maxLength: 100),
                        Lastname = c.String(maxLength: 100),
                        Gender = c.String(),
                        Dob = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        About = c.String(maxLength: 300),
                        Hobbies = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UserSettings_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.UserSettings", t => t.UserSettings_Id)
                .Index(t => t.UserId)
                .Index(t => t.UserSettings_Id);
            
            CreateTable(
                "dbo.UserSettings",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CanAnyoneSendMessage = c.Boolean(nullable: false),
                        CanAnyoneSendVideo = c.Boolean(nullable: false),
                        IsMyDpPublic = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                        UserId = c.String(maxLength: 128),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MenuAttribute",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AttributeKey = c.String(nullable: false, maxLength: 200),
                        AttributeValue = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainMenu",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MenuAttributeId = c.String(),
                        Name = c.String(nullable: false, maxLength: 200),
                        ShortName = c.String(maxLength: 200),
                        LinkText = c.String(nullable: false, maxLength: 200),
                        ActionName = c.String(nullable: false, maxLength: 200),
                        ControllerName = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubMenu",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        MainMenuId = c.String(nullable: false, maxLength: 128),
                        MenuAttributeId = c.String(nullable: false),
                        Name = c.String(nullable: false, maxLength: 200),
                        ShortName = c.String(maxLength: 200),
                        LinkText = c.String(nullable: false, maxLength: 200),
                        ActionName = c.String(nullable: false, maxLength: 200),
                        ControllerName = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainMenu", t => t.MainMenuId, cascadeDelete: true)
                .Index(t => t.MainMenuId);
            
            CreateTable(
                "dbo.ContactUs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Message = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Newsletter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(nullable: false),
                        Active = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        LogLevelId = c.Int(nullable: false),
                        ApplicationObject = c.String(),
                        FullMessage = c.String(nullable: false),
                        ControllerName = c.String(),
                        ExceptionStackTrace = c.String(),
                        LogTime = c.DateTime(nullable: false),
                        HelpLink = c.String(),
                        InnerException = c.String(),
                        Method = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BannerDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Image = c.Binary(),
                        Headline = c.String(maxLength: 100),
                        Slogans = c.String(maxLength: 200),
                        ButtonText = c.String(maxLength: 200),
                        ButtonUrl = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenu", "MainMenuId", "dbo.MainMenu");
            DropForeignKey("dbo.AspNetUsers", "VideoAttributesExtend_Id", "dbo.VideoAttributes");
            DropForeignKey("dbo.AspNetUsers", "UserProfileExtend_Id", "dbo.UserProfile");
            DropForeignKey("dbo.UserProfile", "UserSettings_Id", "dbo.UserSettings");
            DropForeignKey("dbo.UserSettings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserProfile", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PrivateVideoExtend_Id", "dbo.PrivateVideoExtends");
            DropForeignKey("dbo.PrivateVideoExtends", "VideoAttributeId", "dbo.VideoAttributes");
            DropForeignKey("dbo.VideoAttributes", "VideoSettingsId", "dbo.VideoSettings");
            DropForeignKey("dbo.VideoSettings", "VideoAttributes_Id", "dbo.VideoAttributes");
            DropForeignKey("dbo.VideoAttributes", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.VideoAttributes", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.VideoAttributes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateVideoExtends", "ToUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateVideoExtends", "FromUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "PrivateMessagesExtend_Id", "dbo.PrivateMessages");
            DropForeignKey("dbo.PrivateMessages", "ToUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PrivateMessages", "FromUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.SubMenu", new[] { "MainMenuId" });
            DropIndex("dbo.UserSettings", new[] { "UserId" });
            DropIndex("dbo.UserProfile", new[] { "UserSettings_Id" });
            DropIndex("dbo.UserProfile", new[] { "UserId" });
            DropIndex("dbo.VideoSettings", new[] { "VideoAttributes_Id" });
            DropIndex("dbo.VideoAttributes", new[] { "UserId" });
            DropIndex("dbo.VideoAttributes", new[] { "VideoSettingsId" });
            DropIndex("dbo.VideoAttributes", new[] { "LanguageId" });
            DropIndex("dbo.VideoAttributes", new[] { "CategoryId" });
            DropIndex("dbo.PrivateVideoExtends", new[] { "VideoAttributeId" });
            DropIndex("dbo.PrivateVideoExtends", new[] { "ToUserId" });
            DropIndex("dbo.PrivateVideoExtends", new[] { "FromUserId" });
            DropIndex("dbo.PrivateMessages", new[] { "ToUserId" });
            DropIndex("dbo.PrivateMessages", new[] { "FromUserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "VideoAttributesExtend_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserProfileExtend_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PrivateVideoExtend_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "PrivateMessagesExtend_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.BannerDetails");
            DropTable("dbo.Log");
            DropTable("dbo.Newsletter");
            DropTable("dbo.ContactUs");
            DropTable("dbo.SubMenu");
            DropTable("dbo.MainMenu");
            DropTable("dbo.MenuAttribute");
            DropTable("dbo.UserSettings");
            DropTable("dbo.UserProfile");
            DropTable("dbo.VideoSettings");
            DropTable("dbo.Language");
            DropTable("dbo.Category");
            DropTable("dbo.VideoAttributes");
            DropTable("dbo.PrivateVideoExtends");
            DropTable("dbo.PrivateMessages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
