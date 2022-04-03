using Microsoft.EntityFrameworkCore.Migrations;

namespace Challenge.Migrations
{
    public partial class MigracaoInicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PegativesRatio",
                table: "RatioElements");

            migrationBuilder.DropColumn(
                name: "PositiesRatio",
                table: "RatioElements");

            migrationBuilder.AlterColumn<string>(
                name: "ZerosRatio",
                table: "RatioElements",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<string>(
                name: "NegativesRatio",
                table: "RatioElements",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositivesRatio",
                table: "RatioElements",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NegativesRatio",
                table: "RatioElements");

            migrationBuilder.DropColumn(
                name: "PositivesRatio",
                table: "RatioElements");

            migrationBuilder.AlterColumn<float>(
                name: "ZerosRatio",
                table: "RatioElements",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PegativesRatio",
                table: "RatioElements",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "PositiesRatio",
                table: "RatioElements",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
