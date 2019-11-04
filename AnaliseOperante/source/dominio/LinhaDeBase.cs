using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class LinhaDeBase : FaseDoExperimento {

		public int TempoApresentacao { get; set; }

		public override void ToqueBorda() {
			throw new NotImplementedException();
		}

		public override void ToqueFundo() {
			throw new NotImplementedException();
		}

		public override void ToquePlacarGanhos() {
			throw new NotImplementedException();
		}

		public override void ToquePlacarPerdidos() {
			throw new NotImplementedException();
		}

		public override void ToquePlacarTotais() {
			throw new NotImplementedException();
		}

		public override void ToqueQuadrado1() {
			throw new NotImplementedException();
		}

		public override void ToqueQuadrado2() {
			throw new NotImplementedException();
		}

		public override void ToqueQuadrado3() {
			throw new NotImplementedException();
		}
	}
}
