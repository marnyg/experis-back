using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "AddressText" },
                values: new object[,]
                {
                    { 1, "Tollefsengrenda 475, 0946 Mandal" },
                    { 2, "Søndreskrenten 33B, 4326 Stathelle" },
                    { 3, "Gamlestubben 8288, 0899 Moelv" },
                    { 4, "Nedrehaugen 4855, 1093 Kirkenes" },
                    { 5, "Lunde veien 3717, 0088 Hønefoss " },
                    { 6, "Gamleåsen 40, 8565 Namsos " }
                });

            migrationBuilder.InsertData(
                table: "ServiceType",
                columns: new[] { "Id", "ServiceTypeDescription", "ServiceTypeName" },
                values: new object[,]
                {
                    { 1, "Moving your belongings to your new address", "Moving" },
                    { 2, "Packing up your belongings", "Packing" },
                    { 3, "Cleaning your old home", "Cleaning" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CurrentAddressId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "asdf@b.com", "Ola", "Nordman" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CurrentAddressId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 2, "gggs@gda.com", "Svein", "Lund" });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CurrentAddressId", "Email", "FirstName", "LastName" },
                values: new object[] { 3, 2, "kasdf@g.com", "knut", "Sørlig" });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "FromAddressId", "OrderComment", "ToAddressId" },
                values: new object[] { 1, 1, 1, "ikke kom før kl 10", 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "FromAddressId", "OrderComment", "ToAddressId" },
                values: new object[] { 2, 2, 3, "kom etter kl 15", 3 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "CustomerId", "FromAddressId", "OrderComment", "ToAddressId" },
                values: new object[] { 3, 3, 4, "kom etter kl 15", 2 });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Date", "OrderId", "ServiceTypeId" },
                values: new object[] { 1, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Date", "OrderId", "ServiceTypeId" },
                values: new object[] { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "Id", "Date", "OrderId", "ServiceTypeId" },
                values: new object[] { 3, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Service",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Order",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
