﻿using System;
using System.IO;

namespace _07_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {

            CarregarConta();


            Console.WriteLine("Execução finalizada. Tecle entre para sair");
            Console.ReadLine();
        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir

        private static void CarregarConta()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("reame.txt"))
            {
                leitor.LerProximaLinha();
            }
            
        }


        private static void TestarInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(4564, 789684);
                ContaCorrente conta2 = new ContaCorrente(7891, 456794);

                // conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");

                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }

        }

        private static void Metodo()
        {
        }

        private static void TestaDivisao(int divisor)
        {
            int resultado = Dividir(10, divisor);
            Console.WriteLine("Resultado da divisão" + divisor + " é " + resultado);
        }

        private static int Dividir(int numero, int divisor)
        {
            
            //Console.WriteLine(conta.Saldo);
            try
            {
                return numero / divisor;
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Exceção com número =" + numero + "e divisor =" + divisor);

                throw;
            }
            
        }
    }
}