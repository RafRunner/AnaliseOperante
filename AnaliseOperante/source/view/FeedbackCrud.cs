using AnaliseOperante.source.dominio;
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
	public partial class FeedbackCrud : Form {

		private readonly string audioFilter = "WAV|*.wav";
		private readonly OpenFileDialog fileDialog = new OpenFileDialog();

		private readonly FeedBack feedback;

		public FeedbackCrud(long idFeedback = 0) {
			InitializeComponent();

			if (idFeedback == 0) {
				feedback = new FeedBack();
				Text = "Criando novo Feedback";
				return;
			}

			feedback = FeedBackService.GetById(idFeedback);

			Text = "Editando Feedback";

			textNomeAudio.Text = feedback.NomeAudio;
			numericPontos.Value = feedback.Pontos;
			panelCorBlink.BackColor = feedback.ColorBlink;
		}

		private string SelecionaArquivoComFiltro(string filter = null) {
			string retorno = string.Empty;
			if (filter != null) {
				fileDialog.Filter = filter;
			}
			DialogResult result = fileDialog.ShowDialog();
			if (result == DialogResult.OK) {
				retorno = fileDialog.FileName;
			}
			fileDialog.Filter = string.Empty;
			return retorno;
		}

		private void button1_Click(object sender, EventArgs e) {
			textNomeAudio.Text = SelecionaArquivoComFiltro(audioFilter);
		}

		private void btnCorBlink_Click(object sender, EventArgs e) {
			if (colorDialog.ShowDialog() != DialogResult.Cancel) {
				panelCorBlink.BackColor = colorDialog.Color;
			}
		}

		private void btnSalvar_Click(object sender, EventArgs e) {
			feedback.NomeAudio = AudioService.CopiaAudioParaPasta(textNomeAudio.Text);
			feedback.Pontos = Convert.ToInt32(numericPontos.Value);
			feedback.CorBlink = panelCorBlink.BackColor.ToArgb();

			FeedBack feedBackExistente = FeedBackService.GetByObj(feedback);
			if (feedBackExistente != null) {
				MessageBox.Show("Feedback já existente!", "Advertência");
				return;
			}

			FeedBackService.Salvar(feedback);
			MessageBox.Show("Feedback salvo com sucesso!", "Sucesso");
			fileDialog.Dispose();
			Close();
		}
	}
}
