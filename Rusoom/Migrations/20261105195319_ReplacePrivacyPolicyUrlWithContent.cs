using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rusoom.Migrations
{
    /// <inheritdoc />
    public partial class ReplacePrivacyPolicyUrlWithContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                schema: "identity",
                table: "PrivacyPolicyTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "identity",
                table: "PrivacyPolicyTranslations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "identity",
                table: "PrivacyPolicyTranslations");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                schema: "identity",
                table: "PrivacyPolicyTranslations",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");
        }
    }
}
