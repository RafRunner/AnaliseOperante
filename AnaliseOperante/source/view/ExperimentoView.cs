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
			taskCondicaoAtual.TrySetResult(true);
		}

		private void EventoFimCondicao(Object myObject, EventArgs myEventArgs) {
			timerAtual.Stop();
			ApresentarCondicoes(experimento.Condicoes);
		}

		private void ApresentarLinhaDeBase(LinhaDeBase linhaDeBase) {
			if (linhaDeBase == null) {
				return;
			}
			faseAtual = linhaDeBase;
			ColorirTela(linhaDeBase);

			labelPontosTotais.Text = linhaDeBase.PontosTotais.ToString();

			timerAtual = new Timer {
				Interval = Convert.ToInt32(linhaDeBase.TempoApresentacao) * 1000
			};
			timerAtual.Tick += new EventHandler(EventoFimTempoLinhaDeBase);
			timerAtual.Start();
		}

		private void AtualizarLabelsPontos(Condicao condicao) {
			labelPontosGanhos.Text = condicao.PontosGanhos.ToString();
			labelPontosTotais.Text = condicao.PontosTotais.ToString();
			labelPontosPerdidos.Text = condicao.PontosPerdidos.ToString();
		}

		private void ApresentarCondicao(Condicao Condicao) {
			faseAtual = Condicao;
			ColorirTela(Condicao);

			labelPontosTotais.Text = Condicao.PontosTotais.ToString();

			timerAtual = new Timer {
				Interval = Convert.ToInt32(Condicao.TempoApresentacao) * 1000
			};
			timerAtual.Tick += new EventHandler(EventoFimCondicao);
			timerAtual.Start();
		}

		private async void ApresentarCondicoes(List<Condicao> condicoes) {
			foreach (Condicao condicao in condicoes) {
				taskCondicaoAtual = new TaskCompletionSource<bool>(false);
				ApresentarCondicao(condicao);
				await taskCondicaoAtual.Task;
			}
			Close();
		}
	}
}
