public class UserService
{
    public string UserName { get; set; }

    public static string RemoverDominio(string nomeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nomeUsuario))
            return string.Empty;

        var partes = nomeUsuario.Split('/');
        return (partes.Length > 1 ? partes[1] : nomeUsuario).Trim().ToUpperInvariant();
    }
}


public static class StringExtensions
{
    public static string SemDominio(this string nomeUsuario)
    {
        if (string.IsNullOrWhiteSpace(nomeUsuario))
            return string.Empty;
            
        var partes = nomeUsuario.Split('\\', '/');
        return (partes.Length > 1 ? partes[1] : nomeUsuario).Trim().ToUpperInvariant();
    }
}
