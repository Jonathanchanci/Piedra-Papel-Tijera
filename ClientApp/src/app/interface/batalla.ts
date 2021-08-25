import { JugadorBatallas } from "./jugador-batallas";

export interface Batalla {
  idBatalla: number,
  nombre: string,
  fechaInicio: Date,
  fechaFin?: Date,
  jugadorBatallas: JugadorBatallas
}
