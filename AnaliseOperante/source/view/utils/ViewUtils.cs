using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaliseOperante.source.view.utils {
	class ViewUtils {

		public static void CorrigeTamanhoEPosicao(Control controle, double heightRatio, double widthRatio) {
			controle.Height = Convert.ToInt32(controle.Height * heightRatio);
			controle.Width = Convert.ToInt32(controle.Width * widthRatio);
			controle.Location = new Point {
				X = Convert.ToInt32(controle.Location.X * widthRatio),
				Y = Convert.ToInt32(controle.Location.Y * heightRatio)
			};
		}

		public static void CorrigeFonte(Label label, double heightRatio) {
			label.Font = new Font(label.Font.Name, Convert.ToInt32(label.Font.Size * heightRatio));
		}
	}
}
