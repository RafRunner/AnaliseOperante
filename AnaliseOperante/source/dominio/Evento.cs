using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class Evento : EntidadeDeBanco {

		public string Texto { get; set; }

		public string Origem { get; set; }

		public long IdExperimento { get; set; }
		private Experimento experimento;
		public Experimento Experimento {
			get => experimento;
			set {
				IdExperimento = GetIdNullSafe(value, "Evento", "Experimento");
				experimento = value;
			}
		}

		//Na verdade é apenas o offset em segundos a partir do início do experimento
		public long Horario { get; set; }
	}
}
