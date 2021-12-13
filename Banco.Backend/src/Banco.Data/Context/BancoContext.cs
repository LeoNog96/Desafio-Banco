using Banco.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Banco.Data.Context
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Conta>(entity =>
            {
                entity.ToTable("contas");

                entity.Property(e => e.Id).HasColumnName("idConta");
                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");
                entity.Property(e => e.FlagAtivo).HasColumnName("flagAtivo").HasDefaultValue(true);
                entity.Property(e => e.DataCriacao).HasColumnName("dataCriacao").HasDefaultValueSql("getdate()");
                entity.Property(e => e.LimiteSaqueDiario).HasColumnName("limiteSaqueDiario");
                entity.Property(e => e.TipoConta).HasColumnName("tipoConta");
                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.HasOne(d => d.Pessoa)
                    .WithMany(p => p.Contas)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoas");

                entity.HasIndex(u => u.Cpf).IsUnique();
                
                entity.Property(e => e.Id).HasColumnName("idPessoa");
                entity.Property(e => e.Cpf).HasColumnName("cpf");
                entity.Property(e => e.DataNascimento).HasColumnName("dataNascimento");
                entity.Property(e => e.Nome).HasColumnName("nome");
            });


            builder.Entity<Login>(entity =>
            {
                entity.ToTable("logins");

                entity.Property(e => e.Id).HasColumnName("idLogin");
                entity.Property(e => e.Email).HasColumnName("email");
                entity.Property(e => e.IdPessoa).HasColumnName("idPessoa");
                
                entity.HasOne(d => d.Pessoa)
                .WithOne(p => p.Login)
                .HasForeignKey<Login>(d => d.IdPessoa)
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Transacao>(entity =>
            {
                entity.ToTable("transacoes");
                entity.Property(e => e.Id).HasColumnName("idTransacao");
                entity.Property(e => e.DataTransacao).HasColumnName("dataTransacao").HasDefaultValueSql("getdate()"); ;
                entity.Property(e => e.IdConta).HasColumnName("idConta");
                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.Conta)
                    .WithMany(p => p.Transacoes)
                    .HasForeignKey(d => d.IdConta)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(builder);
        }
    }
}
