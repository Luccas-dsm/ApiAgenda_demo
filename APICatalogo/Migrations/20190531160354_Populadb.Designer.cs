﻿// <auto-generated />
using System;
using APICatalogo.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APICatalogo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190531160354_Populadb")]
    partial class Populadb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);
         

            modelBuilder.Entity("APICatalogo.Models.Contatos", b =>
                {
                    b.Property<int>("ContatoId")
                           .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                    .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(14);


                    b.HasKey("ContatoId");

                    b.ToTable("Contatos");
                });

           /* modelBuilder.Entity("APICatalogo.Models.Produto", b =>
                {
                    b.HasOne("APICatalogo.Models.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });*/
#pragma warning restore 612, 618
        }
    }
}
