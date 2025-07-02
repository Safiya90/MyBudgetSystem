
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyBudgetAPI.Models;

namespace MyBudget.DAL.Configuration
{
    internal class TaxRecordConfiguration : IEntityTypeConfiguration<TaxRecord>
    {
        public void Configure(EntityTypeBuilder<TaxRecord> builder)
        {
            builder.Property(t => t.Year)
                .IsRequired();

            builder.Property(t => t.Month)
                .IsRequired();

            builder.Property(t => t.TotalIncome)
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.TotalExpense)
                .HasColumnType("decimal(18,2)");

            builder.Property(t => t.TaxAmount)
                .HasColumnType("decimal(18,2)");

            builder.HasOne(t => t.User)
                .WithMany()
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}