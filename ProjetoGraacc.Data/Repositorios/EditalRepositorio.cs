using Dapper;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using ProjetoGraacc.Data.Models;
using ProjetoGraacc.Data.Models.Config;
using ProjetoGraacc.Data.Models.Filters;
using ProjetoGraacc.Data.Models.Include;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoGraacc.Data.Repositorios
{
    public interface IEditalRespositorio
    {
        Task<IList<Edital>> ListEditaisAsync(EditalFilterViewModel filter);
        Task<bool> AlterFalgFavoritoAsync(int id, bool favoritar);
        Task<bool> EditEditalAsync(int id, decimal valorPleiteado, decimal valorRecebido, DateTime? dtNotificacao, string status);
        Task<bool> IncluiEditalAsync(IncluirEditalModel edital);
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

        public async Task<bool> EditEditalAsync(int id, decimal valorPleiteado, decimal valorRecebido, DateTime? dtNotificacao, string status)
        {
            bool result = false;
            using (var connection = new MySqlConnection(_connectionString.MySQL))
            {
                await connection.OpenAsync();
                
                string sql;
                if (dtNotificacao.HasValue)
                {
                    sql = $"update edital set valor_pleiteado = {valorPleiteado.ToString().Replace(",", ".")}, valor_recebido = {valorRecebido.ToString().Replace(",", ".")}, data_notificacao = '{ dtNotificacao.Value.ToString("yyyy-MM-dd")}', status = {status} where id = {id}";
                }
                else
                {
                    sql = $"update edital set valor_pleiteado = {valorPleiteado.ToString().Replace(",", ".")}, valor_recebido = {valorRecebido.ToString().Replace(",", ".")}, status = {status} where id = {id}";
                }

                await connection.QueryAsync<Edital>(sql);

                result = true;

                await connection.CloseAsync();
            }

            return result;
        }

        public async Task<bool> IncluiEditalAsync(IncluirEditalModel edital)
        {
            bool result = false;
            using (var connection = new MySqlConnection(_connectionString.MySQL))
            {
                await connection.OpenAsync();

                string sql;
                if (edital.DtNotificacao.HasValue)
                {
                    sql = $"insert into edital (num_edital, titulo, link, resumo, texto, texto_html, valor_pleiteado, uf, data_publicacao, data_notificacao, usuario_cadastro, status)" +
                    $"values ('{edital.NrProcesso}', '{edital.Titulo}', '{edital.Link}', 'Resumo', '{edital.Texto}', '{edital.TextoHtml}', {edital.ValorPleiteado.ToString().Replace(",", ".")}, 'ES', '{Convert.ToDateTime(edital.DtPublicacao.Replace("-", "/")).ToString("yyyy-MM-dd")}', '{edital.DtNotificacao.Value.ToString("yyyy-MM-dd")}', 'Carlos', '{edital.Status}')";
                }
                else
                {
                    sql = $"insert into edital (num_edital, titulo, link, resumo, texto, texto_html, valor_pleiteado, uf, data_publicacao, usuario_cadastro, status)" +
                    $"values ('{edital.NrProcesso}', '{edital.Titulo}', '{edital.Link}', 'Resumo', '{edital.Texto}', '{edital.TextoHtml}', {edital.ValorPleiteado.ToString().Replace(",", ".")}, 'ES', '{Convert.ToDateTime(edital.DtPublicacao.Replace("-", "/")).ToString("yyyy-MM-dd")}', 'Carlos', '{edital.Status}')";
                }

                await connection.QueryAsync<Edital>(sql);

                result = true;

                await connection.CloseAsync();
            }

            return result;
        }
    }
}
