using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MyFirstCRUD.Contracts.Repository;
using MyFirstCRUD.DTO;
using MyFirstCRUD.entity;
using MyFirstCRUD.infrastructure;
using MySql.Data.MySqlClient;

namespace MyFirstCRUD.Repository
{
    class EstadoRepository : IEstadoRepository
    {
        public async Task<IEnumerable<EstadoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(EstadoEntity.id)},
                           Nome AS {nameof(EstadoEntity.Nome)},
                           Sigla AS {nameof(EstadoEntity.Sigla)},
                          NACAO_ID AS {nameof(EstadoEntity.Nacao_id)}
                      FROM ESTADO
                ";

                IEnumerable<EstadoEntity> estadoList = await con.QueryAsync<EstadoEntity>(sql);

                return estadoList;
            }
        }

        public async Task Insert(EstadoInsertDTO estado)
        {
            Connection _connection = new Connection();
            string sql = @"
                INSERT INTO ESTADO (NOME,SIGLA,NACAO_ID)
                                VALUES (@Nome,@SIGLA,@NACAO_ID)
                ";

            await _connection.Execute(sql, estado);
        }

        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM ESTADO WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<EstadoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(EstadoEntity.id)},
                           Nome AS {nameof(EstadoEntity.Nome)},
                           Sigla AS {nameof(EstadoEntity.Sigla)},
                          NACAO_ID AS {nameof(EstadoEntity.Nacao_id)}
                      FROM ESTADO
                   WHERE ID = @Id;
                ";

                EstadoEntity estado = await con.QueryFirstAsync<EstadoEntity>(sql, new { id });
                return estado;
            }
        }

        public async Task Update(EstadoEntity estado)
        {
            Connection _connection = new Connection();
            string sql = @"
                          UPDATE ESTADO
                               SET NOME = @Nome,
                                  SIGLA = @Sigla,
                               NACAO_ID = @Nacao_id
                               WHERE ID = @Id;
    ";

            await _connection.Execute(sql, estado);
        }
    }
}
