using AnaliseOperante.source.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public class EventoService : AbstractService {

		private static readonly string TABELA_EVENTOS = "LinhaDeBase";

		public static Evento GetById(long id) {
			return AbstractService.GetById<Evento>(id, TABELA_EVENTOS);
		}

		public static List<Evento> GetAll() {
			return AbstractService.GetAll<Evento>(TABELA_EVENTOS);
		}

		public static void Salvar(Evento evento) {
			AbstractService.Salvar<Evento>(evento, TABELA_EVENTOS,
				$"INSERT INTO {TABELA_EVENTOS} (Nome, CorQuadrado1, CorQuadrado2, CorQuadrado3, CorFundo, CorBorda, TempoApresentacao, PontosTotais) VALUES (@Nome, @CorQuadrado1, @CorQuadrado2, @CorQuadrado3, @CorFundo, @CorBorda, @TempoApresentacao, @PontosTotais)",
				$"UPDATE {TABELA_EVENTOS} SET Nome = @Nome, CorQuadrado1 = @CorQuadrado1, CorQuadrado2 = @CorQuadrado2, CorQuadrado3 = @CorQuadrado3, CorFundo = @CorFundo, CorBorda = @CorBorda, TempoApresentacao = @TempoApresentacao, PontosTotais = @PontosTotais");
		}

		public static void Deletar(Evento evento) {
			AbstractService.Deletar(evento, TABELA_EVENTOS);
		}
	}
}
