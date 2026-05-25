using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace poker_planning_api.Migrations
{
    /// <inheritdoc />
    public partial class addteamstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomParticipants_Users_UserId",
                table: "RoomParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Stories_StoryId",
                table: "Rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_Stories_Rooms_RoomId",
                table: "Stories");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Votes",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stories",
                table: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoomParticipants",
                table: "RoomParticipants");

            migrationBuilder.RenameTable(
                name: "Votes",
                newName: "votes");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Stories",
                newName: "stories");

            migrationBuilder.RenameTable(
                name: "Rounds",
                newName: "rounds");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "rooms");

            migrationBuilder.RenameTable(
                name: "RoomParticipants",
                newName: "room_participants");

            migrationBuilder.RenameIndex(
                name: "IX_Votes_UserId",
                table: "votes",
                newName: "IX_votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "IX_users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_Stories_RoomId",
                table: "stories",
                newName: "IX_stories_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Rounds_StoryId",
                table: "rounds",
                newName: "IX_rounds_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_UserId",
                table: "rooms",
                newName: "IX_rooms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rooms_Slug",
                table: "rooms",
                newName: "IX_rooms_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_RoomParticipants_UserId",
                table: "room_participants",
                newName: "IX_room_participants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_votes",
                table: "votes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stories",
                table: "stories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rounds",
                table: "rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_rooms",
                table: "rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_room_participants",
                table: "room_participants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedByUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_teams_users_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_teams_CreatedByUserId",
                table: "teams",
                column: "CreatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_room_participants_users_UserId",
                table: "room_participants",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rooms_users_UserId",
                table: "rooms",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_rounds_stories_StoryId",
                table: "rounds",
                column: "StoryId",
                principalTable: "stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_stories_rooms_RoomId",
                table: "stories",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_room_participants_users_UserId",
                table: "room_participants");

            migrationBuilder.DropForeignKey(
                name: "FK_rooms_users_UserId",
                table: "rooms");

            migrationBuilder.DropForeignKey(
                name: "FK_rounds_stories_StoryId",
                table: "rounds");

            migrationBuilder.DropForeignKey(
                name: "FK_stories_rooms_RoomId",
                table: "stories");

            migrationBuilder.DropForeignKey(
                name: "FK_votes_users_UserId",
                table: "votes");

            migrationBuilder.DropTable(
                name: "teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_votes",
                table: "votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stories",
                table: "stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rounds",
                table: "rounds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_rooms",
                table: "rooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_room_participants",
                table: "room_participants");

            migrationBuilder.RenameTable(
                name: "votes",
                newName: "Votes");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "stories",
                newName: "Stories");

            migrationBuilder.RenameTable(
                name: "rounds",
                newName: "Rounds");

            migrationBuilder.RenameTable(
                name: "rooms",
                newName: "Rooms");

            migrationBuilder.RenameTable(
                name: "room_participants",
                newName: "RoomParticipants");

            migrationBuilder.RenameIndex(
                name: "IX_votes_UserId",
                table: "Votes",
                newName: "IX_Votes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_users_Email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameIndex(
                name: "IX_stories_RoomId",
                table: "Stories",
                newName: "IX_Stories_RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_rounds_StoryId",
                table: "Rounds",
                newName: "IX_Rounds_StoryId");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_UserId",
                table: "Rooms",
                newName: "IX_Rooms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_rooms_Slug",
                table: "Rooms",
                newName: "IX_Rooms_Slug");

            migrationBuilder.RenameIndex(
                name: "IX_room_participants_UserId",
                table: "RoomParticipants",
                newName: "IX_RoomParticipants_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Votes",
                table: "Votes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stories",
                table: "Stories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rounds",
                table: "Rounds",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoomParticipants",
                table: "RoomParticipants",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomParticipants_Users_UserId",
                table: "RoomParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Users_UserId",
                table: "Rooms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Stories_StoryId",
                table: "Rounds",
                column: "StoryId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stories_Rooms_RoomId",
                table: "Stories",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Users_UserId",
                table: "Votes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
