import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ResultadoParcial } from '../interface/resultado-parcial';

@Injectable({
  providedIn: 'root'
})
export class GameService {

  public resultadoParcial: ResultadoParcial[];
  private URL: string = "https://localhost:44314/api/";
  

  constructor(private http: HttpClient) { }

  consultarResultado(idBatalla: number) {
    return this.http.get(`${this.URL}Game/Resultadoparcial/${idBatalla}`);
  }

  IniciarBatalla(jugadores: string[]) {
    return this.http.post(`${this.URL}Game/IniciarBatalla`, jugadores);
  }

  RegistrarMovimiento(idJugador: number, idMovimiento: number) {
    return this.http.get(`${this.URL}Game/RegistrarMovimiento/${idJugador}/${idMovimiento}`);
  }

  GetBatallaById(idBatalla: number) {
    return this.http.get(`${this.URL}Batalla/${idBatalla}`);
  }

  GetJugadorById(idJugador: number) {
    return this.http.get(`${this.URL}Jugador/${idJugador}`);
  }

  consultarMovimientos() {
    return this.http.get(`${this.URL}movimiento`)
  }

  IniciarRevancha(jugadores: number[]) {
    return this.http.post(`${this.URL}Game/IniciarRevancha`, jugadores);
  }
}
