using AnaliseOperante.source.dominio;
using AnaliseOperante.source.relatorios;
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
	public partial class GeradorRelatoriosView : Form {
		public GeradorRelatoriosView() {
			InitializeComponent();

			CarregarListaExperimento();
		}

		private void CarregarListaExperimento() {
			List<ExperimentoRealizado> experimentos = ExperimentoRealizadoService.GetAll();
			experimentos.OrderBy(it => it.DataHoraInicio);

			listViewExperimento.Items.Clear();
			listViewExperimento.Items.AddRange(experimentos.Select(it => {
				var item = new ListViewItem(it.Nome);
				item.SubItems.Add(it.Id.ToString());
				return item;
			}).Cast<ListViewItem>().ToArray());
		}

		private void btnSelecionarExperimento_Click(object sender, EventArgs e) {
			if (listViewExperimento.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Experimento selecionado!", "Advertência");
				return;
			}

			ExperimentoRealizado experimento = ExperimentoRealizadoService.GetById(Convert.ToInt64(listViewExperimento.SelectedItems[0].SubItems[1].Text));
			new GeradorDeRelatorios(experimento).GerarRelatorio();
			MessageBox.Show("Relatório gerado! Nome do arquivo: " + experimento.GetNomeArquivo(), "Sucesso");
		}

		private void btnDeletarExperimento_Click(object sender, EventArgs e) {
			if (listViewExperimento.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Experimento selecionado!", "Advertência");
				return;
			}

			ExperimentoRealizado experimento = ExperimentoRealizadoService.GetById(Convert.ToInt64(listViewExperimento.SelectedItems[0].SubItems[1].Text));
			ExperimentoRealizadoService.Deletar(experimento);
			listViewExperimento.Items.Remove(listViewExperimento.SelectedItems[0]);
			MessageBox.Show("Arquivo de relatório deletado!", "Sucesso");
		}

	}
}
