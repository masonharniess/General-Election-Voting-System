import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
    selector: 'app-sign-up',
    templateUrl: './sign-up.component.html',
    styleUrls: ['./sign-up.component.css']
})

export class SignUpComponent {
  userData = {
    email: '',
    password: '',
    name: '',
    dateOfBirth: null,
    constituencyName: '',
    uniqueVoterCode: ''
    };

    constituencies: any[] = [];
    selectedConstituencyId: string = '';
    selectedConstituencyName: string = '';

  errorMessage = ''; 
  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.fetchConstituencies();
}

  fetchConstituencies() {
      this.authService.getConstituencies().subscribe(
          response => {
              this.constituencies = response;
          },
          error => {
              console.error('Error fetching constituencies', error);

          }
      );
}


  onSubmit() {
    this.userData.constituencyName = this.selectedConstituencyName;
    this.authService.register(this.userData).subscribe(
      
      data => {
        if (data.role === 'Voter') { 
          this.router.navigate(['/voter-dashboard']); 
        } else {
          this.router.navigate(['/some-general-page']); 
        }
      },
      error => {
        this.errorMessage = error;
      }
    );
  }

  navigateToLogin() {
    this.router.navigate(['/login']);
  }

  navigateToVoterDashboard() {
    this.router.navigate(['/voter-dashboard']);
  }
}
