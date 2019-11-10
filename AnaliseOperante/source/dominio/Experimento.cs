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
				nome = NullCheck(value, "Nome", "Experimento");
			}
		}

		public long IdLinhaDeBase { private get; set; }
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

		public List<Condicao> Condicoes { get; set; }
	}
}
