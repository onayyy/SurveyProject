using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vote_survey_SurveyId",
                table: "vote");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "vote",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_vote_survey_SurveyId",
                table: "vote",
                column: "SurveyId",
                principalTable: "survey",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vote_survey_SurveyId",
                table: "vote");

            migrationBuilder.AlterColumn<int>(
                name: "SurveyId",
                table: "vote",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_vote_survey_SurveyId",
                table: "vote",
                column: "SurveyId",
                principalTable: "survey",
                principalColumn: "id");
        }
    }
}
