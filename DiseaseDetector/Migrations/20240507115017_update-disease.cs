using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiseaseDetector.Migrations
{
    /// <inheritdoc />
    public partial class updatedisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AliasId",
                table: "Diseases",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AliasId",
                table: "Diseases");
        }
    }
}
