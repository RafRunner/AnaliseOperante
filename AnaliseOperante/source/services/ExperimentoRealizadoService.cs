using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class ExperimentoRealizadoService : AbstractService {

		private static readonly string TABELA_ExperimentoRealizado = "ExperimentoRealizado";

		public static ExperimentoRealizado GetById(long id) {
			ExperimentoRealizado experimento = AbstractService.GetById<ExperimentoRealizado>(id, TABELA_ExperimentoRealizado);
			return experimento;
		}

		public static List<ExperimentoRealizado> GetAll() {
			return AbstractService.GetAll<ExperimentoRealizado>(TABELA_ExperimentoRealizado);
		}

		public static void Salvar(ExperimentoRealizado experimento) {
			AbstractService.Salvar<ExperimentoRealizado>(experimento, TABELA_ExperimentoRealizado,
				$"INSERT INTO {TABELA_ExperimentoRealizado} (NomeParticipante, IdadeParticipante, Grupo, CabineUtilizada, TempoDuração, DataHoraInicio, IdExperimento) VALUES (@NomeParticipante, @IdadeParticipante, @Grupo, @CabineUtilizada, @TempoDuração, @DataHoraInicio, @IdExperimento)",
				$"UPDATE {TABELA_ExperimentoRealizado} SET NomeParticipante = @NomeParticipante, IdadeParticipante = @IdadeParticipante, Grupo = @Grupo, CabineUtilizada = @CabineUtilizada, TempoDuração = @TempoDuração, DataHoraInicio = @DataHoraInicio, IdExperimento = @IdExperimento");
		}

		public static void Deletar(ExperimentoRealizado experimento) {
			experimento.Experimento = null;
			Salvar(experimento);
			AbstractService.Deletar(experimento, TABELA_ExperimentoRealizado);
		}
	}
}
