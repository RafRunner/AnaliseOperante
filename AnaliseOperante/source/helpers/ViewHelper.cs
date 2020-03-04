using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaliseOperante.source.helpers {
	public class ViewHelper {

		public static long GetIdSelecionadoInListView(ListView listView) {
			return Convert.ToInt64(listView.SelectedItems[0].SubItems[1].Text);
		}

		public static string SelecionaArquivoComFiltro(FileDialog fileDialog, string filter = null) {
			string retorno = string.Empty;
			if (filter != null) {
				fileDialog.Filter = filter;
			}
			DialogResult result = fileDialog.ShowDialog();
			if (result == DialogResult.OK) {
				retorno = fileDialog.FileName;
			}
			fileDialog.Filter = string.Empty;
			return retorno;
		}
	}
}
