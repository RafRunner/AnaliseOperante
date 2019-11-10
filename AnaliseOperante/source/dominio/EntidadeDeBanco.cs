using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public abstract class EntidadeDeBanco {

		public long Id { get; set; }
		protected long GetId(EntidadeDeBanco value) {
			if (value == null) {
				return 0;
			}
			return value.Id;
		}

		protected long GetIdNullSafe(EntidadeDeBanco value, string classeFilha, string classePai) {
			if (value == null) {
				throw new Exception($"Todo {classeFilha} deve estar associado a um {classePai}!");
			}
			return value.Id;
		}

		protected long GetIdNullSafe(EntidadeDeBanco value) {
			if (value == null) {
				return 0;
			}
			return value.Id;
		}

		protected T NullCheck<T>(T value, string nomePropriedade, string nomeClasse) {
			if (value == null) {
				throw new Exception($"A propriedade {nomePropriedade} de {nomeClasse} não pode ser vazia!");
			}
			return value;
		}
	}
}
