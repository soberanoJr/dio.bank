using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta,
                     double saldo,
                     double credito,
                     string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome  = nome;
        }

        public bool Saque(double valorSaque)
        {
            // Validação de saldo
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            Console.WriteLine($"Nome: {this.Nome} | Saldo: {this.Saldo}");
            return true;
        }

        public void Deposito(double valorDeposito)
        {
            this.Saldo += valorDeposito;
            Console.WriteLine($"Nome: {this.Nome} | Saldo: {this.Saldo}");
        }

        public void Transferencia(double valorTransferencia, Conta contaDestino)
        {
            if(this.Saque(valorTransferencia))
            {
                contaDestino.Deposito(valorTransferencia);
            }
        }

        public override string ToString()
        {
            //return base.ToString();
            string retorno = "";
            retorno += $"Tipo de Conta: {this.TipoConta} | ";
            retorno += $"Nome: {this.Nome} | ";
            retorno += $"Saldo: {this.Saldo} | ";
            retorno += $"Crédito: {this.Credito}";
            return retorno;
        }
    }
}