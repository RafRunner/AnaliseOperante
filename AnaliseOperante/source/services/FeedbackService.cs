using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class FeedBackService : AbstractService {

		private static readonly string TABELA_Feedback = "Feedback";

		public static FeedBack GetById(long id) {
			return AbstractService.GetById<FeedBack>(id, TABELA_Feedback);
		}

		public static List<FeedBack> GetAll() {
			return AbstractService.GetAll<FeedBack>(TABELA_Feedback);
		}

		public static void Salvar(FeedBack linhaDeBase) {
			AbstractService.Salvar<FeedBack>(linhaDeBase, TABELA_Feedback,
				$"INSERT INTO {TABELA_Feedback} (NomeAudio, CorBlink, Pontos) VALUES (@NomeAudio, @CorBlink, @Pontos)",
				$"UPDATE {TABELA_Feedback} SET NomeAudio = @NomeAudio, CorBlink = @CorBlink, Pontos = @Pontos");
		}

		public static void Deletar(FeedBack feedback) {
			AbstractService.Deletar(feedback, TABELA_Feedback);
		}
	}
}
