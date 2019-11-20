using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class ExperimentoRealizado : EntidadeDeBanco {

		private static readonly string FORMATO_DATE_TIME = "yyyy-MM-dd HH:mm:ss";
		private static readonly string FORMATO_DATE_TIME_ARQUIVO = "yyyy-MM-dd HH-mm-ss";

		public long IdExperimento { get; set; }
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

		public DateTime DateTimeInicio {
			get {
				return Convert.ToDateTime(DataHoraInicio, new CultureInfo("pt-BR"));
			}
			set {
				DataHoraInicio = value.ToString(FORMATO_DATE_TIME);
			}
		}

		public string DataHoraInicio { get; set; }

		private List<Evento> eventos = new List<Evento>();

		public void RegistrarEvento(Evento evento) {
			evento.Horario = Convert.ToInt64((DateTime.Now - DateTimeInicio).TotalSeconds);
			eventos.Add(evento);
		}

		public List<Evento> GetListaEventos() {
			return eventos;
		}

		public void SetListaEventos(List<Evento> eventos) {
			this.eventos = eventos;
		}

		public string GetNomeArquivo() {
			return $"{DateTimeInicio.ToString(FORMATO_DATE_TIME_ARQUIVO)} - {NomeParticipante} - grupo '{Grupo}' - cabine '{CabineUtilizada}'";
		}

		public string Nome {
			get => $"{DataHoraInicio} - {NomeParticipante} - grupo {Grupo} - cabine {CabineUtilizada}";
		}

	}
}
