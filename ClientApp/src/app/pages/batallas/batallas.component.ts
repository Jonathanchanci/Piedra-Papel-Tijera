import { Component, OnInit } from '@angular/core';
import { Batalla } from '../../interface/batalla';
import { GameService } from '../../services/game.service';

@Component({
  selector: 'app-batallas',
  templateUrl: './batallas.component.html',
  styleUrls: ['./batallas.component.css']
})
export class BatallasComponent implements OnInit {

  public listaBatallas: Batalla[] = [];
  constructor(private service: GameService) { }

  ngOnInit() {
    this.service.GetListBatallas().subscribe((resp: Batalla[]) => {
      this.listaBatallas = resp;
    });
  }

}
