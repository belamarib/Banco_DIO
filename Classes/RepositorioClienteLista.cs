using System;
using System.Collections.Generic;
using Banco.Classes;

namespace Banco
{
    public class RepositorioClienteLista : RepositorioCliente<Cliente>
    {
        private List<Cliente> listaCliente = new List<Cliente>();

        public void abrirConta(Cliente objeto)
        {
            listaCliente.Add(objeto);
        }

        public void checarCliente(long CPF)
        {
            if (listaCliente.Exists(x => x.cpf == CPF))
            {
                listaCliente.Find(x => x.cpf == CPF).getDadosCliente();
            }
            else
            {
                Console.WriteLine("Não existe conta com este CPF!");
            }
            
        }

        public void depositar(long CPF, int valor)
        {
            if (listaCliente.Exists(x => x.cpf == CPF))
            {
                listaCliente.Find(x => x.cpf == CPF).depositar(valor);
            }
            else
            {
                Console.WriteLine("Não existe conta com este CPF!");
            }
        }

        public void fecharConta(long CPF)
        {
            if (listaCliente.Exists(x => x.cpf == CPF))
            {
                listaCliente.Find(x => x.cpf == CPF).desativarConta();
            }
            else
            {
                Console.WriteLine("Não existe conta com este CPF!");
            }
        }

        public List<Cliente> Lista()
        {
            return listaCliente;
        }

        public void sacar(long CPF, int valor)
        {
            if (listaCliente.Exists(x => x.cpf == CPF))
            {
                listaCliente.Find(x => x.cpf == CPF).sacar(valor);
            }
            else
            {
                Console.WriteLine("Não existe conta com este CPF!");
            }
        }

        public bool contaExiste(long CPF)
        {
            if (listaCliente.Exists(x => x.cpf == CPF))
            {
                listaCliente.Find(x => x.cpf == CPF).reativarConta();
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}