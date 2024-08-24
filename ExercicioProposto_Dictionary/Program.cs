using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;

namespace ExercicioProposto_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)

        /*  Na contagem de votos de uma eleição, são gerados vários registros
de votação contendo o nome do candidato e a quantidade de votos
(formato .csv) que ele obteve em uma urna de votação. Você deve
fazer um programa para ler os registros de votação a partir de um
arquivo, e daí gerar um relatório consolidado com os totais de cada
candidato.

Alex Blue,15
Maria Green,22
Bob Brown,21
Alex Blue,30
Bob Brown,15
Maria Green,27
Maria Green,22
Bob Brown,25
Alex Blue,31*/
        {
            Console.WriteLine("Enter file full path: ");
            string filePath = Console.ReadLine();

            try
            {
                using (StreamReader sr = File.OpenText(filePath))
                {
                    Dictionary<string, int> dictionary = new Dictionary<string, int>();

                    while (!sr.EndOfStream)
                        
                    {
                        string line = sr.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 2)
                        {
                            string candidate = parts[0];
                            int votes = int.Parse(parts[1]);

                            if (dictionary.ContainsKey(candidate))
                            {
                                dictionary[candidate] += votes;
                            }
                            else
                            {
                                dictionary[candidate] = votes;
                            }

                        }

                    }

                    Console.WriteLine("Total votes: ");
                    foreach (var entry in dictionary)
                    {
                        Console.WriteLine($"{entry.Key}: {entry.Value}");
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Um erro ocorreu: {ex.Message}");
            }
        }
    }
}
