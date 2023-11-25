﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TasksManagmentSystem.EF.Migrations
{
    public partial class seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Manager", "Manager".ToUpper(), Guid.NewGuid().ToString() }
                );
            migrationBuilder.InsertData(
           table: "AspNetRoles",
              columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
              values: new object[] { Guid.NewGuid().ToString(), "Member", "Member".ToUpper(), Guid.NewGuid().ToString() }
               );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
        }
    }
}
