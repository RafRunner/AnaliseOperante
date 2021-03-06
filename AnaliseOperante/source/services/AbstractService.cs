﻿using AnaliseOperante.source.dominio;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnaliseOperante.source.services {
	public abstract class AbstractService {

		protected static string GetConnectionString(string id = "Default") {
			return ConfigurationManager.ConnectionStrings[id].ConnectionString;
		}

		protected static T GetById<T>(long id, string nomeTabela) where T : EntidadeDeBanco {
			if (id == 0) {
				return default(T);
			}
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				IEnumerable<T> data = cnn.Query<T>($"SELECT * FROM {nomeTabela} WHERE Id = @Id", new { Id = id });
				return data.Count() > 0 ? data.Single() : default(T);
			}
		}

		protected static List<T> GetByObj<T>(string sql, object obj) {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				return cnn.Query<T>(sql, obj).ToList();
			}
		}

		protected static List<T> GetAll<T>(string nomeTabela) where T : EntidadeDeBanco {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				return cnn.Query<T>($"SELECT * FROM {nomeTabela}").ToList<T>();
			}
		}

		protected static void Salvar<T>(T objeto, string nomeTabela, string sqlInsert, string sqlUpdate) where T : EntidadeDeBanco {
			T objetoExistente = GetById<T>(objeto.Id, nomeTabela);

			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				if (objetoExistente == null) {
					long id = cnn.Query<long>(sqlInsert + "; SELECT CAST(last_insert_rowid() as int)", objeto).Single();
					objeto.Id = id;
				}
				else if (!string.IsNullOrEmpty(sqlUpdate)) {
					cnn.Execute(sqlUpdate + " WHERE Id = @Id", objeto);
				}
			}
		}

		protected static void Deletar(EntidadeDeBanco objeto, string nomeTabela) {
			if (objeto == null) {
				return;
			}

			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				cnn.Execute($"DELETE FROM {nomeTabela} WHERE Id = @Id", objeto);
				objeto.Id = 0;
			}
		}

		protected static void DeletarPorId(long id, string nomeTabela) {
			using (IDbConnection cnn = new SQLiteConnection(GetConnectionString())) {
				cnn.Execute($"DELETE FROM {nomeTabela} WHERE Id = {id}");
			}
		}
	}
}
