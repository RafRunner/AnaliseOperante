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

		private int corBlink;
		public int CorBlink {
			get => corBlink;
			set {
				corBlink = value;
				ColorBlink = Color.FromArgb(corBlink);
			}
		}
		public Color ColorBlink { get; private set; }

		public void PlayAudio() {
			if (soundPlayer != null) {
				soundPlayer.Play();
			}
		}
	}
}
