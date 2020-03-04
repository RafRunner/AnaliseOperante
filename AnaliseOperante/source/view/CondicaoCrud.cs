using AnaliseOperante.source.dominio;
using AnaliseOperante.source.helpers;
using AnaliseOperante.source.services;
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
	public partial class CondicaoCrud : Form {

		private readonly Condicao condicao;

		public CondicaoCrud(long idCondicao = 0) {
			InitializeComponent();
			CarregarListaFeedback();

			if (idCondicao == 0) {
				condicao = new Condicao();
				Text = "Criando nova Condição";
				return;
			}
			else {
				condicao = CondicaoService.GetById(idCondicao);
			}

			Text = "Editando Condição: " + condicao.Nome;
			textNome.Text = condicao.Nome;
			numericTempo.Value = condicao.TempoApresentacao;
			numericPontos.Value = condicao.PontosTotais;
			panelCorBorda.BackColor = condicao.ColorBorda;
			panelCorFundo.BackColor = condicao.ColorFundo;
			panelCorQuadrado1.BackColor = condicao.ColorQuadrado1;
			panelCorQuadrado2.BackColor = condicao.ColorQuadrado2;
			panelCorQuadrado3.BackColor = condicao.ColorQuadrado3;

			textFeedback1.Text = condicao.FeedBackQuadrado1?.Nome;
			textFeedback2.Text = condicao.FeedBackQuadrado2?.Nome;
			textFeedback3.Text = condicao.FeedBackQuadrado3?.Nome;

			textAudio1.Text = condicao.FeedBackQuadrado1?.NomeAudio;
			textAudio2.Text = condicao.FeedBackQuadrado2?.NomeAudio;
			textAudio3.Text = condicao.FeedBackQuadrado3?.NomeAudio;
		}

		private void CarregarListaFeedback() {
			List<FeedBack> feedbacks = FeedBackService.GetAll();

			listViewFeedback.Items.Clear();
			listViewFeedback.Items.AddRange(feedbacks.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void SelecionarCor(Panel painelCor) {
			if (colorDialog.ShowDialog() != DialogResult.Cancel) {
				painelCor.BackColor = colorDialog.Color;
			}
		}

		private long GetIdFeedbackSelecionado() {
			return ViewHelper.GetIdSelecionadoInListView(listViewFeedback);
		}

		private FeedBack GetFeedbackSelecionado() {
			return FeedBackService.GetById(GetIdFeedbackSelecionado());
		}

		private void btnCorFundo_Click(object sender, EventArgs e) {
			SelecionarCor(panelCorFundo);
		}

		private void btnCorBorda_Click(object sender, EventArgs e) {
			SelecionarCor(panelCorBorda);
		}

		private void btnCorQuadrado1_Click(object sender, EventArgs e) {
			SelecionarCor(panelCorQuadrado1);
		}

		private void btnCorQuadrado2_Click(object sender, EventArgs e) {
			SelecionarCor(panelCorQuadrado2);
		}

		private void btnCorQuadrado3_Click(object sender, EventArgs e) {
			SelecionarCor(panelCorQuadrado3);
		}

		private void btnCriarFeedback_Click(object sender, EventArgs e) {
			new FeedbackCrud().ShowDialog();
			CarregarListaFeedback();
		}

		private void btnEditar_Click(object sender, EventArgs e) {
			if (listViewFeedback.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Feedback selecionado!", "Advertência");
				return;
			}

			new FeedbackCrud(GetIdFeedbackSelecionado()).ShowDialog();
			CarregarListaFeedback();
		}

		private void btnDeletarFeedback_Click(object sender, EventArgs e) {
			if (listViewFeedback.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Feedback selecionado!", "Advertência");
				return;
			}

			FeedBackService.Deletar(GetFeedbackSelecionado());
			CarregarListaFeedback();
			MessageBox.Show("Feedback deletado com sucesso!", "Sucesso");
		}

		private void btnFeedback1_Click(object sender, EventArgs e) {
			if (listViewFeedback.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Feedback selecionado!", "Advertência");
				return;
			}

			textFeedback1.Text = listViewFeedback.SelectedItems[0].Text;
			condicao.FeedBackQuadrado1 = GetFeedbackSelecionado();
		}

		private void btnFeedback2_Click(object sender, EventArgs e) {
			if (listViewFeedback.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Feedback selecionado!", "Advertência");
				return;
			}

			textFeedback2.Text = listViewFeedback.SelectedItems[0].Text;
			condicao.FeedBackQuadrado2 = GetFeedbackSelecionado();
		}

		private void btnFeedback3_Click(object sender, EventArgs e) {
			if (listViewFeedback.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Feedback selecionado!", "Advertência");
				return;
			}

			textFeedback3.Text = listViewFeedback.SelectedItems[0].Text;
			condicao.FeedBackQuadrado3 = GetFeedbackSelecionado();
		}

		private void btnSalvar_Click(object sender, EventArgs e) {
			condicao.Nome = textNome.Text;
			condicao.TempoApresentacao = Convert.ToInt32(numericTempo.Value);
			condicao.PontosTotais = Convert.ToInt32(numericPontos.Value);
			condicao.PontosGanhoPassivo = Convert.ToInt32(numericPontosPassivos.Value);
			condicao.TempoGanhoPassivo = Convert.ToInt32(numericIntervalo.Value);
			condicao.CorBorda = panelCorBorda.BackColor.ToArgb();
			condicao.CorFundo = panelCorFundo.BackColor.ToArgb();
			condicao.CorQuadrado1 = panelCorQuadrado1.BackColor.ToArgb();
			condicao.CorQuadrado2 = panelCorQuadrado2.BackColor.ToArgb();
			condicao.CorQuadrado3 = panelCorQuadrado3.BackColor.ToArgb();

			CondicaoService.Salvar(condicao);
			MessageBox.Show("Condição salva com sucesso!", "Sucesso");
			Close();
		}

		private void btnCopiarCores_Click(object sender, EventArgs e) {
			new CopiadorDeCoresView(condicao).ShowDialog();

			panelCorFundo.BackColor = condicao.ColorFundo;
			panelCorBorda.BackColor = condicao.ColorBorda;
			panelCorQuadrado1.BackColor = condicao.ColorQuadrado1;
			panelCorQuadrado2.BackColor = condicao.ColorQuadrado2;
			panelCorQuadrado3.BackColor = condicao.ColorQuadrado3;
		}

		private void CopiaAudioParaPastaESalvaNoFeedback(TextBox textBoxAudio, FeedBack feedBack) {
			string nomeArquivoAudio = ViewHelper.SelecionaArquivoComFiltro(openFileDialog1, "WAV|*.wav");
			if (string.IsNullOrEmpty(nomeArquivoAudio)) {
				return;
			}

			feedBack.NomeAudio = AudioService.CopiaAudioParaPasta(nomeArquivoAudio);
			textBoxAudio.Text = feedBack.NomeAudio;
		}

		private void btnSelecionarAudio1_Click(object sender, EventArgs e) {
			CopiaAudioParaPastaESalvaNoFeedback(textAudio1, condicao.FeedBackQuadrado1);
		}

		private void btnSelecionarAudio2_Click(object sender, EventArgs e) {
			CopiaAudioParaPastaESalvaNoFeedback(textAudio2, condicao.FeedBackQuadrado2);
		}

		private void btnSelecionarAudio3_Click(object sender, EventArgs e) {
			CopiaAudioParaPastaESalvaNoFeedback(textAudio3, condicao.FeedBackQuadrado3);
		}
	}
}
