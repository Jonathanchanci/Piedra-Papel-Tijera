import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResultadoParcial } from '../interface/resultado-parcial';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  public resultadoParcial: ResultadoParcial[];
  private url: "https://localhost:44314/api/Game/";
  constructor(private http: HttpClient) { }

  consultarResultado(idBatalla: number) {
    return this.http.get("https://localhost:44314/api/Game/Resultadoparcial/"+idBatalla);
  }
}
