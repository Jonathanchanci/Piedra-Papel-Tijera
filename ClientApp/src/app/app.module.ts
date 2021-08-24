import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { IniciarBatallaComponent } from './pages/iniciar-batalla/iniciar-batalla.component';
import { MovimientoComponent } from './pages/movimiento/movimiento.component';
import { ResultadoParcialComponent } from './pages/resultado-parcial/resultado-parcial.component';
import { GanadorComponent } from './pages/ganador/ganador.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    IniciarBatallaComponent,
    MovimientoComponent,
    ResultadoParcialComponent,
    GanadorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: IniciarBatallaComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'iniciar-batalla', component: IniciarBatallaComponent},
      { path: 'movimiento', component: MovimientoComponent },
      { path: 'resultado-parcial', component: ResultadoParcialComponent},
      { path: 'ganador', component: GanadorComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
