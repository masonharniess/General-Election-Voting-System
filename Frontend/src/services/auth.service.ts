import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'http://localhost:6001/api'; // Adjust this to your ASP.NET Core API URL

  constructor(private http: HttpClient) {}

  getCandidates(): Observable<any> {
    return this.http.get(`${this.baseUrl}/candidates`).pipe(
        catchError(err => this.handleError('fetching candidates', err))
    );
}

  handleError(operation = 'operation', error: HttpErrorResponse) {
    let errorMessage = `An error occurred during ${operation}.`;
    if (error.error instanceof ErrorEvent) {
        // Client-side error
        errorMessage = `Error: ${error.error.message}`;
    } else {
        if (error.status === 400 || error.status === 500) {
            errorMessage = error.error.message || errorMessage;
        }
    }
    return throwError(() => new Error(errorMessage));
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/login`, credentials);
  }

  register(userData: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/registration`, userData).pipe(
        catchError(err => this.handleError('registration', err))
    );
  }

  startElection(): Observable<any> {
    return this.http.post(`${this.baseUrl}/election/start`, {}).pipe(
        catchError(err => this.handleError('starting the election', err))
    );
  }

  endElection(): Observable<any> {
    return this.http.post(`${this.baseUrl}/election/end`, {}).pipe(
        catchError(err => this.handleError('ending the election', err))
    );
  }

  checkElectionIsActive(): Observable<any> {
    return this.http.get(`${this.baseUrl}/election/isActive`).pipe(
        catchError(err => this.handleError('checking election status', err))
    );
  }

  vote(userId: string, candidateId: string): Observable<any> {
    const voteData = { userId: userId, candidateId: candidateId };
    return this.http.post(`${this.baseUrl}/vote`, voteData).pipe(
        catchError(err => this.handleError('submitting the vote', err))
    );
}

getConstituencies(): Observable<any> {
  return this.http.get(`${this.baseUrl}/constituencies`).pipe(
      catchError(err => this.handleError('fetching constituencies', err))
  );
}


}

