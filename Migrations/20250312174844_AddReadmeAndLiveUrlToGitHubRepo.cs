using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet_my_platform_api.Migrations
{
    /// <inheritdoc />
    public partial class AddReadmeAndLiveUrlToGitHubRepo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LiveUrl",
                table: "GitHubRepos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Readme",
                table: "GitHubRepos",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LiveUrl",
                table: "GitHubRepos");

            migrationBuilder.DropColumn(
                name: "Readme",
                table: "GitHubRepos");
        }
    }
}
