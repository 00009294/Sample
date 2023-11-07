using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DSCC_9294_API.Migrations
{
    /// <inheritdoc />
    public partial class someChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Owner_OwnerId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_OwnerId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Car");

            migrationBuilder.AddColumn<int>(
                name: "CarId",
                table: "Owner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Owner");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Car",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Car_OwnerId",
                table: "Car",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Owner_OwnerId",
                table: "Car",
                column: "OwnerId",
                principalTable: "Owner",
                principalColumn: "Id");
        }
    }
}
