using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_Managment_Project.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LoanID",
                table: "LoansBooks");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "LoansBooks",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "LoansBooks");

            migrationBuilder.AddColumn<string>(
                name: "LoanID",
                table: "LoansBooks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
