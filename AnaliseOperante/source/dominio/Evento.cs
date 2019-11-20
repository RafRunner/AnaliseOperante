using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class Evento : EntidadeDeBanco {

		//Construtor vazio para o Dapper
		public Evento() { }

		public Evento(string texto, string origem) {
			Texto = texto;
			Origem = origem;
		}

		public string Texto { get; set; }

		public string Origem { get; set; }

		public long IdExperimento { get; set; }
		private ExperimentoRealizado experimento;
		public ExperimentoRealizado ExperimentoRealizado {
			get {
				if (experimento == null) {
					experimento = ExperimentoRealizadoService.GetById(IdExperimento);
				}
				return ExperimentoRealizado;
			}
			set {
				IdExperimento = GetIdNullSafe(value, "Evento", "Experimento Realizado");
				experimento = value;
			}
		}

		//Na verdade é apenas o offset em segundos a partir do início do experimento
		public long Horario { get; set; }
	}
}
