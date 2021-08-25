import { Component, Input, OnInit } from '@angular/core';
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
  constructor(private service: GameService) { }

  ngOnInit() {
    this.service.consultarResultado(this.idBatalla).subscribe((resp: ResultadoParcial[]) => {      
      this.resultadoParcial = resp;
    });
  }

}
