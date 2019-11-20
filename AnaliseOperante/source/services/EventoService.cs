using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class EventoService : AbstractService {

		private static readonly string TABELA_EVENTOS = "Evento";

		public static Evento GetById(long id) {
			return AbstractService.GetById<Evento>(id, TABELA_EVENTOS);
		}

		public static List<Evento> GetAll() {
			return AbstractService.GetAll<Evento>(TABELA_EVENTOS);
		}

		public static List<Evento> GetAllByExperimentoRealizado(ExperimentoRealizado experimentoRealizado) {
			return AbstractService.GetByObj<Evento>($"SELECT * FROM {TABELA_EVENTOS} WHERE IdExperimento = @Id ORDER BY Horario", experimentoRealizado);
		}

		public static void Salvar(Evento evento) {
			AbstractService.Salvar<Evento>(evento, TABELA_EVENTOS,
				$"INSERT INTO {TABELA_EVENTOS} (Texto, IdExperimento, Origem, Horario) VALUES (@Texto, @IdExperimento, @Origem, @Horario)",
				"");
		}

		public static void SalvarByExperimentoRealizado(ExperimentoRealizado experimentoRealizado) {
			List<Evento> eventos = experimentoRealizado.GetListaEventos();

			foreach (Evento evento in eventos) {
				evento.IdExperimento = experimentoRealizado.Id;
				Salvar(evento);
			}
		}

		public static void Deletar(Evento evento) {
			AbstractService.Deletar(evento, TABELA_EVENTOS);
		}

		public static void DeletarByExperimentoRealizado(ExperimentoRealizado experimentoRealizado) {
			experimentoRealizado.GetListaEventos().ForEach(it => Deletar(it));
		}

	}
}
