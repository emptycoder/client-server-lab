import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const endpoint = 'http://localhost:5000/api/calculation/';

@Injectable({
  providedIn: 'root'
})
export class MatrixService {
  constructor(private http: HttpClient) {}

  public calculateMatrix(data: any): Observable<any> {
    return this.http.post<any>(endpoint + 'multiplication', data);
  }
}
