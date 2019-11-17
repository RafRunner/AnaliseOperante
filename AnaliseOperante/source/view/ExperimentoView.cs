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

			experimentoRealizado.DateTimeInicio = DateTime.Now;
			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando o experimento de nome '{experimento.Nome}'", "Inicialização"));

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
			experimentoRealizado.RegistrarEvento(new Evento($"Tempo de apresentação da Linha de Base '{faseAtual.Nome}' ({faseAtual.TempoApresentacao} segundos) finalizado", "LinhaDeBase"));
			ApresentarCondicoes(experimento.Condicoes);
		}

		private void EventoFimCondicao(Object myObject, EventArgs myEventArgs) {
			timerAtual.Stop();
			experimentoRealizado.RegistrarEvento(new Evento($"Tempo de apresentação máximo da Condição '{faseAtual.Nome}' ({faseAtual.TempoApresentacao} segundos) finalizado", "Condição"));
			taskCondicaoAtual.TrySetResult(true);
		}

		private void EventoPontosPassivos(Object myObject, EventArgs myEventArgs) {
			Condicao condicao = faseAtual as Condicao;

			if (condicao == null) {
				return;
			}

			experimentoRealizado.RegistrarEvento(new Evento($"Participante recebeu {condicao.PontosGanhoPassivo} pontos passivamente!", "Condição"));
			condicao.AplicarGanhoPassivo();
			AtualizarLabelsPontos(faseAtual);
			CheckFimCondicao(condicao);
		}

		private void ApresentarLinhaDeBase(LinhaDeBase linhaDeBase) {
			if (linhaDeBase == null) {
				ApresentarCondicoes(experimento.Condicoes);
				return;
			}
			faseAtual = linhaDeBase;
			ColorirTela(linhaDeBase);

			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando a apresentação da Linha de Base '{linhaDeBase.Nome}', com tempo de apresentação de {linhaDeBase.TempoApresentacao} segundos", "LinhaDeBase"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cor de fundo: '{linhaDeBase.ColorFundo.Name}', Cor da borda: '{linhaDeBase.ColorFundo.Name}'", "LinhaDeBase"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cores dos quadrados em ordem interior para exterior: '{linhaDeBase.ColorQuadrado1.Name}', '{linhaDeBase.ColorQuadrado2.Name}', '{linhaDeBase.ColorQuadrado3.Name}'", "LinhaDeBase"));

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

			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando a apresentação da Condição '{condicao.Nome}', com tempo máximo de {condicao.TempoApresentacao} segundos, tempo de ganho passivo de {condicao.TempoGanhoPassivo} segundos e quantidade ganha passivamente de {condicao.PontosGanhoPassivo}", "Condição"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cor de fundo: '{condicao.ColorFundo.Name}', Cor da borda: '{condicao.ColorFundo.Name}'", "Condição"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cores dos quadrados em ordem interior para exterior: '{condicao.ColorQuadrado1.Name}', '{condicao.ColorQuadrado2.Name}', '{condicao.ColorQuadrado3.Name}'", "Condição"));

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

			if (condicoes.Count > 0) { 
				experimentoRealizado.RegistrarEvento(new Evento($"Iniciando apresentação de {condicoes.Count.ToString()} condições", "Intervalo"));

				foreach (Condicao condicao in condicoes) {
					taskCondicaoAtual = new TaskCompletionSource<bool>(false);
					ApresentarCondicao(condicao);
					await taskCondicaoAtual.Task;
					experimentoRealizado.RegistrarEvento(new Evento($"Apresentação da condição '{condicao.Nome}' finalizada", "Condição"));
				}

				if (timerPontosPassivos != null) {
					timerPontosPassivos.Stop();
				}
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Não existem condições nesse experimento para serem apresentadas", "Intervalo"));
			}

			Close();
		}

		private void CheckFimCondicao(Condicao condicao) {
			if (condicao.PontosTotais == 0) {
				taskCondicaoAtual.TrySetResult(true);
				experimentoRealizado.RegistrarEvento(new Evento($"Total de pontos da condição '{condicao.Nome}' chegou a 0", "Condição"));
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
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 1, recebendo {condicao.FeedBackQuadrado1.Pontos} pontos", "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado1.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 1", "LinhaDeBase"));
			}
		}

		private void Quadrado2_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado2();
			ComportamentoClickQuadrado(faseAtual);

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 2, recebendo {condicao.FeedBackQuadrado2.Pontos} pontos", "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado2.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 2", "LinhaDeBase"));
			}
		}

		private void Quadrado3_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado3();
			ComportamentoClickQuadrado(faseAtual);

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 3, recebendo {condicao.FeedBackQuadrado3.Pontos} pontos", "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado3.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 3", "LinhaDeBase"));
			}
		}

	}
}
