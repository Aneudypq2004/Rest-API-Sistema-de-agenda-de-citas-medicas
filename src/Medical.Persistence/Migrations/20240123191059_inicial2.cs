using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Persistence.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "497e2277-244a-4900-88ad-2386f34e6fd7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f4f5744e-43be-4b9e-bb70-2b5151a1d051");

            migrationBuilder.AlterColumn<bool>(
                name: "State",
                table: "Appointments",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90d710ea-03f8-4250-9973-1851b5d0b243", "08db95f9-64b4-4a22-adf9-c234b04fad11", "Patient", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c74e99cb-9adb-4d19-895b-5f55e6d5975a", "e26b5e68-fa19-47b0-afb8-18cb0360dc74", "Doctor", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "90d710ea-03f8-4250-9973-1851b5d0b243");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c74e99cb-9adb-4d19-895b-5f55e6d5975a");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Appointments");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                table: "Appointments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "497e2277-244a-4900-88ad-2386f34e6fd7", "8aec330a-06a2-446c-8e4c-2d89736dffe5", "Doctor", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f4f5744e-43be-4b9e-bb70-2b5151a1d051", "9e392e99-81b7-4aa9-8353-9cd397cfd62b", "Patient", null });
        }
    }
}
