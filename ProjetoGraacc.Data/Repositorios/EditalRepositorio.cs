using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Models;
using ProjetoGraacc.Data.Models.Config;
using ProjetoGraacc.Data.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGraacc.Data.Repositorios
{
    public interface IEditalRespositorio
    {
        Task<IList<Edital>> ListEditaisAsync(EditalFilterViewModel filter);
        Task<bool> AlterFalgFavoritoAsync(int id, bool favoritar);
    }

    public class EditalRepositorio : IEditalRespositorio
    {
        private readonly ConnectionStringConfig _connectionString;

        public EditalRepositorio(IOptions<ConnectionStringConfig> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<IList<Edital>> ListEditaisAsync(EditalFilterViewModel filter)
        {
            IEnumerable<Edital> itens;

            using (var connection = new MySqlConnection(_connectionString.MySQL))
            {
                await connection.OpenAsync();
                
                var sql = "select * from edital";
                itens = await connection.QueryAsync<Edital>(sql);

                await connection.CloseAsync();
            }

            if (filter.Pesquisa)
            {
                if (!string.IsNullOrEmpty(filter.UF))
                {
                    itens = itens.Where(x => x.uf.ToUpper() == filter.UF.ToUpper());
                }
                if (!string.IsNullOrEmpty(filter.Municipio))
                {
                    itens = itens.Where(x => x.municipio.ToUpper() == filter.Municipio.ToUpper());
                }
                if (!string.IsNullOrEmpty(filter.Orgao))
                {
                    itens = itens.Where(x => x.orgao.ToUpper() == filter.Orgao.ToUpper());
                }
                if (!string.IsNullOrEmpty(filter.Favoritas))
                {
                    itens = itens.Where(x => x.favorito == true);
                }
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
