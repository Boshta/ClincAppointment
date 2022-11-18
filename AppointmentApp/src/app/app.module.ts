import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppointmentComponentComponent } from './appointment-component/appointment-component.component';
import {HttpClientModule} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [
    AppComponent,
    AppointmentComponentComponent
  ],
  imports: [
    BrowserModule,
    CommonModule ,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule ,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
