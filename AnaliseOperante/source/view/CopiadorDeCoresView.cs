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
	public partial class CopiadorDeCoresView : Form {

		private readonly FaseDoExperimento faseDoExperimento;

		public CopiadorDeCoresView(FaseDoExperimento faseDoExperimento) {
			InitializeComponent();

			CarregarListaLinhaDeBase();
			CarregarListaCondicao();

			this.faseDoExperimento = faseDoExperimento;
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

		private void CopiarCores(FaseDoExperimento fase) {
			faseDoExperimento.CorFundo = fase.CorFundo;
			faseDoExperimento.CorBorda = fase.CorBorda;
			faseDoExperimento.CorQuadrado1 = fase.CorQuadrado1;
			faseDoExperimento.CorQuadrado2 = fase.CorQuadrado2;
			faseDoExperimento.CorQuadrado3 = fase.CorQuadrado3;
		}

		private void btnSelecionarLinhaDeBase_Click(object sender, EventArgs e) {
			if (listViewLinhaDeBase.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Linha de Base selecionada!", "Advertência");
				return;
			}

			long id = long.Parse(listViewLinhaDeBase.SelectedItems[0].SubItems[1].Text);
			LinhaDeBase linhaDeBase = LinhaDeBaseService.GetById(id);

			CopiarCores(linhaDeBase);
			Close();
		}

		private void btnSelecionarCondicao_Click(object sender, EventArgs e) {
			if (listViewCondicao.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Condição selecionada!", "Advertência");
				return;
			}
			Condicao condicao = CondicaoService.GetById(Convert.ToInt64(listViewCondicao.SelectedItems[0].SubItems[1].Text));

			CopiarCores(condicao);
			Close();
		}
	}
}
