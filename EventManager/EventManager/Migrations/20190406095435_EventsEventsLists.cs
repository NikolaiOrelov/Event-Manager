using Microsoft.EntityFrameworkCore.Migrations;

namespace EventManager.Migrations
{
    public partial class EventsEventsLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventLists_Events_EventId",
                table: "EventLists");

            migrationBuilder.DropIndex(
                name: "IX_EventLists_EventId",
                table: "EventLists");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "EventLists");

            migrationBuilder.CreateTable(
                name: "EventsEventLists",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false),
                    EventListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsEventLists", x => new { x.EventId, x.EventListId });
                    table.ForeignKey(
                        name: "FK_EventsEventLists_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventsEventLists_EventLists_EventListId",
                        column: x => x.EventListId,
                        principalTable: "EventLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventsEventLists_EventListId",
                table: "EventsEventLists",
                column: "EventListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventsEventLists");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "EventLists",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EventLists_EventId",
                table: "EventLists",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventLists_Events_EventId",
                table: "EventLists",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
