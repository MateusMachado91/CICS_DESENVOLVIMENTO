using Microsoft.Extensions.Configuration;

namespace PYBWeb.Infrastructure.Helpers;

/// <summary>
/// Utilitário para padronizar caminhos de bancos SQLite na pasta DATA
/// </summary>
public static class DataPathHelper
{
    /// <summary>
    /// Obtém o caminho da pasta DATA a partir da configuração, com fallback para "../DATA"
    /// </summary>
    /// <param name="configuration">Configuração da aplicação</param>
    /// <returns>Caminho da pasta DATA</returns>
    public static string GetPastaData(IConfiguration configuration)
    {
        return configuration.GetValue<string>("PastaData") ?? "../DATA";
    }

    /// <summary>
    /// Obtém o caminho completo para um banco de dados na pasta DATA
    /// </summary>
    /// <param name="configuration">Configuração da aplicação</param>
    /// <param name="filename">Nome do arquivo do banco de dados</param>
    /// <returns>Caminho completo do arquivo</returns>
    public static string GetDatabasePath(IConfiguration configuration, string filename)
    {
        return Path.GetFullPath(Path.Combine(GetPastaData(configuration), filename));
    }

    /// <summary>
    /// Obtém a connection string para um banco SQLite na pasta DATA
    /// </summary>
    /// <param name="configuration">Configuração da aplicação</param>
    /// <param name="filename">Nome do arquivo do banco de dados</param>
    /// <returns>Connection string formatada</returns>
    public static string GetConnectionString(IConfiguration configuration, string filename)
    {
        return $"Data Source={GetDatabasePath(configuration, filename)}";
    }
}
