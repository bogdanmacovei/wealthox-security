using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wealthox.DataAccess.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ConstructionMaterial",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ConstructionMaterial", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Counties",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        Name = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Counties", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Filters",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Price = table.Column<int>(nullable: true),
            //        City = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
            //        County = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
            //        BedroomsNumber = table.Column<int>(nullable: true),
            //        BathroomsNumber = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Filters", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Role",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Name = table.Column<string>(unicode: false, maxLength: 255, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Role", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Search_Filters",
            //    columns: table => new
            //    {
            //        SearchId = table.Column<Guid>(nullable: false),
            //        FilterId = table.Column<Guid>(nullable: false),
            //        SearchDate = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Search_Filters", x => new { x.SearchId, x.FilterId });
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Cities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false),
            //        CountyId = table.Column<int>(nullable: true),
            //        Name = table.Column<string>(maxLength: 100, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cities", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_CityCounties",
            //            column: x => x.CountyId,
            //            principalTable: "Counties",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Users",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        FirstName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
            //        LastName = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
            //        Email = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
            //        RegisterDate = table.Column<DateTime>(type: "date", nullable: true),
            //        DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
            //        RoleId = table.Column<Guid>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Users", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserRole",
            //            column: x => x.RoleId,
            //            principalTable: "Role",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "House",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        Surface = table.Column<int>(nullable: true),
            //        BedroomsNumber = table.Column<int>(nullable: true),
            //        BathroomsNumber = table.Column<int>(nullable: true),
            //        HasElectricity = table.Column<bool>(nullable: true),
            //        HasHeating = table.Column<bool>(nullable: true),
            //        HasGarage = table.Column<bool>(nullable: true),
            //        CountyId = table.Column<int>(nullable: true),
            //        CityId = table.Column<int>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_House", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_HouseCity",
            //            column: x => x.CityId,
            //            principalTable: "Cities",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_HouseCounty",
            //            column: x => x.CountyId,
            //            principalTable: "Counties",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SearchHistory",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        UserId = table.Column<Guid>(nullable: true),
            //        SearchDate = table.Column<DateTime>(type: "date", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_SearchHistory", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_UserSearch",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Announcements",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(nullable: false),
            //        UserId = table.Column<Guid>(nullable: true),
            //        HouseId = table.Column<Guid>(nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Announcements", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_AnnouncementHouse",
            //            column: x => x.HouseId,
            //            principalTable: "House",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_UserAnnouncement",
            //            column: x => x.UserId,
            //            principalTable: "Users",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "House_ConstructionMaterial",
            //    columns: table => new
            //    {
            //        HouseId = table.Column<Guid>(nullable: false),
            //        ConstructionMaterialId = table.Column<Guid>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_House_ConstructionMaterial", x => new { x.HouseId, x.ConstructionMaterialId });
            //        table.ForeignKey(
            //            name: "FK_ConstructionHouse",
            //            column: x => x.ConstructionMaterialId,
            //            principalTable: "ConstructionMaterial",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_HouseConstruction",
            //            column: x => x.HouseId,
            //            principalTable: "House",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Announcements_HouseId",
            //    table: "Announcements",
            //    column: "HouseId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Announcements_UserId",
            //    table: "Announcements",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cities_CountyId",
            //    table: "Cities",
            //    column: "CountyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_House_CityId",
            //    table: "House",
            //    column: "CityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_House_CountyId",
            //    table: "House",
            //    column: "CountyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_House_ConstructionMaterial_ConstructionMaterialId",
            //    table: "House_ConstructionMaterial",
            //    column: "ConstructionMaterialId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SearchHistory_UserId",
            //    table: "SearchHistory",
            //    column: "UserId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Users_RoleId",
            //    table: "Users",
            //    column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Filters");

            migrationBuilder.DropTable(
                name: "House_ConstructionMaterial");

            migrationBuilder.DropTable(
                name: "Search_Filters");

            migrationBuilder.DropTable(
                name: "SearchHistory");

            migrationBuilder.DropTable(
                name: "ConstructionMaterial");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Counties");
        }
    }
}
