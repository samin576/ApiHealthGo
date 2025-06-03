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
                    SELECT ID AS {nameof(EstadoEntity.Id)},
                           NOME AS {nameof(EstadoEntity.Nome)}
                           SIGLA AS {nameof(EstadoEntity.Sigla)}
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
                INSERT INTO ESTADO (NOME,SIGLA)
                                VALUE (@Nome,@Sigla)
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
                    SELECT ID AS {nameof(EstadoEntity.Id)},
                           NOME AS {nameof(EstadoEntity.Nome)}
                          SIGLA AS {nameof(EstadoEntity.Sigla)}
                      FROM Estado
                      Where ID = @id
                ";

                EstadoEntity Estado = await con.QueryFirstAsync<EstadoEntity>(sql, new { id });
                return Estado;
            }
        }

        public async Task Update(EstadoEntity Estado)
        {
            Connection _connection = new Connection();
            string sql = @"UPDATE Estado
                              SET NOME = @Nome
                              SET SIGLA = @Sigla
                              WHERE ID = @Id
            ";

            await _connection.Execute(sql, Estado);
        }
    }
}
