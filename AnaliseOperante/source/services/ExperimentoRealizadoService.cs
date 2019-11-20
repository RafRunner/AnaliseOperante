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
			experimento.SetListaEventos(EventoService.GetAllByExperimentoRealizado(experimento));
			return experimento;
		}

		public static List<ExperimentoRealizado> GetAll() {
			return AbstractService.GetAll<ExperimentoRealizado>(TABELA_ExperimentoRealizado);
		}

		public static void Salvar(ExperimentoRealizado experimento) {
			AbstractService.Salvar<ExperimentoRealizado>(experimento, TABELA_ExperimentoRealizado,
				$"INSERT INTO {TABELA_ExperimentoRealizado} (NomeParticipante, IdadeParticipante, Grupo, CabineUtilizada, DataHoraInicio, IdExperimento) VALUES (@NomeParticipante, @IdadeParticipante, @Grupo, @CabineUtilizada, @DataHoraInicio, @IdExperimento)",
				$"");

			EventoService.SalvarByExperimentoRealizado(experimento);
		}

		public static void Deletar(ExperimentoRealizado experimento) {
			experimento.GetListaEventos().ForEach(it => EventoService.Deletar(it));
			AbstractService.Deletar(experimento, TABELA_ExperimentoRealizado);
		}
	}
}
