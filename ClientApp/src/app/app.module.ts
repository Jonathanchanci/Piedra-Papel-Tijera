import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './shared/nav-menu/nav-menu.component';
import { IniciarBatallaComponent } from './pages/iniciar-batalla/iniciar-batalla.component';
import { MovimientoComponent } from './pages/movimiento/movimiento.component';
import { ResultadoParcialComponent } from './pages/resultado-parcial/resultado-parcial.component';
import { GanadorComponent } from './pages/ganador/ganador.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';
import { BatallasComponent } from './pages/batallas/batallas.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    IniciarBatallaComponent,
    MovimientoComponent,
    ResultadoParcialComponent,
    GanadorComponent,
    NotFoundComponent,
    BatallasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: IniciarBatallaComponent, pathMatch: 'full' },
      { path: 'iniciar-batalla', component: IniciarBatallaComponent},
      { path: 'movimiento/:idBat/:jug1/:jug2', component: MovimientoComponent },
      { path: 'resultado-parcial', component: ResultadoParcialComponent},
      { path: 'ganador/:idBat/:ganador/:perdedor', component: GanadorComponent },
      { path: 'batallas', component: BatallasComponent},
      { path: "**", pathMatch: "full", component: NotFoundComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
