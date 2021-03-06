﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public abstract class FaseDoExperimento : EntidadeDeBanco {

		public readonly static int COR_NEUTRA = -986896;

		private string nome;
		public string Nome {
			get => nome;
			set {
				nome = NullEmptyBlankCheck(value, "Nome", "Linha de Base Ou Condição");
			}
		}

		private int tempoApresentacao;
		public int TempoApresentacao {
			get => tempoApresentacao;
			set {
				tempoApresentacao = NonNegativeCheck(value, "Pontos Totais", "Linha de Base Ou Condição");
			}
		}

		private int pontosTotais;
		public int PontosTotais {
			get => pontosTotais;
			set {
				pontosTotais = NonNegativeCheck(value, "Pontos Totais", "Linha de Base Ou Condição");
			}
		}

		public int PontosGanhos { get; protected set; }

		public int PontosPerdidos { get; protected set; }

		// Métodos responsáveis por alterar os ponto ganhos, perdidos e totais, além de cuidar de outros efeitos colaterias inerentes ao feedback não dependentes da tela (sons e etc);
		public abstract void ToqueQuadrado1();
		public abstract void ToqueQuadrado2();
		public abstract void ToqueQuadrado3();

		private int corQuadrado1;
		public int CorQuadrado1 {
			get => corQuadrado1;
			set {
				corQuadrado1 = value;
				ColorQuadrado1 = Color.FromArgb(corQuadrado1);
			}
		}
		public Color ColorQuadrado1 { get; private set; }

		private int corQuadrado2;
		public int CorQuadrado2 {
			get => corQuadrado2;
			set {
				corQuadrado2 = value;
				ColorQuadrado2 = Color.FromArgb(corQuadrado2);
			}
		}
		public Color ColorQuadrado2 { get; private set; }

		private int corQuadrado3;
		public int CorQuadrado3 {
			get => corQuadrado3;
			set {
				corQuadrado3 = value;
				ColorQuadrado3 = Color.FromArgb(corQuadrado3);
			}
		}
		public Color ColorQuadrado3 { get; private set; }

		private int corBorda;
		public int CorBorda {
			get => corBorda;
			set {
				corBorda = value;
				ColorBorda = Color.FromArgb(corBorda);
			}
		}
		public Color ColorBorda { get; private set; }

		private int corFundo;
		public int CorFundo {
			get => corFundo;
			set {
				corFundo = value;
				ColorFundo = Color.FromArgb(corFundo);
			}
		}
		public Color ColorFundo { get; private set; }

		protected void AtulizarPontos(int quantidadePontos) {
			if (pontosTotais == 0) {
				return;
			}

			int moduloPontos = Math.Abs(quantidadePontos);
			if (moduloPontos > pontosTotais) {
				moduloPontos = pontosTotais;
			}

			pontosTotais -= moduloPontos;

			if (quantidadePontos > 0) {
				PontosGanhos += moduloPontos;
			}
			else {
				PontosPerdidos += moduloPontos;
			}
		}
	}
}
