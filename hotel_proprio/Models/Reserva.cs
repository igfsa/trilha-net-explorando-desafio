using System;

namespace hotel.Models
{
    // Classe que representa uma reserva, com funções para criar e ler reservas
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; } = new List<Pessoa>();
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public decimal Valor { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        // Função para cadastrar e inserir hospedes na reserva, utilizada na função CriarReserva.
        public void CadastrarHospedes(Reserva res)
        {
            int qtd;

            do
            {
                Console.WriteLine("Entre com a quantidade de hóspedes");
                qtd = int.Parse(Console.ReadLine());

                if (res.Suite.Capacidade >= qtd)
                {
                    break;
                }
                else
                {
                    throw new Exception("Ocorreu um erro. A quantidade de hóspedes não pode ser maior que a capacidade da suíte.");
                }
            }
            while (true);

            for (int i = 1; i <= qtd; i++)
            {
                Pessoa pess = new Pessoa();

                Console.WriteLine($"Entre com o primeiro nome da pessoa {i}: ");
                pess.Nome = Console.ReadLine();

                Console.WriteLine($"Entre com o sobrenome da pessoa {i}: ");
                pess.Sobrenome = Console.ReadLine();

                Console.WriteLine($"{pess.NomeCompleto}");

                res.Hospedes.Add(pess);
            }

        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count();
        }

        public void CalcularValorDiaria()
        {
            this.Valor = this.DiasReservados * this.Suite.ValorDiaria;

            if (this.DiasReservados >= 10)
            {
                this.Valor *= Convert.ToDecimal(0.9);
            }
        }

        // Função criar reserva. Checa se o tipo suíte existe, recebe a quantidade de dias e insere os hóspedes.  
        public static Reserva CriarReserva(List<Suite> suites)
        {
            Reserva res = new Reserva();

            res.Suite = Suite.ValidarSuite(suites, true);

            res.CadastrarHospedes(res);

            Console.WriteLine("Entre com a quantidade de dias reservados:");
            res.DiasReservados = int.Parse(Console.ReadLine());

            res.CalcularValorDiaria();

            Console.WriteLine($"Suite: {res.Suite.TipoSuite}");
            Console.WriteLine($"Dias reservados: {res.DiasReservados}");
            Console.WriteLine($"Valor: R$ {res.Valor.ToString("0.00")}");
            Console.WriteLine($"Hospedes: {res.ObterQuantidadeHospedes()}");
            foreach (Pessoa p in res.Hospedes)
            {
                Console.WriteLine($"    {p.NomeCompleto}");
            }

            return res;
        }

        // Função para listar reservas já realizadas.
        public static void ListarReservas(List<Reserva> reservas)
        {
            foreach (Reserva r in reservas)
            {
                Console.WriteLine($"Suite: {r.Suite.TipoSuite}");
                Console.WriteLine($"Dias reservados: {r.DiasReservados}");
                Console.WriteLine($"Valor: R$ {r.Valor.ToString("0.00")}");
                Console.WriteLine($"Hospedes: {r.ObterQuantidadeHospedes()}");
                foreach (Pessoa p in r.Hospedes)
                {
                    Console.WriteLine($"    {p.NomeCompleto}");
                }
                Console.WriteLine($"--------");
            }
        }
    }
}