import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-voter-dashboard',
    templateUrl: './voter-dashboard.component.html',
    styleUrls: ['./voter-dashboard.component.css']
})
export class VoterDashboardComponent implements OnInit {
  candidates: any[''];
  selectedCandidateId: string = '';
  activeElection: boolean = false;
  voterName: string = ''; 
  errorMessage: string = '';
  successMessage: string =  '';

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.checkForActiveElection();
    this.fetchCandidates();
    this.voterName = 'voter'; 
  }

  checkForActiveElection() {
    // Fetch the election status from the backend
    this.authService.checkElectionIsActive().subscribe(
      response => {
        // Assuming the backend returns a boolean value for the election status
        this.activeElection = response;
      },
      error => {
        console.error('Error checking election status', error);
        this.errorMessage = error.message;
      }
    );
  }

  fetchCandidates() {
    this.authService.getCandidates().subscribe(
      response => {
        this.candidates = response;
      },
      error => {
        console.error('Error fetching candidates', error);
        this.errorMessage = error.message;
      }
    );
  }

  submitVote() {
    if (!this.selectedCandidateId) {
        this.errorMessage = 'Please select a candidate to vote for.';
        return;
    }
  
    const userId = localStorage.getItem('userId');
    if (!userId) {
        this.errorMessage = 'User ID not found. Please log in again.';
        return;
    }
  
    this.authService.vote(userId, this.selectedCandidateId).subscribe(
        response => {
            console.log('Vote submitted successfully', response);
            this.successMessage = response.message; // Set the success message from the response
            this.errorMessage = ''; // Clear any previous error messages
        },
        error => {
            console.error('Error submitting vote', error);
            this.errorMessage = error.message;
            this.successMessage = ''; // Clear any previous success messages
        }
    );
  }
  
  

}
