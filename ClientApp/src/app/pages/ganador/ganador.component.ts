import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { Batalla } from '../../interface/batalla';
import { Jugador } from '../../interface/jugador';
import { ResponseIniciarBatalla } from '../../interface/response-iniciar-batalla';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-ganador',
  templateUrl: './ganador.component.html',
  styleUrls: ['./ganador.component.css']
})
export class GanadorComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: GameService, private router: Router) { }

  idBatalla: string;
  ganador: string;
  perdedor: string;
  jugadores: number[] =[];
  public batalla: Batalla;
  public jugadorGanador: Jugador;
  idjug1: number;
  idjug2: number;

  ngOnInit() {
    this.idBatalla = this.route.snapshot.paramMap.get('idBat');
    this.ganador = this.route.snapshot.paramMap.get('ganador');
    this.perdedor = this.route.snapshot.paramMap.get('perdedor');

    //Consultar Batalla
    this.service.GetBatallaById(Number(this.idBatalla)).subscribe((resp: Batalla) => {
      this.batalla = resp;
    }, error => {
      this.errorFormulario("Error", error.error.message);
    });

    //Consulto Ganador
    this.service.GetJugadorById(Number(this.ganador)).subscribe((resp: Jugador) => {
      this.jugadorGanador = resp;
    }, error => {
      this.errorFormulario("Error", error.error.message);
    });
  }

  IniciarRevancha() {
    this.jugadores.push(Number(this.ganador));
    this.jugadores.push(Number(this.perdedor));

    this.service.IniciarRevancha(this.jugadores).subscribe((resp: ResponseIniciarBatalla) => {
      this.idjug1 = resp.jugadorBatallas[0].fkIdJugador;
      this.idjug2 = resp.jugadorBatallas[1].fkIdJugador;

      this.router.navigateByUrl(`/movimiento/${resp.idBatalla}/${this.idjug1}/${this.idjug2}`);
    }, error => {
      this.errorFormulario("Error en " + error.error.eventoValidado, error.error.mensaje);
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
