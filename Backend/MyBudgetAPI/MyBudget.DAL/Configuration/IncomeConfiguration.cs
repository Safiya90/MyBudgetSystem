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
    internal class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.Property(i => i.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(i => i.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Property(i => i.Source)
                .HasMaxLength(100);

            builder.Property(i => i.DateReceived)
                .IsRequired();

            builder.Property(i => i.Note)
                .HasMaxLength(500);

            builder.HasOne(i => i.User)
                .WithMany() // Or .WithMany(u => u.Incomes) if you define navigation collection in ApplicationUser
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}