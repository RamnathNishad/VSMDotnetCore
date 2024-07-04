﻿// <auto-generated />
using MVCEFCoreCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCEFCoreCodeFirst.Migrations
{
    [DbContext(typeof(CustomerDBContext))]
    [Migration("20240704073234_project_manager_tbl_creation")]
    partial class project_manager_tbl_creation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCEFCoreCodeFirst.Models.Manager", b =>
                {
                    b.Property<int>("MgrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MgrId"));

                    b.Property<string>("Ename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MgrId");

                    b.ToTable("tbl_manager");
                });

            modelBuilder.Entity("MVCEFCoreCodeFirst.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MgrId")
                        .HasColumnType("int");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("managerMgrId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("managerMgrId");

                    b.ToTable("tbl_project");
                });

            modelBuilder.Entity("MVCEFCoreCodeFirst.Models.tbl_customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("tbl_customer");
                });

            modelBuilder.Entity("MVCEFCoreCodeFirst.Models.tbl_product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("tbl_product");
                });

            modelBuilder.Entity("MVCEFCoreCodeFirst.Models.Project", b =>
                {
                    b.HasOne("MVCEFCoreCodeFirst.Models.Manager", "manager")
                        .WithMany()
                        .HasForeignKey("managerMgrId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("manager");
                });
#pragma warning restore 612, 618
        }
    }
}
