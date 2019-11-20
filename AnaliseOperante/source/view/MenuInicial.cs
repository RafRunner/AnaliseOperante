﻿using AnaliseOperante.source.dominio;
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

		private ExperimentoRealizado experimentoRealizado;

		public MenuInicial() {
			InitializeComponent();

			CarregarListaLinhaDeBase();
			CarregarListaCondicao();
			CarregarListaExperimento();

			experimentoRealizado = new ExperimentoRealizado();
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

		private void CarregarListaExperimento() {
			List<Experimento> experimentos = ExperimentoService.GetAll();

			listViewExperimento.Items.Clear();
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
				MessageBox.Show("Nenhuma Linha de Base selecionada!", "Advertência");
				return;
			}

			long id = long.Parse(listViewLinhaDeBase.SelectedItems[0].SubItems[1].Text);
			LinhaDeBase linhaDeBase = LinhaDeBaseService.GetById(id);
			LinhaDeBaseService.Deletar(linhaDeBase);
			CarregarListaLinhaDeBase();
			MessageBox.Show("Linha de Base deletada com sucesso!", "Sucesso");
		}

		private void btnEditarLinhaDeBase_Click(object sender, EventArgs e) {
			if (listViewLinhaDeBase.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Linha de Base selecionada!", "Advertência");
				return;
			}
			new LinhaDeBaseCrud(Convert.ToInt64(listViewLinhaDeBase.SelectedItems[0].SubItems[1].Text)).ShowDialog();
			CarregarListaLinhaDeBase();
		}

		private void btnCriarCondicao_Click(object sender, EventArgs e) {
			new CondicaoCrud().ShowDialog();
			CarregarListaCondicao();
		}

		private void btnEditarCondicao_Click(object sender, EventArgs e) {
			if (listViewCondicao.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Condição selecionada!", "Advertência");
				return;
			}
			new CondicaoCrud(Convert.ToInt64(listViewCondicao.SelectedItems[0].SubItems[1].Text)).ShowDialog();
			CarregarListaCondicao();
		}

		private void btnDeletarCondicao_Click(object sender, EventArgs e) {
			if (listViewCondicao.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhuma Condição selecionada!", "Advertência");
				return;
			}
			CondicaoService.Deletar(CondicaoService.GetById(Convert.ToInt64(listViewCondicao.SelectedItems[0].SubItems[1].Text)));
			CarregarListaCondicao();
			MessageBox.Show("Condição deletada com sucesso!", "Sucesso");
		}

		private void btnDeletarExperimento_Click(object sender, EventArgs e) {
			if (listViewCondicao.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Experimento selecionado!", "Advertência");
				return;
			}
			ExperimentoService.Deletar(ExperimentoService.GetById(Convert.ToInt64(listViewExperimento.SelectedItems[0].SubItems[1].Text)));
			CarregarListaExperimento();
			MessageBox.Show("Experimento deletado com sucesso!", "Sucesso");
		}

		private void btnEditarExperimento_Click(object sender, EventArgs e) {
			if (listViewExperimento.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Experimento selecionado!", "Advertência");
				return;
			}
			new ExperimentoCrud(Convert.ToInt64(listViewExperimento.SelectedItems[0].SubItems[1].Text)).ShowDialog();
			CarregarListaExperimento();
		}

		private void btnCriarExperimento_Click(object sender, EventArgs e) {
			new ExperimentoCrud().ShowDialog();
			CarregarListaExperimento();
		}

		private void btnSelecionarExperimento_Click(object sender, EventArgs e) {
			if (listViewExperimento.SelectedItems.Count == 0) {
				MessageBox.Show("Nenhum Experimento selecionado!", "Advertência");
				return;
			}
			Experimento experimento = ExperimentoService.GetById(Convert.ToInt64(listViewExperimento.SelectedItems[0].SubItems[1].Text));
			experimentoRealizado.Experimento = experimento;
			textExperimentoSelecionado.Text = experimento.Nome;
		}

		private async void btnIniciarExperimento_Click(object sender, EventArgs e) {
			if (experimentoRealizado.Experimento == null) {
				MessageBox.Show("Por favor, selecione um Experimento antes de começar!", "Advertência");
				return;
			}

			experimentoRealizado.NomeParticipante = textNomeParticipante.Text;
			experimentoRealizado.IdadeParticipante = Convert.ToInt32(numericIdadeParticipante.Value);
			experimentoRealizado.Grupo = textGrupoParticipante.Text;
			experimentoRealizado.CabineUtilizada = textCabineUtilizada.Text;

			TelaMensagem telaMensagem = new TelaMensagem("Toque nessa mensagem para iniciar o experimento", false);
			telaMensagem.Show();
			await telaMensagem.GetTask().Task;

			telaMensagem.AlterarPropriedades(experimentoRealizado.Experimento.Instrucao, true);
			telaMensagem.Show();
			await telaMensagem.GetTask().Task;

			new ExperimentoView(experimentoRealizado).ShowDialog();

			telaMensagem.AlterarPropriedades("Experimento finalizado! Por favor, chamar o(a) experimentador(a).", false);
			telaMensagem.Show();
		}

		private void btnGerarRelatorios_Click(object sender, EventArgs e) {
			new GeradorRelatoriosView().ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e) {
			MessageBox.Show("Colocar as informações aqui!", "Informações");
		}
	}
}
