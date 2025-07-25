﻿using Dapper;
using MinhaPrimeiraApi.Contracts.Infrastructure;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaPrimeiraApi.Infrastructure
{
    public class Connection : IConnection
    {

        protected string connectionString = "Server=localhost;Database=HealthGo;User=root;Password=1234";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
