import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.prod';
import { AddExtractModel } from '../models/add-extract.model';
import { Extract } from '../models/extract.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private http : HttpClient) { }

  //url = "https://localhost:7061/api/Extract";
  //https://localhost:7061/api/Extract?startDate=2023-10-24&endDate=2023-10-29

  //Post https://localhost:7061/api/Extract
    //put https://localhost:7061/api/Extract/bb737ece-8352-4ad4-9620-08dbd7f0013f date value
    //put cancel https://localhost:7061/api/Extract/cancel-transaction/bb737ece-8352-4ad4-9620-08dbd7f0013f
    //sum https://localhost:7061/api/Extract/sum-transaction
    //automatic https://localhost:7061/api/Extract/not-adhoc

  getTransactionsDefault(): Observable<Extract[]> {
    return this.http.get<Extract[]>(`${environment.apiBaseUrl}/api/Extract`)
  }
  getTransactionsByDate(startDate: Date, endDate: Date): Observable<Extract[]> {
    return this.http.get<Extract[]>(`${environment.apiBaseUrl}/api/Extract?startDate=${startDate}&endDate=${endDate}`)
  }

  addTransaction(model: AddExtractModel): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseUrl}/api/Extract`, model)
  }
}
