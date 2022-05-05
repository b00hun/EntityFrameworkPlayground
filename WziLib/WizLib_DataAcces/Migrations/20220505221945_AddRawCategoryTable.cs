using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WizLib_DataAcces.Migrations
{
    public partial class AddRawCategoryTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Tbl_Category VALUES('Cat 1')");
            migrationBuilder.Sql("INSERT INTO Tbl_Category VALUES('Cat 2')");
            migrationBuilder.Sql("INSERT INTO Tbl_Category VALUES('Cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
