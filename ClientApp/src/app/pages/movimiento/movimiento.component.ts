import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Batalla } from '../../interface/batalla';
import { Jugador } from '../../interface/jugador';
import { JugadorBatallas } from '../../interface/jugador-batallas';
import { Movimiento } from '../../interface/movimiento';
import { GameService } from '../../services/game.service';
import { ResultadoParcialComponent } from '../resultado-parcial/resultado-parcial.component';

@Component({
  selector: 'app-movimiento',
  templateUrl: './movimiento.component.html',
  styleUrls: ['./movimiento.component.css']
})
export class MovimientoComponent implements OnInit {

  public batalla: Batalla;
  public jugadorActual: Jugador;
  public numRonda: number;
  idBatalla: string;
  idJugador1: string;
  idJugador2: string;
  movimiento: Movimiento[] = [];
  ganador: JugadorBatallas;
  perdedor: string;

  Toast = Swal.mixin({
    toast: true,
    position: 'center',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
      toast.addEventListener('mouseenter', Swal.stopTimer)
      toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
  });

  @ViewChild(ResultadoParcialComponent, { static: false }) resultadoParcial !: ResultadoParcialComponent;

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

  ngAfterViewInit() {
    this.resultadoParcial.ActualizarResultadoParcial();
  }

  UpdateRondas(numRon: number) {
    this.numRonda = numRon;
  }

  consultarJugador(idJugador: number) {
    this.service.GetJugadorById(idJugador).subscribe((resp: Jugador) => {
      this.jugadorActual = resp;
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Turno de ' + resp.nombre,
        showConfirmButton: false,
        timer: 3500
      })
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
        if (this.ganador.fkIdJugador == Number(this.idJugador1))
          this.perdedor = this.idJugador2;
        else
          this.perdedor = this.idJugador1;
        this.router.navigateByUrl(`/ganador/${this.idBatalla}/${this.ganador.fkIdJugador}/${this.perdedor}`);
      } else {
        //Cambio de jugador
        if (this.jugadorActual.idJugador == Number(this.idJugador1))
          this.consultarJugador(Number(this.idJugador2));
        else
          this.consultarJugador(Number(this.idJugador1));

        this.resultadoParcial.ActualizarResultadoParcial();
      }
    }, error => {
      this.errorFormulario("Error en " + error.error.eventoValidado, error.error.mensaje);
    });
  }

  MensajeOk(msg: string) {
    this.Toast.fire({
      icon: "success",
      text: "Movimiento almacenado"
    });
  }

  errorFormulario(titulo: string, texto: string) {
    Swal.fire({
      title: titulo,
      text: texto,
      icon: "error",
      allowOutsideClick: false
    });
  }
}
