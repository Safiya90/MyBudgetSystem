using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.DAL.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Expense_AspNetUsers_UserId",
                table: "Expense");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_Income_AspNetUsers_UserId",
                table: "Income");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxRecord_AspNetUsers_ApplicationUserId",
                table: "TaxRecord");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxRecord_AspNetUsers_UserId",
                table: "TaxRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxRecord",
                table: "TaxRecord");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Income",
                table: "Income");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expense",
                table: "Expense");

            migrationBuilder.RenameTable(
                name: "TaxRecord",
                newName: "TaxRecords");

            migrationBuilder.RenameTable(
                name: "Income",
                newName: "Incomes");

            migrationBuilder.RenameTable(
                name: "Expense",
                newName: "Expenses");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "TaxRecords",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_TaxRecord_UserId",
                table: "TaxRecords",
                newName: "IX_TaxRecords_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaxRecord_ApplicationUserId",
                table: "TaxRecords",
                newName: "IX_TaxRecords_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Incomes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Income_UserId",
                table: "Incomes",
                newName: "IX_Incomes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Income_ApplicationUserId",
                table: "Incomes",
                newName: "IX_Incomes_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Expenses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_UserId",
                table: "Expenses",
                newName: "IX_Expenses_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expense_ApplicationUserId",
                table: "Expenses",
                newName: "IX_Expenses_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxRecords",
                table: "TaxRecords",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_AspNetUsers_UserId",
                table: "Incomes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxRecords_AspNetUsers_ApplicationUserId",
                table: "TaxRecords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxRecords_AspNetUsers_UserId",
                table: "TaxRecords",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_ApplicationUserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_AspNetUsers_UserId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_AspNetUsers_UserId",
                table: "Incomes");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxRecords_AspNetUsers_ApplicationUserId",
                table: "TaxRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_TaxRecords_AspNetUsers_UserId",
                table: "TaxRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaxRecords",
                table: "TaxRecords");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Expenses",
                table: "Expenses");

            migrationBuilder.RenameTable(
                name: "TaxRecords",
                newName: "TaxRecord");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Income");

            migrationBuilder.RenameTable(
                name: "Expenses",
                newName: "Expense");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TaxRecord",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_TaxRecords_UserId",
                table: "TaxRecord",
                newName: "IX_TaxRecord_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TaxRecords_ApplicationUserId",
                table: "TaxRecord",
                newName: "IX_TaxRecord_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Income",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_UserId",
                table: "Income",
                newName: "IX_Income_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Income",
                newName: "IX_Income_ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Expense",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_UserId",
                table: "Expense",
                newName: "IX_Expense_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_ApplicationUserId",
                table: "Expense",
                newName: "IX_Expense_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaxRecord",
                table: "TaxRecord",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Income",
                table: "Income",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Expense",
                table: "Expense",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_AspNetUsers_ApplicationUserId",
                table: "Expense",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expense_AspNetUsers_UserId",
                table: "Expense",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Income_AspNetUsers_ApplicationUserId",
                table: "Income",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Income_AspNetUsers_UserId",
                table: "Income",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaxRecord_AspNetUsers_ApplicationUserId",
                table: "TaxRecord",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaxRecord_AspNetUsers_UserId",
                table: "TaxRecord",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
