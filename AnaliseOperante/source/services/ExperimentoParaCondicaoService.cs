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

		public static void DeleteAllByExperimento(Experimento experimento) {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				cnn.Execute("DELETE * FROM ExperimentoParaCondicao WHERE IdExperimento = @Id", experimento);
			}
		}
	}
}
