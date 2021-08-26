import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ResultadoParcial } from '../../interface/resultado-parcial';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-resultado-parcial',
  templateUrl: './resultado-parcial.component.html',
  styleUrls: ['./resultado-parcial.component.css']
})
export class ResultadoParcialComponent implements OnInit {

  public resultadoParcial: ResultadoParcial[] = [];
  @Input() idBatalla: number;
  @Output() numRondas = new EventEmitter<number>();

  constructor(private service: GameService) { }

  ngOnInit() {
    
  }

  ActualizarResultadoParcial() {
    this.service.consultarResultado(this.idBatalla).subscribe((resp: ResultadoParcial[]) => {
      this.resultadoParcial = resp;
      this.numRondas.emit(resp.length + 1);
    });
  }

}
