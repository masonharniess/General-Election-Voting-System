import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';


@Component({
  selector: 'app-election-officer-dashboard',
  templateUrl: './election-officer-dashboard.component.html',
  styleUrls: ['./election-officer-dashboard.component.css']
})

export class ElectionOfficerDashboardComponent implements OnInit {
  electionStatus = '';
  errorMessage = '';

  constructor(private authService: AuthService, private router: Router) {}
  ngOnInit(): void {}

  startElection() {
    this.authService.startElection().subscribe(
      response => {
        console.log('Election started successfully', response);
      },
      error => {
        console.error('Error starting the election', error);
        this.errorMessage = error;
      }
    );
  }

  endElection() {
    this.authService.endElection().subscribe(
      response => {
        console.log('Election ended successfully', response);
        this.electionStatus = 'Election has ended.';
      },
        error => {
          console.error('Error ending the election', error);
          this.errorMessage = error.message || 'An error occurred during ending the election.';
        }
    );
  }
}