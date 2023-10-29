import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment.prod';
import { Extract } from '../models/extract.model';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private http : HttpClient) { }

  //url = "https://localhost:7061/api/Extract";
  //https://localhost:7061/api/Extract?startDate=2023-10-24&endDate=2023-10-29

  getTransactionsDefault(): Observable<Extract[]> {
    return this.http.get<Extract[]>(`${environment.apiBaseUrl}/api/Extract`)
  }
  getTransactionsByDate(startDate: Date, endDate: Date): Observable<Extract[]> {
    return this.http.get<Extract[]>(`${environment.apiBaseUrl}/api/Extract?startDate=${startDate}&endDate=${endDate}`)
  }
}
