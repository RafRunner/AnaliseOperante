using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public abstract class FaseDoExperimento : EntidadeDeBanco {

		public string CorQuadrado1 { get; set; }
		private Color colorQuadrado1;
		public Color ColorQuadrado1 {
			get => colorQuadrado1;
			set {
				colorQuadrado1 = value;
				CorQuadrado1 = colorQuadrado1.ToString();
			}
		}

		public string CorQuadrado2 { get; set; }
		private Color colorQuadrado2;
		public Color ColorQuadrado2 {
			get => colorQuadrado2;
			set {
				colorQuadrado2 = value;
				CorQuadrado2 = colorQuadrado2.ToString();
			}
		}

		public string CorQuadrado3 { get; set; }
		private Color colorQuadrado3;
		public Color ColorQuadrado3 {
			get => colorQuadrado3;
			set {
				colorQuadrado3 = value;
				CorQuadrado3 = colorQuadrado3.ToString();
			}
		}

		public string CorBorda { get; set; }
		private Color colorCorBorda;
		public Color ColorCorBorda {
			get => colorCorBorda;
			set {
				colorCorBorda = value;
				CorQuadrado1 = colorCorBorda.ToString();
			}
		}

		public string CorFundo { get; set; }
		private Color colorFundo;
		public Color ColorFundo {
			get => colorFundo;
			set {
				colorFundo = value;
				CorFundo = colorFundo.ToString();
			}
		}
	}
}
