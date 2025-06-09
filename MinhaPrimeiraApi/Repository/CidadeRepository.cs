using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MinhaPrimeiraApi.Contracts.Repository;
using MinhaPrimeiraApi.DTO;
using MinhaPrimeiraApi.entity;
using MinhaPrimeiraApi.Infrastructure;
using MySql.Data.MySqlClient;

namespace MinhaPrimeiraApi.Repository
{
    class CidadeRepository : ICidadeRepository
    {
        public async Task<IEnumerable<CidadeEntity>> GetAll()
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                     SELECT ID AS {nameof(CidadeEntity.id)},
                            NOME AS {nameof(CidadeEntity.Nome)},
                           ESTADO_ID {nameof(CidadeEntity.Estado_id)}
                       FROM CIDADE
                ";
                IEnumerable<CidadeEntity> cidadeList = await con.QueryAsync<CidadeEntity>(sql);
                return cidadeList;
            }
        }
        public async Task Insert(CidadeInsertDTO cidade)
        {
            Connection _connection = new Connection();
            string sql = @$"
                INSERT INTO CIDADE (NOME,ESTADO_ID)
                                VALUES (@Nome,@ESTADO_ID)                                                         
            ";
            await _connection.Execute(sql, cidade);
        }
        public async Task Delete(int id)
        {
            Connection _connection = new Connection();
            string sql = "DELETE FROM CIDADE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<CidadeEntity> GetById(int id)
        {
            Connection _connection = new Connection();
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                            SELECT ID AS {nameof(CidadeEntity.id)},
                            NOME AS {nameof(CidadeEntity.Nome)},
                           ESTADO_ID {nameof(CidadeEntity.Estado_id)}
                       FROM CIDADE
                         WHERE ID = @Id
                              
                            ";
                CidadeEntity cidade = await con.QueryFirstAsync<CidadeEntity>(sql, new { id });
                return cidade;
            }
        }
        public async Task Update(CidadeEntity cidade)
        {
            Connection _connection = new Connection();
            string sql = @$"
                      UPDATE CIDADE
                               SET NOME = @Nome,
                               ESTADO_ID = @Estado_id
                               WHERE ID = @Id;
                          ";
            await _connection.Execute(sql, cidade);
        }
    }
}
