using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// Gerador de clientes fictícios para testes de performance.
/// </summary>
public static class CustomerGenerateData
{
    private static readonly Random _rng = new Random();

    // ──────────────────────────────────────────────────────────────
    // Dados base
    // ──────────────────────────────────────────────────────────────

    private static readonly string[] _segments = new[]
    {
        "Soluções", "Serviços", "Tecnologia", "Comércio", "Indústria",
        "Consultoria", "Logística", "Distribuição", "Engenharia", "Sistemas"
    };

    private static readonly string[] _nouns = new[]
    {
        "Alpha", "Beta", "Delta", "Global", "Prime", "Max", "Plus",
        "Smart", "Nova", "Flex", "Link", "Net", "Pro", "Fast", "Top"
    };

    private static readonly string[] _suffixes = new[]
    {
        "Ltda.", "S.A.", "EIRELI", "ME", "EPP", "S/A", "Ltda. ME"
    };

    private static readonly string[] _tradeSuffixes = new[]
    {
        "Corp", "Group", "Solutions", "Tech", "Hub", "Connect", "360"
    };

    private static readonly string[] _emailDomains = new[]
    {
        "gmail.com", "outlook.com", "hotmail.com", "yahoo.com.br",
        "empresa.com.br", "negocio.com", "corp.com.br"
    };

    private static readonly string[] _ddds = new[]
    {
        "11", "21", "31", "41", "51", "61", "71", "81", "85", "92"
    };

    private static readonly string[] _types = new[]
    {
        "PJ", "PF"
    };

    // ──────────────────────────────────────────────────────────────
    // API pública
    // ──────────────────────────────────────────────────────────────

    /// <summary>Gera um único cliente fictício.</summary>
    public static FakeClient Generate()
    {
        string type        = Pick(_types);
        string noun        = Pick(_nouns);
        string segment     = Pick(_segments);
        string suffix      = Pick(_suffixes);
        string tradeSuffix = Pick(_tradeSuffixes);

        string corporateName = $"{noun} {segment} {suffix}";
        string tradeName     = $"{noun} {tradeSuffix}";
        string document      = type == "PJ" ? GenerateCnpj() : GenerateCpf();
        string email         = BuildEmail(noun, segment);
        string phone         = GeneratePhone();

        return new FakeClient
        {
            CorporateName = corporateName,
            TradeName     = tradeName,
            Type          = type,
            Document      = document,
            Email         = email,
            Phone         = phone
        };
    }

    /// <summary>Gera uma lista com <paramref name="count"/> clientes fictícios.</summary>
    public static List<FakeClient> GenerateMany(int count)
    {
        var list = new List<FakeClient>(count);
        for (int i = 0; i < count; i++)
            list.Add(Generate());
        return list;
    }

    // ──────────────────────────────────────────────────────────────
    // Helpers internos
    // ──────────────────────────────────────────────────────────────

    private static T Pick<T>(T[] array) => array[_rng.Next(array.Length)];

    private static string BuildEmail(string noun, string segment)
    {
        string local  = $"{noun.ToLower()}.{segment.ToLower().Replace(" ", "")}";
        string domain = Pick(_emailDomains);
        return $"{local}@{domain}";
    }

    private static string GeneratePhone()
    {
        string ddd    = Pick(_ddds);
        int    first  = _rng.Next(9, 10);           // celular sempre começa com 9
        string rest   = _rng.Next(10_000_000, 99_999_999).ToString();
        return $"({ddd}) {first}{rest[..4]}-{rest[4..]}";
    }

    // ── CNPJ ──────────────────────────────────────────────────────

    private static string GenerateCnpj()
    {
        int[] n = new int[12];
        for (int i = 0; i < 8; i++) n[i] = _rng.Next(0, 9);
        n[8] = 0; n[9] = 0; n[10] = 0; n[11] = 1;   // filial 0001

        int d1 = CnpjDigit(n, 12);
        int d2 = CnpjDigit(n, 13, d1);

        return $"{n[0]}{n[1]}.{n[2]}{n[3]}{n[4]}.{n[5]}{n[6]}{n[7]}" +
               $"/{n[8]}{n[9]}{n[10]}{n[11]}-{d1}{d2}";
    }

    private static int CnpjDigit(int[] n, int length, int? previousDigit = null)
    {
        int[] weights = length == 12
            ? new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 }
            : new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        int sum = 0;
        var digits = previousDigit.HasValue
            ? new List<int>(n) { previousDigit.Value }
            : new List<int>(n);

        for (int i = 0; i < weights.Length; i++)
            sum += digits[i] * weights[i];

        int rem = sum % 11;
        return rem < 2 ? 0 : 11 - rem;
    }

    // ── CPF ───────────────────────────────────────────────────────

    private static string GenerateCpf()
    {
        int[] n = new int[9];
        for (int i = 0; i < 9; i++) n[i] = _rng.Next(0, 9);

        int d1 = CpfDigit(n, 10);
        int d2 = CpfDigit(n, 11, d1);

        return $"{n[0]}{n[1]}{n[2]}.{n[3]}{n[4]}{n[5]}.{n[6]}{n[7]}{n[8]}-{d1}{d2}";
    }

    private static int CpfDigit(int[] n, int factor, int? previousDigit = null)
    {
        int sum = 0;
        var digits = previousDigit.HasValue
            ? new List<int>(n) { previousDigit.Value }
            : new List<int>(n);

        int f = factor;
        for (int i = 0; i < digits.Count; i++, f--)
            sum += digits[i] * f;

        int rem = sum % 11;
        return rem < 2 ? 0 : 11 - rem;
    }
}

// ──────────────────────────────────────────────────────────────────
// DTO de saída  (espelha os campos BsonElement do seu model)
// ──────────────────────────────────────────────────────────────────

public sealed class FakeClient
{
    public string CorporateName { get; set; } = string.Empty;
    public string TradeName     { get; set; } = string.Empty;
    public string Type          { get; set; } = string.Empty;
    public string Document      { get; set; } = string.Empty;
    public string Email         { get; set; } = string.Empty;
    public string Phone         { get; set; } = string.Empty;

    public override string ToString() =>
        $"[{Type}] {CorporateName} | {TradeName} | {Document} | {Email} | {Phone}";
}

// ──────────────────────────────────────────────────────────────────
// Exemplo de uso (remova ou mova para seu projeto de teste)
// ──────────────────────────────────────────────────────────────────

// class Program
// {
//     static void Main()
//     {
//         // Gera 1 cliente
//         var single = ClientFaker.Generate();
//         Console.WriteLine(single);
//
//         // Gera 10.000 clientes para teste de carga
//         var batch = ClientFaker.GenerateMany(10_000);
//         Console.WriteLine($"{batch.Count} clientes gerados.");
//     }
// }