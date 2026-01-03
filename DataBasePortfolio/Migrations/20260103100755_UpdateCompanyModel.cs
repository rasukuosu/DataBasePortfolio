using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBasePortfolio.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Companys_CompanyName",
                table: "Companys",
                column: "CompanyName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Companys_CompanyName",
                table: "Companys");
        }
    }
}
