using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaliseOperante.source.view {
	public partial class ExperimentoView : Form {

		private readonly ExperimentoRealizado experimentoRealizado;
		private readonly Experimento experimento;

		private Timer timerAtual;
		private Timer timerPontosPassivos;

		private FaseDoExperimento faseAtual;

		private TaskCompletionSource<bool> taskCondicaoAtual;

		public ExperimentoView(ExperimentoRealizado experimentoRealizado) {
			InitializeComponent();

			this.experimentoRealizado = experimentoRealizado;
			experimento = experimentoRealizado.Experimento;

			ApresentarLinhaDeBase(experimento.LinhaDeBase);
		}

		private void ExperimentoView_Load(object sender, EventArgs e) {
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;

			Location = new Point(0, 0);
			Size = new Size(width, height);
		}

		private void ColorirTela(FaseDoExperimento fase) {
			BackColor = fase.ColorFundo;
			Borda1.BackColor = fase.ColorBorda;
			Borda2.BackColor = fase.ColorBorda;
			Borda3.BackColor = fase.ColorBorda;

			Quadrado1.BackColor = fase.ColorQuadrado1;
			Quadrado2.BackColor = fase.ColorQuadrado2;
			Quadrado3.BackColor = fase.ColorQuadrado3;
		}

		private void EventoFimTempoLinhaDeBase(Object myObject, EventArgs myEventArgs) {
			timerAtual.Stop();
			ApresentarCondicoes(experimento.Condicoes);
		}

		private void EventoFimCondicao(Object myObject, EventArgs myEventArgs) {
			timerAtual.Stop();
			taskCondicaoAtual.TrySetResult(true);
		}

		private void EventoPontosPassivos(Object myObject, EventArgs myEventArgs) {
			(faseAtual as Condicao).AplicarGanhoPassivo();
			AtualizarLabelsPontos(faseAtual);
			CheckFimCondicao(faseAtual as Condicao);
		}

		private void ApresentarLinhaDeBase(LinhaDeBase linhaDeBase) {
			if (linhaDeBase == null) {
				ApresentarCondicoes(experimento.Condicoes);
				return;
			}
			faseAtual = linhaDeBase;
			ColorirTela(linhaDeBase);

			AtualizarLabelsPontos(linhaDeBase);

			timerAtual = new Timer {
				Interval = Convert.ToInt32(linhaDeBase.TempoApresentacao) * 1000
			};
			timerAtual.Tick += new EventHandler(EventoFimTempoLinhaDeBase);
			timerAtual.Start();
		}

		private void AtualizarLabelsPontos(FaseDoExperimento fase) {
			labelPontosGanhos.Text = fase.PontosGanhos.ToString();
			labelPontosTotais.Text = fase.PontosTotais.ToString();
			labelPontosPerdidos.Text = fase.PontosPerdidos.ToString();
		}

		private void IniciarTimerPontosPassivos(Condicao condicao) {
			if (timerPontosPassivos != null) {
				timerPontosPassivos.Stop();
			}

			timerPontosPassivos = new Timer {
				Interval = Convert.ToInt32(condicao.TempoGanhoPassivo) * 1000
			};
			timerPontosPassivos.Tick += new EventHandler(EventoPontosPassivos);
			timerPontosPassivos.Start();
		}

		private void ApresentarCondicao(Condicao condicao) {
			faseAtual = condicao;
			ColorirTela(condicao);

			AtualizarLabelsPontos(condicao);

			if (condicao.TempoApresentacao > 0) {
				timerAtual = new Timer {
					Interval = Convert.ToInt32(condicao.TempoApresentacao) * 1000
				};
				timerAtual.Tick += new EventHandler(EventoFimCondicao);
				timerAtual.Start();
			}

			if (condicao.TempoGanhoPassivo > 0 && condicao.PontosGanhoPassivo != 0) {
				IniciarTimerPontosPassivos(condicao);
			}
			else if (timerPontosPassivos != null) {
				timerPontosPassivos.Stop();
			}
		}

		private async void ApresentarCondicoes(List<Condicao> condicoes) {
			foreach (Condicao condicao in condicoes) {
				taskCondicaoAtual = new TaskCompletionSource<bool>(false);
				ApresentarCondicao(condicao);
				await taskCondicaoAtual.Task;
			}

			if (timerPontosPassivos != null) {
				timerPontosPassivos.Stop();
			}

			Close();
		}

		private void CheckFimCondicao(Condicao condicao) {
			if (condicao.PontosTotais == 0) {
				taskCondicaoAtual.TrySetResult(true);
			}
		}

		private void ComportamentoClickQuadrado(FaseDoExperimento fase) {
			AtualizarLabelsPontos(fase);
			if (fase is Condicao) {
				CheckFimCondicao(fase as Condicao);
			}
		}

		private void ComportamentoPontosPassivos(int pontosFeedback, Condicao condicao) {
			if ((pontosFeedback < 0 && condicao.PontosGanhoPassivo > 0) || (pontosFeedback > 0 && condicao.PontosGanhoPassivo < 0)) {
				IniciarTimerPontosPassivos(condicao);
			}
		}

		private void Quadrado1_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado1();
			ComportamentoClickQuadrado(faseAtual);

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado1.Pontos, condicao);
			}
		}

		private void Quadrado2_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado2();
			ComportamentoClickQuadrado(faseAtual);

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado2.Pontos, condicao);
			}
		}

		private void Quadrado3_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado3();
			ComportamentoClickQuadrado(faseAtual);

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado3.Pontos, condicao);
			}
		}

	}
}
