import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Extract } from '../../models/extract.model';
import { TransactionService } from '../../services/transaction.service';


@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {

  transactions$?: Observable<Extract[]>;
  startDate: Date; 
  endDate: Date;

  constructor(private transactionService: TransactionService, private router: Router) {
    this.startDate = new Date();
    this.endDate = new Date();
}

  ngOnInit(): void {
    console.log("hello")
    console.log(typeof(this.transactions$))
    console.log(this.transactions$)
    this.transactions$ = this.transactionService.getTransactionsDefault();
  }
  OnChanged(): void {
    this.getTransactionsByDate()
  }
  getTransactionsByDate() {
    console.log(this.startDate)
    console.log(this.endDate)
    this.transactions$ = this.transactionService.getTransactionsByDate(this.startDate, this.endDate);
  }

  addNewTransaction() {
    this.router.navigateByUrl('new-transaction');
  }
 

}
