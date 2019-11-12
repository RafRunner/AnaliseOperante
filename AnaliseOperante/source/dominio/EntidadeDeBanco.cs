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
			if (value.Equals(default(T))) {
				throw new Exception($"A propriedade {nomePropriedade} de {nomeClasse} não pode ser vazia!");
			}
			return value;
		}

		protected string NullEmptyBlankCheck(string value, string nomePropriedade, string nomeObjeto) {
			if (string.IsNullOrWhiteSpace(value)) {
				throw new Exception($"{nomePropriedade} de {nomeObjeto} não pode ser vazio!");
			}
			return value;
		}

		protected int GreaterThanZeroCheck(int valor, string nomePropriedade, string nomeObjeto) {
			if (valor <= 0) {
				throw new Exception($"{nomePropriedade} de {nomeObjeto} deve ser positiva maior que zero!");
			}
			return valor;
		}

		protected int NonNegativeCheck(int valor, string nomePropriedade, string nomeObjeto) {
			if (valor < 0) {
				throw new Exception($"{nomePropriedade} de {nomeObjeto} não pode ser negativa!");
			}
			return valor;
		}

		protected long NonNegativeCheck(long valor, string nomePropriedade, string nomeObjeto) {
			if (valor < 0) {
				throw new Exception($"{nomePropriedade} de {nomeObjeto} não pode ser negativa!");
			}
			return valor;
		}

		protected int NotZeroCheck(int valor, string nomePropriedade, string nomeObjeto) {
			if (valor == 0) {
				throw new Exception($"{nomePropriedade} de {nomeObjeto} não pode ser zero!");
			}
			return valor;
		}
	}
}
