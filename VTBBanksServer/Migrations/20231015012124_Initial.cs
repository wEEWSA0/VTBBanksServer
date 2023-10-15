using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace VTBBanksServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankOffices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Rko = table.Column<string>(type: "text", nullable: true),
                    OfficeType = table.Column<string>(type: "text", nullable: true),
                    SalePointFormat = table.Column<string>(type: "text", nullable: true),
                    SuoAvailability = table.Column<string>(type: "text", nullable: true),
                    HasRamp = table.Column<string>(type: "text", nullable: true),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    MetroStation = table.Column<string>(type: "text", nullable: true),
                    Distance = table.Column<int>(type: "integer", nullable: false),
                    Kep = table.Column<bool>(type: "boolean", nullable: true),
                    MyBranch = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankOffices", x => new { x.Id, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "CashMachines",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<double>(type: "double precision", nullable: false),
                    Longitude = table.Column<double>(type: "double precision", nullable: false),
                    AllDay = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashMachines", x => new { x.Id, x.Address });
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankOfficeWorkloads",
                columns: table => new
                {
                    BankOfficeId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BankOfficeName = table.Column<string>(type: "text", nullable: true),
                    OperationsCount = table.Column<int>(type: "integer", nullable: false),
                    PeopleVisited = table.Column<int>(type: "integer", nullable: false),
                    PeopleLeft = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankOfficeWorkloads", x => new { x.BankOfficeId, x.Date });
                    table.ForeignKey(
                        name: "FK_BankOfficeWorkloads_BankOffices_BankOfficeId_BankOfficeName",
                        columns: x => new { x.BankOfficeId, x.BankOfficeName },
                        principalTable: "BankOffices",
                        principalColumns: new[] { "Id", "Name" });
                });

            migrationBuilder.CreateTable(
                name: "FavouriteBankOffices",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BankOfficeId = table.Column<long>(type: "bigint", nullable: false),
                    BankOfficeName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteBankOffices", x => new { x.UserId, x.BankOfficeId });
                    table.ForeignKey(
                        name: "FK_FavouriteBankOffices_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteBankOffices_BankOffices_BankOfficeId_BankOfficeName",
                        columns: x => new { x.BankOfficeId, x.BankOfficeName },
                        principalTable: "BankOffices",
                        principalColumns: new[] { "Id", "Name" });
                });

            migrationBuilder.CreateTable(
                name: "OpenHours",
                columns: table => new
                {
                    SalePointId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    SalePointName = table.Column<string>(type: "text", nullable: true),
                    OpenHour = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    CloseHour = table.Column<TimeOnly>(type: "time without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenHours", x => new { x.SalePointId, x.Type, x.Day });
                    table.ForeignKey(
                        name: "FK_OpenHours_BankOffices_SalePointId_SalePointName",
                        columns: x => new { x.SalePointId, x.SalePointName },
                        principalTable: "BankOffices",
                        principalColumns: new[] { "Id", "Name" });
                });

            migrationBuilder.CreateTable(
                name: "CashMachineAmenities",
                columns: table => new
                {
                    CashMachineId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Capability = table.Column<bool>(type: "boolean", nullable: false),
                    Activity = table.Column<bool>(type: "boolean", nullable: false),
                    CashMachineAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashMachineAmenities", x => new { x.CashMachineId, x.Name });
                    table.ForeignKey(
                        name: "FK_CashMachineAmenities_CashMachines_CashMachineId_CashMachine~",
                        columns: x => new { x.CashMachineId, x.CashMachineAddress },
                        principalTable: "CashMachines",
                        principalColumns: new[] { "Id", "Address" });
                });

            migrationBuilder.CreateTable(
                name: "CashMachineWorkloads",
                columns: table => new
                {
                    CashMachineId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CashMachineAddress = table.Column<string>(type: "text", nullable: true),
                    OperationsCount = table.Column<int>(type: "integer", nullable: false),
                    PeopleVisited = table.Column<int>(type: "integer", nullable: false),
                    PeopleLeft = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CashMachineWorkloads", x => new { x.CashMachineId, x.Date });
                    table.ForeignKey(
                        name: "FK_CashMachineWorkloads_CashMachines_CashMachineId_CashMachine~",
                        columns: x => new { x.CashMachineId, x.CashMachineAddress },
                        principalTable: "CashMachines",
                        principalColumns: new[] { "Id", "Address" });
                });

            migrationBuilder.CreateTable(
                name: "FavouriteCashMachines",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    CashMachineId = table.Column<long>(type: "bigint", nullable: false),
                    CashMachineAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteCashMachines", x => new { x.UserId, x.CashMachineId });
                    table.ForeignKey(
                        name: "FK_FavouriteCashMachines_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteCashMachines_CashMachines_CashMachineId_CashMachin~",
                        columns: x => new { x.CashMachineId, x.CashMachineAddress },
                        principalTable: "CashMachines",
                        principalColumns: new[] { "Id", "Address" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BankOfficeWorkloads_BankOfficeId_BankOfficeName",
                table: "BankOfficeWorkloads",
                columns: new[] { "BankOfficeId", "BankOfficeName" });

            migrationBuilder.CreateIndex(
                name: "IX_CashMachineAmenities_CashMachineId_CashMachineAddress",
                table: "CashMachineAmenities",
                columns: new[] { "CashMachineId", "CashMachineAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_CashMachineWorkloads_CashMachineId_CashMachineAddress",
                table: "CashMachineWorkloads",
                columns: new[] { "CashMachineId", "CashMachineAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteBankOffices_BankOfficeId_BankOfficeName",
                table: "FavouriteBankOffices",
                columns: new[] { "BankOfficeId", "BankOfficeName" });

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteCashMachines_CashMachineId_CashMachineAddress",
                table: "FavouriteCashMachines",
                columns: new[] { "CashMachineId", "CashMachineAddress" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenHours_SalePointId_SalePointName",
                table: "OpenHours",
                columns: new[] { "SalePointId", "SalePointName" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BankOfficeWorkloads");

            migrationBuilder.DropTable(
                name: "CashMachineAmenities");

            migrationBuilder.DropTable(
                name: "CashMachineWorkloads");

            migrationBuilder.DropTable(
                name: "FavouriteBankOffices");

            migrationBuilder.DropTable(
                name: "FavouriteCashMachines");

            migrationBuilder.DropTable(
                name: "OpenHours");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CashMachines");

            migrationBuilder.DropTable(
                name: "BankOffices");
        }
    }
}
