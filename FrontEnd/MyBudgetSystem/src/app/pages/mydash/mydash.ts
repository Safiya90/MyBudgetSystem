import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-mydash',
  templateUrl: './mydash.html',
  imports:[   FormsModule],
  styleUrl: './mydash.scss'
})
export class Mydash {
showIncomeForm = false;
  showExpensesForm = false;
  showTaxForm = false;

  // Form models
  incomeForm = {
    title: '',
    amount: null,
    source: '',
    note: ''
  };

  expensesForm = {
    title: '',
    amount: null,
    category: '',
    date: '',
    note: ''
  };

  taxForm = {
    year: new Date().getFullYear(),
    month: '',
    totalIncome: null,
    totalExpenses: null,
    taxAmount: null
  };

  constructor(private router: Router) {}

  toggleIncomeForm() {
    this.showIncomeForm = !this.showIncomeForm;
    this.showExpensesForm = false;
    this.showTaxForm = false;
  }

  toggleExpensesForm() {
    this.showExpensesForm = !this.showExpensesForm;
    this.showIncomeForm = false;
    this.showTaxForm = false;
  }

  toggleTaxForm() {
    this.showTaxForm = !this.showTaxForm;
    this.showIncomeForm = false;
    this.showExpensesForm = false;
  }

  onAddIncome() {
    console.log('Adding income:', this.incomeForm);
    // Add your income submission logic here
    this.resetIncomeForm();
    this.showIncomeForm = false;
  }

  onAddExpenses() {
    console.log('Adding expenses:', this.expensesForm);
    // Add your expenses submission logic here
    this.resetExpensesForm();
    this.showExpensesForm = false;
  }

  onCalculateTax() {
    console.log('Calculating tax:', this.taxForm);
    // Add your tax calculation logic here
  }

  resetIncomeForm() {
    this.incomeForm = {
      title: '',
      amount: null,
      source: '',
      note: ''
    };
  }

  resetExpensesForm() {
    this.expensesForm = {
      title: '',
      amount: null,
      category: '',
      date: '',
      note: ''
    };
  }

  navigateToIncome() {
    this.router.navigate(['/income']);
  }

  navigateToExpenses() {
    this.router.navigate(['/expenses']);
  }
}
