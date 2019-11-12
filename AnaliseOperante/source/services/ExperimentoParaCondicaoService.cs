using AnaliseOperante.source.dominio;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class ExperimentoParaCondicaoService : AbstractService {

		public static List<Condicao> GetAllCondicoesByExperimento(Experimento experimento) {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				List<ExperimentoParaCondicao> experimentoParaCondicoes = cnn.Query<ExperimentoParaCondicao>("SELECT * FROM ExperimentoParaCondicao WHERE IdExperimento = @Id ORDER BY Ordem", experimento).ToList();

				return experimentoParaCondicoes.Select(it => {
					return CondicaoService.GetById(it.IdCondicao);
				}).ToList();
			}
		}

		public static void CreateByExperimento(Experimento experimento) {
			DeleteAllByExperimento(experimento);
			List<Condicao> condicoes = experimento.Condicoes;

			for(int i = 0; i < condicoes.Count; i++) {
				var condicao = condicoes[i];
				var experimentoParaCondicao = new ExperimentoParaCondicao {
					IdCondicao = condicao.Id,
					IdExperimento = experimento.Id,
					Ordem = i
				};

				using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
					cnn.Execute("INSERT INTO ExperimentoParaCondicao (IdExperimento, IdCondicao, Ordem) VALUES (@IdExperimento, @IdCondicao, @Ordem)", experimentoParaCondicao);
				}
			}
		}

		public static void DeleteAllByExperimento(Experimento experimento) {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				cnn.Execute("DELETE FROM ExperimentoParaCondicao WHERE IdExperimento = @Id", experimento);
			}
		}
	}
}
