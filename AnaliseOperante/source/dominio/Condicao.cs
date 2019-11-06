using AnaliseOperante.source.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.dominio {
	public class Condicao : FaseDoExperimento {

		public long IdFeedBackQuadrado1 { get; set; }
		private FeedBack feedBackQuadrado1;
		public FeedBack FeedBackQuadrado1 {
			get {
				if (feedBackQuadrado1 == null) {
					feedBackQuadrado1 = FeedBackService.GetById(IdFeedBackQuadrado1);
				}
				return feedBackQuadrado1;
			}
		}

		public long IdFeedBackQuadrado2 { get; set; }
		private FeedBack feedBackQuadrado2;
		public FeedBack FeedBackQuadrado2 {
			get {
				if (feedBackQuadrado2 == null) {
					feedBackQuadrado2 = FeedBackService.GetById(IdFeedBackQuadrado2);
				}
				return feedBackQuadrado2;
			}
		}

		public long IdFeedBackQuadrado3 { get; set; }
		private FeedBack feedBackQuadrado3;
		public FeedBack FeedBackQuadrado3 {
			get {
				if (feedBackQuadrado3 == null) {
					feedBackQuadrado3 = FeedBackService.GetById(IdFeedBackQuadrado3);
				}
				return feedBackQuadrado3;
			}
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
