namespace ProdutosFinanceiros.Domain;
public static class EntityHelpers
{
    public static string RandomString(int length)
    {
        const string chars = "0123456789";
        var random = new Random();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
