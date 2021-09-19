using System;
using Banco.Classes;

namespace Banco
{
    class Program
    {
        static RepositorioClienteLista repositorio = new RepositorioClienteLista();
        static void Main(string[] args)
        {
            string operacao = MenuOpcoes();
			int indiceLista = 0;

            while (operacao.ToUpper() != "X")
			{
				switch (operacao)
				{
					case "1":
						CriarConta(indiceLista);
						indiceLista++;
						break;
					case "2":
						Depositar();
						break;
					case "3":
						Sacar();
						break;
					case "4":
						ChecarCliente();
						break;
					case "5":
						ListarClientes();
						break;
					case "6":
						FecharConta();
						break;

					default:
						throw new ArgumentOutOfRangeException("Digite uma opção válida!");
				}

				operacao = MenuOpcoes();
			}
        }

        private static void CriarConta(int indiceLista)
		{
		
            Console.Write("Nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("CPF do cliente: ");
            if (long.TryParse(Console.ReadLine(), out long entradaCPF)){}
            else
            {
                throw new ArgumentException("O CPF deve ser um número!");
            }
			
			if (repositorio.contaExiste(entradaCPF))
			{
				Console.WriteLine("Conta reativada com sucesso!");
			}
			else
			{
				Console.Write("Idade do cliente: ");
				int entradaIdade = int.Parse(Console.ReadLine());

				Console.WriteLine();
				foreach (int i in Enum.GetValues(typeof(Conta)))
				{
					Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Conta), i)); 
				}
            	Console.WriteLine();
				Console.Write("Tipo de conta desejada: ");
				int entradaConta = int.Parse(Console.ReadLine());

            	Cliente novo = new Cliente(entradaNome, entradaCPF, entradaIdade, (Conta)entradaConta);

				repositorio.abrirConta(novo);
			}
		}

		private static void Depositar()
		{
			Console.Write("Digite o CPF da conta: ");
			if (long.TryParse(Console.ReadLine(), out long entradaCPF)){}
            else
            {
                throw new ArgumentException("O CPF deve ser um número!");
            }

			Console.Write("Digite o valor do depósito: ");
			int entradaDeposito = int.Parse(Console.ReadLine());
			repositorio.depositar(entradaCPF, entradaDeposito);
		}

		public static void Sacar()
		{
			Console.Write("Digite o CPF da conta: ");
			if (long.TryParse(Console.ReadLine(), out long entradaCPF)){}
            else
            {
                throw new ArgumentException("O CPF deve ser um número!");
            }

			Console.Write("Digite o valor do saque: ");
			int entradaSaque = int.Parse(Console.ReadLine());
			repositorio.sacar(entradaCPF, entradaSaque);
		}

		public static void ChecarCliente()
		{
			Console.Write("Digite o CPF da conta: ");
			if (long.TryParse(Console.ReadLine(), out long entradaCPF)){}
            else
            {
                throw new ArgumentException("O CPF deve ser um número!");
            }
			repositorio.checarCliente(entradaCPF);
		}

		public static void ListarClientes()
		{
			var lista = repositorio.Lista();
			
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum cliente cadastrado!");
				Console.WriteLine();
				return;
			}
			else
			{
				Console.WriteLine("Lista de clientes com contas ativas:");
				Console.WriteLine();
				int contador = 0;

				foreach (var cliente in lista)
				{
					if (cliente.isAtiva())
					{
						contador++;
						Console.WriteLine(cliente.getNome());
					}
				
				}

				if (contador == 0)
				{
					Console.WriteLine("Nenhum cliente com conta ativa!");
				}
				Console.WriteLine();
			}
		}

		public static void FecharConta()
		{
			Console.Write("Digite o CPF da conta que deseja fechar: ");
			if (long.TryParse(Console.ReadLine(), out long entradaCPF)){}
            else
            {
                throw new ArgumentException("O CPF deve ser um número!");
            }
			repositorio.fecharConta(entradaCPF);
		}

        private static string MenuOpcoes()
		{
			Console.WriteLine();
			Console.WriteLine("Digite a operação desejada:");

			Console.WriteLine("1- Criar conta");
			Console.WriteLine("2- Fazer depósito");
			Console.WriteLine("3- Fazer saque");
			Console.WriteLine("4- Checar dados do cliente");
			Console.WriteLine("5- Listar clientes");
			Console.WriteLine("6- Fechar conta");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string operacao = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return operacao;
		}
    }
}
