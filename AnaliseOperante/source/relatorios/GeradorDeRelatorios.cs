using AnaliseOperante.source.dominio;
using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.relatorios {
	public class GeradorDeRelatorios {

		private static string PASTA_RELATORIOS = "Relatorios";
		private static readonly string FORMATO_DATE_TIME = "HH:mm:ss";

		private readonly ExperimentoRealizado experimentoRealizado;

		public GeradorDeRelatorios(ExperimentoRealizado experimentoRealizado) {
			this.experimentoRealizado = experimentoRealizado;
		}

		private static void CreateDirectoryIfNotExists() {
			if (!Directory.Exists(GetPath())) {
				Directory.CreateDirectory(GetPath());
			}
		}

		public static string GetPath(string nomeArquivo = "") {
			return Ambiente.GetFullPath(PASTA_RELATORIOS, nomeArquivo);
		}

		public void GerarRelatorio() {
			if (experimentoRealizado.GetListaEventos().Count == 0) {
				throw new Exception("Não se pode geara relatório de ume experimento sem eventos!");
			}

			CreateDirectoryIfNotExists();
			StringBuilder relatorio = GeraRodape(GeraEventos(GeraCabecalho(new StringBuilder())));

			File.WriteAllText(GetPath(experimentoRealizado.GetNomeArquivo()) + ".txt", relatorio.ToString());
		}

		private StringBuilder GeraCabecalho(StringBuilder relatorio) {
			relatorio.AppendLine("Relatório de Análise Operante").AppendLine();

			relatorio.Append("Nome do participante: ").AppendLine(experimentoRealizado.NomeParticipante);
			relatorio.Append("Idade do participante: ").AppendLine(experimentoRealizado.IdadeParticipante.ToString());
			relatorio.Append("Grupo do participante: ").AppendLine(experimentoRealizado.Grupo);
			relatorio.Append("Cabine utilizada: ").AppendLine(experimentoRealizado.CabineUtilizada).AppendLine();

			relatorio.AppendLine("Data hora do início do experimento: ").AppendLine(experimentoRealizado.DataHoraInicio).AppendLine();

			return relatorio;
		}

		private string RegistraEvento(Evento evento) {
			DateTime horaEvento = experimentoRealizado.DateTimeInicio.AddSeconds(evento.Horario);

			return $"\t{horaEvento.ToString(FORMATO_DATE_TIME)} - {evento.Origem} - {evento.Texto}";
		}

		private StringBuilder GeraEventos(StringBuilder relatorio) {
			relatorio.AppendLine("Eventos do experimento:").AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////").AppendLine();
			
			string ultimaOrigemEvento = experimentoRealizado.GetListaEventos().First().Origem;

			foreach (Evento evento in experimentoRealizado.GetListaEventos()) {
				if (ultimaOrigemEvento != evento.Origem) {
					relatorio.AppendLine();
					ultimaOrigemEvento = evento.Origem;
				}

				relatorio.AppendLine(RegistraEvento(evento));
			}

			relatorio.AppendLine().AppendLine("////////////////////////////////////////////////////////////////////////////////////////////////////").AppendLine();

			return relatorio;
		}

		private StringBuilder GeraRodape(StringBuilder relatorio) {
			DateTime horaFimExperimento = experimentoRealizado.DateTimeInicio.AddSeconds(experimentoRealizado.GetListaEventos().Last().Horario);

			relatorio.AppendLine("Resumo do relatório:").AppendLine();

			relatorio.Append("Total de eventos gerados: ").AppendLine(experimentoRealizado.GetListaEventos().Count.ToString());
			relatorio.Append("Duração do experimento em segundos: ").AppendLine(horaFimExperimento.Subtract(experimentoRealizado.DateTimeInicio).TotalSeconds.ToString()) ;

			return relatorio;
		}
	}
}
