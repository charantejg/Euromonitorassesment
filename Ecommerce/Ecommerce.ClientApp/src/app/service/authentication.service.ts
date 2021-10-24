import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { loggedinUser } from '../models/loggedInUser';
import {user} from '../models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {


  private pathAPI =  environment.baseUrl;
  private controllername = 'api/user/login';

  constructor(private httpClient: HttpClient) { }



  login(user: user) :Observable<loggedinUser>
  {
    return this.httpClient.post<loggedinUser>(this.pathAPI+this.controllername,user)
    .pipe(map(response => {
      if (response && response.token) {

        localStorage.setItem('authToken', response.token);
        localStorage.setItem('userId', response.id.toString());
        localStorage.setItem('email', response.email);
        localStorage.setItem('isLoggedIn', "true");
      }
      return response;
    }),
      catchError(this.errorHandler)
    );
  }


    errorHandler(error: {
      error: { message: string };
      status: any;
      message: any;
    }) {
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        errorMessage = error.error.message;
      } else {
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
      return throwError(errorMessage);
    }

}
