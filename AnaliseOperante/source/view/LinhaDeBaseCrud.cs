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
	public partial class LinhaDeBaseCrud : Form {
		public LinhaDeBaseCrud() {
			InitializeComponent();
		}

		private void SelecionarCor(Panel painelCor) {
			if (colorDialog.ShowDialog() != DialogResult.Cancel) {
				painelCor.BackColor = colorDialog.Color;
			}
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

		private void btnSalvar_Click(object sender, EventArgs e) {
			string nome = textNome.Text;
			int tempo = Convert.ToInt32(numericTempo.Value);

			int corFundo = panelCorFundo.BackColor.ToArgb();
			int corBorda = panelCorBorda.BackColor.ToArgb();
			int corQuadrado1 = panelCorQuadrado1.BackColor.ToArgb();
			int corQuadrado2 = panelCorQuadrado2.BackColor.ToArgb();
			int corQuadrado3 = panelCorQuadrado3.BackColor.ToArgb();

			var linhaDeBase = new LinhaDeBase {
				Nome = nome,
				TempoApresentacao = tempo,
				CorFundo = corFundo,
				CorBorda = corBorda,
				CorQuadrado1 = corQuadrado1,
				CorQuadrado2 = corQuadrado2,
				CorQuadrado3 = corQuadrado3,
			};

			LinhaDeBaseService.Salvar(linhaDeBase);
			MessageBox.Show("Linha de Base cadastrada com sucesso!", "Sucesso");
			Close();
		}
	}
}
