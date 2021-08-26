import { JugadorBatallas } from "./jugador-batallas";

export interface ResponseIniciarBatalla {
  idBatalla: number,
  nombre: string,
  fechaInicio: Date,
  fechaFin?: Date,
  jugadorBatallas: JugadorBatallas,
  eventoValidado: string,
  resultado: string,
  mensaje: string,
  MensajeUsuario: string,
  MensajeEspecifico: string,
  StackTrace: string
}
