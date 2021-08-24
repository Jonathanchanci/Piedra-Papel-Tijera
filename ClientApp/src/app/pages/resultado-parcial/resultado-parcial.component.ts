import { Component, OnInit } from '@angular/core';
import { ResultadoParcial } from '../../interface/resultado-parcial';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-resultado-parcial',
  templateUrl: './resultado-parcial.component.html',
  styleUrls: ['./resultado-parcial.component.css']
})
export class ResultadoParcialComponent implements OnInit {

  resultadoParcial: ResultadoParcial[] = [];
  constructor(private service: GameService) { }

  ngOnInit() {
    this.service.consultarResultado(5).subscribe((resp: ResultadoParcial[]) => {
      console.log(resp);
      this.resultadoParcial = resp;
    });
  }

}
