using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        CriarConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("> Obrigado por utilizar o Banco DIO!");
        }

        private static void Sacar()
        {
            Console.WriteLine("--- Saque ---");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do saque: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Saque(valorSaque);
        }

        private static void Depositar()
        {
            Console.WriteLine("--- Depósito ---");

            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor do depósito: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Deposito(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("--- Transferência ---");

            Console.Write("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor da transferência: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listaContas[indiceContaOrigem].Transferencia(valorTransferencia, listaContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("--- Listar contas ---");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("> Nenhuma conta cadastrada!");
                return;
            }

            for (int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write($"Conta # {i}: ");
                Console.WriteLine(conta);
            }
        }

        private static void CriarConta()
        {
            Console.WriteLine("--- Criar nova conta ---");

            Console.Write("Digite '1' para 'PF' ou '2' para 'PJ': ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldoInicial = double.Parse(Console.ReadLine());

            Console.Write("Digite o valor do cheque especial: ");
            double entradaChequeEspecial = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldoInicial,
                                        credito: entradaChequeEspecial,
                                        nome: entradaNome);
            
            listaContas.Add(novaConta);

        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("> Bem-vindo(a) ao Banco DIO!");
            Console.WriteLine("> Digite a opção desejada:");
            Console.WriteLine("1. Listar contas");
            Console.WriteLine("2. Criar nova conta");
            Console.WriteLine("3. Transferir");
            Console.WriteLine("4. Sacar");
            Console.WriteLine("5. Depositar");
            Console.WriteLine("C. Limpar tela");
            Console.WriteLine("X. Sair");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            return opcaoUsuario;
        }
    }
}
