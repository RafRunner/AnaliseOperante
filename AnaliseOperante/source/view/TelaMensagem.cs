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
	public partial class TelaMensagem : Form {

		private bool mostrarBotao;

		private TaskCompletionSource<bool> taskAtual;

		private readonly int height = Screen.PrimaryScreen.Bounds.Height;
		private readonly int width = Screen.PrimaryScreen.Bounds.Width;

		public TelaMensagem(string mensagem, bool mostrarBotao) {
			InitializeComponent();

			double heightRatio = height / 1080.0;
			double widthRatio = width / 1920.0;

			ViewUtils.CorrigeTamanhoEPosicao(panel1, heightRatio, widthRatio);
			ViewUtils.CorrigeTamanhoEPosicao(btnContinuar, heightRatio, widthRatio);
			ViewUtils.CorrigeFonte(labelMensagem, heightRatio);

			AlterarPropriedades(mensagem, mostrarBotao);
		}

		public void AlterarPropriedades(string mensagem, bool mostrarBotao) {
			this.mostrarBotao = mostrarBotao;

			labelMensagem.Text = IdentarMensagem(mensagem);
			btnContinuar.Visible = mostrarBotao;
			taskAtual = new TaskCompletionSource<bool>(false);
		}

		public TaskCompletionSource<bool> GetTask() {
			return taskAtual;
		}

		private string IdentarMensagem(string mensagem) {
			int split = 100;
			if (mensagem.Length <= split) {
				return mensagem;
			}

			char[] caracteres = mensagem.ToCharArray();
			List<char> mensagemIdentada = new List<char>();
			int i = 0;

			foreach (char caractere in caracteres) {
				i++;
				if (i - split > 0 && caractere == ' ') {
					mensagemIdentada.Add('\n');
					i = 0;
					continue;
				}
				mensagemIdentada.Add(caractere);
			}

			return new string(mensagemIdentada.ToArray());
		}

		private void TelaMensagem_Load(object sender, EventArgs e) {
			int width = Screen.PrimaryScreen.Bounds.Width;
			int height = Screen.PrimaryScreen.Bounds.Height;

			Location = new Point(0, 0);
			Size = new Size(width, height);
		}

		private void btnContinuar_Click(object sender, EventArgs e) {
			if (mostrarBotao) {
				taskAtual.SetResult(true);
			}
		}

		private void labelMensagem_Click(object sender, EventArgs e) {
			if (!mostrarBotao) {
				taskAtual.SetResult(true);
			}
		}
	}
}
