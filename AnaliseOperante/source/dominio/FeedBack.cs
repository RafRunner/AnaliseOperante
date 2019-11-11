using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class FeedBack : EntidadeDeBanco {

		public int Pontos { get; set; }

		private SoundPlayer soundPlayer;
		private string nomeAudio;
		public string NomeAudio {
			get => nomeAudio;
			set {
				nomeAudio = value;
				if (!string.IsNullOrEmpty(nomeAudio)) {
					soundPlayer = new SoundPlayer(@AudioService.GetFullPath(nomeAudio));
				}
			}
		}

		private Nullable<int> corBlink;
		public Nullable<int> CorBlink {
			get => corBlink;
			set {
				corBlink = value;
				if (corBlink.HasValue) {
					ColorBlink = Color.FromArgb(corBlink.GetValueOrDefault());
				}
			}
		}
		public Color ColorBlink { get; private set; }

		public void PlayAudio() {
			if (soundPlayer != null) {
				soundPlayer.Play();
			}
		}

		public string Nome {
			get {
				return $"{Pontos} pontos{(string.IsNullOrEmpty(NomeAudio) ? "" : $" - {nomeAudio}")}{(!CorBlink.HasValue ? "" : $" - {ColorBlink.Name}")}";
			}
		}
	}
}
