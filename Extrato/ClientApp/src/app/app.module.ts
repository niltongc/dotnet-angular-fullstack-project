import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ViewComponent } from './transaction/view/view.component';
import { AddTransactionComponent } from './transaction/add-transaction/add-transaction.component';
import { SumValidTransactionComponent } from './transaction/sum-valid-transaction/sum-valid-transaction.component';
import { UpdateDateValueTransactionComponent } from './transaction/update-date-value-transaction/update-date-value-transaction.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ViewComponent,
    AddTransactionComponent,
    SumValidTransactionComponent,
    UpdateDateValueTransactionComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'transaction', component: ViewComponent },
      { path: 'new-transaction', component: AddTransactionComponent },
      {path: 'update-date-value/:id', component: UpdateDateValueTransactionComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
