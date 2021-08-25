import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Batalla } from '../../interface/batalla';
import { Jugador } from '../../interface/jugador';
import { JugadorBatallas } from '../../interface/jugador-batallas';
import { Movimiento } from '../../interface/movimiento';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-movimiento',
  templateUrl: './movimiento.component.html',
  styleUrls: ['./movimiento.component.css']
})
export class MovimientoComponent implements OnInit {

  idBatalla: string;
  idJugador1: string;
  idJugador2: string;
  public batalla: Batalla;
  public jugadorActual: Jugador;
  movimiento: Movimiento[] = [];
  ganador: JugadorBatallas;

  constructor(private route: ActivatedRoute, private service: GameService, private router: Router) { }

  ngOnInit() {
    this.idBatalla = this.route.snapshot.paramMap.get('idBat');
    this.idJugador1 = this.route.snapshot.paramMap.get('jug1');
    this.idJugador2 = this.route.snapshot.paramMap.get('jug2');

    //Consultar Batalla
    this.service.GetBatallaById(Number(this.idBatalla)).subscribe((resp: Batalla) => {
      this.batalla = resp;
    }, error => {
      this.errorFormulario("Error", error.error.message);
    });

    //Consultar Movimientos
    this.service.consultarMovimientos().subscribe((resp: Movimiento[]) => {
      this.movimiento = resp;
    });

    //Consultar Jugador
    this.consultarJugador(Number(this.idJugador1));
  }

  errorFormulario(titulo: string, texto: string) {
    Swal.fire({
      title: titulo,
      text: texto,
      icon: "error",
      allowOutsideClick: false
    });
  }

  consultarJugador(idJugador: number) {
    this.service.GetJugadorById(idJugador).subscribe((resp: Jugador) => {
      this.jugadorActual = resp;
    }, error => {
      this.errorFormulario("Error", error.error.message);
    });
  }

  MovimientoPiedra() {
    let piedra;
    this.movimiento.forEach(element => element.nombre == "PIEDRA" ? piedra = element.idMovimiento : "");
    if (piedra != undefined && piedra != "") {
      this.RegistrarMovimiento(this.jugadorActual.idJugador, piedra);
    }
  }

  MovimientoPapel() {
    let papel;
    this.movimiento.forEach(element => element.nombre == "PAPEL" ? papel = element.idMovimiento : "");
    if (papel != undefined && papel != "") {
      this.RegistrarMovimiento(this.jugadorActual.idJugador, papel);
    }
  }

  MovimientoTijera() {
    let tijera;
    this.movimiento.forEach(element => element.nombre == "TIJERA" ? tijera = element.idMovimiento : "");
    if (tijera != undefined && tijera != "") {
      this.RegistrarMovimiento(this.jugadorActual.idJugador, tijera);
    }
  }

  RegistrarMovimiento(idJugador: number, idMovimiento: number) {
    this.service.RegistrarMovimiento(idJugador, idMovimiento).subscribe((resp: JugadorBatallas) => {
      this.ganador = resp;
      if (this.ganador.gadador) {
        //Redireccionar a componente ganador
      }
      console.log("vamos bien hasta aqui");
    }, error => {
      this.errorFormulario("Error en " + error.error.eventoValidado, error.error.mensaje);
    });
  }
}
