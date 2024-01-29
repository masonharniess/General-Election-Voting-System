using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GEVSAPI4.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConstituencyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstituencyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElectionEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartyEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UvcEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UniqueVoterCode = table.Column<string>(type: "TEXT", nullable: false),
                    isUsed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UvcEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CandidateEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ConstituencyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartyId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateEntities_ConstituencyEntities_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "ConstituencyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateEntities_PartyEntities_PartyId",
                        column: x => x.PartyId,
                        principalTable: "PartyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DoB = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    RoleId = table.Column<Guid>(type: "TEXT", nullable: false),
                    ConstituencyId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UvcId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEntities_ConstituencyEntities_ConstituencyId",
                        column: x => x.ConstituencyId,
                        principalTable: "ConstituencyEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEntities_RoleEntities_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RoleEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEntities_UvcEntities_UvcId",
                        column: x => x.UvcId,
                        principalTable: "UvcEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoteEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CandidateId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoteEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoteEntities_CandidateEntities_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "CandidateEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VoteEntities_UserEntities_UserId",
                        column: x => x.UserId,
                        principalTable: "UserEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ConstituencyEntities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("15afd41c-99f5-4b66-b1f8-12980103c583"), "Northern-Kunlun-Mountain" },
                    { new Guid("2eb9e977-d88d-4f15-b7a1-49a98be60ef7"), "Shangri-la-Town" },
                    { new Guid("35745314-d6bc-43dd-b108-b1e793126b0a"), "Naboo-Vallery" },
                    { new Guid("9a876053-f634-40da-94c3-aed77b7c5e64"), "Western-Shangri-la" },
                    { new Guid("f9c66b4e-ab57-4bc7-a8e0-632fefcf9842"), "New-Felucia" }
                });

            migrationBuilder.InsertData(
                table: "PartyEntities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("179c885c-7ffd-4540-a579-2e58a9fb3afe"), "Red Party" },
                    { new Guid("3baceb86-1e40-4e57-a848-c2a0d83d5d0b"), "Yellow Party" },
                    { new Guid("b2f8deab-fcc3-4d66-aa7b-3104d0fe14a1"), "Independent" },
                    { new Guid("ec1cd589-3006-46c1-ae7b-f3ef28b758cb"), "Blue Party" }
                });

            migrationBuilder.InsertData(
                table: "RoleEntities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("c8a458ed-01ad-47fe-bdcf-86eb7cc25bb7"), "Admin" },
                    { new Guid("ee137f00-1c56-49e4-83f8-02c336a287d9"), "Voter" }
                });

            migrationBuilder.InsertData(
                table: "UvcEntities",
                columns: new[] { "Id", "UniqueVoterCode", "isUsed" },
                values: new object[,]
                {
                    { new Guid("04817f32-d32c-4450-814f-174733dd3dd3"), "BQCRWTSG", false },
                    { new Guid("07cb227e-8421-454d-a8a7-86c1e6527638"), "9GTZQNKB", false },
                    { new Guid("0b76de0f-fa5d-4900-be02-4d56023d0167"), "WL3K3YPT", false },
                    { new Guid("0d0a2d55-2a26-4df1-9be3-93845cb9b6d9"), "UMT3RLVS", false },
                    { new Guid("0dbfa013-0c64-46a3-9931-d6356fed73e6"), "UVE5M7FR", false },
                    { new Guid("114c1808-61eb-4a8e-a85d-2edc89fb8560"), "UNP4A5T7", false },
                    { new Guid("19bebef6-a7eb-4ba5-8497-1093624f92ea"), "JF2QD3UF", false },
                    { new Guid("22495351-1b44-4df4-a48c-b6993ba3b495"), "B7DMPWCQ", false },
                    { new Guid("257edd96-5b41-4040-a551-6982c59b4be0"), "Z93G7PN9", false },
                    { new Guid("2b6b4548-625c-4f78-a8d9-4ee6d13803e6"), "2TEHRTHJ", false },
                    { new Guid("2e00c994-01be-4c24-a57f-e8aaebcb81d2"), "W44QP7XJ", false },
                    { new Guid("34d8bb09-65d8-49c7-8794-0cf4cfdd4f65"), "YADA47RL", false },
                    { new Guid("439e7f57-3734-40e4-83d2-5435cf64804e"), "D5BG6FDH", false },
                    { new Guid("44b528dd-2115-4486-8e60-6895dba6414a"), "HH64FWPE", true },
                    { new Guid("4d9d80ec-6bc6-4281-a8cb-7c824aefbb5e"), "38NWLPY3", false },
                    { new Guid("519bb968-8239-40d3-9f5e-002fb6ecb919"), "BKMKJN5S", false },
                    { new Guid("5b533fd2-12bf-4918-bd27-d560b002fd42"), "PFXB8QXM", false },
                    { new Guid("629d1c3a-dfcb-47b6-8147-8999643807a1"), "TZZZCJV8", false },
                    { new Guid("6dd0f28a-d743-4644-a008-1126afa9f246"), "ML5NSKKG", false },
                    { new Guid("7544cabc-778c-4187-9010-e20057addeee"), "N6HBFD2X", false },
                    { new Guid("75a26b60-09aa-4583-a2bb-f04904725d6e"), "NW9ETHS7", false },
                    { new Guid("766c8f47-7e91-4ba2-a18a-0c163cd3b51d"), "556JTA32", false },
                    { new Guid("7937cf6d-9922-4056-ba77-d1d8ff5e8b2c"), "G994LD9T", false },
                    { new Guid("79ef12c5-6bb9-475e-9db0-e1b28cb3febb"), "DHKVCU8T", false },
                    { new Guid("81736bc7-e63f-49e2-94b6-a39002ffd8ee"), "KYMK9PUH", false },
                    { new Guid("824112f6-36a8-4ded-8f65-f9ee8715a731"), "75NKUXAH", false },
                    { new Guid("853b8de3-37ec-40d3-9219-6b0c2b171711"), "WPC5GEHA", false },
                    { new Guid("855b9499-f465-406c-b4fa-714cd7be80a0"), "LVTFN8G5", false },
                    { new Guid("966b4b19-cf07-4f39-8491-42acfe969de6"), "JA9WCMAS", false },
                    { new Guid("96d52486-ebe6-4b82-b809-d49fe270c23f"), "TH9A6HUB", false },
                    { new Guid("9bf2eab4-3c03-4b34-b9c6-2054831b00c9"), "U5LGC65X", false },
                    { new Guid("9f3932f9-ba1a-4bf8-8fe3-37431ae2d2a2"), "8TEXF2HD", false },
                    { new Guid("a4c568d0-b386-497f-af9a-0171f2eb2ef4"), "Q452KVQE", false },
                    { new Guid("a542c00d-53c0-4652-9711-acf5bfd3a7a3"), "K3EVS3NM", false },
                    { new Guid("be871292-398c-45eb-bd88-53e0b335f2a7"), "ZSRBTK9S", false },
                    { new Guid("bf37aa40-95a8-40ea-ab1d-0d9500f60698"), "K96JNSXY", false },
                    { new Guid("c4aee7a7-6b10-4f8f-b238-7c1931058d92"), "9FCV9RMT", false },
                    { new Guid("c5988e26-76ac-4c58-a89f-d5b11174be5b"), "KSM9NB5L", false },
                    { new Guid("d10ee694-1e75-499e-95ab-82b4df0c9d1b"), "DBP4GQBQ", false },
                    { new Guid("d2f0e1d6-4283-407e-9e2f-3006b5e28b9b"), "DBAD57ZR", false },
                    { new Guid("d3cf2421-da33-4136-887f-212931291022"), "5492AC6V", false },
                    { new Guid("da7beb0a-bf9b-4cd7-9a9e-88e2e39ed22a"), "7XUFD78Y", false },
                    { new Guid("e2192b4f-bd52-43ca-a4d1-3ac3a46f5dd1"), "2LJFM6PM", false },
                    { new Guid("eab693c2-6c5c-4ca0-8b59-1d4ec36e8d2e"), "2GYDT5D3", false },
                    { new Guid("ed827ba2-6aea-42d9-8edf-66a79b55d3f8"), "7983XU4M", false },
                    { new Guid("f56bbfc8-a1e0-43b0-8083-417f3731cc37"), "VFBH8W6W", false },
                    { new Guid("f5ead772-d949-420e-8829-81237deb23c6"), "LUFKZAHW", false },
                    { new Guid("f88b83e3-adcd-4288-9c17-27337d3d1eda"), "BBMNS9ZJ", true },
                    { new Guid("faa3b32f-99a0-4482-83ab-5a28492f057c"), "RXLNLTA6", false },
                    { new Guid("fcd119f4-4e2b-4b65-8e2d-d0dcff5c8aed"), "2E5BHT5R", false }
                });

            migrationBuilder.InsertData(
                table: "CandidateEntities",
                columns: new[] { "Id", "ConstituencyId", "Name", "PartyId" },
                values: new object[,]
                {
                    { new Guid("25a5f7f5-bac1-4d4a-bd23-dc4a06821933"), new Guid("35745314-d6bc-43dd-b108-b1e793126b0a"), "David Oh", new Guid("b2f8deab-fcc3-4d66-aa7b-3104d0fe14a1") },
                    { new Guid("34755256-2c12-4d88-a0ba-5d325850afe1"), new Guid("2eb9e977-d88d-4f15-b7a1-49a98be60ef7"), "John Politician", new Guid("ec1cd589-3006-46c1-ae7b-f3ef28b758cb") },
                    { new Guid("b501397b-49b8-4c4a-805e-d6c1244dcd2a"), new Guid("9a876053-f634-40da-94c3-aed77b7c5e64"), "Steven Armstrong", new Guid("3baceb86-1e40-4e57-a848-c2a0d83d5d0b") },
                    { new Guid("d8317768-c9d7-4cf9-af5d-7fe035a04456"), new Guid("15afd41c-99f5-4b66-b1f8-12980103c583"), "George Sears", new Guid("179c885c-7ffd-4540-a579-2e58a9fb3afe") }
                });

            migrationBuilder.InsertData(
                table: "UserEntities",
                columns: new[] { "Id", "ConstituencyId", "DoB", "Email", "Name", "Password", "RoleId", "UvcId" },
                values: new object[,]
                {
                    { new Guid("c8a458ed-01ad-47fe-bdcf-86eb7cc25bb7"), new Guid("2eb9e977-d88d-4f15-b7a1-49a98be60ef7"), new DateOnly(2000, 1, 1), "election@shangrila.gov.sr", "Admin", "LQwOoT/XLdhyDSqVjBvIUw==.3TJQWUGrOpbimn/+IpKp1N76gRXCaC0BRIsMXYiZFsY=", new Guid("c8a458ed-01ad-47fe-bdcf-86eb7cc25bb7"), new Guid("0b76de0f-fa5d-4900-be02-4d56023d0167") },
                    { new Guid("edcd167a-2475-47d1-8170-aa5d85879ccb"), new Guid("2eb9e977-d88d-4f15-b7a1-49a98be60ef7"), new DateOnly(2001, 2, 14), "test@outlook.com", "Mason Harniess", "e2j7FuxPvuxwwkfiF/MkUA==.65CSYTZoemoPX4j/Tvf6AFZPqCNYD5u18+8FzF+beKc=", new Guid("ee137f00-1c56-49e4-83f8-02c336a287d9"), new Guid("44b528dd-2115-4486-8e60-6895dba6414a") }
                });

            migrationBuilder.InsertData(
                table: "VoteEntities",
                columns: new[] { "Id", "CandidateId", "UserId" },
                values: new object[] { new Guid("322cdb1f-2396-4f47-8ae2-188e067f315b"), new Guid("34755256-2c12-4d88-a0ba-5d325850afe1"), new Guid("edcd167a-2475-47d1-8170-aa5d85879ccb") });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEntities_ConstituencyId",
                table: "CandidateEntities",
                column: "ConstituencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateEntities_PartyId",
                table: "CandidateEntities",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_ConstituencyId",
                table: "UserEntities",
                column: "ConstituencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_RoleId",
                table: "UserEntities",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEntities_UvcId",
                table: "UserEntities",
                column: "UvcId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteEntities_CandidateId",
                table: "VoteEntities",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_VoteEntities_UserId",
                table: "VoteEntities",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectionEntities");

            migrationBuilder.DropTable(
                name: "VoteEntities");

            migrationBuilder.DropTable(
                name: "CandidateEntities");

            migrationBuilder.DropTable(
                name: "UserEntities");

            migrationBuilder.DropTable(
                name: "PartyEntities");

            migrationBuilder.DropTable(
                name: "ConstituencyEntities");

            migrationBuilder.DropTable(
                name: "RoleEntities");

            migrationBuilder.DropTable(
                name: "UvcEntities");
        }
    }
}
