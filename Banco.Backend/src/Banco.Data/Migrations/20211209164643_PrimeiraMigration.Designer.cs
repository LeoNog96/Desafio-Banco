﻿// <auto-generated />
using System;
using Banco.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Banco.Data.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20211209164643_PrimeiraMigration")]
    partial class PrimeiraMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Banco.Domain.Model.Conta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idConta")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("dataCriacao")
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("FlagAtivo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("flagAtivo");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint")
                        .HasColumnName("idPessoa");

                    b.Property<decimal>("LimiteSaqueDiario")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("limiteSaqueDiario");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("saldo");

                    b.Property<int>("TipoConta")
                        .HasColumnType("int")
                        .HasColumnName("tipoConta");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa");

                    b.ToTable("contas");
                });

            modelBuilder.Entity("Banco.Domain.Model.Login", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idLogin")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("email");

                    b.Property<long>("IdPessoa")
                        .HasColumnType("bigint")
                        .HasColumnName("idPessoa");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdPessoa")
                        .IsUnique();

                    b.ToTable("logins");
                });

            modelBuilder.Entity("Banco.Domain.Model.Pessoa", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idPessoa")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("dataNascimento");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("nome");

                    b.HasKey("Id");

                    b.ToTable("pessoas");
                });

            modelBuilder.Entity("Banco.Domain.Model.Transacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("idTransacao")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("dataTransacao")
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("IdConta")
                        .HasColumnType("bigint")
                        .HasColumnName("idConta");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("IdConta");

                    b.ToTable("transacoes");
                });

            modelBuilder.Entity("Banco.Domain.Model.Conta", b =>
                {
                    b.HasOne("Banco.Domain.Model.Pessoa", "Pessoa")
                        .WithMany("Contas")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Banco.Domain.Model.Login", b =>
                {
                    b.HasOne("Banco.Domain.Model.Pessoa", "Pessoa")
                        .WithOne("Login")
                        .HasForeignKey("Banco.Domain.Model.Login", "IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("Banco.Domain.Model.Transacao", b =>
                {
                    b.HasOne("Banco.Domain.Model.Conta", "Conta")
                        .WithMany("Transacoes")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Conta");
                });

            modelBuilder.Entity("Banco.Domain.Model.Conta", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("Banco.Domain.Model.Pessoa", b =>
                {
                    b.Navigation("Contas");

                    b.Navigation("Login");
                });
#pragma warning restore 612, 618
        }
    }
}
