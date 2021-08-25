import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { ResponseIniciarBatalla } from '../../interface/response-iniciar-batalla';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-iniciar-batalla',
  templateUrl: './iniciar-batalla.component.html',
  styleUrls: ['./iniciar-batalla.component.css']
})
export class IniciarBatallaComponent implements OnInit {

  public jugador1: string;
  public jugador2: string;
  idjug1: number;
  idjug2: number;
  jugadores: string[] = [];
  constructor(private service: GameService, private router: Router) { }

  ngOnInit() {
  }

  IniciarBatalla(form: NgForm) {
    this.jugadores = [];
    if (form.invalid) {
      this.errorFormulario("Error", "Por favor ingrese todos los nombres de jugadores");
      return;
    }
    if (this.jugador1.trim() == "" || this.jugador2.trim() == "") {
      this.errorFormulario("Error", "Por favor ingrese todos los nombres de jugadores");
      return;
    }
    this.jugadores.push(this.jugador1);
    this.jugadores.push(this.jugador2);

    //Consumo servicio
    this.service.IniciarBatalla(this.jugadores).subscribe((resp: ResponseIniciarBatalla) => {
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
