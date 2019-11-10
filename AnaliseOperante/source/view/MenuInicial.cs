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
	public partial class MenuInicial : Form {
		public MenuInicial() {
			InitializeComponent();

			CarregarListaLinhaDeBase();
			CarregarListaCondicao();
			CarregarListaExperimento();
		}

		private void CarregarListaLinhaDeBase() {
			List<LinhaDeBase> linhasDeBase = LinhaDeBaseService.GetAll();

			listViewLinhaDeBase.Items.AddRange(linhasDeBase.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void CarregarListaCondicao() {
			List<Condicao> condicoes = CondicaoService.GetAll();

			listViewCondicao.Items.AddRange(condicoes.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void CarregarListaExperimento() {
			List<Experimento> experimentos = ExperimentoService.GetAll();

			listViewExperimento.Items.AddRange(experimentos.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void btnCriarLinhaDeBase_Click(object sender, EventArgs e) {
			new LinhaDeBaseCrud().ShowDialog();
			CarregarListaLinhaDeBase();
		}

		private void btnDeletarLinhaDeBase_Click(object sender, EventArgs e) {
			if (listViewLinhaDeBase.SelectedItems.Count == 0) {
				return;
			}

			long id = long.Parse(listViewLinhaDeBase.SelectedItems[0].SubItems[1].Text);
			LinhaDeBase linhaDeBase = LinhaDeBaseService.GetById(id);
			LinhaDeBaseService.Deletar(linhaDeBase);
		}
	}
}
