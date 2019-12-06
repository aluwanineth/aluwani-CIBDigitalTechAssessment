import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { retry, catchError } from 'rxjs/internal/operators';
import { PhoneBook } from '../models/requests/phoneBook';
import { PhoneBooks } from '../models/responses/phoneBooks';
import { AppSettings } from 'src/app/appSettings';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class PhoneBookService {

  constructor(private httpClient: HttpClient) { }
  endPoint = AppSettings.API_ENDPOINT + 'api/PhoneBooks';

  createPhoneBook(phoneBook: PhoneBook): Observable<any> {
    return this.httpClient.post<any>(this.endPoint, phoneBook, httpOptions).pipe(
      retry(3), catchError(this.handleError<any>('createPhoneBook', [])));
  }

  getPhoneBooks(): Observable<PhoneBooks>{
    return this.httpClient.get<any>(this.endPoint, httpOptions).pipe(
      retry(3), catchError(this.handleError<any>('getPhoneBooks', [])));
  }

  getPhoneBookEntryByName(phoneBookId: number, name: string): Observable<PhoneBooks>{
    const url = this.endPoint + '/GetPhoneBookByName?phoneBookId=' + phoneBookId + '&name=' + name;
    return this.httpClient.get<any>(url, httpOptions).pipe(
      retry(3), catchError(this.handleError<any>('getPhoneBooks', [])));
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      this.log(`${operation} failed: ${error.message}`);
      return of(result as T);
    };
  }
  private log(message: string) {
    console.log(message);
  }
}

