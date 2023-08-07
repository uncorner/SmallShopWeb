﻿using Microsoft.EntityFrameworkCore;
using SmallShopWeb.Catalog.App.Entities;

namespace SmallShopWeb.Catalog.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product("Автоматическая кофемашина Kitfort КТ-7166")
                {
                    Id = 1,
                    Description = "Автоматическая кофемашина Kitfort КТ-7166 — отличный выбор для гурманов, которые не желают тратить много времени и сил, чтобы насладиться полным букетом вкуса свежего кофе. Особая технология приготовления позволяет сохранить большое количество полезных веществ и тонкий аромат напитка.",
                    Price = 32990.0M
                },
                new Product("Клей монтажный \"Жидкие гвозди\" DONEWELL FIX-N-DECOR акриловый морозостойкий, DBK-301, Белый")
                {
                    Id = 2,
                    Description = "Высококачественный универсальный акриловый клей DONEWELL® FIX‑N‑DECOR специально разработан для приклеивания изделий из древесины, ДСП, ДВП, EPS, XPS и UPVC на бетонные, кирпичные, каменные, металлические, оштукатуренные и деревянные поверхности. Идеально подходит для сборки деревянных конструкций, приклеивания гипсокартона, OSB‑плит, декоративных элементов, подоконников, утеплителей различных видов.",
                    Price = 188.0M
                },
                new Product("Приставной стол LoftMagic из дерева / Придиванный столик коричневый/ Журнальный стол")
                {
                    Id = 3,
                    Description = "Изготовитель дает гарантию на изделие при соблюдении правил транспортировки, хранения, сборки (для мебели, поставляемой в разобранном виде) и эксплуатации. Упаковка - часть товара.\r\nЕсли хотите выбрать определенную столешницу, то напишите нам напрямую, тогда мы сможем помочь с выбором. У нас много разного дерева и столешниц, которые не представлены на этой площадке. ",
                    Price = 6569.0M
                }
                );
        }
    }
}
