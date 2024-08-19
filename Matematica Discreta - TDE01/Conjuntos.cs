// Guilherme Felippe Lazari

namespace Matematica_Discreta___TDE01;

public class Conjutos
{
    public void ConjuntoOperacoes(string nome_arquivo)
    {
        
        string[] linhas = File.ReadAllLines(nome_arquivo);

        
        int quantidade_operacoes = int.Parse(linhas[0].Trim());
        int inicio = 1;
        List<string> resultados = new List<string>();

        
        for (int i = 0; i < quantidade_operacoes; i++)
        {
            string operacao = linhas[inicio].Trim();
            HashSet<string> conjunto_01 = new HashSet<string>(linhas[inicio + 1].Trim().Split(new[] { ", " }, StringSplitOptions.None));
            HashSet<string> conjunto_02 = new HashSet<string>(linhas[inicio + 2].Trim().Split(new[] { ", " }, StringSplitOptions.None));
            HashSet<string> resultado = new HashSet<string>();
            string nome_operacao = "";

            switch (operacao)
            {
                case "U":
                    resultado = new HashSet<string>(conjunto_01);
                    resultado.UnionWith(conjunto_02);
                    nome_operacao = "União";
                    break;
                case "I":
                    resultado = new HashSet<string>(conjunto_01);
                    resultado.IntersectWith(conjunto_02);
                    nome_operacao = "Interseção";
                    if (resultado.Count == 0)
                    {
                        resultado.Add("Ø");
                    }
                    break;
                case "D":
                    resultado = new HashSet<string>(conjunto_01);
                    resultado.ExceptWith(conjunto_02);
                    nome_operacao = "Diferença";
                    break;
                case "C":
                    var produto_cartesiano = new List<string>();
                    foreach (var a in conjunto_01)
                    {
                        foreach (var b in conjunto_02)
                        {
                            produto_cartesiano.Add($"({a}, {b})");
                        }
                    }
                    resultado = new HashSet<string>(produto_cartesiano);
                    nome_operacao = "Produto Cartesiano";
                    break;
            }

            
            string resultado_operacao = operacao != "C"
                ? string.Join(", ", resultado.OrderBy(x => x))
                : string.Join(", ", resultado);

            
            resultados.Add($"{nome_operacao}: conjunto 1 {{{string.Join(", ", conjunto_01.OrderBy(x => x))}}}, conjunto 2 {{{string.Join(", ", conjunto_02.OrderBy(x => x))}}}. Resultado: {{{resultado_operacao}}}");

            
            inicio += 3;
        }

        
        foreach (string resultado in resultados)
        {
            Console.WriteLine(resultado);
        }
    }

}

