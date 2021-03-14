﻿// <auto-generated />
using System;
using Aplicacao.Infra.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Aplicacao.Infra.DataAccess.Migrations
{
    [DbContext(typeof(AplicacaoContext))]
    [Migration("20210314225922_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Customer.Model.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasMaxLength(10)
                        .HasColumnType("datetime")
                        .HasColumnName("dataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("nomeCompleto");

                    b.Property<DateTime>("RegistrationDate")
                        .HasMaxLength(30)
                        .HasColumnType("datetime")
                        .HasColumnName("dataCadastro");

                    b.HasKey("Id")
                        .HasName("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Order.Model.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("CompraId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Order.Model.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasMaxLength(300)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("preco");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasMaxLength(300)
                        .HasColumnType("int")
                        .HasColumnName("quantidade");

                    b.HasKey("Id")
                        .HasName("CompraItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("CompraItem");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Product.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("descricao");

                    b.Property<decimal>("Price")
                        .HasMaxLength(300)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("preco");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("sku");

                    b.Property<double>("Weight")
                        .HasMaxLength(300)
                        .HasColumnType("float")
                        .HasColumnName("peso");

                    b.HasKey("Id")
                        .HasName("ProdutoId");

                    b.ToTable("Produto");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "IPhone 12",
                            Price = 8799.22m,
                            SKU = "ae831b1c",
                            Weight = 200.0
                        });
                });

            modelBuilder.Entity("Aplicacao.Domain.ValueObject.Address.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("cidade");

                    b.Property<string>("Complement")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("complemento");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("pais");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("bairro");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("numero");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("estado");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("rua");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("cep");

                    b.HasKey("Id")
                        .HasName("EnderecoId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Order.Model.Order", b =>
                {
                    b.HasOne("Aplicacao.Domain.Aggregate.Customer.Model.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Order.Model.OrderItems", b =>
                {
                    b.HasOne("Aplicacao.Domain.Aggregate.Order.Model.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Aplicacao.Domain.Aggregate.Product.Model.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Aplicacao.Domain.ValueObject.Address.Address", b =>
                {
                    b.HasOne("Aplicacao.Domain.Aggregate.Customer.Model.Customer", "Customer")
                        .WithMany("Address")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Customer.Model.Customer", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Aplicacao.Domain.Aggregate.Order.Model.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
