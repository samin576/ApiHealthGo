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
    class NacaoRepository : INacaoRepository
    {
        public async Task<IEnumerable<NacaoEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                     SELECT ID AS {nameof(NacaoEntity.id)},
                            NOME AS {nameof(NacaoEntity.Nome)}
                       FROM Nacao
                ";
                IEnumerable<NacaoEntity> nationList = await con.QueryAsync<NacaoEntity>(sql);
                return nationList;
            }
        }
        public async Task Insert(NacaoInsertDTO nacao)
        {
            Connection _connection = new Connection();
            string sql = @$"
                 INSERT INTO Nacao (Nome)
                              VALUES(@Nome)                                                           
            ";
            await _connection.Execute(sql, nacao);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM NACAO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<NacaoEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                            SELECT ID AS {nameof(NacaoEntity.id)},
                            NOME AS {nameof(NacaoEntity.Nome)}
                            FROM Nacao
                            WHERE ID = @id
                            ";
                NacaoEntity nacao = await con.QueryFirstAsync<NacaoEntity>(sql, new { id });
                return nacao;
            }
        }
        public async Task Update(NacaoEntity nacao)
        {
            Connection _connection = new Connection();
            string sql = @$"
                     UPDATE NACAO
                        SET Nome = @Nome
                      WHERE ID= @Id
                          ";
            await _connection.Execute(sql, nacao);
        }
    }
}
