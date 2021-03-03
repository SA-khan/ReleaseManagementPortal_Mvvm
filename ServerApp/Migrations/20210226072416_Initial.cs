using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppArchitypes",
                columns: table => new
                {
                    AppArchitypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppArchitypes", x => x.AppArchitypeId);
                });

            migrationBuilder.CreateTable(
                name: "ClientBrowsers",
                columns: table => new
                {
                    ClientBrowserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBrowsers", x => x.ClientBrowserId);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseServer",
                columns: table => new
                {
                    DatabaseServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Domain = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    isRemote = table.Column<bool>(nullable: false),
                    onCloud = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseServer", x => x.DatabaseServerId);
                });

            migrationBuilder.CreateTable(
                name: "DataLogFiles",
                columns: table => new
                {
                    DataLogFileId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataLogFiles", x => x.DataLogFileId);
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentTypes",
                columns: table => new
                {
                    EnvironmentTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentTypes", x => x.EnvironmentTypeId);
                });

            migrationBuilder.CreateTable(
                name: "HealthChecks",
                columns: table => new
                {
                    HealthCheckId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ReferenceLink = table.Column<string>(nullable: true),
                    Directory = table.Column<string>(nullable: true),
                    Passed = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthChecks", x => x.HealthCheckId);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    IndustryId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.IndustryId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ISO2 = table.Column<string>(maxLength: 2, nullable: true),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: true),
                    Example = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "MailServer",
                columns: table => new
                {
                    MailServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<long>(nullable: false),
                    isSMTP = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServer", x => x.MailServerId);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    OperatingSystemId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    CompatibilityMode = table.Column<string>(nullable: true),
                    Build = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.OperatingSystemId);
                });

            migrationBuilder.CreateTable(
                name: "PasswordPolicies",
                columns: table => new
                {
                    PasswordPolicyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CapitalLetter = table.Column<long>(nullable: false),
                    SmallLetter = table.Column<long>(nullable: false),
                    Number = table.Column<long>(nullable: false),
                    SpecialLetter = table.Column<long>(nullable: false),
                    Example = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordPolicies", x => x.PasswordPolicyId);
                });

            migrationBuilder.CreateTable(
                name: "PrintServer",
                columns: table => new
                {
                    PrintServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<long>(nullable: false),
                    isSMTP = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintServer", x => x.PrintServerId);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProductTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Code = table.Column<long>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Enabled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProductTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ISO2 = table.Column<string>(maxLength: 2, nullable: true),
                    ISO3 = table.Column<string>(maxLength: 3, nullable: true),
                    OfficialName = table.Column<string>(nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "ServerTypes",
                columns: table => new
                {
                    ServerTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerTypes", x => x.ServerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    ThemeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ThemeCode = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.ThemeId);
                });

            migrationBuilder.CreateTable(
                name: "WebBrowsers",
                columns: table => new
                {
                    WebServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebBrowsers", x => x.WebServerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    LoginName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneExtension = table.Column<long>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    ClientPoc = table.Column<bool>(nullable: false),
                    Processed = table.Column<bool>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    LoggedIn = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: false),
                    CurrentPassword = table.Column<string>(nullable: true),
                    WrongAttemptCount = table.Column<int>(nullable: false),
                    LastPassword1 = table.Column<string>(nullable: true),
                    LastPassword2 = table.Column<string>(nullable: true),
                    LastPassword3 = table.Column<string>(nullable: true),
                    LastPassword4 = table.Column<string>(nullable: true),
                    PasswordPolicyId = table.Column<long>(nullable: true),
                    Question1QuestionId = table.Column<long>(nullable: true),
                    Answer1 = table.Column<string>(nullable: true),
                    Question2QuestionId = table.Column<long>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true),
                    Question3QuestionId = table.Column<long>(nullable: true),
                    Answer3 = table.Column<string>(nullable: true),
                    ChangePasswordDate = table.Column<DateTime>(nullable: false),
                    LanguageId = table.Column<long>(nullable: true),
                    ThemeId = table.Column<long>(nullable: true),
                    RegionId = table.Column<long>(nullable: true),
                    TermsAgreeed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_PasswordPolicies_PasswordPolicyId",
                        column: x => x.PasswordPolicyId,
                        principalTable: "PasswordPolicies",
                        principalColumn: "PasswordPolicyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Questions_Question1QuestionId",
                        column: x => x.Question1QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Questions_Question2QuestionId",
                        column: x => x.Question2QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Questions_Question3QuestionId",
                        column: x => x.Question3QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "ThemeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TagLine = table.Column<string>(nullable: true),
                    IndustryId = table.Column<long>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Ntn = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Still = table.Column<bool>(nullable: false),
                    TechnicalPocUserId = table.Column<long>(nullable: true),
                    OperationalPocUserId = table.Column<long>(nullable: true),
                    ProjectPocUserId = table.Column<long>(nullable: true),
                    FinancialPocUserId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                    table.ForeignKey(
                        name: "FK_Companies_Users_FinancialPocUserId",
                        column: x => x.FinancialPocUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "IndustryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_OperationalPocUserId",
                        column: x => x.OperationalPocUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_ProjectPocUserId",
                        column: x => x.ProjectPocUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Companies_Users_TechnicalPocUserId",
                        column: x => x.TechnicalPocUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HybridServer",
                columns: table => new
                {
                    HybridServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    WebServerName = table.Column<string>(nullable: true),
                    WebServerVersion = table.Column<string>(nullable: true),
                    WebServerDescription = table.Column<string>(nullable: true),
                    DatabaseServerName = table.Column<string>(nullable: true),
                    DatabaseServerIp = table.Column<string>(nullable: true),
                    DatabaseServerPort = table.Column<string>(nullable: true),
                    DatabaseServerInstance = table.Column<string>(nullable: true),
                    DatabaseServerInitialCatalog = table.Column<string>(nullable: true),
                    DatabaseServerUserId = table.Column<string>(nullable: true),
                    DatabaseServerPassword = table.Column<string>(nullable: true),
                    DatabaseServerMdfInformationDataLogFileId = table.Column<long>(nullable: true),
                    DatabaseServerLdfInformationDataLogFileId = table.Column<long>(nullable: true),
                    DatabaseServerLastBackUpDate = table.Column<DateTime>(nullable: false),
                    DatabaseServerBackUpFileName = table.Column<string>(nullable: true),
                    DatabaseServerBackUpFileLocation = table.Column<string>(nullable: true),
                    DatabaseServerBackupTakenPOCUserId = table.Column<long>(nullable: true),
                    DatabaseServerLastRestoredDate = table.Column<DateTime>(nullable: false),
                    DatabaseServerRestoredFileName = table.Column<string>(nullable: true),
                    DatabaseServerRestoredPOCUserId = table.Column<long>(nullable: true),
                    DatabaseServerComments = table.Column<string>(nullable: true),
                    MailServerName = table.Column<string>(nullable: true),
                    MailServerIp = table.Column<string>(nullable: true),
                    MailServerPort = table.Column<long>(nullable: false),
                    MailServerisSMTP = table.Column<bool>(nullable: false),
                    MailServerAddress = table.Column<string>(nullable: true),
                    MailServerEmailId = table.Column<string>(nullable: true),
                    MailServerPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HybridServer", x => x.HybridServerId);
                    table.ForeignKey(
                        name: "FK_HybridServer_Users_DatabaseServerBackupTakenPOCUserId",
                        column: x => x.DatabaseServerBackupTakenPOCUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HybridServer_DataLogFiles_DatabaseServerLdfInformationDataLogFileId",
                        column: x => x.DatabaseServerLdfInformationDataLogFileId,
                        principalTable: "DataLogFiles",
                        principalColumn: "DataLogFileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HybridServer_DataLogFiles_DatabaseServerMdfInformationDataLogFileId",
                        column: x => x.DatabaseServerMdfInformationDataLogFileId,
                        principalTable: "DataLogFiles",
                        principalColumn: "DataLogFileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HybridServer_Users_DatabaseServerRestoredPOCUserId",
                        column: x => x.DatabaseServerRestoredPOCUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParentProducts",
                columns: table => new
                {
                    ParentProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    TagLine = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserManualLink = table.Column<string>(nullable: true),
                    MainPocUserId = table.Column<long>(nullable: true),
                    TeamName = table.Column<string>(nullable: true),
                    TeamQuantity = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentProducts", x => x.ParentProductId);
                    table.ForeignKey(
                        name: "FK_ParentProducts_Users_MainPocUserId",
                        column: x => x.MainPocUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QualityAssurances",
                columns: table => new
                {
                    QualityAssuranceId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PerformedByUserId = table.Column<long>(nullable: true),
                    VerifiedByUserId = table.Column<long>(nullable: true),
                    isPassed = table.Column<bool>(nullable: false),
                    DocumentationLink = table.Column<string>(nullable: true),
                    DocumentLocation = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityAssurances", x => x.QualityAssuranceId);
                    table.ForeignKey(
                        name: "FK_QualityAssurances_Users_PerformedByUserId",
                        column: x => x.PerformedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QualityAssurances_Users_VerifiedByUserId",
                        column: x => x.VerifiedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Financials",
                columns: table => new
                {
                    CompanyFinancialId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financials", x => x.CompanyFinancialId);
                    table.ForeignKey(
                        name: "FK_Financials_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerTypeId = table.Column<long>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Ip = table.Column<string>(nullable: true),
                    Port = table.Column<long>(nullable: false),
                    Domain = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    isRemoteBased = table.Column<bool>(nullable: false),
                    isVirtualized = table.Column<bool>(nullable: false),
                    isCloudBased = table.Column<bool>(nullable: false),
                    Processor = table.Column<string>(nullable: true),
                    Memory = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Dependency = table.Column<string>(nullable: true),
                    isAppServer = table.Column<bool>(nullable: false),
                    isWebServer = table.Column<bool>(nullable: false),
                    isDNSServer = table.Column<bool>(nullable: false),
                    isProxyServer = table.Column<bool>(nullable: false),
                    isDatabaseServer = table.Column<bool>(nullable: false),
                    isMailServer = table.Column<bool>(nullable: false),
                    isFileServer = table.Column<bool>(nullable: false),
                    isPrintServer = table.Column<bool>(nullable: false),
                    isMonitoringServer = table.Column<bool>(nullable: false),
                    isHybridServer = table.Column<bool>(nullable: false),
                    WebServerSupportWebServerId = table.Column<long>(nullable: true),
                    DatabaseServerSupportDatabaseServerId = table.Column<long>(nullable: true),
                    MailServerSupportMailServerId = table.Column<long>(nullable: true),
                    PrintServerSupportPrintServerId = table.Column<long>(nullable: true),
                    HybridServerSupportHybridServerId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                    table.ForeignKey(
                        name: "FK_Servers_DatabaseServer_DatabaseServerSupportDatabaseServerId",
                        column: x => x.DatabaseServerSupportDatabaseServerId,
                        principalTable: "DatabaseServer",
                        principalColumn: "DatabaseServerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servers_HybridServer_HybridServerSupportHybridServerId",
                        column: x => x.HybridServerSupportHybridServerId,
                        principalTable: "HybridServer",
                        principalColumn: "HybridServerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servers_MailServer_MailServerSupportMailServerId",
                        column: x => x.MailServerSupportMailServerId,
                        principalTable: "MailServer",
                        principalColumn: "MailServerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servers_PrintServer_PrintServerSupportPrintServerId",
                        column: x => x.PrintServerSupportPrintServerId,
                        principalTable: "PrintServer",
                        principalColumn: "PrintServerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servers_ServerTypes_ServerTypeId",
                        column: x => x.ServerTypeId,
                        principalTable: "ServerTypes",
                        principalColumn: "ServerTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Servers_WebBrowsers_WebServerSupportWebServerId",
                        column: x => x.WebServerSupportWebServerId,
                        principalTable: "WebBrowsers",
                        principalColumn: "WebServerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    TypeProductTypeId = table.Column<long>(nullable: true),
                    ParentProductId = table.Column<long>(nullable: true),
                    SupplierId = table.Column<long>(nullable: true),
                    Updated = table.Column<bool>(nullable: false),
                    ReleaseNotes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_ParentProducts_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "ParentProducts",
                        principalColumn: "ParentProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_TypeProductTypeId",
                        column: x => x.TypeProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClientBrowserSupport",
                columns: table => new
                {
                    ClientBrowserSupportId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrowserClientBrowserId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientBrowserSupport", x => x.ClientBrowserSupportId);
                    table.ForeignKey(
                        name: "FK_ClientBrowserSupport_ClientBrowsers_BrowserClientBrowserId",
                        column: x => x.BrowserClientBrowserId,
                        principalTable: "ClientBrowsers",
                        principalColumn: "ClientBrowserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientBrowserSupport_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Environments",
                columns: table => new
                {
                    EnvironmentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ServerId = table.Column<long>(nullable: true),
                    OperatingSystemId = table.Column<long>(nullable: true),
                    WebServerId = table.Column<long>(nullable: true),
                    ApplicationHyperLink = table.Column<string>(nullable: true),
                    WorkingDirectory = table.Column<string>(nullable: true),
                    Dependency = table.Column<string>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    EnvironmentTypeId = table.Column<long>(nullable: true),
                    Main = table.Column<bool>(nullable: false),
                    Dockerized = table.Column<bool>(nullable: false),
                    DockerImage = table.Column<string>(nullable: true),
                    DockerDescription = table.Column<string>(nullable: true),
                    Updated = table.Column<bool>(nullable: false),
                    LastHealthCheckHealthCheckId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    Logo = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Environments", x => x.EnvironmentId);
                    table.ForeignKey(
                        name: "FK_Environments_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_EnvironmentTypes_EnvironmentTypeId",
                        column: x => x.EnvironmentTypeId,
                        principalTable: "EnvironmentTypes",
                        principalColumn: "EnvironmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_HealthChecks_LastHealthCheckHealthCheckId",
                        column: x => x.LastHealthCheckHealthCheckId,
                        principalTable: "HealthChecks",
                        principalColumn: "HealthCheckId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "OperatingSystemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Environments_WebBrowsers_WebServerId",
                        column: x => x.WebServerId,
                        principalTable: "WebBrowsers",
                        principalColumn: "WebServerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrerequisites",
                columns: table => new
                {
                    ProductPrerequisiteId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<long>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Details = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Dependency = table.Column<string>(nullable: true),
                    ProductId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrerequisites", x => x.ProductPrerequisiteId);
                    table.ForeignKey(
                        name: "FK_ProductPrerequisites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(nullable: true),
                    IsCompany = table.Column<bool>(nullable: false),
                    IsProduct = table.Column<bool>(nullable: false),
                    Stars = table.Column<int>(nullable: false),
                    CompanyId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apis",
                columns: table => new
                {
                    ApiId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    TagLine = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EnvironmentId = table.Column<long>(nullable: true),
                    Main = table.Column<bool>(nullable: false),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apis", x => x.ApiId);
                    table.ForeignKey(
                        name: "FK_Apis_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnvironmentId = table.Column<long>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Likes = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Databases",
                columns: table => new
                {
                    DatabaseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    EnvironmentTypeId = table.Column<long>(nullable: true),
                    Main = table.Column<bool>(nullable: false),
                    ServerId = table.Column<long>(nullable: true),
                    MdfInformationDataLogFileId = table.Column<long>(nullable: true),
                    LdfInformationDataLogFileId = table.Column<long>(nullable: true),
                    LastBackUpDate = table.Column<DateTime>(nullable: false),
                    BackUpFileName = table.Column<string>(nullable: true),
                    BackUpFileLocation = table.Column<string>(nullable: true),
                    BackupTakenPOCUserId = table.Column<long>(nullable: true),
                    LastRestoredDate = table.Column<DateTime>(nullable: false),
                    RestoredFileName = table.Column<string>(nullable: true),
                    RestoredPOCUserId = table.Column<long>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    EnvironmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Databases", x => x.DatabaseId);
                    table.ForeignKey(
                        name: "FK_Databases_Users_BackupTakenPOCUserId",
                        column: x => x.BackupTakenPOCUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_EnvironmentTypes_EnvironmentTypeId",
                        column: x => x.EnvironmentTypeId,
                        principalTable: "EnvironmentTypes",
                        principalColumn: "EnvironmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_DataLogFiles_LdfInformationDataLogFileId",
                        column: x => x.LdfInformationDataLogFileId,
                        principalTable: "DataLogFiles",
                        principalColumn: "DataLogFileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_DataLogFiles_MdfInformationDataLogFileId",
                        column: x => x.MdfInformationDataLogFileId,
                        principalTable: "DataLogFiles",
                        principalColumn: "DataLogFileId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_Users_RestoredPOCUserId",
                        column: x => x.RestoredPOCUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Databases_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "ServerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Releases",
                columns: table => new
                {
                    ReleaseId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PatchNumber = table.Column<string>(nullable: true),
                    DevelopedByUserId = table.Column<long>(nullable: true),
                    DeployedByUserId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    DeployedDate = table.Column<DateTime>(nullable: false),
                    QualityAssuranceId = table.Column<long>(nullable: true),
                    CompanyId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    EnvironmentId = table.Column<long>(nullable: true),
                    EnvironmentTypeId = table.Column<long>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Releases", x => x.ReleaseId);
                    table.ForeignKey(
                        name: "FK_Releases_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_Users_DeployedByUserId",
                        column: x => x.DeployedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_Users_DevelopedByUserId",
                        column: x => x.DevelopedByUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_Environments_EnvironmentId",
                        column: x => x.EnvironmentId,
                        principalTable: "Environments",
                        principalColumn: "EnvironmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_EnvironmentTypes_EnvironmentTypeId",
                        column: x => x.EnvironmentTypeId,
                        principalTable: "EnvironmentTypes",
                        principalColumn: "EnvironmentTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Releases_QualityAssurances_QualityAssuranceId",
                        column: x => x.QualityAssuranceId,
                        principalTable: "QualityAssurances",
                        principalColumn: "QualityAssuranceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystemSupport",
                columns: table => new
                {
                    OperatingSystemSupportId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatingSystemId = table.Column<long>(nullable: true),
                    ProductId = table.Column<long>(nullable: true),
                    ProductPrerequisiteId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystemSupport", x => x.OperatingSystemSupportId);
                    table.ForeignKey(
                        name: "FK_OperatingSystemSupport_OperatingSystems_OperatingSystemId",
                        column: x => x.OperatingSystemId,
                        principalTable: "OperatingSystems",
                        principalColumn: "OperatingSystemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperatingSystemSupport_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OperatingSystemSupport_ProductPrerequisites_ProductPrerequisiteId",
                        column: x => x.ProductPrerequisiteId,
                        principalTable: "ProductPrerequisites",
                        principalColumn: "ProductPrerequisiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Apis_EnvironmentId",
                table: "Apis",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBrowserSupport_BrowserClientBrowserId",
                table: "ClientBrowserSupport",
                column: "BrowserClientBrowserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientBrowserSupport_ProductId",
                table: "ClientBrowserSupport",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_EnvironmentId",
                table: "Comments",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_FinancialPocUserId",
                table: "Companies",
                column: "FinancialPocUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_OperationalPocUserId",
                table: "Companies",
                column: "OperationalPocUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProjectPocUserId",
                table: "Companies",
                column: "ProjectPocUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TechnicalPocUserId",
                table: "Companies",
                column: "TechnicalPocUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_BackupTakenPOCUserId",
                table: "Databases",
                column: "BackupTakenPOCUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_CompanyId",
                table: "Databases",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_EnvironmentId",
                table: "Databases",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_EnvironmentTypeId",
                table: "Databases",
                column: "EnvironmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_LdfInformationDataLogFileId",
                table: "Databases",
                column: "LdfInformationDataLogFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_MdfInformationDataLogFileId",
                table: "Databases",
                column: "MdfInformationDataLogFileId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_ProductId",
                table: "Databases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_RestoredPOCUserId",
                table: "Databases",
                column: "RestoredPOCUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Databases_ServerId",
                table: "Databases",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_CompanyId",
                table: "Environments",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_EnvironmentTypeId",
                table: "Environments",
                column: "EnvironmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_LastHealthCheckHealthCheckId",
                table: "Environments",
                column: "LastHealthCheckHealthCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_OperatingSystemId",
                table: "Environments",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_ProductId",
                table: "Environments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_ServerId",
                table: "Environments",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Environments_WebServerId",
                table: "Environments",
                column: "WebServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Financials_CompanyId",
                table: "Financials",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_HybridServer_DatabaseServerBackupTakenPOCUserId",
                table: "HybridServer",
                column: "DatabaseServerBackupTakenPOCUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HybridServer_DatabaseServerLdfInformationDataLogFileId",
                table: "HybridServer",
                column: "DatabaseServerLdfInformationDataLogFileId");

            migrationBuilder.CreateIndex(
                name: "IX_HybridServer_DatabaseServerMdfInformationDataLogFileId",
                table: "HybridServer",
                column: "DatabaseServerMdfInformationDataLogFileId");

            migrationBuilder.CreateIndex(
                name: "IX_HybridServer_DatabaseServerRestoredPOCUserId",
                table: "HybridServer",
                column: "DatabaseServerRestoredPOCUserId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystemSupport_OperatingSystemId",
                table: "OperatingSystemSupport",
                column: "OperatingSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystemSupport_ProductId",
                table: "OperatingSystemSupport",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatingSystemSupport_ProductPrerequisiteId",
                table: "OperatingSystemSupport",
                column: "ProductPrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentProducts_MainPocUserId",
                table: "ParentProducts",
                column: "MainPocUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrerequisites_ProductId",
                table: "ProductPrerequisites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentProductId",
                table: "Products",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SupplierId",
                table: "Products",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TypeProductTypeId",
                table: "Products",
                column: "TypeProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityAssurances_PerformedByUserId",
                table: "QualityAssurances",
                column: "PerformedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityAssurances_VerifiedByUserId",
                table: "QualityAssurances",
                column: "VerifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_CompanyId",
                table: "Ratings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ProductId",
                table: "Ratings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_CompanyId",
                table: "Releases",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_DeployedByUserId",
                table: "Releases",
                column: "DeployedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_DevelopedByUserId",
                table: "Releases",
                column: "DevelopedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EnvironmentId",
                table: "Releases",
                column: "EnvironmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_EnvironmentTypeId",
                table: "Releases",
                column: "EnvironmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_ProductId",
                table: "Releases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Releases_QualityAssuranceId",
                table: "Releases",
                column: "QualityAssuranceId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_DatabaseServerSupportDatabaseServerId",
                table: "Servers",
                column: "DatabaseServerSupportDatabaseServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_HybridServerSupportHybridServerId",
                table: "Servers",
                column: "HybridServerSupportHybridServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_MailServerSupportMailServerId",
                table: "Servers",
                column: "MailServerSupportMailServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_PrintServerSupportPrintServerId",
                table: "Servers",
                column: "PrintServerSupportPrintServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_ServerTypeId",
                table: "Servers",
                column: "ServerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Servers_WebServerSupportWebServerId",
                table: "Servers",
                column: "WebServerSupportWebServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LanguageId",
                table: "Users",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PasswordPolicyId",
                table: "Users",
                column: "PasswordPolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Question1QuestionId",
                table: "Users",
                column: "Question1QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Question2QuestionId",
                table: "Users",
                column: "Question2QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Question3QuestionId",
                table: "Users",
                column: "Question3QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RegionId",
                table: "Users",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ThemeId",
                table: "Users",
                column: "ThemeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apis");

            migrationBuilder.DropTable(
                name: "AppArchitypes");

            migrationBuilder.DropTable(
                name: "ClientBrowserSupport");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Databases");

            migrationBuilder.DropTable(
                name: "Financials");

            migrationBuilder.DropTable(
                name: "OperatingSystemSupport");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Releases");

            migrationBuilder.DropTable(
                name: "ClientBrowsers");

            migrationBuilder.DropTable(
                name: "ProductPrerequisites");

            migrationBuilder.DropTable(
                name: "Environments");

            migrationBuilder.DropTable(
                name: "QualityAssurances");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "EnvironmentTypes");

            migrationBuilder.DropTable(
                name: "HealthChecks");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Servers");

            migrationBuilder.DropTable(
                name: "Industries");

            migrationBuilder.DropTable(
                name: "ParentProducts");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "DatabaseServer");

            migrationBuilder.DropTable(
                name: "HybridServer");

            migrationBuilder.DropTable(
                name: "MailServer");

            migrationBuilder.DropTable(
                name: "PrintServer");

            migrationBuilder.DropTable(
                name: "ServerTypes");

            migrationBuilder.DropTable(
                name: "WebBrowsers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DataLogFiles");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "PasswordPolicies");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Themes");
        }
    }
}
