import { Component } from '@angular/core';
import { TransactionService } from '../../services/transaction.service';

@Component({
  selector: 'app-sum-valid-transaction',
  templateUrl: './sum-valid-transaction.component.html',
  styleUrls: ['./sum-valid-transaction.component.css']
})
export class SumValidTransactionComponent {
  sum = 0

  constructor(private transactionService: TransactionService) { }

  ngOnInit(): void {
    this.sumValidTransaction()
  }
  sumValidTransaction() {
    this.transactionService.sumValidTransaction().subscribe({
      next: (result) => {
        this.sum = result;
      }
    });
  }

}
