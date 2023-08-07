using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmallShopWeb.Catalog.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Автоматическая кофемашина Kitfort КТ-7166 — отличный выбор для гурманов, которые не желают тратить много времени и сил, чтобы насладиться полным букетом вкуса свежего кофе. Особая технология приготовления позволяет сохранить большое количество полезных веществ и тонкий аромат напитка.", "Автоматическая кофемашина Kitfort КТ-7166", 32990.0m },
                    { 2, "Высококачественный универсальный акриловый клей DONEWELL® FIX‑N‑DECOR специально разработан для приклеивания изделий из древесины, ДСП, ДВП, EPS, XPS и UPVC на бетонные, кирпичные, каменные, металлические, оштукатуренные и деревянные поверхности. Идеально подходит для сборки деревянных конструкций, приклеивания гипсокартона, OSB‑плит, декоративных элементов, подоконников, утеплителей различных видов.", "Клей монтажный \"Жидкие гвозди\" DONEWELL FIX-N-DECOR акриловый морозостойкий, DBK-301, Белый", 188.0m },
                    { 3, "Изготовитель дает гарантию на изделие при соблюдении правил транспортировки, хранения, сборки (для мебели, поставляемой в разобранном виде) и эксплуатации. Упаковка - часть товара.\r\nЕсли хотите выбрать определенную столешницу, то напишите нам напрямую, тогда мы сможем помочь с выбором. У нас много разного дерева и столешниц, которые не представлены на этой площадке. ", "Приставной стол LoftMagic из дерева / Придиванный столик коричневый/ Журнальный стол", 6569.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
