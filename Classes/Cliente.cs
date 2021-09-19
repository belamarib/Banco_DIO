using System;

namespace Banco.Classes
{
    public class Cliente : Pessoa
    {
        private Conta tipoDeConta {get; set;}
        private int saldo {get; set;}
        private bool ativa {get; set;}

        public Cliente(string nome, long cpf, int idade, Conta tipo)
		{
			this.nome = nome;
			this.cpf = cpf;
			this.idade = idade;
			this.tipoDeConta = tipo;
            this.saldo = 0;
            this.ativa = true;
		}

        public void getDadosCliente()
		{
            string dados = "";
            dados += "NOME: " + this.nome + Environment.NewLine;
            dados += "CPF: " + this.cpf + Environment.NewLine;
            dados += "IDADE: " + this.idade + Environment.NewLine;
            dados += "TIPO DE CONTA: " + this.tipoDeConta + Environment.NewLine;
            if (this.ativa)
            {
                dados += "ESTADO DA CONTA: ATIVA" + Environment.NewLine;
                dados+= "SALDO DA CONTA: " + this.saldo;

            }
            else
            {
                dados += "ESTADO DA CONTA: INATIVA";
            }
			Console.WriteLine(dados);
            Console.WriteLine();
		}

        public void ativarConta()
        {
            if (this.ativa)
            {
                Console.WriteLine("Esta conta já está ativa!");
            }
            else
            {
                this.ativa = true;
                Console.WriteLine("Conta ativada com sucesso!");
            }
        }

        public void desativarConta()
        {
            if (this.ativa)
            {
                this.saldo = 0;
                this.ativa = false;
                Console.WriteLine("Conta desativada com sucesso!");
            }
            else
            {
                Console.WriteLine("Esta conta já está desativada!");
            }
        }

        public void depositar(int valor)
        {
            this.saldo = this.saldo + valor;
            Console.WriteLine("Depósito realizado com sucesso!");
        }

        public void sacar(int valor)
        {
            this.saldo = this.saldo - valor;
            Console.WriteLine("Saque realizado com sucesso!");
        }

        public bool isAtiva()
        {
            return this.ativa;
        }

        public String getNome()
        {
            return this.nome;
        }

        public void reativarConta()
        {
            this.ativa = true;
        }

    }
}