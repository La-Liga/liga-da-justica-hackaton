using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Models;
using ProjetoGraacc.Data.Models.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGraacc.Data.Repositorios
{
    public interface IEditalRespositorio
    {
        Task<IList<Edital>> ListAllEditalAsync();
        Task<bool> AlterFalgFavoritoAsync(int id, bool favoritar);
    }

    public class EditalRepositorio : IEditalRespositorio
    {
        private readonly ConnectionStringConfig _connectionString;

        public EditalRepositorio(IOptions<ConnectionStringConfig> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<IList<Edital>> ListAllEditalAsync()
        {
            IEnumerable<Edital> itens;

            using (var connection = new MySqlConnection(_connectionString.MySQL))
            {
                await connection.OpenAsync();

                var sql = "select * from edital";
                itens = await connection.QueryAsync<Edital>(sql);

                await connection.CloseAsync();
            }

            return itens.ToList();
        }

        public async Task<bool> AlterFalgFavoritoAsync(int id, bool favoritar)
        {
            bool result = false;
            using (var connection = new MySqlConnection(_connectionString.MySQL))
            {
                await connection.OpenAsync();

                var sql = $"update edital set favorito = {favoritar} where id = {id}";
                await connection.QueryAsync<Edital>(sql);

                result = true;

                await connection.CloseAsync();
            }

            return result;
        }
    }
}
