using System;

namespace hotel.Models
{

    // Classe suite, representa uma suite e possui funções para criação, edição e listagem.
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        // Função para validar se existe ou não a Suite e em caso de não existir, retornar uma nova Suite
        // O parâmetro bool 'Existe' permite indicar se o resultado final precisa da existência ou ausência da Suite. 
        // Caso seu valor seja false (ou seja, verificar se não existe) e a busca não retornar uma Suite, 
        // a função retorna uma nova Suite com o tipoSuite recebendo o valor indicado para consulta.
        public static Suite ValidarSuite(List<Suite> suites, bool Existe)
        {
            Suite auxMatch = new Suite();

            do
            {
                Console.WriteLine("Entre com o nome da suite:");
                string tpSuite = Console.ReadLine();
                auxMatch = suites.FindLast(m => m.TipoSuite.ToUpper() == tpSuite.ToUpper());

                if (auxMatch == null && Existe)
                {
                    Console.WriteLine("Tipo não existente. Digite outro nome.");
                }
                else if (auxMatch == null && !Existe)
                {
                    Suite aux = new Suite(tpSuite, 0, 0);
                    auxMatch = aux;
                    break;
                }
                else if (auxMatch != null && Existe)
                {
                    break;
                }
                else if (auxMatch != null && !Existe)
                {
                    Console.WriteLine("Tipo existente. Digite outro nome.");
                }
            } while (true);
            return auxMatch;
        }

        // Função para cadastrar suíte.
        public static void CadastrarSuite(List<Suite> suites)
        {
            Suite auxSuite = new Suite();
            string tpSuite;

            auxSuite = ValidarSuite(suites, false);

            Console.WriteLine("Entre com o valor da diária:");
            auxSuite.ValorDiaria = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a quantidade máxima de hóspedes:");
            auxSuite.Capacidade = int.Parse(Console.ReadLine());

            suites.Add(auxSuite);
            Console.WriteLine($"Suíte {suites.Last().TipoSuite} com capacidade de {suites.Last().Capacidade} pessoas e "
            + $"diária de R$ {suites.Last().ValorDiaria.ToString("0.00")} cadastrada com sucesso.");

        }

        // Função para listar suítes. 
        public static void ListarSuites(List<Suite> suites)
        {
            foreach (Suite suite in suites)
            {
                Console.WriteLine($"Tipo de Suíte: {suite.TipoSuite}");
                Console.WriteLine($"Capacidade: {suite.Capacidade}");
                Console.WriteLine($"Valor da Diária: R$ {suite.ValorDiaria.ToString("0.00")}");
                Console.WriteLine($"--------");
            }
        }

        public static void AlterarSuite(List<Suite> suites)
        {
            var match = ValidarSuite(suites, true);

            Console.WriteLine("Entre com o novo valor da diária:");
            match.ValorDiaria = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Entre com a nova quantidade máxima de hóspedes:");
            match.Capacidade = int.Parse(Console.ReadLine());

            Console.WriteLine($"Suíte {match.TipoSuite} com capacidade de {match.Capacidade} pessoas e "
            + $"diária de R$ {match.ValorDiaria.ToString("0.00")} alterada com sucesso.");

        }
    }
}