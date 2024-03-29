﻿// <auto-generated />
using ForeignKeyAPI.Modules;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ForeignKeyAPI.Migrations
{
	[DbContext(typeof(ApplicationDBContext))]
	[Migration("20211229115252_creatingProjec")]
	partial class creatingProjec
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "6.0.1")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

			modelBuilder.Entity("ForeignKeyAPI.Modules.Entities.GroupEntity", b =>
				{
					b.Property<int>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("integer");

					NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

					b.Property<string>("Nome")
						.HasColumnType("text");

					b.HasKey("Id");

					b.ToTable("Group");
				});
#pragma warning restore 612, 618
		}
	}
}
