import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  private url: "https://localhost:44314/api/Game/";
  constructor(private http: HttpClient) { }
}
