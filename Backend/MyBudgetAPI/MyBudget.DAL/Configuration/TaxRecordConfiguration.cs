
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
            builder.HasKey(tr => tr.Id);
            // أزل ValueGeneratedOnAdd() إذا كنت تولد الـ Id في C#
            // builder.Property(tr => tr.Id).ValueGeneratedOnAdd();

            builder.Property(tr => tr.Year)
                .IsRequired();

            builder.Property(tr => tr.Month)
                .IsRequired();

            builder.Property(tr => tr.TotalIncome)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(tr => tr.TotalExpense)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // لا يوجد تكوين لـ NetIncome أو CalculationDate هنا

            builder.Property(tr => tr.TaxAmount)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(tr => tr.User)
                .WithMany()
                .HasForeignKey(tr => tr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(tr => new { tr.UserId, tr.Year }).IsUnique();
        }
    }
}
    
