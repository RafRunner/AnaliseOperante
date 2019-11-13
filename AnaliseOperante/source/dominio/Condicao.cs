using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class Condicao : FaseDoExperimento {
		// Em ms
		private long tempoGanhoPassivo;
		public long TempoGanhoPassivo {
			get => tempoGanhoPassivo;
			set {
				tempoGanhoPassivo = NonNegativeCheck(value, "Tempo Ganho Passivo", "Condição");
			}
		}
		public int PontosGanhoPassivo { get; set; }

		public long IdFeedBackQuadrado1 { get; set; }
		private FeedBack feedBackQuadrado1;
		public FeedBack FeedBackQuadrado1 {
			get {
				if (feedBackQuadrado1 == null) {
					feedBackQuadrado1 = FeedBackService.GetById(IdFeedBackQuadrado1);
				}
				return feedBackQuadrado1;
			}
			set {
				feedBackQuadrado1 = value;
				IdFeedBackQuadrado1 = GetIdNullSafe(value);
			}
		}

		public long IdFeedBackQuadrado2 { get; set; }
		private FeedBack feedBackQuadrado2;
		public FeedBack FeedBackQuadrado2 {
			get {
				if (feedBackQuadrado2 == null) {
					feedBackQuadrado2 = FeedBackService.GetById(IdFeedBackQuadrado2);
				}
				return feedBackQuadrado2;
			}
			set {
				feedBackQuadrado2 = value;
				IdFeedBackQuadrado2 = GetIdNullSafe(value);
			}
		}

		public long IdFeedBackQuadrado3 { get; set; }
		private FeedBack feedBackQuadrado3;
		public FeedBack FeedBackQuadrado3 {
			get {
				if (feedBackQuadrado3 == null) {
					feedBackQuadrado3 = FeedBackService.GetById(IdFeedBackQuadrado3);
				}
				return feedBackQuadrado3;
			}
			set {
				feedBackQuadrado3 = value;
				IdFeedBackQuadrado3 = GetIdNullSafe(value);
			}
		}

		public override void ToqueQuadrado1() {
			int pontosFeedback = FeedBackQuadrado1.Pontos;
			AtulizarPontos(pontosFeedback);
			FeedBackQuadrado1.PlayAudio();
		}

		public override void ToqueQuadrado2() {
			int pontosFeedback = FeedBackQuadrado2.Pontos;
			AtulizarPontos(pontosFeedback);
			FeedBackQuadrado2.PlayAudio();
		}

		public override void ToqueQuadrado3() {
			int pontosFeedback = FeedBackQuadrado3.Pontos;
			AtulizarPontos(pontosFeedback);
			FeedBackQuadrado3.PlayAudio();
		}

		public void AplicarGanhoPassivo() {
			AtulizarPontos(PontosGanhoPassivo);
		}
	}
}
