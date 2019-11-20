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

		private readonly LinhaDeBase linhaDeBase;

		public LinhaDeBaseCrud(long idLinhaDeBase = 0) {
			InitializeComponent();

			if (idLinhaDeBase == 0) {
				linhaDeBase = new LinhaDeBase();
				Text = "Criando nova Linha de Base";
				return;
			}

			linhaDeBase = LinhaDeBaseService.GetById(idLinhaDeBase);

			Text = "Editando Linha de Base: " + linhaDeBase.Nome;
			textNome.Text = linhaDeBase.Nome;
			numericTempo.Value = linhaDeBase.TempoApresentacao;
			numericPontos.Value = linhaDeBase.PontosTotais;
			panelCorBorda.BackColor = linhaDeBase.ColorBorda;
			panelCorFundo.BackColor = linhaDeBase.ColorFundo;
			panelCorQuadrado1.BackColor = linhaDeBase.ColorQuadrado1;
			panelCorQuadrado2.BackColor = linhaDeBase.ColorQuadrado2;
			panelCorQuadrado3.BackColor = linhaDeBase.ColorQuadrado3;
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

			if (tempo == 0) {
				throw new Exception("O tempo de apresentação de uma Linha de Base não pode ser zero!");
			}

			int pontosTotais = Convert.ToInt32(numericPontos.Value);

			int corFundo = panelCorFundo.BackColor.ToArgb();
			int corBorda = panelCorBorda.BackColor.ToArgb();
			int corQuadrado1 = panelCorQuadrado1.BackColor.ToArgb();
			int corQuadrado2 = panelCorQuadrado2.BackColor.ToArgb();
			int corQuadrado3 = panelCorQuadrado3.BackColor.ToArgb();

			linhaDeBase.Nome = nome;
			linhaDeBase.TempoApresentacao = tempo;
			linhaDeBase.PontosTotais = pontosTotais;
			linhaDeBase.CorFundo = corFundo;
			linhaDeBase.CorBorda = corBorda;
			linhaDeBase.CorQuadrado1 = corQuadrado1;
			linhaDeBase.CorQuadrado2 = corQuadrado2;
			linhaDeBase.CorQuadrado3 = corQuadrado3;

			LinhaDeBaseService.Salvar(linhaDeBase);
			MessageBox.Show("Linha de Base salva com sucesso!", "Sucesso");
			Close();
		}

		private void btnCopiarCores_Click(object sender, EventArgs e) {
			new CopiadorDeCoresView(linhaDeBase).ShowDialog();

			panelCorFundo.BackColor = linhaDeBase.ColorFundo;
			panelCorBorda.BackColor = linhaDeBase.ColorBorda;
			panelCorQuadrado1.BackColor = linhaDeBase.ColorQuadrado1;
			panelCorQuadrado2.BackColor = linhaDeBase.ColorQuadrado2;
			panelCorQuadrado3.BackColor = linhaDeBase.ColorQuadrado3;
		}

	}
}
