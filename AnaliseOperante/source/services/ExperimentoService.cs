using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class ExperimentoService : AbstractService {

		private static readonly string TABELA_Experimento = "Experimento";

		public static Experimento GetById(long id) {
			Experimento experimento = AbstractService.GetById<Experimento>(id, TABELA_Experimento);
			if (experimento == null) {
				return null;
			}

			experimento.Condicoes = ExperimentoParaCondicaoService.GetAllCondicoesByExperimento(experimento);

			return experimento;
		}

		public static List<Experimento> GetByLinhaDeBase(LinhaDeBase linhaDeBase) {
			return AbstractService.GetByObj<Experimento>($"SELECT * FROM {TABELA_Experimento} WHERE IdLinhaDeBase = @Id", linhaDeBase);
		}

		public static List<Experimento> GetByCondicao(Condicao condicao) {
			return ExperimentoParaCondicaoService.GetAllExperimentosByCondicao(condicao);
		}

		public static List<Experimento> GetAll() {
			return AbstractService.GetAll<Experimento>(TABELA_Experimento);
		}

		public static void Salvar(Experimento experimento) {
			AbstractService.Salvar<Experimento>(experimento, TABELA_Experimento,
				$"INSERT INTO {TABELA_Experimento} (Nome, IdLinhaDeBase, Instrucao) VALUES (@Nome, @IdLinhaDeBase, @Instrucao)",
				$"UPDATE {TABELA_Experimento} SET Nome = @Nome, IdLinhaDeBase = @IdLinhaDeBase, Instrucao = @Instrucao");
			ExperimentoParaCondicaoService.CreateByExperimento(experimento);
		}

		public static void Deletar(Experimento experimento) {
			ExperimentoParaCondicaoService.DeleteAllByExperimento(experimento);
			AbstractService.Deletar(experimento, TABELA_Experimento);
		}
	}
}
