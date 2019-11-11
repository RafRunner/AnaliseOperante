using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class CondicaoService : AbstractService {

		private static readonly string TABELA_Condicao = "Condicao";

		public static Condicao GetById(long id) {
			return AbstractService.GetById<Condicao>(id, TABELA_Condicao);
		}

		public static List<Condicao> GetAll() {
			return AbstractService.GetAll<Condicao>(TABELA_Condicao);
		}

		public static void Salvar(Condicao condicao) {
			AbstractService.Salvar<Condicao>(condicao, TABELA_Condicao,
				$"INSERT INTO {TABELA_Condicao} (Nome, CorQuadrado1, CorQuadrado2, CorQuadrado3, CorFundo, CorBorda, TempoApresentacao, PontosTotais, TempoGanhoPassivo, PontosGanhoPassivo, IdFeedBackQuadrado1, IdFeedBackQuadrado2, IdFeedBackQuadrado3) VALUES (@Nome, @CorQuadrado1, @CorQuadrado2, @CorQuadrado3, @CorFundo, @CorBorda, @TempoApresentacao, @PontosTotais, @TempoGanhoPassivo, @PontosGanhoPassivo, @IdFeedBackQuadrado1, @IdFeedBackQuadrado2, @IdFeedBackQuadrado3)",
				$"UPDATE {TABELA_Condicao} SET Nome = @Nome, CorQuadrado1 = @CorQuadrado1, CorQuadrado2 = @CorQuadrado2, CorQuadrado3 = @CorQuadrado3, CorFundo = @CorFundo, CorBorda = @CorBorda, TempoApresentacao = @TempoApresentacao,  PontosTotais =@PontosTotais, TempoGanhoPassivo = @TempoGanhoPassivo, PontosGanhoPassivo = @PontosGanhoPassivo, IdFeedBackQuadrado1 = @IdFeedBackQuadrado1, IdFeedBackQuadrado2 = @IdFeedBackQuadrado2, IdFeedBackQuadrado3 = @IdFeedBackQuadrado3");
		}

		public static void Deletar(Condicao condicao) {
			AbstractService.Deletar(condicao, TABELA_Condicao);
		}
	}
}
