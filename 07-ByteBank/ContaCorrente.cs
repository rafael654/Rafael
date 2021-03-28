using System;

namespace _07_ByteBank
{

    public class ContaCorrente
    {
        public Cliente Titular;
        public static int TotalDeContasCriadas { get; private set; }
        public static double TaxaOperacao { get; set; }
        public int contadorDeSaquesNaoPermitidos { get; set; }
        public int Agencia { get; }
        public int Numero { get; } 

        private double _saldo = 100;
        



        public ContaCorrente(int agencia, int numero)
        {
            
            if (agencia <= 0)
            {
                throw new ArgumentException(" Ocorreu um erro no Argument Agencia ! Deve ser maior que 0.", nameof (agencia));
            }
            if (numero <= 0)
            {
                throw new ArgumentException(" Ocorreu um erro no Argument Conta ! Deve ser maior que 0.", nameof(numero));
            }
            
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }


 


        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor do Saque não pode Ser negativo.", nameof(valor));

            }

            if (_saldo < valor)
                
            {
                contadorDeSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(_saldo , valor);
                
            }
                _saldo -= valor;
            
        }


        public void Depositar(double valor)
        {
            _saldo += valor;
        }



        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor do Saque não pode Ser negativo.", nameof(valor));

            }

            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException(_saldo, valor);

            }
            try 
            {

            Sacar(valor);
            }
            catch(SaldoInsuficienteException  ex ) 
            {
                contadorDeSaquesNaoPermitidos++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
                
            }
        }


    }



