import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Entry } from '../Models/requests/entry';
import { Observable, of } from 'rxjs';
import { retry, catchError } from 'rxjs/internal/operators';
import { AppSettings } from 'src/app/appSettings';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};
@Injectable({
  providedIn: 'root'
}) 
export class EntryService {

  constructor(private httpClient: HttpClient) { }
  endPoint = AppSettings.API_ENDPOINT + 'api/entries';

  createEntry(entry: Entry): Observable<any> {
    return this.httpClient.post<any>(this.endPoint, entry, httpOptions).pipe(
      retry(3), catchError(this.handleError<any>('createEntry', [])));
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
