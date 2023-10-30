import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { UpdateValueOrDate } from '../../models/update-value-date-extract.model';
import { Extract } from '../../models/extract.model';
import { TransactionService } from '../../services/transaction.service';

@Component({
  selector: 'app-update-date-value-transaction',
  templateUrl: './update-date-value-transaction.component.html',
  styleUrls: ['./update-date-value-transaction.component.css']
})
export class UpdateDateValueTransactionComponent implements OnInit {

  id: string | null = null;
  paramsSubscription?: Subscription;
  editExtractSubscription?: Subscription;
  extract?: Extract;
  constructor(private transactionService: TransactionService, private router: Router, private route: ActivatedRoute) {

  }
  ngOnInit(): void {
    console.log("onInit")
    this.paramsSubscription = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');
        console.log(`id: ${this.id}`)

        if (this.id) {
          this.transactionService.getTransactionById(this.id)
            .subscribe({
              next: (response) => {
                this.extract = response;
                console.log(this.extract)
              }
            });
        }
      }
    });
  }

  onSubmit() {
    const updateTransaction: UpdateValueOrDate = {
      value: this.extract?.value ?? 0,
      dateTime: this.extract?.dateTime ?? new Date()
    };

    if (this.id) {
      console.log(`updateTransaction: ${updateTransaction.value}`)
      console.log(`updateTransaction: ${updateTransaction.dateTime}`)
      this.editExtractSubscription = this.transactionService.updateDateOfValue(this.id, updateTransaction)
        .subscribe({
          next: (response) => {
            this.router.navigateByUrl('transaction')
          }
        });
    }
  }

  cancelSubmit() {
    this.router.navigateByUrl('/transaction')
  }
}
