import { JugadorBatallas } from "./jugador-batallas";

export interface ResponseIniciarBatalla {
  idBatalla: number,
  nombre: string,
  fechaInicio: Date,
  fechaFin?: Date,
  jugadorBatallas: JugadorBatallas,
  EventoValidado: string,
  Resultado: string,
  Mensaje: string,
  MensajeUsuario: string,
  MensajeEspecifico: string,
  StackTrace: string
}
