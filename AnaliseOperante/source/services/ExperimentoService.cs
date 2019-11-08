using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class ExperimentoService : AbstractService {

		private static readonly string TABELA_Experimento = "Condicao";

		public static Experimento GetById(long id) {
			Experimento experimento = AbstractService.GetById<Experimento>(id, TABELA_Experimento);
			experimento.Condicoes = ExperimentoParaCondicaoService.GetAllCondicoesByExperimento(experimento);

			return experimento;
		}

		public static List<Experimento> GetAll() {
			return AbstractService.GetAll<Experimento>(TABELA_Experimento);
		}

		public static void Salvar(Experimento experimento) {
			AbstractService.Salvar<Experimento>(experimento, TABELA_Experimento,
				$"INSERT INTO {TABELA_Experimento} (CorQuadrado1, CorQuadrado2, CorQuadrado3, CorFundo, CorBorda, TempoApresentacao, PontosTotais, TempoGanhoPassivo, PontosGanhoPassivo, IdFeedBackQuadrado1, IdFeedBackQuadrado2, IdFeedBackQuadrado3) VALUES (@CorQuadrado1, @CorQuadrado2, @CorQuadrado3, @CorFundo, @CorBorda, @TempoApresentacao, @PontosTotais, @TempoGanhoPassivo, @PontosGanhoPassivo, @IdFeedBackQuadrado1, @IdFeedBackQuadrado2, @IdFeedBackQuadrado3)",
				$"UPDATE {TABELA_Experimento} SET CorQuadrado1 = @CorQuadrado1, CorQuadrado2 = @CorQuadrado2, CorQuadrado3 = @CorQuadrado3, CorFundo = @CorFundo, CorBorda = @CorBorda, TempoApresentacao = @TempoApresentacao,  PontosTotais =@PontosTotais, TempoGanhoPassivo = @TempoGanhoPassivo, PontosGanhoPassivo = @PontosGanhoPassivo, IdFeedBackQuadrado1 = @IdFeedBackQuadrado1, IdFeedBackQuadrado2 = @IdFeedBackQuadrado2, IdFeedBackQuadrado3 = @IdFeedBackQuadrado3");

		}

		public static void Deletar(Experimento experimento) {
			AbstractService.Deletar(experimento, TABELA_Experimento);
		}
	}
}
