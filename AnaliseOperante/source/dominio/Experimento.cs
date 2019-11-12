using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class Experimento : EntidadeDeBanco {

		private string nome;
		public string Nome {
			get => nome;
			set {
				nome = NullEmptyBlankCheck(value, "Nome", "Experimento");
			}
		}

		private string instrucao;
		public string Instrucao {
			get => instrucao;
			set {
				instrucao = NullEmptyBlankCheck(value, "Instrução", "Experimento");
			}
		}

		public long IdLinhaDeBase { get; set; }
		private LinhaDeBase linhaDeBase;
		public LinhaDeBase LinhaDeBase {
			get {
				if (linhaDeBase == null) {
					linhaDeBase = LinhaDeBaseService.GetById(IdLinhaDeBase);
				}
				return linhaDeBase;
			}
			set {
				linhaDeBase = value;
				IdLinhaDeBase = GetIdNullSafe(value);
			}
		}

		public List<Condicao> Condicoes = new List<Condicao>();
	}
}
