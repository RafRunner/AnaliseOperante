using AnaliseOperante.source.dominio;
using AnaliseOperante.source.relatorios;
using AnaliseOperante.source.services;
using AnaliseOperante.source.view.utils;
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
		private bool fadingIn;

		private FaseDoExperimento faseAtual;

		private TaskCompletionSource<bool> taskCondicaoAtual;

		private readonly int height = Screen.PrimaryScreen.Bounds.Height;
		private readonly int width = Screen.PrimaryScreen.Bounds.Width;

		public ExperimentoView(ExperimentoRealizado experimentoRealizado) {
			InitializeComponent();

			this.experimentoRealizado = experimentoRealizado;
			experimento = experimentoRealizado.Experimento;

			experimentoRealizado.DateTimeInicio = DateTime.Now;
			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando o experimento de nome '{experimento.Nome}'", "Inicialização"));

			double heightRatio = height / 1080.0;
			double widthRatio = width / 1920.0;

			ViewUtils.CorrigeTamanhoEPosicao(panel1, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(panel2, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(panel3, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Borda1, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Borda2, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Borda3, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Quadrado1, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Quadrado2, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(Quadrado3, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(label1, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(label2, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(label3, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(labelPontosGanhos, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(labelPontosPerdidos, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(labelPontosTotais, heightRatio, widthRatio);

			ViewUtils.CorrigeFonte(label1, heightRatio);
			ViewUtils.CorrigeFonte(label2, heightRatio);
			ViewUtils.CorrigeFonte(label3, heightRatio);
			ViewUtils.CorrigeFonte(labelPontosGanhos, heightRatio);
			ViewUtils.CorrigeFonte(labelPontosPerdidos, heightRatio);
			ViewUtils.CorrigeFonte(labelPontosTotais, heightRatio);

			Opacity = 0;
			ApresentarLinhaDeBase(experimento.LinhaDeBase);
		}

		private void ExperimentoView_Load(object sender, EventArgs e) {
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;

			Location = new Point(0, 0);
			Size = new Size(width, height);
		}

		private void FadeIn() {
			fadingIn = true;
			timerFade.Start();
		}

		private void FadeOut() {
			fadingIn = false;
			timerFade.Start();
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
			FadeOut();
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

			experimentoRealizado.RegistrarEvento(new Evento($"Participante recebeu {condicao.PontosGanhoPassivo} pontos passivamente!" + GetResumoPontosAtual(), "Condição"));
			condicao.AplicarGanhoPassivo();
			AtualizarLabelsPontos(faseAtual);
			CheckFimCondicao(condicao);
		}

		private void ApresentarLinhaDeBase(LinhaDeBase linhaDeBase) {
			if (linhaDeBase == null) {
				ApresentarCondicoes(experimento.Condicoes);
				return;
			}
			FadeIn();

			faseAtual = linhaDeBase;
			ColorirTela(linhaDeBase);

			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando a apresentação da Linha de Base '{linhaDeBase.Nome}', com tempo de apresentação de {linhaDeBase.TempoApresentacao} segundos, pontos totais {linhaDeBase.PontosTotais.ToString()}", "LinhaDeBase"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cor de fundo: '{linhaDeBase.ColorFundo.Name}', Cor da borda: '{linhaDeBase.ColorBorda.Name}'", "LinhaDeBase"));
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
			FadeOut();
			faseAtual = condicao;
			ColorirTela(condicao);

			experimentoRealizado.RegistrarEvento(new Evento($"Iniciando a apresentação da Condição '{condicao.Nome}', com tempo máximo de {condicao.TempoApresentacao} segundos, pontos totais {condicao.PontosTotais.ToString()}, tempo de ganho passivo de {condicao.TempoGanhoPassivo} segundos e quantidade ganha passivamente de {condicao.PontosGanhoPassivo}", "Condição"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cor de fundo: '{condicao.ColorFundo.Name}', Cor da borda: '{condicao.ColorBorda.Name}'", "Condição"));
			experimentoRealizado.RegistrarEvento(new Evento($"Cores dos quadrados em ordem interior para exterior: '{condicao.ColorQuadrado1.Name}', '{condicao.ColorQuadrado2.Name}', '{condicao.ColorQuadrado3.Name}'", "Condição"));

			AtualizarLabelsPontos(condicao);
			FadeIn();

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

			experimentoRealizado.RegistrarEvento(new Evento($"Fim do experimento!", "Finalização"));

			ExperimentoRealizadoService.Salvar(experimentoRealizado);
			new GeradorDeRelatorios(experimentoRealizado).GerarRelatorio();

			Close();
		}

		private void CheckFimCondicao(Condicao condicao) {
			if (condicao.PontosTotais == 0) {
				taskCondicaoAtual.TrySetResult(true);
				experimentoRealizado.RegistrarEvento(new Evento($"Total de pontos da condição '{condicao.Nome}' chegou a 0", "Condição"));
			}
		}

		async private void Piscar(Panel panel, Color color) {
			if (color == FeedBack.CorNeutra) {
				return;
			}

			Color corAnterior = panel.BackColor;
			panel.BackColor = color;
			await Task.Delay(300);
			panel.BackColor = corAnterior;
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

		private string GetResumoPontosAtual() {
			return $" Pontos Totais: {faseAtual.PontosTotais}, Pontos Ganhos: {faseAtual.PontosGanhos}, Pontos Perdidos: {faseAtual.PontosPerdidos}";
		}

		private void Quadrado1_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado1();

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				Piscar(Quadrado1, condicao.FeedBackQuadrado1.ColorBlink);

				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 1, recebendo {condicao.FeedBackQuadrado1.Pontos} pontos." + GetResumoPontosAtual(), "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado1.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 1", "LinhaDeBase"));
			}

			ComportamentoClickQuadrado(faseAtual);
		}

		private void Quadrado2_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado2();

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				Piscar(Quadrado2, condicao.FeedBackQuadrado2.ColorBlink);

				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 2, recebendo {condicao.FeedBackQuadrado2.Pontos} pontos." + GetResumoPontosAtual(), "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado2.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 2", "LinhaDeBase"));
			}

			ComportamentoClickQuadrado(faseAtual);
		}

		private void Quadrado3_Click(object sender, EventArgs e) {
			faseAtual.ToqueQuadrado3();

			if (faseAtual is Condicao) {
				Condicao condicao = faseAtual as Condicao;
				Piscar(Quadrado3, condicao.FeedBackQuadrado3.ColorBlink);

				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 3, recebendo {condicao.FeedBackQuadrado3.Pontos} pontos." + GetResumoPontosAtual(), "Condição"));
				ComportamentoPontosPassivos(condicao.FeedBackQuadrado3.Pontos, condicao);
			}
			else {
				experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou no quadrado 3", "LinhaDeBase"));
			}

			ComportamentoClickQuadrado(faseAtual);
		}

		private string GetTipoFaseAtual() {
			if (faseAtual is Condicao) {
				return "Condição";
			}
			return "LinhaDeBase";
		}

		private void RegistrarToqueElementoNaoInterativo(string nomeElemento) {
			experimentoRealizado.RegistrarEvento(new Evento($"Participante tocou {nomeElemento}", GetTipoFaseAtual()));
		}

		private void ExperimentoView_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("no fundo");
		}

		private void panel1_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("no placar de pontos perdidos");
		}

		private void panel2_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("no placar de pontos totais");
		}

		private void panel3_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("no placar de pontos ganhos");
		}

		private void Borda3_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("na borda do quadrado 3");
		}

		private void Borda2_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("na borda do quadrado 2");
		}

		private void Borda1_Click(object sender, EventArgs e) {
			RegistrarToqueElementoNaoInterativo("na borda do quadrado 1");
		}

		private void timerFade_Tick(object sender, EventArgs e) {
			if (fadingIn) {
				if (Opacity < 1.0) {
					Opacity += 0.025;
				}
				else {
					timerFade.Stop();
				}
			}
			else {
				if (Opacity > 0) {
					Opacity -= 0.025;
				}
				else {
					timerFade.Stop();
				}
			}
		}
	}
}
