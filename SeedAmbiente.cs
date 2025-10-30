using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PYBWeb.Domain.Entities;
using PYBWeb.Infrastructure.Data;
using PYBWeb.Infrastructure.Helpers;

// Carregar configuração
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var connectionString = DataPathHelper.GetConnectionString(configuration, "ambiente.db");
using var context = new AmbienteDbContext(connectionString);

// Verificar se já existem dados
var existentes = await context.AmbientesCics.CountAsync();
Console.WriteLine($"Ambientes existentes: {existentes}");

if (existentes == 0)
{
    Console.WriteLine("Inserindo dados de exemplo...");
    
    context.AmbientesCics.AddRange(
        new AmbienteCics { Nome = "DESENV", Descricao = "Ambiente de Desenvolvimento", Servidor = "dev-server", Porta = 23, Ativo = true },
        new AmbienteCics { Nome = "TESTE", Descricao = "Ambiente de Teste", Servidor = "test-server", Porta = 23, Ativo = true },
        new AmbienteCics { Nome = "PRODUCAO", Descricao = "Ambiente de Produção", Servidor = "prod-server", Porta = 23, Ativo = true },
        new AmbienteCics { Nome = "HOMOLOG", Descricao = "Ambiente de Homologação", Servidor = "hom-server", Porta = 23, Ativo = true }
    );
    
    await context.SaveChangesAsync();
    Console.WriteLine("Dados inseridos com sucesso!");
}
else
{
    Console.WriteLine("Dados já existem no banco.");
}

// Listar todos os ambientes
var ambientes = await context.AmbientesCics.Where(a => a.Ativo).ToListAsync();
Console.WriteLine($"\nAmbientes ativos ({ambientes.Count}):");
foreach (var ambiente in ambientes)
{
    Console.WriteLine($"- {ambiente.Nome}: {ambiente.Descricao} ({ambiente.Servidor}:{ambiente.Porta})");
}