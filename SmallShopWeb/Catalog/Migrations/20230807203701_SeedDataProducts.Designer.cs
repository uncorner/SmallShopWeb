﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmallShopWeb.Catalog.Infrastructure;
using SmallShopWeb.Catalog.Infrastructure.Persistence;

#nullable disable

namespace SmallShopWeb.Catalog.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230807203701_SeedDataProducts")]
    partial class SeedDataProducts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmallShopWeb.Catalog.App.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Автоматическая кофемашина Kitfort КТ-7166 — отличный выбор для гурманов, которые не желают тратить много времени и сил, чтобы насладиться полным букетом вкуса свежего кофе. Особая технология приготовления позволяет сохранить большое количество полезных веществ и тонкий аромат напитка.",
                            Name = "Автоматическая кофемашина Kitfort КТ-7166",
                            Price = 32990.0m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Высококачественный универсальный акриловый клей DONEWELL® FIX‑N‑DECOR специально разработан для приклеивания изделий из древесины, ДСП, ДВП, EPS, XPS и UPVC на бетонные, кирпичные, каменные, металлические, оштукатуренные и деревянные поверхности. Идеально подходит для сборки деревянных конструкций, приклеивания гипсокартона, OSB‑плит, декоративных элементов, подоконников, утеплителей различных видов.",
                            Name = "Клей монтажный \"Жидкие гвозди\" DONEWELL FIX-N-DECOR акриловый морозостойкий, DBK-301, Белый",
                            Price = 188.0m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Изготовитель дает гарантию на изделие при соблюдении правил транспортировки, хранения, сборки (для мебели, поставляемой в разобранном виде) и эксплуатации. Упаковка - часть товара.\r\nЕсли хотите выбрать определенную столешницу, то напишите нам напрямую, тогда мы сможем помочь с выбором. У нас много разного дерева и столешниц, которые не представлены на этой площадке. ",
                            Name = "Приставной стол LoftMagic из дерева / Придиванный столик коричневый/ Журнальный стол",
                            Price = 6569.0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
