﻿using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class ExperimentoRealizado : EntidadeDeBanco {

		private static readonly string FORMATO_DATE_TIME = "yyyy-MM-dd HH:mm:ss";

		public long IdExperimento { private get; set; }
		private Experimento experimento;
		public Experimento Experimento {
			get {
				if (experimento == null) {
					experimento = ExperimentoService.GetById(IdExperimento);
				}
				return experimento;
			}
			set {
				experimento = value;
				IdExperimento = experimento == null ? 0 : experimento.Id;
			}
		}

		private string nomeParticipante;
		public string NomeParticipante {
			get => nomeParticipante;
			set {
				nomeParticipante = NullEmptyBlankCheck(value, "Nome do Participante", "Experimento");
			}
		}

		private int idadeParticipante;
		public int IdadeParticipante {
			get => idadeParticipante;
			set {
				idadeParticipante = GreaterThanZeroCheck(value, "Idade do Participante", "Experimento");
			}
		}

		public string Grupo { get; set; }
		public string CabineUtilizada { get; set; }
		//Tempo em Segundos (não é predeterminado, é o corrido)
		public long TempoDuracao { get; set; }

		private DateTime dateTimeInicio;
		public DateTime DateTimeInicio {
			get => dateTimeInicio;
			set {
				dateTimeInicio = value;
				DataHoraInicio = dateTimeInicio.ToString(FORMATO_DATE_TIME);
			}
		}

		public string DataHoraInicio { get; set; }

		private List<Evento> eventos = new List<Evento>();

		public void RegistrarEvento(Evento evento) {
			eventos.Add(evento);
			evento.IdExperimento = experimento.Id;
			evento.Horario = Convert.ToInt64((DateTime.Now - DateTimeInicio).TotalSeconds);
		}

		public List<Evento> GetListaEventos() {
			return eventos;
		}

		public string GetNomeArquivo() {
			return $"Relatório ${NomeParticipante} - grupo {Grupo} - cabine {CabineUtilizada} - {DataHoraInicio}";
		}

	}
}
