using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Server.Migrations
{
    public partial class seedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "this category have all electronic devices", "electronic" },
                    { 2, "this category have all descktop devices", "computers" },
                    { 3, "this category have all laptops devices", "laptops" },
                    { 4, "this category have all mobiles devices", "mobiles" }
                });

            migrationBuilder.InsertData(
                table: "Product_Attributes",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "this attribute descripte ram memory in computers and mobile and ...", "ram" },
                    { 2, "this attribute descripte processor  in computers and mobile and ...", "processor" },
                    { 3, "this attribute descripte hard memory in computers and mobile and ...", "hard" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "forSearchByCategory" },
                values: new object[,]
                {
                    { 1, "new laptop for engineer", "Asus laptop", 0f, ".1.3" },
                    { 2, "new computer from asus", "Asus computer", 0f, ".1.2" }
                });

            migrationBuilder.InsertData(
                table: "Product_Attribute_Mapping",
                columns: new[] { "Id", "AttributeId", "ProductId", "Value" },
                values: new object[,]
                {
                    { 1, 1, 1, "4 GB" },
                    { 2, 2, 1, "intel core i3" },
                    { 3, 1, 2, "4 GB" },
                    { 4, 2, 2, "intel core i7" }
                });

            migrationBuilder.InsertData(
                table: "Product_Category_Mapping",
                columns: new[] { "Id", "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 1, 2 },
                    { 4, 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product_Attribute_Mapping",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product_Attribute_Mapping",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product_Attribute_Mapping",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product_Attribute_Mapping",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Product_Attributes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product_Category_Mapping",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product_Category_Mapping",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Product_Category_Mapping",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product_Category_Mapping",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product_Attributes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product_Attributes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
