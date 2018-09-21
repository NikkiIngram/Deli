﻿// <auto-generated />
using System;
using Deli.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Deli.Migrations
{
    [DbContext(typeof(DeliContext))]
    [Migration("20180921163536_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Deli.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngredientName");

                    b.Property<int>("IngredientTypeId");

                    b.Property<bool>("SaladIngredient");

                    b.Property<bool>("SandwichIngredient");

                    b.Property<bool>("Selected");

                    b.HasKey("IngredientId");

                    b.HasIndex("IngredientTypeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("Deli.Models.IngredientType", b =>
                {
                    b.Property<int>("IngredientTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IngredientTypeName");

                    b.HasKey("IngredientTypeId");

                    b.ToTable("IngredientTypes");
                });

            modelBuilder.Entity("Deli.Models.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ItemTypeId");

                    b.Property<int>("OrderId");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemTypeId");

                    b.HasIndex("OrderId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Deli.Models.Item_Ingredient", b =>
                {
                    b.Property<int>("Item_IngredientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngredientId");

                    b.Property<int>("ItemId");

                    b.HasKey("Item_IngredientId");

                    b.HasIndex("IngredientId");

                    b.HasIndex("ItemId");

                    b.ToTable("Item_Ingredients");
                });

            modelBuilder.Entity("Deli.Models.ItemType", b =>
                {
                    b.Property<int>("ItemTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemTypeName");

                    b.HasKey("ItemTypeId");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("Deli.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate");

                    b.Property<int>("UserId");

                    b.HasKey("OrderId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Deli.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<int?>("CVC");

                    b.Property<long?>("CardNumber");

                    b.Property<int?>("CardType");

                    b.Property<string>("City");

                    b.Property<string>("EmailAddress");

                    b.Property<DateTime?>("ExpDate");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<int?>("PaymentType");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("State");

                    b.Property<string>("UserName");

                    b.Property<int?>("Zip");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Deli.Models.Ingredient", b =>
                {
                    b.HasOne("Deli.Models.IngredientType", "IngredientType")
                        .WithMany()
                        .HasForeignKey("IngredientTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deli.Models.Item", b =>
                {
                    b.HasOne("Deli.Models.ItemType", "ItemType")
                        .WithMany()
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deli.Models.Order", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deli.Models.Item_Ingredient", b =>
                {
                    b.HasOne("Deli.Models.Ingredient", "Ingredient")
                        .WithMany()
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Deli.Models.Item", "Item")
                        .WithMany("Ingredients")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Deli.Models.Order", b =>
                {
                    b.HasOne("Deli.Models.User", "Users")
                        .WithMany("Order")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
