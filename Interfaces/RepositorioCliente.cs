using System;
using System.Collections.Generic;

namespace Banco
{
    public interface RepositorioCliente<T>
    {
        List<T> Lista();       
        void abrirConta(T objeto);        
        void fecharConta(long cpf);        
        void depositar(long cpf, int valor);
        void sacar(long cpf, int valor);
        void checarCliente(long cpf);
        bool contaExiste(long cpf);
    }
}