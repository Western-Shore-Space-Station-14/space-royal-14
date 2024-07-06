﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Content.Server.Database.Migrations.Sqlite
{
    /// <inheritdoc />
    public partial class Scores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scores",
                columns: table => new
                {
                    player_user_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    win_score = table.Column<int>(type: "INTEGER", nullable: false),
                    kills = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scores", x => x.player_user_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scores_player_user_id",
                table: "scores",
                column: "player_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scores");
        }
    }
}
