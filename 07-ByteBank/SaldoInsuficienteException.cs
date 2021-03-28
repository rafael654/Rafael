using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ByteBank
{
    public class SaldoInsuficienteException : Exception
    {
        public double Saldo { get; }
        public double valorDoSaque { get; }


        public SaldoInsuficienteException(double saldo, double valor) : this("Você tentou sacar " + valor + " de um Saldo de : " + saldo)
        {
            Saldo = saldo;
            valorDoSaque = valor;
            
        }
        public SaldoInsuficienteException()
        {

        }
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
            
        }


    }
}
