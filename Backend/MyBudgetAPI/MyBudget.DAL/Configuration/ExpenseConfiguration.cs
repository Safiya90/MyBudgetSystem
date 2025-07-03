using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyBudgetAPI.Models;

namespace MyBudget.DAL.Configuration
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.HasKey(e => e.Id);

       
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();


            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Amount)
                .HasColumnType("decimal(18,2)");

            builder.Property(e => e.Category)
                .HasMaxLength(100);

            builder.Property(e => e.DateIncurred)
                .IsRequired();

            builder.Property(e => e.Note)
                .HasMaxLength(500);

            //  relationship to the User table.
            builder.HasOne(e => e.User)
                .WithMany() 
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}