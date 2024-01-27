using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Medical.Persistence.Migrations
{
    public partial class Apoinment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "90d710ea-03f8-4250-9973-1851b5d0b243");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c74e99cb-9adb-4d19-895b-5f55e6d5975a");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                newName: "IX_Appointments_DoctorId");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "54f3d15d-8150-4e35-bacd-6906ba16cc2b", "38936e9d-c807-4363-ae27-a300c5c01bad", "Doctor", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cc7e4292-567b-40c8-a003-faacaa7eb4ba", "3132f0b6-53cd-4bea-b313-88c5263d1727", "Patient", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_AspNetUsers_DoctorId",
                table: "Appointments");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "54f3d15d-8150-4e35-bacd-6906ba16cc2b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cc7e4292-567b-40c8-a003-faacaa7eb4ba");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointments",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                newName: "IX_Appointments_PatientId");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "90d710ea-03f8-4250-9973-1851b5d0b243", "08db95f9-64b4-4a22-adf9-c234b04fad11", "Patient", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c74e99cb-9adb-4d19-895b-5f55e6d5975a", "e26b5e68-fa19-47b0-afb8-18cb0360dc74", "Doctor", null });

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_AspNetUsers_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
