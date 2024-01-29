import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SignUpComponent } from 'src/signup/sign-up.component';
import { LoginComponent } from 'src/login/login.component';

import { ElectionOfficerDashboardComponent } from '../dashboard/election-officer-dashboard.component';
import { VoterDashboardComponent } from 'src/dashboard/voter-dashboard.component';

@NgModule({
  declarations: [
    AppComponent, 
    SignUpComponent,
    LoginComponent,
    ElectionOfficerDashboardComponent,
    VoterDashboardComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
