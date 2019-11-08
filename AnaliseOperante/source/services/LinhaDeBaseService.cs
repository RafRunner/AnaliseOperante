using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class LinhaDeBaseService : AbstractService {

		private static readonly string TABELA_LinhaDeBase = "LinhaDeBase";

		public static LinhaDeBase GetById(long id) {
			return AbstractService.GetById<LinhaDeBase>(id, TABELA_LinhaDeBase);
		}

		public static List<LinhaDeBase> GetAll() {
			return AbstractService.GetAll<LinhaDeBase>(TABELA_LinhaDeBase);
		}

		public static void Salvar(LinhaDeBase linhaDeBase) {
			AbstractService.Salvar<LinhaDeBase>(linhaDeBase, TABELA_LinhaDeBase,
				$"INSERT INTO {TABELA_LinhaDeBase} (Nome, CorQuadrado1, CorQuadrado2, CorQuadrado3, CorFundo, CorBorda, TempoApresentacao, PontosTotais) VALUES (@Nome, @CorQuadrado1, @CorQuadrado2, @CorQuadrado3, @CorFundo, @CorBorda, @TempoApresentacao, @PontosTotais)",
				$"UPDATE {TABELA_LinhaDeBase} SET Nome = @Nome, CorQuadrado1 = @CorQuadrado1, CorQuadrado2 = @CorQuadrado2, CorQuadrado3 = @CorQuadrado3, CorFundo = @CorFundo, CorBorda = @CorBorda, TempoApresentacao = @TempoApresentacao, PontosTotais = @PontosTotais");
		}

		public static void Deletar(LinhaDeBase linhaDeBase) {
			AbstractService.Deletar(linhaDeBase, TABELA_LinhaDeBase);
		}
	}
}
