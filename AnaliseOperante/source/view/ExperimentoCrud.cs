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
	public partial class ExperimentoCrud : Form {

		private readonly Experimento experimento;

		public ExperimentoCrud(long idExperimento = 0) {
			InitializeComponent();
			CarregarListaLinhaDeBase();
			CarregarListaCondicao();

			if (idExperimento == 0) {
				experimento = new Experimento();
				Text = "Criando novo Experimento";
				return;
			}

			experimento = ExperimentoService.GetById(idExperimento);

			Text = "Editando Experimento: " + experimento.Nome;
			textNome.Text = experimento.Nome;
			textLinhaDeBase.Text = experimento.LinhaDeBase?.Nome;
			textInstrucao.Text = experimento.Instrucao;
			experimento.Condicoes.ForEach(it => AdicionaCondicaoEscolhida(it));
		}

		private void CarregarListaLinhaDeBase() {
			List<LinhaDeBase> linhasDeBase = LinhaDeBaseService.GetAll();

			listViewLinhaDeBase.Items.Clear();
			listViewLinhaDeBase.Items.AddRange(linhasDeBase.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void CarregarListaCondicao() {
			List<Condicao> condicoes = CondicaoService.GetAll();

			listViewCondicao.Items.Clear();
			listViewCondicao.Items.AddRange(condicoes.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void AdicionaCondicaoEscolhida(Condicao condicao) {
			var item = new ListViewItem(condicao.Nome);
			item.SubItems.Add(condicao.Id.ToString());
			listViewCondicoesSelecionadas.Items.Add(item);
		}

		private void btnSelecionarLinhaDeBase_Click(object sender, EventArgs e) {
			if (listViewLinhaDeBase.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Linha De Base selecionada!", "Advertência");
				return;
			}

			experimento.LinhaDeBase = LinhaDeBaseService.GetById(Convert.ToInt64(listViewLinhaDeBase.SelectedItems[0].SubItems[1].Text));
			textLinhaDeBase.Text = experimento.LinhaDeBase.Nome;
		}

		private void btnRemoverLinhaDeBase_Click(object sender, EventArgs e) {
			if (experimento.LinhaDeBase == null) {
				MessageBox.Show("Esse experimento não possui Linha De Base!", "Advertência");
				return;
			}

			experimento.LinhaDeBase = null;
			textLinhaDeBase.Text = string.Empty;
		}

		private void btnAdicionarCondicao_Click(object sender, EventArgs e) {
			if (listViewCondicao.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Condição selecionada!", "Advertência");
				return;
			}

			Condicao condicao = CondicaoService.GetById(Convert.ToInt64(listViewCondicao.SelectedItems[0].SubItems[1].Text));
			experimento.Condicoes.Add(condicao);
			AdicionaCondicaoEscolhida(condicao);
		}

		private void btnRemoverCondicao_Click(object sender, EventArgs e) {
			if (listViewCondicoesSelecionadas.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Condição selecionada!", "Advertência");
				return;
			}

			experimento.Condicoes.Remove(experimento.Condicoes.Find(it => it.Id == Convert.ToInt64(listViewCondicoesSelecionadas.SelectedItems[0].SubItems[1].Text)));
			listViewCondicao.Items.Clear();
			experimento.Condicoes.ForEach(it => AdicionaCondicaoEscolhida(it));
		}

		private void btnSalvarExperimento_Click(object sender, EventArgs e) {
			experimento.Nome = textNome.Text;
			experimento.Instrucao = textInstrucao.Text;

			ExperimentoService.Salvar(experimento);
			MessageBox.Show("Experimento salvo com sucesso!", "Sucesso");
			Close();
		}
	}
}
