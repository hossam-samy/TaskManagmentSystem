using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksManagmentSystem.EF.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "GroupProject");

            migrationBuilder.CreateTable(
                name: "groupMembers",
                columns: table => new
                {
                    GId = table.Column<int>(type: "int", nullable: false),
                    MId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupMembers", x => new { x.GId, x.MId });
                    table.ForeignKey(
                        name: "FK_groupMembers_Groups_GId",
                        column: x => x.GId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groupMembers_Members_MId",
                        column: x => x.MId,
                        principalSchema: "AspNetUsers",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groupProjects",
                columns: table => new
                {
                    GId = table.Column<int>(type: "int", nullable: false),
                    PId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupProjects", x => new { x.GId, x.PId });
                    table.ForeignKey(
                        name: "FK_groupProjects_Groups_GId",
                        column: x => x.GId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_groupProjects_Projects_PId",
                        column: x => x.PId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_groupMembers_MId",
                table: "groupMembers",
                column: "MId");

            migrationBuilder.CreateIndex(
                name: "IX_groupProjects_PId",
                table: "groupProjects",
                column: "PId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "groupMembers");

            migrationBuilder.DropTable(
                name: "groupProjects");

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupMember", x => new { x.GroupsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_GroupMember_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupMember_Members_MembersId",
                        column: x => x.MembersId,
                        principalSchema: "AspNetUsers",
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupProject",
                columns: table => new
                {
                    GroupsId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupProject", x => new { x.GroupsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_GroupProject_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_MembersId",
                table: "GroupMember",
                column: "MembersId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupProject_ProjectsId",
                table: "GroupProject",
                column: "ProjectsId");
        }
    }
}
