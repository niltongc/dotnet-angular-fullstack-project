import { Component } from '@angular/core';
import { Subscription } from 'rxjs';
import { TransactionService } from '../../services/transaction.service';
import { AddExtractModel } from '../../models/add-extract.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-transaction',
  templateUrl: './add-transaction.component.html',
  styleUrls: ['./add-transaction.component.css']
})
export class AddTransactionComponent {
  model: AddExtractModel;
  private addTransactionSubscription?: Subscription;

  constructor(private transactionService: TransactionService, private router: Router) {
    this.model = {
      description: '',
      value: 0,
      isAdHoc: true
    };
  }

  onSubmit(): void {
    this.addTransactionSubscription = this.transactionService.addTransaction(this.model).subscribe({
      next: (response) => {
        console.log('Successful')
        this.router.navigateByUrl('/transaction')
      },
      error: (error) => {
        console.log(error)
      }
    })
  }
  ngOnDestroy(): void {
    this.addTransactionSubscription?.unsubscribe();
  }

}
