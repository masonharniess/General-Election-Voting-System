import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignUpComponent } from '../signup/sign-up.component';
import { LoginComponent } from '../login/login.component';
import { VoterDashboardComponent } from '../dashboard/voter-dashboard.component';
import { ElectionOfficerDashboardComponent } from '../dashboard/election-officer-dashboard.component';

const routes: Routes = [
  { path: 'signup', component: SignUpComponent },
  { path: 'login', component: LoginComponent },
  { path: 'voter-dashboard', component: VoterDashboardComponent },
  { path: 'election-officer-dashboard', component: ElectionOfficerDashboardComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
