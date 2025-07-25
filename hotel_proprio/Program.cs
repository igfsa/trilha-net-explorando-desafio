using System.Text;
using hotel.Models;

namespace hotel
{
    class Program
    {

        public static string ObterOpcao()
        {
            Console.Clear();
            Console.WriteLine("1 - Cadastrar Suíte");
            Console.WriteLine("2 - Criar Reserva");
            Console.WriteLine("3 - Listar Suítes");
            Console.WriteLine("4 - Listar Reservas");
            Console.WriteLine("5 - Alterar Suíte");
            Console.WriteLine("X - Sair");

            return Console.ReadLine();

        }

        static void Main()
        {
            string opcao;
            List<Suite> suites = new List<Suite>();
            List<Reserva> reservas = new List<Reserva>();

            do
            {
                opcao = ObterOpcao().ToUpper();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("----- Cadastrar Suíte -----");
                        Suite.CadastrarSuite(suites);

                        break;
                    case "2":
                        Console.WriteLine("----- Criar Reserva -----");
                        reservas.Add(Reserva.CriarReserva(suites));

                        break;
                    case "3":
                        Console.WriteLine("----- Listar Suítes -----");
                        Suite.ListarSuites(suites);

                        break;
                    case "4":
                        Console.WriteLine("----- Listar Reservas -----");
                        Reserva.ListarReservas(reservas);

                        break;
                    case "5":
                        Console.WriteLine("----- Alterar Suíte -----");
                        Suite.AlterarSuite(suites);

                        break;
                    case "X":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.WriteLine("Para continuar, pressione uma tecla: ");
                Console.ReadLine();
            } while (opcao.ToUpper() != "X");
        }
    }
}
