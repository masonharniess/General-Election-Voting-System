import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  credentials = {
    email: '',
    password: ''
  };
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}

  onSubmit() {
    this.authService.login(this.credentials).subscribe(
      data => {
        localStorage.setItem('userId', data.userId); // Save userId to localStorage
        console.log('Logged in user ID:', localStorage.getItem('userId'));
        if (data.role === 'Voter') {
          this.router.navigate(['/voter-dashboard']);
        } else if (data.role === 'Admin') { 
          this.router.navigate(['/election-officer-dashboard']);
        } else {
          // Handle other roles or errors
        }
      },
      error => {
        this.errorMessage = error.error.message || 'An error occurred during login.';
      }
    );
  }

  navigateToSignUp() {
    this.router.navigate(['/signup']);
  }
}
