using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomIdentity.Migrations
{
    /// <inheritdoc />
    public partial class properties_initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "AppUserLists",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Property_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Property_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Property_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size_SqFt = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Number_of_Bedrooms = table.Column<int>(type: "int", nullable: false),
                    Number_of_Bathrooms = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Property_ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "AppUserLists");
        }
    }
}
